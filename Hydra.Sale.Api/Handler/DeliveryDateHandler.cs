using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class DeliveryDateHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="deliveryDateService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IDeliveryDateService deliveryDateService)
        {
            try
            {
                var result = await deliveryDateService.GetList();
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
        /// <param name="deliveryDateService"></param>
        /// <param name="deliveryDateId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetDeliveryDateById(IDeliveryDateService deliveryDateService, int deliveryDateId)
        {
            var result = await deliveryDateService.GetById(deliveryDateId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="deliveryDateService"></param>
        /// <param name="deliveryDateModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddDeliveryDate(ClaimsPrincipal userClaim, IDeliveryDateService deliveryDateService, [FromBody] DeliveryDateModel deliveryDateModel)
        {
            var result = await deliveryDateService.Add(deliveryDateModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="deliveryDateService"></param>
        /// <param name="deliveryDateModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateDeliveryDate(ClaimsPrincipal userClaim, IDeliveryDateService deliveryDateService, [FromBody] DeliveryDateModel deliveryDateModel)
        {
            var result = await deliveryDateService.Update(deliveryDateModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="deliveryDateService"></param>
        /// <param name="deliveryDateId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteDeliveryDate(IDeliveryDateService deliveryDateService, int deliveryDateId)
        {
            try
            {
                var result = await deliveryDateService.Delete(deliveryDateId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}