using Hydra.FileStorage.Core.Interfaces;
using Hydra.FileStorage.Core.Models;
using Hydra.Infrastructure;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Hydra.FileStorage.Api.Handler
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
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetFileInfoByName(IFileStorageService _fileStorageService, string fileName)
        {
            var result = await _fileStorageService.GetFileInfoByName(fileName);
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
        public static async Task<IResult> GetGalleyFiles(IFileStorageService _fileStorageService, HttpContext context)
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
        public static async Task<IResult> UploadFile(IFileStorageService _fileStorageService, HttpContext _context, IFormFile file, CancellationToken cancellationToken)
        {
            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
            var result =
                await _fileStorageService.Upload(file, uploadAction, cancellationToken);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="file"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IResult> UploadBase64File(IFileStorageService _fileStorageService, HttpContext _context, [FromBody] Base64FileUploadModel base64File, CancellationToken cancellationToken)
        {
            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
            var result =
                await _fileStorageService.UploadBase64File(base64File, uploadAction);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        public static async Task<IResult> UploadSmallFile(IFileStorageService _fileStorageService, HttpContext _context, IFormFile file, CancellationToken cancellationToken)
        {
            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
            var filename = file.FileName;
            var contentType = file.ContentType;
            var stream = file.OpenReadStream();
            var result =
                await _fileStorageService.UploadSmallFileStreamAsync(filename, uploadAction, contentType, stream,
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
        public static async Task<IResult> UploadLargeFile(IFileStorageService _fileStorageService, HttpContext _context, CancellationToken cancellationToken, HttpContext context)
        {
            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
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

                result = await _fileStorageService.UploadLargeFileStreamAsync(fileName, uploadAction, contentType,
                    section.Body, cancellationToken);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
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

        public static async Task<IResult> DownloadFile(IFileStorageService _fileStorageService, HttpContext context, int fileId, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoById(fileId);

            return Results.File(HydraHelper.GetCurrentDomain(context) + file.FileName, contentType: "application/octet-stream", file.FileName, enableRangeProcessing: true);
        }

        public static async Task<IResult> DownloadFileStream(IFileStorageService _fileStorageService, HttpContext context, int fileId, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoById(fileId);

            var fs = new FileStream(HydraHelper.GetCurrentDomain(context) + file.FileName, FileMode.Open);

            return Results.Stream(fs, contentType: "application/octet-stream", file.FileName, enableRangeProcessing: true);
        }


        public static async Task<IResult> DownloadFileByName(IFileStorageService _fileStorageService, HttpContext context, string fileName, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoByName(fileName.Trim());

            return Results.File(HydraHelper.GetCurrentDomain(context) + file.FileName, contentType: "application/octet-stream", file.FileName, enableRangeProcessing: true);
        }

        public static async Task<IResult> DownloadFileStreamByName(IFileStorageService _fileStorageService, HttpContext context, string fileName, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoByName(fileName);

            var fs = new FileStream(HydraHelper.GetCurrentDomain(context) + file.FileName, FileMode.Open);

            return Results.Stream(fs, contentType: "application/octet-stream", file.FileName, enableRangeProcessing: true);
        }
    }
}