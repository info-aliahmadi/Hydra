using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class SearchTermHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="searchTermService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ISearchTermService searchTermService, GridDataBound dataGrid)
        {
            try
            {
                var result = await searchTermService.GetList(dataGrid);
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
        /// <param name="searchTermService"></param>
        /// <param name="searchTermId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetSearchTermById(ISearchTermService searchTermService, int searchTermId)
        {
            var result = await searchTermService.GetById(searchTermId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="searchTermService"></param>
        /// <param name="searchTermModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddSearchTerm(ClaimsPrincipal userClaim, ISearchTermService searchTermService, [FromBody] SearchTermModel searchTermModel)
        {
            var result = await searchTermService.Add(searchTermModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="searchTermService"></param>
        /// <param name="searchTermModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateSearchTerm(ClaimsPrincipal userClaim, ISearchTermService searchTermService, [FromBody] SearchTermModel searchTermModel)
        {
            var result = await searchTermService.Update(searchTermModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="searchTermService"></param>
        /// <param name="searchTermId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteSearchTerm(ISearchTermService searchTermService, int searchTermId)
        {
            try
            {
                var result = await searchTermService.Delete(searchTermId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}