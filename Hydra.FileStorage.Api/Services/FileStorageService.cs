
using Hydra.Infrastructure;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Hydra.Infrastructure.Setting;
using Hydra.FileStorage.Core.Interfaces;
using Hydra.FileStorage.Core.Domain;
using Hydra.FileStorage.Core.Models;
using Hydra.FileStorage.Core.Settings;
using Hydra.Kernel.Extensions;

namespace Hydra.FileStorage.Api.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IValidationService _validationService;
        private readonly IUploadFileSetting _fileStorageSetting;
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;
        string uploadsPaths = HydraHelper.GetUploadsDirectory();

        public FileStorageService(
            IUploadFileSetting fileStorageSetting,
            IValidationService validationService,
            ICommandRepository commandRepository,
            IQueryRepository queryRepository

            )
        {
            _fileStorageSetting = fileStorageSetting;
            _validationService = validationService;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }


        /// <summary>
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public bool IsExist(string fileName)
        {
            var isExist = _queryRepository.Table<FileUpload>().Any(x => x.FileName == fileName);

            return isExist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public async Task<Result<List<FileUploadModel>>> GetFilesList()
        {
            var result = new Result<List<FileUploadModel>>();
            var List = _queryRepository.Table<FileUpload>().ToList().Select(x => new FileUploadModel()
            {
                Id = x.Id,
                FileName = GetFolder(x.Extension) + x.FileName,
                Thumbnail = x.Thumbnail,
                Extension = x.Extension,
                Size = ConvertSizeToString(x.Size),
                Alt = x.Alt,
                Tags = x.Tags,
                UploadDate = x.UploadDate
            }).ToList();

            result.Data = List;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GalleryResultModel> GetGalleyFiles(HttpContext context)
        {
            var result = new GalleryResultModel();

            var Files = await _queryRepository.Table<FileUpload>().Where(x => _fileStorageSetting.ImagesExtensions.Contains(x.Extension))
                .Select(x => new ImageModel()
                {
                    Name = x.FileName,
                    Src = HydraHelper.GetCurrentDomain(context) + GetFolder(x.Extension) + x.FileName,
                    Tag = x.Tags ?? "",
                    Alt = x.Alt ?? ""
                }).ToListAsync();
            result.Result = Files;
            result.statusCode = 200;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public async Task<FileUploadModel> GetFileInfoById(int fileId)
        {
            var fileUpload = await _queryRepository.Table<FileUpload>().FirstOrDefaultAsync(x => x.Id == fileId);



            var fileUploadModel = new FileUploadModel()
            {
                Id = fileUpload.Id,
                FileName = GetFolder(fileUpload.Extension) + fileUpload.FileName,
                Thumbnail = fileUpload.Thumbnail,
                Extension = fileUpload.Extension,
                Size = ConvertSizeToString(fileUpload.Size),
                Alt = fileUpload.Alt,
                Tags = fileUpload.Tags,
                UploadDate = fileUpload.UploadDate
            };

            return fileUploadModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public async Task<FileUploadModel> GetFileInfoByName(string fileName)
        {
            var fileUpload = await _queryRepository.Table<FileUpload>().FirstOrDefaultAsync(x => x.FileName == fileName);



            var fileUploadModel = new FileUploadModel()
            {
                Id = fileUpload.Id,
                FileName = GetFolder(fileUpload.Extension) + fileUpload.FileName,
                Thumbnail = fileUpload.Thumbnail,
                Extension = fileUpload.Extension,
                Size = ConvertSizeToString(fileUpload.Size),
                Alt = fileUpload.Alt,
                Tags = fileUpload.Tags,
                UploadDate = fileUpload.UploadDate
            };

            return fileUploadModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bytes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> UploadFromBytesAsync(FileUploadModel uploadModel, string uploadAction, byte[] bytes, CancellationToken cancellationToken = default)
        {
            var result = new Result<FileUploadModel>();
            try
            {
                // Don't trust any file name, file extension, and file data from the request unless you trust them completely
                // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
                // In short, it is necessary to restrict and verify the upload
                // Here, we just use the temporary folder and a random file name
                var firstBytes = bytes.Take(64).ToArray();
                var validateResult =
                    _validationService.ValidateFile(firstBytes, uploadModel.FileName, bytes.Length, FileSizeEnum.Small);
                if (validateResult != ValidationFileEnum.Ok)
                {
                    result.Status = ResultStatusEnum.InvalidValidation;
                    result.Message = _validationService.GetValidationMessage(validateResult);
                    return result;
                }
                var isExisted = IsExist(uploadModel.FileName);
                if (isExisted && uploadAction != "Rename" && uploadAction != "Replace")
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The file Is already Existed";
                    return result;
                }
                var extension = Path.GetExtension(uploadModel.FileName).ToLowerInvariant();
                var fileNameWithPath = uploadsPaths + GetFolder(extension);

                if (isExisted && uploadAction == "Rename")
                {
                    uploadModel.FileName = Rename(uploadModel.FileName);
                }

                fileNameWithPath += uploadModel.FileName;


                var fileInfo = new FileInfo(fileNameWithPath);

                using (var fs = new FileStream(fileNameWithPath, FileMode.Create, FileAccess.Write))
                {
                    await fs.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
                }

                var registerDate = DateTime.UtcNow;
                var thumbnail = GenerateThumbnail(fileInfo);

                if (isExisted && uploadAction == "Replace")
                {
                    var existedFileUpload = _queryRepository.Table<FileUpload>().First(x => x.FileName == uploadModel.FileName);

                    existedFileUpload.Size = bytes.Length;
                    existedFileUpload.Thumbnail = thumbnail;
                    existedFileUpload.Alt = uploadModel.Alt;
                    existedFileUpload.Tags = uploadModel.Tags;
                    existedFileUpload.UploadDate = registerDate;

                    _commandRepository.UpdateAsync(existedFileUpload);
                    await _commandRepository.SaveChangesAsync();

                    uploadModel.Id = existedFileUpload.Id;
                    uploadModel.Size = ConvertSizeToString(existedFileUpload.Size);
                    uploadModel.Thumbnail = existedFileUpload.Thumbnail;
                    uploadModel.Extension = existedFileUpload.Extension;

                    result.Data = uploadModel;

                    return result;
                }
                var fileUpload = new FileUpload()
                {
                    FileName = uploadModel.FileName,
                    Size = bytes.Length,
                    Extension = fileInfo.Extension,
                    Thumbnail = thumbnail,
                    Alt = uploadModel.Alt,
                    Tags = uploadModel.Tags,
                    UploadDate = registerDate
                };
                await _commandRepository.InsertAsync(fileUpload);
                await _commandRepository.SaveChangesAsync();

                uploadModel.Id = fileUpload.Id;
                uploadModel.Size = ConvertSizeToString(fileUpload.Size);
                uploadModel.Thumbnail = fileUpload.Thumbnail;
                uploadModel.Extension = fileUpload.Extension;


                result.Data = uploadModel;

                return result;


            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> Upload(IFormFile fileForm, string uploadAction, CancellationToken cancellationToken = default)
        {
            var result = new Result<FileUploadModel>();
            try
            {

                var stream = fileForm.OpenReadStream();
                var validBuffer = new byte[64];
                stream.Read(validBuffer, 0, validBuffer.Length);
                stream.Position = 0;
                var firstBytes = validBuffer.Take(64).ToArray();
                var fileName = fileForm.FileName;

                var validateResult =
                    _validationService.ValidateFile(firstBytes, fileName, fileForm.Length, FileSizeEnum.Small);

                if (validateResult != ValidationFileEnum.Ok)
                {
                    result.Status = ResultStatusEnum.InvalidValidation;
                    result.Message = _validationService.GetValidationMessage(validateResult);
                    return result;
                }
                var isExisted = IsExist(fileName);

                if (isExisted && uploadAction != "Rename" && uploadAction != "Replace")
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The file Is already Existed";
                    return result;
                }
                var extension = Path.GetExtension(fileName).ToLowerInvariant();
                var fileNameWithPath = uploadsPaths + GetFolder(extension);

                if (isExisted && uploadAction == "Rename")
                {
                    fileName = Rename(fileName);
                }
                fileNameWithPath += fileName;

                var fileInfo = new FileInfo(fileNameWithPath);

                using (var fileStream = File.Create(fileNameWithPath))
                {
                    await stream.CopyToAsync(fileStream);
                }

                var registerDate = DateTime.UtcNow;
                var thumbnail = GenerateThumbnail(fileInfo);
                var uploadModel = new FileUploadModel();
                if (isExisted && uploadAction == "Replace")
                {
                    var existedFileUpload = _queryRepository.Table<FileUpload>().First(x => x.FileName == fileName);

                    existedFileUpload.Size = fileForm.Length;
                    existedFileUpload.Thumbnail = thumbnail;
                    existedFileUpload.UploadDate = registerDate;

                    _commandRepository.UpdateAsync(existedFileUpload);
                    await _commandRepository.SaveChangesAsync();

                    uploadModel.Id = existedFileUpload.Id;
                    uploadModel.Size = ConvertSizeToString(existedFileUpload.Size);
                    uploadModel.Thumbnail = existedFileUpload.Thumbnail;
                    uploadModel.Extension = existedFileUpload.Extension;

                    result.Data = uploadModel;

                    return result;
                }

                var fileUpload = new FileUpload()
                {
                    FileName = fileName,
                    Size = fileForm.Length,
                    Extension = fileInfo.Extension,
                    Thumbnail = thumbnail,
                    UploadDate = registerDate
                };
                await _commandRepository.InsertAsync(fileUpload);

                await _commandRepository.SaveChangesAsync();

                uploadModel.Id = fileUpload.Id;
                uploadModel.FileName = fileUpload.FileName;
                uploadModel.Extension = fileUpload.Extension;
                uploadModel.Thumbnail = fileUpload.Thumbnail;
                uploadModel.Size = ConvertSizeToString(fileUpload.Size);

                result.Data = uploadModel;

                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> UploadSmallFileStreamAsync(string? fileName, string uploadAction, string? contentType, Stream stream, CancellationToken cancellationToken = default)
        {

            var result = await UploadFromStreamAsync(fileName, uploadAction, FileSizeEnum.Small, stream, contentType,
                cancellationToken);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> UploadLargeFileStreamAsync(string? fileName, string uploadAction, string? contentType, Stream stream, CancellationToken cancellationToken = default)
        {

            var result = await UploadFromStreamAsync(fileName, uploadAction, FileSizeEnum.Large, stream, contentType,
                cancellationToken);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> UploadFromStreamAsync(string? fileName, string uploadAction, FileSizeEnum fileSize, Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            var result = new Result<FileUploadModel>();
            try
            {

                //var validBuffer = new byte[64];
                //await stream.ReadAsync(validBuffer, 0, validBuffer.Length);
                //stream.Position = 0;
                //var firstBytes = validBuffer.Take(64).ToArray();

                var validateWhiteList = _validationService.ValidateFileWhiteList(fileName);
                if (validateWhiteList != ValidationFileEnum.Ok)
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = _validationService.GetValidationMessage(validateWhiteList);
                    return result;
                }
                if (fileSize == FileSizeEnum.Small)
                {
                    var validateFileLength = _validationService.ValidateFileLength(stream.Length, fileSize);
                    if (validateFileLength != ValidationFileEnum.Ok)
                    {
                        result.Status = validateFileLength == ValidationFileEnum.FileIsTooLarge ? ResultStatusEnum.FileIsTooLarge : ResultStatusEnum.FileIsTooSmall;
                        result.Message = _validationService.GetValidationMessage(validateFileLength);
                        return result;
                    }
                }

                var isExisted = IsExist(fileName);
                if (isExisted && uploadAction != "Rename" && uploadAction != "Replace")
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The file Is already Existed";
                    return result;
                }
                var extension = Path.GetExtension(fileName).ToLowerInvariant();
                var fileNameWithPath = uploadsPaths + GetFolder(extension);

                if (isExisted && uploadAction == "Rename")
                {
                    fileName = Rename(fileName);
                }
                fileNameWithPath += fileName;

                var fileInfo = new FileInfo(fileNameWithPath);


                byte[] buffer = new byte[8 * 1024];
                int len;
                int totalLength = 0;
                using (var streamFile = new FileStream(fileNameWithPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 1024))
                {
                    // first time we check the signature with operation the turn to while
                    len = await stream.ReadAsync(buffer, 0, buffer.Length);
                    totalLength = totalLength + len;
                    var validateSignature = _validationService.ValidateFileSignature(buffer.Take(60).ToArray(), fileInfo.Extension);
                    if (validateSignature != ValidationFileEnum.Ok)
                    {
                        result.Status = ResultStatusEnum.InvalidValidation;
                        result.Message = _validationService.GetValidationMessage(validateSignature);
                        return result;
                    }

                    await streamFile.WriteAsync(buffer, 0, len);

                    while ((len = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        totalLength = totalLength + len;
                        await streamFile.WriteAsync(buffer, 0, len);
                    }

                }
                stream.Close();
                stream.Close();

                if (totalLength > _fileStorageSetting.MaxSizeLimitLargeFile && fileSize == FileSizeEnum.Large)
                {
                    File.Delete(fileNameWithPath);
                    result.Status = ResultStatusEnum.FileIsTooLarge;
                    result.Message = _validationService.GetValidationMessage(ValidationFileEnum.FileIsTooLarge);
                    return result;
                }
                var registerDate = DateTime.UtcNow;
                var thumbnail = GenerateThumbnail(fileInfo);
                var uploadModel = new FileUploadModel();

                if (isExisted && uploadAction == "Replace")
                {
                    var existedFileUpload = _queryRepository.Table<FileUpload>().First(x => x.FileName == fileName);

                    existedFileUpload.Size = totalLength;
                    existedFileUpload.Thumbnail = thumbnail;
                    existedFileUpload.UploadDate = registerDate;

                    _commandRepository.UpdateAsync(existedFileUpload);
                    await _commandRepository.SaveChangesAsync();

                    uploadModel.Id = existedFileUpload.Id;
                    uploadModel.Size = ConvertSizeToString(existedFileUpload.Size);
                    uploadModel.Thumbnail = existedFileUpload.Thumbnail;
                    uploadModel.Extension = existedFileUpload.Extension;

                    result.Data = uploadModel;

                    return result;
                }
                var fileUpload = new FileUpload()
                {
                    FileName = fileName,
                    Size = totalLength,
                    Extension = fileInfo.Extension,
                    Thumbnail = thumbnail,
                    UploadDate = registerDate
                };
                await _commandRepository.InsertAsync(fileUpload);
                await _commandRepository.SaveChangesAsync();

                uploadModel.Id = fileUpload.Id;
                uploadModel.FileName = fileUpload.FileName;
                uploadModel.Thumbnail = fileUpload.Thumbnail;
                uploadModel.Extension = fileUpload.Extension;
                uploadModel.Size = ConvertSizeToString(fileUpload.Size);
                uploadModel.UploadDate = fileUpload.UploadDate;

                result.Data = uploadModel;
                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64File"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> UploadBase64File(Base64FileUploadModel base64File, string uploadAction)
        {
            var result = new Result<FileUploadModel>();
            try
            {

                var validateWhiteList = _validationService.ValidateFileWhiteList(base64File.FileName);
                if (validateWhiteList != ValidationFileEnum.Ok)
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = _validationService.GetValidationMessage(validateWhiteList);
                    return result;
                }
                var validateFileLength = _validationService.ValidateFileLength(base64File.FileLength, FileSizeEnum.Small);
                if (validateFileLength != ValidationFileEnum.Ok)
                {
                    result.Status = validateFileLength == ValidationFileEnum.FileIsTooLarge ? ResultStatusEnum.FileIsTooLarge : ResultStatusEnum.FileIsTooSmall;
                    result.Message = _validationService.GetValidationMessage(validateFileLength);
                    return result;
                }
                var isExisted = IsExist(base64File.FileName);
                if (isExisted && uploadAction != "Rename" && uploadAction != "Replace")
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The file Is already Existed";
                    return result;
                }

                var extension = Path.GetExtension(base64File.FileName).ToLowerInvariant();

                var fileNameWithPath = uploadsPaths + GetFolder(extension);

                if (isExisted && uploadAction == "Rename")
                {
                    base64File.FileName = Rename(base64File.FileName);
                }

                fileNameWithPath += base64File.FileName;

                var fileInfo = new FileInfo(fileNameWithPath);
                if (!string.IsNullOrEmpty(base64File.Base64File))
                {
                    var fileBytes = base64File.Base64File.Base64FileToBytes();
                    await File.WriteAllBytesAsync(string.Format(fileNameWithPath, base64File.FileName), fileBytes.FileBytes);
                }
                var registerDate = DateTime.UtcNow;
                var thumbnail = GenerateThumbnail(fileInfo);
                var uploadModel = new FileUploadModel();

                if (isExisted && uploadAction == "Replace")
                {
                    var existedFileUpload = _queryRepository.Table<FileUpload>().First(x => x.FileName == base64File.FileName);

                    existedFileUpload.Size = base64File.FileLength;
                    existedFileUpload.Thumbnail = thumbnail;
                    existedFileUpload.UploadDate = registerDate;

                    _commandRepository.UpdateAsync(existedFileUpload);
                    await _commandRepository.SaveChangesAsync();

                    uploadModel.Id = existedFileUpload.Id;
                    uploadModel.Size = ConvertSizeToString(existedFileUpload.Size);
                    uploadModel.Thumbnail = existedFileUpload.Thumbnail;
                    uploadModel.Extension = existedFileUpload.Extension;

                    result.Data = uploadModel;

                    return result;
                }
                var fileUpload = new FileUpload()
                {
                    FileName = base64File.FileName,
                    Size = base64File.FileLength,
                    Extension = fileInfo.Extension,
                    Thumbnail = GenerateThumbnail(fileInfo),
                    UploadDate = DateTime.UtcNow
                };
                await _commandRepository.InsertAsync(fileUpload);
                await _commandRepository.SaveChangesAsync();

                uploadModel.Id = fileUpload.Id;
                uploadModel.FileName = fileUpload.FileName;
                uploadModel.Thumbnail = fileUpload.Thumbnail;
                uploadModel.Extension = fileUpload.Extension;
                uploadModel.Size = ConvertSizeToString(fileUpload.Size);
                uploadModel.UploadDate = fileUpload.UploadDate;

                result.Data = uploadModel;
                return result;

            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }

        public async Task<Result> Delete(int fileId)
        {
            var result = new Result();
            var fileUpload = await _queryRepository.Table<FileUpload>().FirstOrDefaultAsync(x => x.Id == fileId);
            if (fileUpload is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                return result;
            }
            if (File.Exists(uploadsPaths + fileUpload.FileName))
            {
                File.Delete(uploadsPaths + fileUpload.FileName);
            }
            if (File.Exists(uploadsPaths + fileUpload.Thumbnail))
            {
                File.Delete(uploadsPaths + fileUpload.Thumbnail);
            }
            _commandRepository.DeleteAsync(fileUpload);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public string? GenerateThumbnail(FileInfo fileInfo)
        {
            var imagesExtension = _fileStorageSetting.ImagesExtensions.Split(',');

            if (imagesExtension.Contains(fileInfo.Extension))
            {

                var thumbnailSize = _fileStorageSetting.ImageThumbnailSize;

                var extension = fileInfo.Extension;
                var fileNameOnly = fileInfo.Name.Substring(0, fileInfo.Name.Length - extension.Length);

                SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(fileInfo.FullName);

                var imageHeight = image.Height;
                var imageWidth = image.Width;

                if (imageHeight > imageWidth)
                {
                    imageWidth = (int)((float)imageWidth / (float)imageHeight * thumbnailSize);
                    imageHeight = thumbnailSize;
                }
                else
                {
                    imageHeight = (int)((float)imageHeight / (float)imageWidth * thumbnailSize);
                    imageWidth = thumbnailSize;
                }

                image.Mutate(x => x.Resize(imageWidth, imageHeight, KnownResamplers.Lanczos3));

                var newSImageName = fileNameOnly + "-Thumb.png";

                image.SaveAsPng(uploadsPaths + newSImageName);
                image.Dispose();
                return newSImageName;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string ConvertSizeToString(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            return fileSize switch
            {
                _ when fileSize < kilobyte => "Less then 1KB",
                _ when fileSize < megabyte =>
                    $"{Math.Round(fileSize / kilobyte, fileSize < 10 * kilobyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}KB",
                _ when fileSize < gigabyte =>
                    $"{Math.Round(fileSize / megabyte, fileSize < 10 * megabyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}MB",
                _ when fileSize >= gigabyte =>
                    $"{Math.Round(fileSize / gigabyte, fileSize < 10 * gigabyte ? 2 : 1, MidpointRounding.AwayFromZero):##,###.##}GB",
                _ => "n/a"
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public string GetFolder(string extension)
        {
            if (_fileStorageSetting.ImagesExtensions.Split(',').Contains(extension))
            {
                return "images/";
            }
            if (_fileStorageSetting.VideosExtensions.Split(',').Contains(extension))
            {
                return "videos/";
            }
            if (_fileStorageSetting.MusicExtensions.Split(',').Contains(extension))
            {
                return "music/";
            }
            if (_fileStorageSetting.DocumentsExtensions.Split(',').Contains(extension))
            {
                return "documents/";
            }
            return "others/";
        }

        /// <summary>
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public string Rename(string fileName)
        {

            var extension = Path.GetExtension(fileName).ToLower();
            var fileNameOnly = fileName.Substring(0, fileName.Length - extension.Length);

            for (int i = 1; i < 2000; i++)
            {
                var newFileName = fileNameOnly + "-" + i + extension;
                if (!IsExist(newFileName))
                {
                    return newFileName;
                }
            }
            return fileName;
        }
    }
}