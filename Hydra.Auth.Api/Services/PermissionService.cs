using EFCoreSecondLevelCacheInterceptor;
using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Api.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public PermissionService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckPermissionForUser(int userId, string permissionName)
        {
            var result = new Result<List<PermissionModel>>();

            //var cachedPermissions = _queryRepository.Table<Permission>().Cacheable().ToList();

            //var cachedRoles = _queryRepository.Table<Role>().Cacheable().ToList();

            var permissionRoleQuery = (from PermissionRoleTable in _queryRepository.Table<PermissionRole>()

                                       join permissionTable in _queryRepository.Table<Permission>().Cacheable()
                                         on PermissionRoleTable.PermissionId equals permissionTable.Id

                                       join roleTable in _queryRepository.Table<Role>().Cacheable()
                                         on PermissionRoleTable.RoleId equals roleTable.Id

                                       select new
                                       {
                                           PermissionId = PermissionRoleTable.PermissionId,
                                           PermissionName = permissionTable.Name,
                                           RoleId = PermissionRoleTable.RoleId,
                                           RoleName = roleTable.Name
                                       }).Cacheable();

            var permissionsList = (from permissionRoleTable in permissionRoleQuery
                                   join userRoleTable in _queryRepository.Table<UserRole>()
                                    on permissionRoleTable.RoleId equals userRoleTable.RoleId
                                   select new
                                   {
                                       UserId = userRoleTable.UserId,
                                       Permissions = permissionRoleTable
                                   }).Cacheable().ToList();

            var userPermissions = permissionsList.Where(s => s.UserId == userId);


            var checkUserPermission = permissionsList.Any(s => s.Permissions.PermissionName == permissionName);

            return checkUserPermission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<PermissionModel>>> GetList()
        {
            var result = new Result<List<PermissionModel>>();

            var list = await _queryRepository.Table<Permission>().ToListAsync();

            result.DataResult = list.Select(x => new PermissionModel()
            {
                Id = x.Id,
                Name = x.Name,
                NormalizedName = x.NormalizedName
            }).ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<PermissionModel>> GetById(int id)
        {
            var result = new Result<PermissionModel>();

            var record = await _queryRepository.Table<Permission>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var permission = new PermissionModel();
            if (record != null)
            {
                permission.Id = record!.Id;
                permission.Name = record.Name;
                permission.NormalizedName = record.NormalizedName;
            }
            result.DataResult = permission;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        public async Task<Result<PermissionModel>> Add(PermissionModel permissionModel)
        {
            var result = new Result<PermissionModel>();

            var isExist = await _queryRepository.Table<Permission>().AnyAsync(x => x.Name == permissionModel.Name || (x.NormalizedName == permissionModel.NormalizedName && x.NormalizedName != null));
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The permission existed";
                return result;
            }

            var permission = new Permission()
            {
                Name = permissionModel.Name,
                NormalizedName = permissionModel.NormalizedName
            };
            await _commandRepository.InsertAsync(permission);

            await _commandRepository.SaveChangesAsync();

            permissionModel.Id = permission.Id;
            result.DataResult = permissionModel;
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        public async Task<Result<PermissionModel>> Update(PermissionModel permissionModel)
        {
            var result = new Result<PermissionModel>();
            var permission = await _queryRepository.Table<Permission>().FirstOrDefaultAsync(x => x.Id == permissionModel.Id);
            if (permission is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The permission not found";
                return result;
            }

            permission.Name = permissionModel.Name;
            permission.NormalizedName = permissionModel.NormalizedName;

            _commandRepository.UpdateAsync(permission);

            await _commandRepository.SaveChangesAsync();

            result.DataResult = permissionModel;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var permission = _queryRepository.Table<Permission>().FirstOrDefaultAsync(x => x.Id == id);
            if (permission == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The permission not found";
                return result;
            }

            var haveUser = await _queryRepository.Table<PermissionRole>().AnyAsync(x => x.PermissionId == id);
            if (haveUser)
            {
                result.Status = ResultStatusEnum.IsNotAllowed;
                result.Message = "Is Not Allowed. because this permission have role";
                return result;
            }

            _commandRepository.DeleteAsync(permission);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}