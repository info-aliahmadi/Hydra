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
    public static class ArticleHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_articleService"></param>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             IArticleService _articleService, GridDataBound dataGrid)
        {
            try
            {
                var result = await _articleService.GetList(dataGrid);

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
        /// <param name="_articleService"></param>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetArticleById(
            IArticleService _articleService,
            int articleId
            )
        {
            var result = await _articleService.GetById(articleId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_articleService"></param>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddArticle(
            ClaimsPrincipal userClaim,
            IArticleService _articleService,
            [FromBody] ArticleModel articleModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            articleModel.WriterId = userId;
            var result = await _articleService.Add(articleModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_articleService"></param>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateArticle(
            ClaimsPrincipal userClaim,
            IArticleService _articleService,
            [FromBody] ArticleModel articleModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            articleModel.EditorId = userId;
            var result = await _articleService.Update(articleModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_articleService"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteArticle(
            IArticleService _articleService,
            int articleId
            )
        {
            try
            {
                var result = await _articleService.Delete(articleId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}