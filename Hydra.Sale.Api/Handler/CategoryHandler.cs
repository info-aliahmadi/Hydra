using System.Security.Claims;
using Hydra.Kernel.Extensions;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Sale.Api.Handler
{
    public static class CategoryHandler
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ICategoryService categoryService, GridDataBound dataGrid)
        {
            try
            {
                var result = await categoryService.GetList(dataGrid);
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
        /// <param name="categoryService"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetCategoryById(ICategoryService categoryService, int categoryId)
        {
            var result = await categoryService.GetById(categoryId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="categoryService"></param>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddCategory(ClaimsPrincipal userClaim, ICategoryService categoryService, [FromBody] CategoryModel categoryModel)
        {
            var result = await categoryService.Add(categoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="categoryService"></param>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateCategory(ClaimsPrincipal userClaim, ICategoryService categoryService, [FromBody] CategoryModel categoryModel)
        {
            var result = await categoryService.Update(categoryModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteCategory(ICategoryService categoryService, int categoryId)
        {
            try
            {
                var result = await categoryService.Delete(categoryId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}