using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class PageHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_articleService"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetPageByIdForVisitors(
            IPageService _pageService,
            int pageId
            )
        {
            var result = await _pageService.GetById(pageId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pageService"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             IPageService _pageService, GridDataBound dataGrid)
        {
            try
            {
                var result = await _pageService.GetList(dataGrid);

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
        /// <param name="_pageService"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetPageById(
            IPageService _pageService,
            int pageId
            )
        {
            var result = await _pageService.GetById(pageId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pageService"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddPage(
            ClaimsPrincipal userClaim,
            IPageService _pageService,
            [FromBody] PageModel pageModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            pageModel.WriterId = userId;
            var result = await _pageService.Add(pageModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pageService"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdatePage(
            ClaimsPrincipal userClaim,
            IPageService _pageService,
            [FromBody] PageModel pageModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            pageModel.EditorId = userId;
            var result = await _pageService.Update(pageModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pageService"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeletePage(
            IPageService _pageService,
            int pageId
            )
        {
            try
            {
                var result = await _pageService.Delete(pageId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}