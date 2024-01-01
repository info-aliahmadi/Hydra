using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductTagHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productTagService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductTagService productTagService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productTagService.GetList(dataGrid);
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
        /// <param name="productTagService"></param>
        /// <param name="productTagId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductTagById(IProductTagService productTagService, int productTagId)
        {
            var result = await productTagService.GetById(productTagId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productTagService"></param>
        /// <param name="productTagModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductTag(ClaimsPrincipal userClaim, IProductTagService productTagService, [FromBody] ProductTagModel productTagModel)
        {
            var result = await productTagService.Add(productTagModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productTagService"></param>
        /// <param name="productTagModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductTag(ClaimsPrincipal userClaim, IProductTagService productTagService, [FromBody] ProductTagModel productTagModel)
        {
            var result = await productTagService.Update(productTagModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productTagService"></param>
        /// <param name="productTagId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductTag(IProductTagService productTagService, int productTagId)
        {
            try
            {
                var result = await productTagService.Delete(productTagId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}