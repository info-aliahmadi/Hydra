using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class OrderNoteHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderNoteService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IOrderNoteService orderNoteService, GridDataBound dataGrid)
        {
            try
            {
                var result = await orderNoteService.GetList(dataGrid);
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
        /// <param name="orderNoteService"></param>
        /// <param name="orderNoteId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetOrderNoteById(IOrderNoteService orderNoteService, int orderNoteId)
        {
            var result = await orderNoteService.GetById(orderNoteId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderNoteService"></param>
        /// <param name="orderNoteModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddOrderNote(ClaimsPrincipal userClaim, IOrderNoteService orderNoteService, [FromBody] OrderNoteModel orderNoteModel)
        {
            var result = await orderNoteService.Add(orderNoteModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="orderNoteService"></param>
        /// <param name="orderNoteModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateOrderNote(ClaimsPrincipal userClaim, IOrderNoteService orderNoteService, [FromBody] OrderNoteModel orderNoteModel)
        {
            var result = await orderNoteService.Update(orderNoteModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderNoteService"></param>
        /// <param name="orderNoteId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteOrderNote(IOrderNoteService orderNoteService, int orderNoteId)
        {
            try
            {
                var result = await orderNoteService.Delete(orderNoteId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}