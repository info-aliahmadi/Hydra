using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductCategoryHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCategoryService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductCategoryService productCategoryService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productCategoryService.GetList(dataGrid);
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
        /// <param name="productCategoryService"></param>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductCategoryById(IProductCategoryService productCategoryService, int productCategoryId)
        {
            var result = await productCategoryService.GetById(productCategoryId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productCategoryService"></param>
        /// <param name="productCategoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductCategory(ClaimsPrincipal userClaim, IProductCategoryService productCategoryService, [FromBody] ProductCategoryModel productCategoryModel)
        {
            var result = await productCategoryService.Add(productCategoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productCategoryService"></param>
        /// <param name="productCategoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductCategory(ClaimsPrincipal userClaim, IProductCategoryService productCategoryService, [FromBody] ProductCategoryModel productCategoryModel)
        {
            var result = await productCategoryService.Update(productCategoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCategoryService"></param>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductCategory(IProductCategoryService productCategoryService, int productCategoryId)
        {
            try
            {
                var result = await productCategoryService.Delete(productCategoryId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}