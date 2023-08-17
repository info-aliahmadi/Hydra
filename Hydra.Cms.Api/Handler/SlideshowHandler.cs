using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class SlideshowHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_slideshowService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ISlideshowService _slideshowService)
        {
            try
            {
                var result = await _slideshowService.GetList();

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
        /// <param name="_slideshowService"></param>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetSlideshowById(
            ISlideshowService _slideshowService,
            int slideshowId
            )
        {
            var result = await _slideshowService.GetById(slideshowId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_slideshowService"></param>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddSlideshow(ClaimsPrincipal userClaim,
            ISlideshowService _slideshowService,
            [FromBody] SlideshowModel slideshowModel
            )
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
                slideshowModel.UserId = userId;
                var result = await _slideshowService.Add(slideshowModel);

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
        /// <param name="_slideshowService"></param>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateOrders(ClaimsPrincipal userClaim,
            ISlideshowService _slideshowService,
            [FromBody] List<SlideshowModel> slideshowModelList
            )
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
                foreach (var slideshowModel in slideshowModelList.Where(x => x.IsVisible))
                {
                    slideshowModel.UserId = userId;
                }

                var result = await _slideshowService.UpdateOrder(slideshowModelList);

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
        /// <param name="_slideshowService"></param>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateSlideshow(ClaimsPrincipal userClaim,
            ISlideshowService _slideshowService,
            [FromBody] SlideshowModel slideshowModel
            )
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
                slideshowModel.UserId = userId;
                var result = await _slideshowService.Update(slideshowModel);

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
        /// <param name="_slideshowService"></param>
        /// <param name="slideshowId"></param>
        /// <returns></returns>
        public static async Task<IResult> VisibleSlideshow(ISlideshowService _slideshowService, int slideshowId)
        {
            try
            {
                var result = await _slideshowService.Visible(slideshowId);

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
        /// <param name="_slideshowService"></param>
        /// <param name="slideshowId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteSlideshow(ISlideshowService _slideshowService, int slideshowId)
        {
            try
            {
                var result = await _slideshowService.Delete(slideshowId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}