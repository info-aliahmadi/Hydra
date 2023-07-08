using EFCoreSecondLevelCacheInterceptor;
using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                                    userRole.UserId,
                                };
            foreach (var item in list.Items)
            {
                item.RoleIds = userRoleTable.Where(x => x.UserId == item.Id).Select(x => x.Id).ToList();
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

                userModel.RoleIds = (from userRole in _queryRepository.Table<UserRole>()
                                     join role in _queryRepository.Table<Role>() on userRole.RoleId equals role.Id
                                     where userRole.UserId == id
                                     select role.Id
                                   ).ToList();
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

            try
            {

                bool isExist = false;

                var user = await _queryRepository.Table<User>().FirstOrDefaultAsync(x => x.Id == userModel.Id);
                if (user is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The user not found";
                    return result;
                }

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
                    isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.PhoneNumber == userModel.PhoneNumber);
                    if (isExist)
                    {
                        result.Status = ResultStatusEnum.ItsDuplicate;
                        result.Message = "The PhoneNumber already exist";
                        result.Errors.Add(new Error("Duplicate", "The PhoneNumber already exist"));
                        return result;
                    }
                }

                user.Id = userModel.Id;
                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                user.Name = userModel.UserName;
                user.PhoneNumber = user.PhoneNumber;
                user.Avatar = userModel.Avatar;
                user.AccessFailedCount = userModel.AccessFailedCount;
                user.DefaultLanguage = userModel.DefaultLanguage;
                user.EmailConfirmed = userModel.EmailConfirmed;
                user.LockoutEnabled = userModel.LockoutEnabled;
                user.LockoutEnd = userModel.LockoutEnd;
                user.PhoneNumberConfirmed = userModel.PhoneNumberConfirmed;


                var saveFileResult = SaveAvatarFile(userModel.AvatarFile, user.Avatar);
                if (saveFileResult.Succeeded)
                {
                    user.Avatar = saveFileResult.Data;
                }

                _commandRepository.UpdateAsync(user);

                var userRoles = await _userManager.GetRolesAsync(user);

                //var mergedCount = userRoles.Count(x => userModel.RoleIds.Contains(x));

                //var inputRoleIdsCount = userModel.RoleIds.Count();

                //var existedRolesCount = userRoles.Count();

                //if (inputRoleIdsCount > existedRolesCount || inputRoleIdsCount < existedRolesCount || mergedCount != existedRolesCount)
                //{
                var roles = _queryRepository.Table<Role>().ToList();

                    //var oldRoleNames = roles.Where(x => userRoles.Select(c => c.RoleId).Contains(x.Id)).Select(x => x.Name).ToList();

                    await _userManager.RemoveFromRolesAsync(user, userRoles);

                    var newRoleNames = roles.Where(x => userModel.RoleIds.Contains(x.Id)).Select(c => c.Name).ToList();

                    await _userManager.AddToRolesAsync(user, newRoleNames);

                //}

                await _commandRepository.SaveChangesAsync();

                result.Data = userModel;
                return result;

            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;

                result.Message = e.Message;
                return result;
            }
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
        public Result<string> SaveAvatarFile(string avatarFile, string oldAvatarName = null)
        {
            var result = new Result();
            try
            {
                if (!string.IsNullOrEmpty(avatarFile))
                {
                    var fileBytes = avatarFile.Base64FileToBytes();
                    var fileName = fileBytes.RandomFileName;
                    var avatarPath = HydraHelper.GetAvatarDirectory() + "{0}";
                    File.WriteAllBytes(string.Format(avatarPath, fileName), fileBytes.FileBytes);
                    if (!string.IsNullOrEmpty(oldAvatarName))
                    {
                        if (File.Exists(string.Format(avatarPath, oldAvatarName)))
                        {
                            File.Delete(string.Format(avatarPath, oldAvatarName));
                        }
                    }
                    result.Data = fileName;
                    return result;
                }
                result.Status = ResultStatusEnum.NotFound;
                return result;

            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }

    }
}