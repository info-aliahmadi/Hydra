using System.Security.Claims;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class OrderItemHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderItemService"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IOrderItemService orderItemService, [FromQuery] int orderId)
        {
            try
            {
                var result = await orderItemService.GetListByOrderId(orderId);
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
        /// <param name="orderItemService"></param>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetOrderItemById(IOrderItemService orderItemService, int orderItemId)
        {
            var result = await orderItemService.GetById(orderItemId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderItemService"></param>
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddOrderItem(ClaimsPrincipal userClaim, IOrderItemService orderItemService, [FromBody] OrderItemModel orderItemModel)
        {
            var result = await orderItemService.Add(orderItemModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderItemService"></param>
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateOrderItem(ClaimsPrincipal userClaim, IOrderItemService orderItemService, [FromBody] OrderItemModel orderItemModel)
        {
            var result = await orderItemService.Update(orderItemModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderItemService"></param>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteOrderItem(IOrderItemService orderItemService, int orderItemId)
        {
            try
            {
                var result = await orderItemService.Delete(orderItemId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}