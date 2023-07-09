using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Cms.Api.Handler
{
    public static class ContentHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contentService"></param>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             IContentService _contentService, GridDataBound dataGrid)
        {
            try
            {
                var result = await _contentService.GetList(dataGrid);

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
        /// <param name="_contentService"></param>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetContentById(
            IContentService _contentService,
            int contentId
            )
        {
            var result = await _contentService.GetById(contentId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contentService"></param>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddContent(
            IContentService _contentService,
            [FromBody] ContentModel contentModel
            )
        {
            var result = await _contentService.Add(contentModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contentService"></param>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateContent(
            IContentService _contentService,
            [FromBody] ContentModel contentModel
            )
        {
            var result = await _contentService.Update(contentModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contentService"></param>
        /// <param name="contentId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteContent(
            IContentService _contentService,
            int contentId
            )
        {
            try
            {
                var result = await _contentService.Delete(contentId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}