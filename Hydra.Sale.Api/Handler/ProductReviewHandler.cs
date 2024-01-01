using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductReviewHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductReviewService productReviewService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productReviewService.GetList(dataGrid);
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
        /// <param name="productReviewService"></param>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductReviewById(IProductReviewService productReviewService, int productReviewId)
        {
            var result = await productReviewService.GetById(productReviewId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productReviewService"></param>
        /// <param name="productReviewModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductReview(ClaimsPrincipal userClaim, IProductReviewService productReviewService, [FromBody] ProductReviewModel productReviewModel)
        {
            var result = await productReviewService.Add(productReviewModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productReviewService"></param>
        /// <param name="productReviewModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductReview(ClaimsPrincipal userClaim, IProductReviewService productReviewService, [FromBody] ProductReviewModel productReviewModel)
        {
            var result = await productReviewService.Update(productReviewModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewService"></param>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductReview(IProductReviewService productReviewService, int productReviewId)
        {
            try
            {
                var result = await productReviewService.Delete(productReviewId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}