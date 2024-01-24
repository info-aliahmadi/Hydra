using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductAttributeHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productAttributeService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductAttributeService productAttributeService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productAttributeService.GetList(dataGrid);
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
        /// <param name="productAttributeService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static IResult GetListForSelect(IProductAttributeService productAttributeService)
        {
            try
            {
                var result = productAttributeService.GetListForSelect();
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
        /// <param name="productAttributeService"></param>
        /// <param name="productAttributeId"></param>
        /// <returns></returns>
        public static IResult GetProductAttributeById(IProductAttributeService productAttributeService, int productAttributeId)
        {
            var result = productAttributeService.GetById(productAttributeId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productAttributeService"></param>
        /// <param name="productAttributeModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductAttribute(ClaimsPrincipal userClaim, IProductAttributeService productAttributeService, [FromBody] ProductAttributeModel productAttributeModel)
        {
            var result = await productAttributeService.Add(productAttributeModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productAttributeService"></param>
        /// <param name="productAttributeModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductAttribute(ClaimsPrincipal userClaim, IProductAttributeService productAttributeService, [FromBody] ProductAttributeModel productAttributeModel)
        {
            var result = await productAttributeService.Update(productAttributeModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productAttributeService"></param>
        /// <param name="productAttributeId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductAttribute(IProductAttributeService productAttributeService, int productAttributeId)
        {
            try
            {
                var result = await productAttributeService.Delete(productAttributeId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}