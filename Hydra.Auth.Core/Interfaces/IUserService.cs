using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;


namespace Hydra.Auth.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<PaginatedList<UserModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<UserModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        Task<Result<UserModel>> Add(UserModel userModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        Task<Result<UserModel>> Update(UserModel userModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Result> DeleteUser(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Result> AssignRoleToUserByRoleId(int roleId, int userId);


    }
}
