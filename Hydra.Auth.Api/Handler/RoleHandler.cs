using Hydra.Auth.Interface;
using Hydra.Auth.Models;
using Hydra.Kernel.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Auth.Api.Handler
{
    public class RoleHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="permissionId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static async Task<IResult> AssignPermissionToRoleByRoleId(
            IRoleService _roleService,
            int roleId,
            int permissionId
            )
        {
            var result = await _roleService.AssignPermissionToRoleAsync(permissionId, roleId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="permissionId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static async Task<IResult> DismissPermissionToRoleByRoleId(
            IRoleService _roleService,
            int roleId,
            int permissionId
            )
        {
            var result = await _roleService.DismissPermissionToRoleAsync(permissionId, roleId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             IRoleService _roleService, GridDataBound dataGrid)
        {
            var result = await _roleService.GetList(dataGrid);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetAllRoles(IRoleService _roleService)
        {
            var result = await _roleService.GetAllRoles();

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetRoleById(
            IRoleService _roleService,
            int roleId
            )
        {
            var result = await _roleService.GetById(roleId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddRole(
            IRoleService _roleService,
            [FromBody] RoleModel roleModel
            )
        {
            var result = await _roleService.Add(roleModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateRole(
            IRoleService _roleService,
            [FromBody] RoleModel roleModel
            )
        {
            var result = await _roleService.Update(roleModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_roleService"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteRole(
            IRoleService _roleService,
            int roleId
            )
        {
            var result = await _roleService.Delete(roleId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }


    }
}
