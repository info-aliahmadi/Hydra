using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductManufacturerHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productManufacturerService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductManufacturerService productManufacturerService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productManufacturerService.GetList(dataGrid);
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
        /// <param name="productManufacturerService"></param>
        /// <param name="productManufacturerId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductManufacturerById(IProductManufacturerService productManufacturerService, int productManufacturerId)
        {
            var result = await productManufacturerService.GetById(productManufacturerId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productManufacturerService"></param>
        /// <param name="productManufacturerModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductManufacturer(ClaimsPrincipal userClaim, IProductManufacturerService productManufacturerService, [FromBody] ProductManufacturerModel productManufacturerModel)
        {
            var result = await productManufacturerService.Add(productManufacturerModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productManufacturerService"></param>
        /// <param name="productManufacturerModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductManufacturer(ClaimsPrincipal userClaim, IProductManufacturerService productManufacturerService, [FromBody] ProductManufacturerModel productManufacturerModel)
        {
            var result = await productManufacturerService.Update(productManufacturerModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productManufacturerService"></param>
        /// <param name="productManufacturerId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductManufacturer(IProductManufacturerService productManufacturerService, int productManufacturerId)
        {
            try
            {
                var result = await productManufacturerService.Delete(productManufacturerId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}