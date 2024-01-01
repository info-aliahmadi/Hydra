using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class RelatedProductHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="relatedProductService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IRelatedProductService relatedProductService, GridDataBound dataGrid)
        {
            try
            {
                var result = await relatedProductService.GetList(dataGrid);
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
        /// <param name="relatedProductService"></param>
        /// <param name="relatedProductId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetRelatedProductById(IRelatedProductService relatedProductService, int relatedProductId)
        {
            var result = await relatedProductService.GetById(relatedProductId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="relatedProductService"></param>
        /// <param name="relatedProductModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddRelatedProduct(ClaimsPrincipal userClaim, IRelatedProductService relatedProductService, [FromBody] RelatedProductModel relatedProductModel)
        {
            var result = await relatedProductService.Add(relatedProductModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="relatedProductService"></param>
        /// <param name="relatedProductModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateRelatedProduct(ClaimsPrincipal userClaim, IRelatedProductService relatedProductService, [FromBody] RelatedProductModel relatedProductModel)
        {
            var result = await relatedProductService.Update(relatedProductModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="relatedProductService"></param>
        /// <param name="relatedProductId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteRelatedProduct(IRelatedProductService relatedProductService, int relatedProductId)
        {
            try
            {
                var result = await relatedProductService.Delete(relatedProductId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}