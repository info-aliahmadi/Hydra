using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class ProductPictureHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="productPictureService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(IProductPictureService productPictureService, GridDataBound dataGrid)
        {
            try
            {
                var result = await productPictureService.GetList(dataGrid);
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
        /// <param name="productPictureService"></param>
        /// <param name="productPictureId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetProductPictureById(IProductPictureService productPictureService, int productPictureId)
        {
            var result = await productPictureService.GetById(productPictureId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productPictureService"></param>
        /// <param name="productPictureModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddProductPicture(ClaimsPrincipal userClaim, IProductPictureService productPictureService, [FromBody] ProductPictureModel productPictureModel)
        {
            var result = await productPictureService.Add(productPictureModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="productPictureService"></param>
        /// <param name="productPictureModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateProductPicture(ClaimsPrincipal userClaim, IProductPictureService productPictureService, [FromBody] ProductPictureModel productPictureModel)
        {
            var result = await productPictureService.Update(productPictureModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productPictureService"></param>
        /// <param name="productPictureId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteProductPicture(IProductPictureService productPictureService, int productPictureId)
        {
            try
            {
                var result = await productPictureService.Delete(productPictureId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}