using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Models;

namespace Hydra.Auth.Core.Interfaces
{
    public interface IPermissionService
    {
        bool CheckPermissionForUser(int userId, string permissionName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<PermissionModel>>> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<PermissionModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        Task<Result<PermissionModel>> Add(PermissionModel permissionModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        Task<Result<PermissionModel>> Update(PermissionModel permissionModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
