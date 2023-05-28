using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Auth.Api.Handler
{
    public class PermissionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <returns></returns>
        [Permission("AUTH_GET.ONE.PERMISSION")]
        public static async Task<IResult> GetList(
            IPermissionService _permissionService
            )
        {
            var result = await _permissionService.GetList();

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        [Authorize("ssssss")]
        public static async Task<IResult> GetById(
            IPermissionService _permissionService,
            int permissionId
            )
        {
            var result = await _permissionService.GetById(permissionId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        
        public static async Task<IResult> AddPermission(
            IPermissionService _permissionService,
            [FromBody] PermissionModel permissionModel
            )
        {
            var result = await _permissionService.Add(permissionModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdatePermission(
            IPermissionService _permissionService,
            [FromBody] PermissionModel permissionModel
            )
        {
            var result = await _permissionService.Update(permissionModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeletePermission(
            IPermissionService _permissionService,
            int permissionId
            )
        {
            var result = await _permissionService.Delete(permissionId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

    }
}
