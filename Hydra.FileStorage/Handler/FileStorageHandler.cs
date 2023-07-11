using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Cms.Api.Handler
{
    public static class FileStorageHandler
    {

        public static async Task<IResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var filename = file.FileName;
            var contentType = file.ContentType;
            var stream = file.OpenReadStream();
            var result =
                await _fileStorageService.UploadSmallFileFromStreamAsync(filename, contentType, stream,
                    cancellationToken);
            return Results.Ok(result);
        }


        public static async Task<IResult> UploadMultipleFiles(IFormFileCollection files,
            CancellationToken cancellationToken)
        {
            var filesUploadResult = new List<FileUploadResultModel>();

            foreach (var file in files)
            {
                var filename = file.FileName;

                var contentType = file.ContentType;
                var result = await _fileStorageService.UploadSmallFileFromStreamAsync(filename, contentType,
                    file.OpenReadStream(),
                    cancellationToken);
                filesUploadResult.Add(result);
            }

            return Results.Ok(filesUploadResult);
        }

    }
}