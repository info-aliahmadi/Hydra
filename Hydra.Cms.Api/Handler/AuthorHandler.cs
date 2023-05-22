using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Cms.Api.Handler
{
    public static class AuthorHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_authorService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
            IAuthorService _authorService
            )
        {
            var result = await _authorService.GetList();

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_authorService"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetById(
            IAuthorService _authorService,
            int authorId
            )
        {
            var result = await _authorService.GetById(authorId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_authorService"></param>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddAuthor(
            IAuthorService _authorService,
            [FromBody] AuthorModel authorModel
            )
        {
            var result = await _authorService.Add(authorModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_authorService"></param>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateAuthor(
            IAuthorService _authorService,
            [FromBody] AuthorModel authorModel
            )
        {
            var result = await _authorService.Update(authorModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_authorService"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteAuthor(
            IAuthorService _authorService,
            int authorId
            )
        {
            var result = await _authorService.Delete(authorId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }


    }
}