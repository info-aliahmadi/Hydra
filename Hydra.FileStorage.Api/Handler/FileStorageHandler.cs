using Hydra.FileStorage.Core.Interfaces;
using Hydra.FileStorage.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.GeneralModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

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
        public static async Task<IResult> GetFilesInfo(IFileStorageService _fileStorageService,[FromBody] int[] fileIds)
        {
            var result = await _fileStorageService.GetFilesInfoByIds(fileIds);
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
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetDirectories(IFileStorageService _fileStorageService)
        {
            try
            {
                var result = await _fileStorageService.GetDirectoryList();

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetFilesByDirectory(IFileStorageService _fileStorageService, string directoryName)
        {
            try
            {
                directoryName = directoryName.Contains("/") ? directoryName : directoryName + "/";
                var result = await _fileStorageService.GetFilesListByDirectory(directoryName.ToLower());

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
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
        public static async Task<IResult> UploadFile(ClaimsPrincipal userClaim, IFileStorageService _fileStorageService, HttpContext _context, IFormFile file, CancellationToken cancellationToken)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);

            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
            var result =
                await _fileStorageService.Upload(userId, file, uploadAction, cancellationToken);
            return result.Succeeded ? Results.Ok(result) : Results.StatusCode(((int)result.Status));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileStorageService"></param>
        /// <param name="file"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IResult> UploadBase64File(ClaimsPrincipal userClaim, IFileStorageService _fileStorageService, HttpContext _context, [FromBody] Base64FileUploadModel base64File, CancellationToken cancellationToken)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
            var result =
                await _fileStorageService.UploadBase64File(userId, base64File, uploadAction);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        public static async Task<IResult> UploadSmallFile(ClaimsPrincipal userClaim, IFileStorageService _fileStorageService, HttpContext _context, IFormFile file, CancellationToken cancellationToken)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);

            var uploadAction = _context.Request.Headers["UploadAction"]; // none / Rename / Replace
            var filename = file.FileName;
            var contentType = file.ContentType;
            var stream = file.OpenReadStream();
            var result =
                await _fileStorageService.UploadSmallFileStreamAsync(userId, filename, uploadAction, contentType, stream,
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
        public static async Task<IResult> UploadLargeFile(ClaimsPrincipal userClaim, IFileStorageService _fileStorageService, HttpContext _context, CancellationToken cancellationToken, HttpContext context)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
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

                result = await _fileStorageService.UploadLargeFileStreamAsync(userId, fileName, uploadAction, contentType,
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
        public static async Task<IResult> DeleteFile(ClaimsPrincipal userClaim, IFileStorageService _fileStorageService, int fileId)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            var result = await _fileStorageService.Delete(userId, fileId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        public static async Task<IResult> DownloadFile(IFileStorageService _fileStorageService, HttpContext context, int fileId, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoById(fileId);

            return Results.File(HydraHelper.GetCurrentDomain(context) + file.Data.FileName, contentType: "application/octet-stream", file.Data.FileName, enableRangeProcessing: true);
        }

        public static async Task<IResult> DownloadFileStream(IFileStorageService _fileStorageService, HttpContext context, int fileId, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoById(fileId);

            var fs = new FileStream(HydraHelper.GetCurrentDomain(context) + file.Data.FileName, FileMode.Open);

            return Results.Stream(fs, contentType: "application/octet-stream", file.Data.FileName, enableRangeProcessing: true);
        }


        public static async Task<IResult> DownloadFileByName(IFileStorageService _fileStorageService, HttpContext context, string fileName, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoByName(fileName.Trim());

            return Results.File(HydraHelper.GetCurrentDomain(context) + file.Data.FileName, contentType: "application/octet-stream", file.Data.FileName, enableRangeProcessing: true);
        }

        public static async Task<IResult> DownloadFileStreamByName(IFileStorageService _fileStorageService, HttpContext context, string fileName, CancellationToken cancellationToken)
        {
            var file = await _fileStorageService.GetFileInfoByName(fileName);

            var fs = new FileStream(HydraHelper.GetCurrentDomain(context) + file.Data.FileName, FileMode.Open);

            return Results.Stream(fs, contentType: "application/octet-stream", file.Data.FileName, enableRangeProcessing: true);
        }
    }
}