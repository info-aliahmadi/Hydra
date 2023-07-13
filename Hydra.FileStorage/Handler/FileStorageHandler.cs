using Hydra.FileStorage.Models;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Nitro.FileStorage.Services;

namespace Hydra.FileStorage.Handler
{
    public static class FileStorageHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetFileInfo(IFileStorageService _fileStorageService, int fileId)
        {
            var result = await _fileStorageService.GetFileInfoById(fileId);
            return Results.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetFilesList(IFileStorageService _fileStorageService)
        {
            var result = await _fileStorageService.GetFilesList();
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetGalleyFiles(IFileStorageService _fileStorageService,HttpContext context)
        {
            var result = await _fileStorageService.GetGalleyFiles(context);
            return Results.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="file"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IResult> UploadFile(IFileStorageService _fileStorageService, IFormFile file, CancellationToken cancellationToken)
        {
            var result =
                await _fileStorageService.UploadSmallFileFromFormFile(file, cancellationToken);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        public static async Task<IResult> UploadFileAsStream(IFileStorageService _fileStorageService, IFormFile file, CancellationToken cancellationToken)
        {
            var filename = file.FileName;
            var contentType = file.ContentType;
            var stream = file.OpenReadStream();
            var result =
                await _fileStorageService.UploadSmallFileFromStreamAsync(filename, contentType, stream,
                    cancellationToken);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<IResult> UploadLargeFile(IFileStorageService _fileStorageService, CancellationToken cancellationToken, HttpContext context)
        {
            var result = new Result<FileUploadModel>();
            try
            {
                var request = context.Request;
                // validation of Content-Type
                // 1. first, it must be a form-data request
                // 2. a MediaType should be found in the Content-Type
                if (!request.HasFormContentType ||
                    !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                    string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    return Results.BadRequest(result);
                }

                var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
                var section = await reader.ReadNextSectionAsync(cancellationToken);
                if (section == null)
                    return Results.BadRequest("No files data in the request.");

                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                    out var contentDisposition);

                if (!hasContentDispositionHeader || !contentDisposition.DispositionType.Equals("form-data") ||
                    string.IsNullOrEmpty(contentDisposition.FileName.Value))
                    return Results.BadRequest("No files data in the request.");

                var fileSection = section.AsFileSection();
                if (fileSection == null)
                {
                    var unknown = new Result()
                    {
                        Status = ResultStatusEnum.Failed,
                        Message = "Unknown content"
                    };
                    return Results.Ok(unknown);

                }

                var contentType = section.ContentType;
                var fileName = Path.GetFileName(fileSection?.FileName);

                result = await _fileStorageService.UploadLargeFileFromStreamAsync(fileName, contentType,
                    section.Body, cancellationToken);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception)
            {
                return Results.BadRequest("No files data in the request.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteFile(IFileStorageService _fileStorageService, int fileId)
        {
            var result = await _fileStorageService.Delete(fileId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
    }
}