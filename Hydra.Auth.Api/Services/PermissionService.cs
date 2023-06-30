using EFCoreSecondLevelCacheInterceptor;
using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
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
        public async Task<Result<PaginatedList<PermissionModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<PermissionModel>>();

            var list = await _queryRepository.Table<Permission>().Select(x => new PermissionModel()
            {
                Id = x.Id,
                Name = x.Name,
                NormalizedName = x.NormalizedName
            }).ToPaginatedListAsync(dataGrid);

            result.Data = list;

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
            result.Data = permission;
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
            result.Data = permissionModel;
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

            result.Data = permissionModel;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var permission = await _queryRepository.Table<Permission>().FirstOrDefaultAsync(x => x.Id == id);
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