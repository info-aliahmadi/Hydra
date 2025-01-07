using Hydra.Infrastructure.Security.Models;
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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<UserModel>> GetAdminUser();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Result<List<UserModel>>> GetListForSelect(string input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<Result<List<UserModel>>> GetListForSelectByIds(int[] userIds);

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
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<Result> AssignRoleToUser(int userId, int roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task<Result<UserModel>> AssignRolesToUser(int userId, int[] roleIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="avatarFile"></param>
        /// <param name="oldAvatarName"></param>
        /// <returns></returns>
        Result<string> SaveAvatarFile(string avatarFile, string oldAvatarName = null);


    }
}
