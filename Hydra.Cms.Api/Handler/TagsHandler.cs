using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Api.Services;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class TagHandler
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagService"></param>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             ITagService _tagService, GridDataBound dataGrid)
        {
            try
            {
                var result = await _tagService.GetList(dataGrid);

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
        /// <param name="_tagService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetListForSelect(ITagService _tagService)
        {
            try
            {
                var result = await _tagService.GetListForSelect();

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
        /// <param name="_tagService"></param>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetTagById(
            ITagService _tagService,
            int tagId
            )
        {
            var result = await _tagService.GetById(tagId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagService"></param>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddTag(ClaimsPrincipal userClaim,
            ITagService _tagService,
            [FromBody] TagModel tagModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            var result = await _tagService.Add(tagModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagService"></param>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateTag(ClaimsPrincipal userClaim,
            ITagService _tagService,
            [FromBody] TagModel tagModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            var result = await _tagService.Update(tagModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tagService"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteTag(ClaimsPrincipal userClaim,
            ITagService _tagService,
            int tagId
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            try
            {
                var result = await _tagService.Delete(tagId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}