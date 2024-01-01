using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class OrderHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IOrderService orderService, GridDataBound dataGrid)
        {
            try
            {
                var result = await orderService.GetList(dataGrid);
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
        /// <param name="orderService"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetOrderById(IOrderService orderService, int orderId)
        {
            var result = await orderService.GetById(orderId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderService"></param>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddOrder(ClaimsPrincipal userClaim, IOrderService orderService, [FromBody] OrderModel orderModel)
        {
            var result = await orderService.Add(orderModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderService"></param>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateOrder(ClaimsPrincipal userClaim, IOrderService orderService, [FromBody] OrderModel orderModel)
        {
            var result = await orderService.Update(orderModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderService"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteOrder(IOrderService orderService, int orderId)
        {
            try
            {
                var result = await orderService.Delete(orderId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}