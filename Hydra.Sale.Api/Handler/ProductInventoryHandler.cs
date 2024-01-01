using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductInventoryHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productInventoryService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductInventoryService productInventoryService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productInventoryService.GetList(dataGrid);
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
        /// <param name="productInventoryService"></param>
        /// <param name="productInventoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductInventoryById(IProductInventoryService productInventoryService, int productInventoryId)
        {
            var result = await productInventoryService.GetById(productInventoryId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productInventoryService"></param>
        /// <param name="productInventoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductInventory(ClaimsPrincipal userClaim, IProductInventoryService productInventoryService, [FromBody] ProductInventoryModel productInventoryModel)
        {
            var result = await productInventoryService.Add(productInventoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productInventoryService"></param>
        /// <param name="productInventoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductInventory(ClaimsPrincipal userClaim, IProductInventoryService productInventoryService, [FromBody] ProductInventoryModel productInventoryModel)
        {
            var result = await productInventoryService.Update(productInventoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productInventoryService"></param>
        /// <param name="productInventoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductInventory(IProductInventoryService productInventoryService, int productInventoryId)
        {
            try
            {
                var result = await productInventoryService.Delete(productInventoryId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}