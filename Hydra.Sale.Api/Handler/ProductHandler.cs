using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductService productService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productService.GetList(dataGrid);
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
        /// <param name="productService"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductById(IProductService productService, int productId)
        {
            var result = await productService.GetById(productId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductsByIds(IProductService productService, string productIds)
        {
            var Ids = productIds.Split(',').Select(x => int.Parse(x)).ToArray();

            var result = await productService.GetByIds(Ids);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductsByInput(IProductService productService, string input)
        {
            var result = await productService.GetProductsByInput(input);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productService"></param>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProduct(ClaimsPrincipal userClaim, IProductService productService, [FromBody] ProductModel productModel)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            productModel.CreateUserId = userId;
            var result = await productService.Add(productModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productService"></param>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProduct(ClaimsPrincipal userClaim, IProductService productService, [FromBody] ProductModel productModel)
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            productModel.UpdateUserId = userId;

            var result = await productService.Update(productModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProduct(IProductService productService, int productId)
        {
            try
            {
                var result = await productService.Delete(productId);
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
        /// <param name="productService"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static async Task<IResult> RemoveProduct(IProductService productService, int productId)
        {
            try
            {
                var result = await productService.Remove(productId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}