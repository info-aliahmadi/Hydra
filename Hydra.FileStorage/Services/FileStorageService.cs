using Hydra.FileStorage.Domain;
using Hydra.FileStorage.Infrastructure.Settings;
using Hydra.FileStorage.Models;
using Hydra.Infrastructure;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Nitro.FileStorage.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Hydra.Cms.Core.Models;
using Microsoft.AspNetCore.Http;
using Hydra.Infrastructure.Setting;


namespace Hydra.FileStorage.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IValidationService _validationService;
        private readonly IUploadFileSetting _fileStorageSetting;
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;
        string drivePaths = HydraHelper.GetDriveDirectory();

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
        /// 
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
            var List = await _queryRepository.Table<FileUpload>().Select(x => new FileUploadModel()
            {
                Id = x.Id,
                FileName = x.FileName,
                Thumbnail = x.Thumbnail,
                Extension = x.Extension,
                Size = ConvertSizeToString(x.Size),
                Alt = x.Alt,
                Tags = x.Tags,
                UploadDate = x.UploadDate
            }).ToListAsync();

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

            // Get the directory
            DirectoryInfo place = new DirectoryInfo(HydraHelper.GetDriveDirectory());

            // Using GetFiles() method to get list of all
            // the files present in the Train directory
            var Files = await _queryRepository.Table<FileUpload>().Where(x => _fileStorageSetting.ImagesExtensions.Contains(x.Extension))
                .Select(x => new ImageModel()
                {
                    Name = x.FileName,
                    Src = HydraHelper.GetCurrentDomain(context) + "drive/" + x.Thumbnail,
                    Tag = x.Tags,
                    Alt = x.Alt
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
            var fileUploadModel = await _queryRepository.Table<FileUpload>().Select(x => new FileUploadModel()
            {
                Id = x.Id,
                FileName = x.FileName,
                Thumbnail = x.Thumbnail,
                Extension = x.Extension,
                Size = ConvertSizeToString(x.Size),
                Alt = x.Alt,
                Tags = x.Tags,
                UploadDate = x.UploadDate
            }).FirstOrDefaultAsync(x => x.Id == fileId);

            return fileUploadModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bytes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<FileUploadModel>> UploadFromBytesAsync(FileUploadModel uploadModel, byte[] bytes, CancellationToken cancellationToken = default)
        {
            var result = new Result<FileUploadModel>();
            try
            {
                if (IsExist(uploadModel.FileName))
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The file Is already Existed";
                    return result;
                }

                var fileNameWithPath = drivePaths + uploadModel.FileName;
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

                var fileInfo = new FileInfo(fileNameWithPath);

                using (var fs = new FileStream(fileNameWithPath, FileMode.Create, FileAccess.Write))
                {
                    await fs.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
                }

                var fileModel = new FileUpload()
                {
                    FileName = uploadModel.FileName,
                    Size = bytes.Length,
                    Extension = fileInfo.Extension,
                    Thumbnail = GenerateThumbnail(fileInfo),
                    Alt = uploadModel.Alt,
                    Tags = uploadModel.Tags,
                    UploadDate = DateTime.UtcNow
                };
                await _commandRepository.InsertAsync(fileModel);

                uploadModel.Size = ConvertSizeToString(fileModel.Size);
                uploadModel.Thumbnail = fileModel.Thumbnail;
                uploadModel.Extension = fileModel.Extension;


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
        public async Task<Result<FileUploadModel>> UploadSmallFileFromFormFile(IFormFile fileForm, CancellationToken cancellationToken = default)
        {
            var result = new Result<FileUploadModel>();
            try
            {
                if (IsExist(fileForm.FileName))
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The file Is already Existed";
                    return result;
                }

                var fileNameWithPath = drivePaths + fileForm.FileName;

                var fileInfo = new FileInfo(fileNameWithPath);

                using (var stream = File.Create(fileNameWithPath))
                {
                    var buffer = new byte[1024];
                    var fileBytes = stream.ReadExactlyAsync(buffer, cancellationToken);
                    var signatureResult = _validationService.ValidateFileSignature(buffer.ToArray(), fileInfo.Extension);
                    if (signatureResult != ValidationFileEnum.Ok)
                    {
                        result.Status = ResultStatusEnum.InvalidValidation;
                        result.Message = _validationService.GetValidationMessage(signatureResult);
                        return result;
                    }
                    stream.Position = 0;
                    await fileForm.CopyToAsync(stream);
                }

                var fileUpload = new FileUpload()
                {
                    FileName = fileForm.FileName,
                    Size = fileForm.Length,
                    Extension = fileInfo.Extension,
                    Thumbnail = GenerateThumbnail(fileInfo),
                    UploadDate = DateTime.UtcNow
                };
                await _commandRepository.InsertAsync(fileUpload);

                var uploadModel = new FileUploadModel()
                {
                    Id = fileUpload.Id,
                    FileName = fileUpload.FileName,
                    Extension = fileUpload.Extension,
                    Thumbnail = fileUpload.Thumbnail,
                    Size = ConvertSizeToString(fileUpload.Size)
                };

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
        public async Task<Result<FileUploadModel>> UploadSmallFileFromStreamAsync(string? fileName, string? contentType, Stream stream, CancellationToken cancellationToken = default)
        {

            var result = await UploadFromStreamAsync(fileName, FileSizeEnum.Small, stream, contentType,
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
        public async Task<Result<FileUploadModel>> UploadLargeFileFromStreamAsync(string? fileName, string? contentType, Stream stream, CancellationToken cancellationToken = default)
        {

            var result = await UploadFromStreamAsync(fileName, FileSizeEnum.Large, stream, contentType,
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
        public async Task<Result<FileUploadModel>> UploadFromStreamAsync(
            string? fileName,
            FileSizeEnum fileSize,
            Stream fileStream,
            string contentType,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = new Result<FileUploadModel>();
            var whiteListResult = _validationService.ValidateFileWhiteList(fileName);
            if (whiteListResult != ValidationFileEnum.Ok)
            {
                result.Status = ResultStatusEnum.IsNotAllowed;
                result.Message = _validationService.GetValidationMessage(whiteListResult);
                return result;
            }

            long totalSizeInBytes = 0;
            var boundary = GetBoundary(MediaTypeHeaderValue.Parse(contentType));
            var multipartReader = new MultipartReader(boundary, fileStream);
            var section = await multipartReader.ReadNextSectionAsync();
            var fileNameWithPath = drivePaths + fileName;
            var isFilledFirstBytes = false;
            while (section != null)
            {
                var fileSection = section.AsFileSection();
                if (fileSection != null)
                {
                    if (!isFilledFirstBytes)
                    {
                        var buffer = new byte[46];
                        fileSection.FileStream?.ReadExactly(buffer, 64, 64);
                        var fileExtension = Path.GetExtension(fileName);
                        var signatureResult = _validationService.ValidateFileSignature(buffer.ToArray(), fileExtension);
                        if (signatureResult != ValidationFileEnum.Ok)
                        {
                            result.Status = ResultStatusEnum.InvalidValidation;
                            result.Message = _validationService.GetValidationMessage(signatureResult);
                            return result;
                        }

                        fileSection.FileStream.Position = 0;
                        isFilledFirstBytes = true;
                    }


                    totalSizeInBytes += await SaveStreamFileAsync(fileSection, fileNameWithPath, cancellationToken);

                    var fileLengthResult = _validationService.ValidateFileMaxLength(totalSizeInBytes, fileSize);
                    if (fileLengthResult != ValidationFileEnum.Ok)
                    {
                        File.Delete(fileNameWithPath);
                        result.Status = fileLengthResult == ValidationFileEnum.FileIsTooLarge ? ResultStatusEnum.FileIsTooLarge : ResultStatusEnum.FileIsTooSmall;
                        result.Message = _validationService.GetValidationMessage(fileLengthResult);
                        return result;
                    }

                }
                section = await multipartReader.ReadNextSectionAsync();
            }
            var fileInfo = new FileInfo(fileNameWithPath);
            var fileUpload = new FileUpload()
            {
                FileName = fileName,
                Size = totalSizeInBytes,
                Extension = fileInfo.Extension,
                Thumbnail = GenerateThumbnail(fileInfo),
                UploadDate = DateTime.UtcNow
            };
            await _commandRepository.InsertAsync(fileUpload);

            result.Data = new FileUploadModel()
            {
                Id = fileUpload.Id,
                FileName = fileUpload.FileName,
                Thumbnail = fileUpload.Thumbnail,
                Extension = fileUpload.Extension,
                Size = ConvertSizeToString(fileUpload.Size),
                UploadDate = fileUpload.UploadDate
            };

            return result;
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
            if (File.Exists(drivePaths + fileUpload.FileName))
            {
                File.Delete(drivePaths + fileUpload.FileName);
            }
            _commandRepository.DeleteAsync(fileUpload);
            return result;
        }

        private async Task<long> SaveStreamFileAsync(FileMultipartSection fileSection, string filePath, CancellationToken cancellationToken = default(CancellationToken))
        {
            await using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            await fileSection.FileStream?.CopyToAsync(stream, cancellationToken);

            return fileSection.FileStream.Length;
        }


        private string GetBoundary(MediaTypeHeaderValue contentType)
        {
            var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;

            if (string.IsNullOrWhiteSpace(boundary))
            {
                throw new InvalidDataException("Missing content-type boundary.");
            }

            return boundary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public string? GenerateThumbnail(FileInfo fileInfo)
        {
            var imagesExtension = _fileStorageSetting.ImagesExtensions.Split('.');

            if (imagesExtension.Contains(fileInfo.Extension))
            {

                var thumbnailSize = _fileStorageSetting.ImageThumbnailSize;

                var extension = fileInfo.Extension;
                var fileNameOnly = fileInfo.Replace(extension, "");

                SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(fileInfo.FullName);

                var imageHeight = image.Height;
                var imageWidth = image.Width;

                if (imageHeight > imageWidth)
                {
                    imageWidth = (int)(((float)imageWidth / (float)imageHeight) * thumbnailSize);
                    imageHeight = thumbnailSize;
                }
                else
                {
                    imageHeight = (int)(((float)imageHeight / (float)imageWidth) * thumbnailSize);
                    imageWidth = thumbnailSize;
                }

                image.Mutate(x => x.Resize(imageWidth, imageHeight, KnownResamplers.Lanczos3));

                var newSImageName = fileNameOnly + "-small-Thumb.png";

                image.SaveAsPng(drivePaths + newSImageName);

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
    }
}