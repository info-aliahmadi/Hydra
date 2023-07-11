using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Hydra.Cms.Api.Handler
{
    public static class DriveHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_topicService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetFiles(IDriveService _driveService, HttpContext context)
        {
            try
            {
                var result = await _driveService.GetFiles(context);

                return Results.Ok(result);

            }
            catch (Exception e)
            {
                return Results.Ok(new GalleryResultModel() { statusCode = StatusCodes.Status501NotImplemented });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_topicService"></param>
        /// <returns></returns>
        public static async Task<IResult> Add(IDriveService _driveService, IFormFile formFile)
        {
            try
            {
                var result = await _driveService.Add(formFile);

                return Results.Ok(result);

            }
            catch (Exception e)
            {
                return Results.Ok(new GalleryResultModel() { statusCode = StatusCodes.Status501NotImplemented });
            }
        }

    }
}