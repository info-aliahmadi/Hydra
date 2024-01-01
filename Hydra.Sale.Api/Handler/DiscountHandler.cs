using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class DiscountHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="discountService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IDiscountService discountService, GridDataBound dataGrid)
        {
            try
            {
                var result = await discountService.GetList(dataGrid);
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
        /// <param name="discountService"></param>
        /// <param name="discountId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetDiscountById(IDiscountService discountService, int discountId)
        {
            var result = await discountService.GetById(discountId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="discountService"></param>
        /// <param name="discountModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddDiscount(ClaimsPrincipal userClaim, IDiscountService discountService, [FromBody] DiscountModel discountModel)
        {
            var result = await discountService.Add(discountModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="discountService"></param>
        /// <param name="discountModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateDiscount(ClaimsPrincipal userClaim, IDiscountService discountService, [FromBody] DiscountModel discountModel)
        {
            var result = await discountService.Update(discountModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="discountService"></param>
        /// <param name="discountId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteDiscount(IDiscountService discountService, int discountId)
        {
            try
            {
                var result = await discountService.Delete(discountId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}