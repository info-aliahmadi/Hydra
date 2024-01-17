using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class TaxCategoryHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="taxCategoryService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ITaxCategoryService taxCategoryService)
        {
            try
            {
                var result = await taxCategoryService.GetList();
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
        /// <param name="taxCategoryService"></param>
        /// <param name="taxCategoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetTaxCategoryById(ITaxCategoryService taxCategoryService, int taxCategoryId)
        {
            var result = await taxCategoryService.GetById(taxCategoryId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="taxCategoryService"></param>
        /// <param name="taxCategoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddTaxCategory(ClaimsPrincipal userClaim, ITaxCategoryService taxCategoryService, [FromBody] TaxCategoryModel taxCategoryModel)
        {
            var result = await taxCategoryService.Add(taxCategoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="taxCategoryService"></param>
        /// <param name="taxCategoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateTaxCategory(ClaimsPrincipal userClaim, ITaxCategoryService taxCategoryService, [FromBody] TaxCategoryModel taxCategoryModel)
        {
            var result = await taxCategoryService.Update(taxCategoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="taxCategoryService"></param>
        /// <param name="taxCategoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteTaxCategory(ITaxCategoryService taxCategoryService, int taxCategoryId)
        {
            try
            {
                var result = await taxCategoryService.Delete(taxCategoryId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}