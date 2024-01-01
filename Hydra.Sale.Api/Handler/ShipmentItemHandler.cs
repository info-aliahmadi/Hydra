using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ShipmentItemHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentItemService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IShipmentItemService shipmentItemService, GridDataBound dataGrid)
        {
            try
            {
                var result = await shipmentItemService.GetList(dataGrid);
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
        /// <param name="shipmentItemService"></param>
        /// <param name="shipmentItemId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetShipmentItemById(IShipmentItemService shipmentItemService, int shipmentItemId)
        {
            var result = await shipmentItemService.GetById(shipmentItemId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shipmentItemService"></param>
        /// <param name="shipmentItemModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddShipmentItem(ClaimsPrincipal userClaim, IShipmentItemService shipmentItemService, [FromBody] ShipmentItemModel shipmentItemModel)
        {
            var result = await shipmentItemService.Add(shipmentItemModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shipmentItemService"></param>
        /// <param name="shipmentItemModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateShipmentItem(ClaimsPrincipal userClaim, IShipmentItemService shipmentItemService, [FromBody] ShipmentItemModel shipmentItemModel)
        {
            var result = await shipmentItemService.Update(shipmentItemModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentItemService"></param>
        /// <param name="shipmentItemId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteShipmentItem(IShipmentItemService shipmentItemService, int shipmentItemId)
        {
            try
            {
                var result = await shipmentItemService.Delete(shipmentItemId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}