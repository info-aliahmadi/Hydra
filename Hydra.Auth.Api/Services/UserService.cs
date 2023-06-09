﻿using EFCoreSecondLevelCacheInterceptor;
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

            var isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id == id);
            if (!isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The User Not Found";
                result.Errors.Add(new Error(nameof(id), "The User Not Found"));
                return result;
            }

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
            try
            {
                bool isExist = false;
                isExist = await _queryRepository.Table<User>().AnyAsync(x => x.UserName == userModel.UserName);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Username already exist";
                    result.Errors.Add(new Error(nameof(userModel.UserName), "The Username already exist"));
                    return result;
                }
                isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Email == userModel.Email);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Email already exist";
                    result.Errors.Add(new Error(nameof(userModel.Email), "The Email already exist"));
                    return result;
                }
                if (!string.IsNullOrEmpty(userModel.PhoneNumber))
                {
                    isExist = await _queryRepository.Table<User>().AnyAsync(x => x.PhoneNumber == userModel.PhoneNumber);
                    if (isExist)
                    {
                        result.Status = ResultStatusEnum.ItsDuplicate;
                        result.Message = "The PhoneNumber already exist";
                        result.Errors.Add(new Error(nameof(userModel.PhoneNumber), "The PhoneNumber already exist"));
                        return result;
                    }
                }

                var user = new User()
                {
                    Name = userModel.Name,
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber,
                    DefaultLanguage = userModel.DefaultLanguage,
                    RegisterDate = DateTime.UtcNow
                };

                if (!string.IsNullOrEmpty(userModel.AvatarFile))
                {
                    var saveFileResult = SaveAvatarFile(userModel.AvatarFile);
                    if (saveFileResult.Succeeded)
                    {
                        user.Avatar = saveFileResult.Data;
                    }
                }

                await _userManager.CreateAsync(user, userModel.Password);

                await _commandRepository.SaveChangesAsync();

                var assigntResult = await AssignRolesToUser(user.Id, userModel.RoleIds.ToArray());

                if (!assigntResult.Succeeded)
                {
                    return assigntResult;
                }


                userModel.Id = user.Id;
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
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<Result<UserModel>> Update(UserModel userModel)
        {
            var result = new Result<UserModel>();

            try
            {

                bool isExist = false;

                var user = await _queryRepository.Table<User>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == userModel.Id);
                if (user is null)
                {
                    result.Status = ResultStatusEnum.NotFound;

                    result.Errors.Add(new Error(nameof(userModel.Id), "The User Not Found"));
                    result.Message = "The user not found";
                    return result;
                }

                isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.UserName == userModel.UserName);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Username already exist";
                    result.Errors.Add(new Error(nameof(userModel.UserName), "The Username already exist"));
                    return result;
                }
                isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.Email == userModel.Email);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Email already exist";
                    result.Errors.Add(new Error(nameof(userModel.Email), "The Email already exist"));
                    return result;
                }
                if (!string.IsNullOrEmpty(userModel.PhoneNumber))
                {
                    isExist = await _queryRepository.Table<User>().AnyAsync(x => x.Id != userModel.Id && x.PhoneNumber == userModel.PhoneNumber);
                    if (isExist)
                    {
                        result.Status = ResultStatusEnum.ItsDuplicate;
                        result.Message = "The PhoneNumber already exist";
                        result.Errors.Add(new Error(nameof(userModel.PhoneNumber), "The PhoneNumber already exist"));
                        return result;
                    }
                }

                user.Id = userModel.Id;
                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                user.Name = userModel.UserName;
                user.PhoneNumber = userModel.PhoneNumber;
                user.AccessFailedCount = userModel.AccessFailedCount;
                user.DefaultLanguage = userModel.DefaultLanguage;
                user.EmailConfirmed = userModel.EmailConfirmed;
                user.LockoutEnabled = userModel.LockoutEnabled;
                user.LockoutEnd = userModel.LockoutEnd;
                user.PhoneNumberConfirmed = userModel.PhoneNumberConfirmed;

                if (string.IsNullOrEmpty(userModel.Avatar) && !string.IsNullOrEmpty(user.Avatar))
                {
                    DeleteAvatarFile(user.Avatar);
                    user.Avatar = null;
                }
                if (!string.IsNullOrEmpty(userModel.AvatarFile))
                {
                    var saveFileResult = SaveAvatarFile(userModel.AvatarFile, user.Avatar);
                    if (saveFileResult.Succeeded)
                    {
                        user.Avatar = saveFileResult.Data;
                    }
                }

                _commandRepository.UpdateAsync(user);
                await _commandRepository.SaveChangesAsync();


                var assigntResult = await AssignRolesToUser(userModel.Id, userModel.RoleIds.ToArray());

                if (!assigntResult.Succeeded)
                {
                    return assigntResult;
                }

                if (!string.IsNullOrEmpty(userModel.Password))
                {
                    await _userManager.AddPasswordAsync(user, userModel.Password);
                }

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
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Result> DeleteUser(int userId)
        {
            var result = new Result();
            try
            {
                var user = await _queryRepository.Table<User>().FirstOrDefaultAsync(x => x.Id == userId);
                if (user != null)
                {
                    var identityResult = await _userManager.DeleteAsync(user);

                    if (identityResult.Succeeded)
                    {
                        DeleteAvatarFile(user.Avatar);
                    }

                    result.Status = identityResult.Succeeded ? ResultStatusEnum.Succeeded : ResultStatusEnum.Failed;
                    result.Message = identityResult.Succeeded == false ? identityResult.Errors.First().Description : "";
                    return result;
                }
                else
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The user not found";
                    return result;
                }

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
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<Result> AssignRoleToUser(int userId, int roleId)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<Result<UserModel>> AssignRolesToUser(int userId, int[] roleIds)
        {
            var result = new Result<UserModel>();
            try
            {
                var userRoles = _queryRepository.Table<UserRole>().Where(x => x.UserId == userId).ToList();

                var mergedCount = userRoles.Count(x => roleIds.Contains(x.RoleId));

                var inputRoleIdsCount = roleIds.Count();

                var existedRolesCount = userRoles.Count();

                if (inputRoleIdsCount > existedRolesCount || inputRoleIdsCount < existedRolesCount || mergedCount != existedRolesCount)
                {
                    foreach (var userRole in userRoles)
                    {
                        _commandRepository.DeleteAsync<UserRole>(userRole);
                    }

                    var newRoles = _queryRepository.Table<Role>().Where(x => roleIds.Contains(x.Id)).ToList();

                    foreach (var roleid in roleIds)
                    {
                        await _commandRepository.InsertAsync(new UserRole()
                        {
                            UserId = userId,
                            RoleId = roleid
                        });
                    }

                    await _commandRepository.SaveChangesAsync();
                }

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
        /// <param name="avatarFile"></param>
        /// <param name="oldAvatarName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="avatarFile"></param>
        /// <param name="oldAvatarName"></param>
        /// <returns></returns>
        public Result<string> DeleteAvatarFile(string avatarName)
        {
            var result = new Result();
            try
            {
                if (!string.IsNullOrEmpty(avatarName))
                {
                    var avatarPath = HydraHelper.GetAvatarDirectory() + "{0}";
                    if (File.Exists(string.Format(avatarPath, avatarName)))
                    {
                        File.Delete(string.Format(avatarPath, avatarName));
                    }
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