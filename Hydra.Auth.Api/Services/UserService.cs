using EFCoreSecondLevelCacheInterceptor;
using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Auth.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        UserManager<User> _userManager;
        RoleManager<Role> _roleManager;

        public UserService(IQueryRepository queryRepository, ICommandRepository commandRepository, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<PaginatedList<UserModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<UserModel>>();

            var list = await (from user in _queryRepository.Table<User>()
                              select new UserModel()
                              {
                                  UserName = user.UserName,
                                  Email = user.Email,
                                  Name = user.Name,
                                  PhoneNumber = user.PhoneNumber,
                                  Avatar = user.Avatar,
                                  AccessFailedCount = user.AccessFailedCount,
                                  DefaultLanguage = user.DefaultLanguage,
                                  RegisterDate = user.RegisterDate,
                                  EmailConfirmed = user.EmailConfirmed,
                                  Id = user.Id,
                                  LockoutEnabled = user.LockoutEnabled,
                                  LockoutEnd = user.LockoutEnd,
                                  PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                              }).ToPaginatedListAsync(dataGrid);

            var userIds = list.Items.Select(x => x.Id);

            var userRoleTable = from userRole in _queryRepository.Table<UserRole>()
                                join role in _queryRepository.Table<Role>() on userRole.RoleId equals role.Id
                                where userIds.Contains(userRole.UserId)
                                select new
                                {
                                    role.Id,
                                    role.Name,
                                    userRole.UserId,
                                };
            foreach (var item in list.Items)
            {
                item.Roles = userRoleTable.Where(x => x.UserId == item.Id).Select(x => new RoleModel() { Id = x.Id, Name = x.Name }).ToList();
            }

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<UserModel>> GetById(int id)
        {
            var result = new Result<UserModel>();

            var user = await _queryRepository.Table<User>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var userModel = new UserModel();
            if (user != null)
            {
                userModel.Id = user.Id;
                userModel.UserName = user.UserName;
                userModel.Email = user.Email;
                userModel.Name = user.Name;
                userModel.PhoneNumber = user.PhoneNumber;
                userModel.Avatar = user.Avatar;
                userModel.AccessFailedCount = user.AccessFailedCount;
                userModel.DefaultLanguage = user.DefaultLanguage;
                userModel.RegisterDate = user.RegisterDate;
                userModel.EmailConfirmed = user.EmailConfirmed;
                userModel.LockoutEnabled = user.LockoutEnabled;
                userModel.LockoutEnd = user.LockoutEnd;
                userModel.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            }
            result.Data = userModel;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<Result<UserModel>> Add(UserModel userModel)
        {
            var result = new Result<UserModel>();
            bool isExist = false;
            isExist = await _queryRepository.Table<User>().AnyAsync(x => x.UserName == userModel.UserName);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Username already exist";
                result.Errors.Add(new Error("Duplicate", "The Username already exist"));
                return result;
            }
            isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Email == userModel.Email);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Email already exist";
                result.Errors.Add(new Error("Duplicate", "The Email already exist"));
                return result;
            }
            if (!string.IsNullOrEmpty(userModel.PhoneNumber))
            {
                isExist = await _queryRepository.Table<User>().AnyAsync(x => x.PhoneNumber == x.PhoneNumber);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The PhoneNumber already exist";
                    result.Errors.Add(new Error("Duplicate", "The PhoneNumber already exist"));
                    return result;
                }
            }

            var user = new User()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                Name = userModel.Name,
                PhoneNumber = userModel.PhoneNumber,
                Avatar = userModel.Avatar,
                AccessFailedCount = userModel.AccessFailedCount,
                DefaultLanguage = userModel.DefaultLanguage,
                RegisterDate = userModel.RegisterDate,
                EmailConfirmed = userModel.EmailConfirmed,
                Id = userModel.Id,
                LockoutEnabled = userModel.LockoutEnabled,
                PhoneNumberConfirmed = userModel.PhoneNumberConfirmed,
            };
            await _commandRepository.InsertAsync(user);
            await _commandRepository.SaveChangesAsync();

            userModel.Id = user.Id;
            result.Data = userModel;
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<Result<UserModel>> Update(UserModel userModel)
        {
            var result = new Result<UserModel>();
            bool isExist = false;
            isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.UserName == userModel.UserName);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Username already exist";
                result.Errors.Add(new Error("Duplicate", "The Username already exist"));
                return result;
            }
            isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.Email == userModel.Email);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Email already exist";
                result.Errors.Add(new Error("Duplicate", "The Email already exist"));
                return result;
            }
            if (!string.IsNullOrEmpty(userModel.PhoneNumber))
            {
                isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.PhoneNumber == x.PhoneNumber);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The PhoneNumber already exist";
                    result.Errors.Add(new Error("Duplicate", "The PhoneNumber already exist"));
                    return result;
                }
            }

            var user = await _queryRepository.Table<User>().FirstOrDefaultAsync(x => x.Id == userModel.Id);
            if (user is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The user not found";
                return result;
            }

            user.Id = userModel.Id;
            user.UserName = userModel.UserName;
            user.Email = userModel.Email;
            user.Name = userModel.UserName;
            user.PhoneNumber = user.PhoneNumber;
            user.Avatar = userModel.Avatar;
            user.AccessFailedCount = userModel.AccessFailedCount;
            user.DefaultLanguage = userModel.DefaultLanguage;
            user.RegisterDate = userModel.RegisterDate;
            user.EmailConfirmed = userModel.EmailConfirmed;
            user.LockoutEnabled = userModel.LockoutEnabled;
            user.LockoutEnd = userModel.LockoutEnd;
            user.PhoneNumberConfirmed = userModel.PhoneNumberConfirmed;

            _commandRepository.UpdateAsync(user);

            await _commandRepository.SaveChangesAsync();

            result.Data = userModel;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Result> DeleteUser(
            int userId
            )
        {
            try
            {
                var result = new Result();
                var user = await _userManager.FindByIdAsync(userId.ToString());
                var identityResult = await _userManager.DeleteAsync(user);

                result.Status = identityResult.Succeeded ? ResultStatusEnum.Succeeded : ResultStatusEnum.Failed;
                result.Message = identityResult.Errors.First().Description;
                return result;

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
        public async Task<Result> AssignRoleToUserByRoleId(int roleId, int userId)
        {
            try
            {
                var result = new Result();

                var role = await _roleManager.FindByIdAsync(roleId.ToString());

                var user = _queryRepository.Table<User>().FirstOrDefault(x => x.Id == userId);
                if (user is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The user not found";
                    return result;
                }

                var identityResult = await _userManager.AddToRoleAsync(user, role.Name);

                result.Status = identityResult.Succeeded ? ResultStatusEnum.Succeeded : ResultStatusEnum.Failed;
                result.Message = identityResult.Errors.First().Description;
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}