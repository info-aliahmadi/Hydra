using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ShoppingCartItemHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="shoppingCartItemService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IShoppingCartItemService shoppingCartItemService, GridDataBound dataGrid)
        {
            try
            {
                var result = await shoppingCartItemService.GetList(dataGrid);
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
        /// <param name="shoppingCartItemService"></param>
        /// <param name="shoppingCartItemId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetShoppingCartItemById(IShoppingCartItemService shoppingCartItemService, int shoppingCartItemId)
        {
            var result = await shoppingCartItemService.GetById(shoppingCartItemId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shoppingCartItemService"></param>
        /// <param name="shoppingCartItemModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddShoppingCartItem(ClaimsPrincipal userClaim, IShoppingCartItemService shoppingCartItemService, [FromBody] ShoppingCartItemModel shoppingCartItemModel)
        {
            var result = await shoppingCartItemService.Add(shoppingCartItemModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shoppingCartItemService"></param>
        /// <param name="shoppingCartItemModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateShoppingCartItem(ClaimsPrincipal userClaim, IShoppingCartItemService shoppingCartItemService, [FromBody] ShoppingCartItemModel shoppingCartItemModel)
        {
            var result = await shoppingCartItemService.Update(shoppingCartItemModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shoppingCartItemService"></param>
        /// <param name="shoppingCartItemId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteShoppingCartItem(IShoppingCartItemService shoppingCartItemService, int shoppingCartItemId)
        {
            try
            {
                var result = await shoppingCartItemService.Delete(shoppingCartItemId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}