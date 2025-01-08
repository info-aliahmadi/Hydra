using Hydra.Infrastructure.Security.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.GeneralModels;

namespace Hydra.Infrastructure.Security.Interface
{
    public interface IPermissionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<PaginatedList<PermissionModel>>> GetList(GridDataBound dataGrid);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<PermissionModel>>> GetPermissionsByName(string name);

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
