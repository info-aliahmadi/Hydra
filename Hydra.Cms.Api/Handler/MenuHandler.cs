﻿using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class MenuHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_menuService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetMenusHierarchy(IMenuService _menuService)
        {
            try
            {
                var result = await _menuService.GetHierarchy();

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
        /// <param name="_menuService"></param>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetMenuById(
            IMenuService _menuService,
            int menuId
            )
        {
            var result = await _menuService.GetById(menuId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_menuService"></param>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddMenu(ClaimsPrincipal userClaim,
            IMenuService _menuService,
            [FromBody] MenuModel menuModel
            )
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
                menuModel.UserId = userId;
                var result = await _menuService.Add(menuModel);

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
        /// <param name="_menuService"></param>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateMenu(ClaimsPrincipal userClaim,
            IMenuService _menuService,
            [FromBody] MenuModel menuModel
            )
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
                menuModel.UserId = userId;
                var result = await _menuService.Update(menuModel);

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
        /// <param name="_menuService"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteMenu(IMenuService _menuService, int menuId)
        {
            try
            {
                var result = await _menuService.Delete(menuId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}