using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Interfaces.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Hydra.Auth.Api.Handler
{
    public class UserHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_repository"></param>
        /// <param name="_userManager"></param>
        /// <param name="_roleManager"></param>
        /// <param name="roleName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<IResult> AssignRoleToUserByRoleName(
            IQueryRepository _repository,
            UserManager<User> _userManager,
            RoleManager<Role> _roleManager,
            string roleName,
            int userId
            )
        {
            try
            {
                var result = new AccountResult();

                if (!await _roleManager.RoleExistsAsync(roleName))
                    await _roleManager.CreateAsync(new Role() { Name = roleName, NormalizedName = roleName });

                var user = _repository.Table<User>().FirstOrDefault(x => x.Id == userId);
                if (user is null)
                {
                    result.Status = AccountStatusEnum.Failed;
                    result.Message = "The User does not found";
                    return Results.NotFound(result);
                }

                _ = _userManager.AddToRoleAsync(user, roleName);

                result.Status = AccountStatusEnum.Succeeded;

                return Results.Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_repository"></param>
        /// <param name="_userManager"></param>
        /// <param name="_roleManager"></param>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<IResult> AssignRoleToUserByRoleId(
            IQueryRepository _repository,
            UserManager<User> _userManager,
            RoleManager<Role> _roleManager,
            int roleId,
            int userId
            )
        {
            try
            {
                var result = new AccountResult();

                var role = await _roleManager.FindByIdAsync(roleId.ToString());

                var user = _repository.Table<User>().FirstOrDefault(x => x.Id == userId);
                if (user is null)
                {
                    result.Status = AccountStatusEnum.Failed;
                    result.Message = "The role does not found";
                    return Results.NotFound(result);
                }

                _ = _userManager.AddToRoleAsync(user, role.Name);

                result.Status = AccountStatusEnum.Succeeded;

                return Results.Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
