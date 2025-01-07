using Hydra.Infrastructure.Security.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Auth.Core.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<PaginatedList<RoleModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<RoleModel>>> GetAllRoles();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<RoleModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        Task<Result<RoleModel>> Add(RoleModel roleModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<Result<PermissionModel>> AssignPermissionToRoleAsync(int permissionId, int roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<Result> DismissPermissionToRoleAsync(int permissionId, int roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        Task<Result<RoleModel>> Update(RoleModel roleModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
