using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Interface;
using Hydra.Infrastructure.Security.Models;
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
        public static async Task<IResult> GetList(
            IPermissionService _permissionService, GridDataBound dataGrid
            )
        {
            var result = await _permissionService.GetList(dataGrid);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetPermissionsByName(
            IPermissionService _permissionService, string name
            )
        {
            var result = await _permissionService.GetPermissionsByName(name);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permissionService"></param>
        /// <param name="permissionId"></param>
        /// <returns></returns>
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
