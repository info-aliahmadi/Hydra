using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ShipmentHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IShipmentService shipmentService, GridDataBound dataGrid)
        {
            try
            {
                var result = await shipmentService.GetList(dataGrid);
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
        /// <param name="shipmentService"></param>
        /// <param name="shipmentId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetShipmentById(IShipmentService shipmentService, int shipmentId)
        {
            var result = await shipmentService.GetById(shipmentId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shipmentService"></param>
        /// <param name="shipmentModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddShipment(ClaimsPrincipal userClaim, IShipmentService shipmentService, [FromBody] ShipmentModel shipmentModel)
        {
            var result = await shipmentService.Add(shipmentModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="shipmentService"></param>
        /// <param name="shipmentModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateShipment(ClaimsPrincipal userClaim, IShipmentService shipmentService, [FromBody] ShipmentModel shipmentModel)
        {
            var result = await shipmentService.Update(shipmentModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentService"></param>
        /// <param name="shipmentId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteShipment(IShipmentService shipmentService, int shipmentId)
        {
            try
            {
                var result = await shipmentService.Delete(shipmentId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}