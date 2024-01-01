using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductReviewHelpfulnessHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewHelpfulnessService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductReviewHelpfulnessService productReviewHelpfulnessService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productReviewHelpfulnessService.GetList(dataGrid);
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
        /// <param name="productReviewHelpfulnessService"></param>
        /// <param name="productReviewHelpfulnessId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductReviewHelpfulnessById(IProductReviewHelpfulnessService productReviewHelpfulnessService, int productReviewHelpfulnessId)
        {
            var result = await productReviewHelpfulnessService.GetById(productReviewHelpfulnessId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productReviewHelpfulnessService"></param>
        /// <param name="productReviewHelpfulnessModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductReviewHelpfulness(ClaimsPrincipal userClaim, IProductReviewHelpfulnessService productReviewHelpfulnessService, [FromBody] ProductReviewHelpfulnessModel productReviewHelpfulnessModel)
        {
            var result = await productReviewHelpfulnessService.Add(productReviewHelpfulnessModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productReviewHelpfulnessService"></param>
        /// <param name="productReviewHelpfulnessModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductReviewHelpfulness(ClaimsPrincipal userClaim, IProductReviewHelpfulnessService productReviewHelpfulnessService, [FromBody] ProductReviewHelpfulnessModel productReviewHelpfulnessModel)
        {
            var result = await productReviewHelpfulnessService.Update(productReviewHelpfulnessModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewHelpfulnessService"></param>
        /// <param name="productReviewHelpfulnessId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductReviewHelpfulness(IProductReviewHelpfulnessService productReviewHelpfulnessService, int productReviewHelpfulnessId)
        {
            try
            {
                var result = await productReviewHelpfulnessService.Delete(productReviewHelpfulnessId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}