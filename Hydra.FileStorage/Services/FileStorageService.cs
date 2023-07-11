using System.Security.Cryptography;
using Hydra.FileStorage.Domain;
using Hydra.FileStorage.Infrastructure.Settings;
using Hydra.FileStorage.Models;
using Hydra.Kernel.Interfaces.Data;
using Nitro.FileStorage.Models;
using Nitro.FileStorage.Services;

namespace Hydra.FileStorage.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IValidationService _validationService;
        private readonly IUploadFileSetting _fileStorageSetting;
        private readonly ICommandRepository _commandRepository;
        private readonly IQueryRepository _queryRepository;

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
        public async Task<FileUploadModel> GetFileInfoById(int fileId)
        {
            var filter = _queryRepository.Table<FileUpload>().Select(x => new FileUploadModel()
            {
                Id = x.Id,
                FileName = x.FileName,
                Thumbnail = x.Thumbnail,
                Extension = x.Extension,
                Size = x.Size,
                Alt = x.Alt,
                Tags = x.Tags
            }).FirstOrDefault(x => x.Id == fileId);

            var cursor = await ImagesBucket.FindAsync(new BsonDocument { { "_id", objectId } });

            var result = (await cursor.ToListAsync()).FirstOrDefault();

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="bytes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FileUploadResultModel> UploadFromBytesAsync(string? fileName, string? contentType,
            byte[] bytes,
            CancellationToken cancellationToken = default)
        {
            var result = new FileUploadResultModel()
            {
                FileName = fileName
            };
            if (!_fileStorageSetting.AllowDuplicateFile)
            {
                var md5 = GetMd5HashCode(bytes);
                var existedFile = await GetFileInfoByMd5HashCode(md5);
                if (existedFile != null)
                {
                    result.ObjectId = existedFile.Id.ToString();
                    return result;
                }
            }

            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    {"ContentType", contentType},
                    {"UntrustedFileName", fileName}
                }
            };
            var firstBytes = bytes.Take(64).ToArray();
            var validateResult =
                _validationService.ValidateFile(firstBytes, fileName, bytes.Length, FileSizeEnum.Small);
            if (validateResult != ValidationFileEnum.Ok)
            {
                result.IsSuccessful = false;
                result.ErrorMessage = _validationService.GetValidationMessage(validateResult);
                return result;
            }

            // Don't trust any file name, file extension, and file data from the request unless you trust them completely
            // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
            // In short, it is necessary to restrict and verify the upload
            // Here, we just use the temporary folder and a random file name
            var newFileName = Path.GetRandomFileName();
            try
            {
                var id = await ImagesBucket.UploadFromBytesAsync(newFileName, bytes, options, cancellationToken);

                result.ObjectId = id.ToString();
                return result;

            }
            catch (Exception e)
            {
                result.IsSuccessful = false;
                result.ErrorMessage = e.Message + " " + e.InnerException;
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
        public async Task<FileUploadResultModel> UploadSmallFileFromStreamAsync(string? fileName, string? contentType,
            Stream stream,
            CancellationToken cancellationToken = default)
        {

            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    {"ContentType", contentType},
                    {"UntrustedFileName", fileName}
                }
            };
            // Don't trust any file name, file extension, and file data from the request unless you trust them completely
            // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
            // In short, it is necessary to restrict and verify the upload
            // Here, we just use the temporary folder and a random file name
            var newFileName = Path.GetRandomFileName();

            var result = await UploadFromStreamAsync(fileName, newFileName, FileSizeEnum.Small, stream, options,
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
        public async Task<FileUploadResultModel> UploadLargeFileFromStreamAsync(string? fileName, string? contentType,
            Stream stream,
            CancellationToken cancellationToken = default)
        {
            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    {"ContentType", contentType},
                    {"UntrustedFileName", fileName}
                }
            };
            // Don't trust any file name, file extension, and file data from the request unless you trust them completely
            // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
            // In short, it is necessary to restrict and verify the upload
            // Here, we just use the temporary folder and a random file name
            var newFileName = Path.GetRandomFileName();

            var result = await UploadFromStreamAsync(fileName, newFileName, FileSizeEnum.Large, stream, options,
                cancellationToken);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FileUploadResultModel> UploadFromStreamAsync(
            string? fileName,
            string newFileName,
            FileSizeEnum fileSize,
            Stream source,
            GridFSUploadOptions? options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull<string>(fileName, nameof(fileName));
            Ensure.IsNotNull<string>(newFileName, nameof(newFileName));
            Ensure.IsNotNull<Stream>(source, nameof(source));
            MD5 hasher = MD5.Create();

            hasher.Initialize();
            var result = new FileUploadResultModel()
            {
                FileName = fileName
            };
            var whiteListResult = _validationService.ValidateFileWhiteList(fileName);
            if (whiteListResult != ValidationFileEnum.Ok)
            {
                result.IsSuccessful = false;
                result.ErrorMessage = _validationService.GetValidationMessage(whiteListResult);
                return result;
            }

            options ??= new GridFSUploadOptions();

            var chunkSizeBytes = options.ChunkSizeBytes ?? 261120; // 255KB

            var id = ObjectId.GenerateNewId();
            await using GridFSUploadStream<ObjectId> destination = await ImagesBucket
                .OpenUploadStreamAsync(id, newFileName, options, cancellationToken).ConfigureAwait(false);
            var buffer = new byte[chunkSizeBytes];
            var isFilledFirstBytes = false;
            long lengthOfFile = 0;
            Exception sourceException;


            while (true)
            {
                var bytesRead = 0;
                sourceException = (Exception)null;
                try
                {
                    bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    sourceException = ex;
                }

                if (sourceException == null)
                {
                    if (bytesRead != 0)
                    {
                        hasher.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                        if (!isFilledFirstBytes)
                        {
                            var firstBytes = buffer.Take(64).ToArray();
                            var fileExtension = Path.GetExtension(fileName);
                            var signatureResult = _validationService.ValidateFileSignature(firstBytes, fileExtension);
                            if (signatureResult != ValidationFileEnum.Ok)
                            {
                                try
                                {
                                    await destination.AbortAsync(cancellationToken).ConfigureAwait(false);
                                }
                                catch
                                {

                                }
                                finally
                                {
                                    await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
                                    //await DeleteChunkAsync(destination.Id);
                                    //await ImagesBucket.DeleteAsync(destination.Id, cancellationToken);
                                }
                                buffer = (byte[])null;
                                //result.ObjectId = destination.Id.ToString();
                                result.IsSuccessful = false;
                                result.ErrorMessage = _validationService.GetValidationMessage(signatureResult);
                                return result;
                            }

                            isFilledFirstBytes = true;
                        }

                        lengthOfFile += bytesRead;

                        var fileLengthResult = _validationService.ValidateFileMaxLength(lengthOfFile, fileSize);
                        if (fileLengthResult != ValidationFileEnum.Ok)
                        {
                            try
                            {
                                await destination.AbortAsync(cancellationToken).ConfigureAwait(false);
                            }
                            catch
                            {

                            }
                            finally
                            {
                                await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
                                //await DeleteChunkAsync(destination.Id);
                                //await ImagesBucket.DeleteAsync(destination.Id, cancellationToken);
                            }

                            buffer = (byte[])null;
                            result.IsSuccessful = false;
                            result.ErrorMessage = _validationService.GetValidationMessage(fileLengthResult);
                            return result;
                        }

                        await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        hasher.TransformFinalBlock(new byte[0], 0, 0);
                        string md5hashCode = BitConverter.ToString(hasher.Hash).Replace("-", "").ToLowerInvariant();

                        if (!_fileStorageSetting.AllowDuplicateFile)
                        {
                            var existedFile = await GetFileInfoByMd5HashCode(md5hashCode);
                            if (existedFile != null)
                            {
                                try
                                {
                                    await destination.AbortAsync(cancellationToken).ConfigureAwait(false);
                                }
                                catch
                                {

                                }
                                finally
                                {
                                    await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
                                }

                                result.ObjectId = existedFile.Id.ToString();
                                return result;
                            }
                        }

                        var fileLengthResult = _validationService.ValidateFileMinLength(lengthOfFile, fileSize);
                        if (fileLengthResult != ValidationFileEnum.Ok)
                        {
                            try
                            {
                                await destination.AbortAsync(cancellationToken).ConfigureAwait(false);
                            }
                            catch
                            {

                            }
                            finally
                            {
                                await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
                            }

                            result.IsSuccessful = false;
                            result.ErrorMessage = _validationService.GetValidationMessage(fileLengthResult);
                            return result;
                        }

                        await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
                        buffer = (byte[])null;

                        result.ObjectId = destination.Id.ToString();
                        return result;

                    }
                }
                else
                {
                    try
                    {
                        await destination.AbortAsync(cancellationToken).ConfigureAwait(false);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
                    }

                    break;
                }
            }

            await destination.CloseAsync(cancellationToken).ConfigureAwait(false);
            buffer = (byte[])null;

            result.IsSuccessful = false;
            result.ErrorMessage = sourceException.Message + "_" + sourceException.InnerException;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public async Task DeleteChunkAsync(ObjectId objectId)
        {
            FilterDefinition<BsonDocument> filter = new BsonDocument("files_id", objectId);
            var chunksCollection =
                MongoDatabase.GetCollection<BsonDocument>(ImagesBucket.Options.BucketName + ".chunks");

            await chunksCollection.DeleteManyAsync(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<byte[]> DownloadAsBytesAsync(ObjectId objectId,
            CancellationToken cancellationToken = default)
        {
            var options = new GridFSDownloadOptions
            {
                Seekable = true,

            };
            var bytes = await ImagesBucket.DownloadAsBytesAsync(objectId, options, cancellationToken);

            return bytes;
        }

        public async Task DownloadToStreamAsync(ObjectId objectId, Stream destination,
            CancellationToken cancellationToken = default)
        {
            await ImagesBucket.DownloadToStreamAsync(objectId, destination, null, cancellationToken);
        }
    }
}