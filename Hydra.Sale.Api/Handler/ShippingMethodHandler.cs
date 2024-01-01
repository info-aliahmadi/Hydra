using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ShippingMethodHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="shippingMethodService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IShippingMethodService shippingMethodService, GridDataBound dataGrid)
        {
            try
            {
                var result = await shippingMethodService.GetList(dataGrid);
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
        /// <param name="shippingMethodService"></param>
        /// <param name="shippingMethodId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetShippingMethodById(IShippingMethodService shippingMethodService, int shippingMethodId)
        {
            var result = await shippingMethodService.GetById(shippingMethodId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shippingMethodService"></param>
        /// <param name="shippingMethodModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddShippingMethod(ClaimsPrincipal userClaim, IShippingMethodService shippingMethodService, [FromBody] ShippingMethodModel shippingMethodModel)
        {
            var result = await shippingMethodService.Add(shippingMethodModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shippingMethodService"></param>
        /// <param name="shippingMethodModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateShippingMethod(ClaimsPrincipal userClaim, IShippingMethodService shippingMethodService, [FromBody] ShippingMethodModel shippingMethodModel)
        {
            var result = await shippingMethodService.Update(shippingMethodModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shippingMethodService"></param>
        /// <param name="shippingMethodId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteShippingMethod(IShippingMethodService shippingMethodService, int shippingMethodId)
        {
            try
            {
                var result = await shippingMethodService.Delete(shippingMethodId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}