using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class OrderDiscountHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderDiscountService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IOrderDiscountService orderDiscountService, GridDataBound dataGrid)
        {
            try
            {
                var result = await orderDiscountService.GetList(dataGrid);
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
        /// <param name="orderDiscountService"></param>
        /// <param name="orderDiscountId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetOrderDiscountById(IOrderDiscountService orderDiscountService, int orderDiscountId)
        {
            var result = await orderDiscountService.GetById(orderDiscountId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderDiscountService"></param>
        /// <param name="orderDiscountModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddOrderDiscount(ClaimsPrincipal userClaim, IOrderDiscountService orderDiscountService, [FromBody] OrderDiscountModel orderDiscountModel)
        {
            var result = await orderDiscountService.Add(orderDiscountModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderDiscountService"></param>
        /// <param name="orderDiscountModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateOrderDiscount(ClaimsPrincipal userClaim, IOrderDiscountService orderDiscountService, [FromBody] OrderDiscountModel orderDiscountModel)
        {
            var result = await orderDiscountService.Update(orderDiscountModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderDiscountService"></param>
        /// <param name="orderDiscountId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteOrderDiscount(IOrderDiscountService orderDiscountService, int orderDiscountId)
        {
            try
            {
                var result = await orderDiscountService.Delete(orderDiscountId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}