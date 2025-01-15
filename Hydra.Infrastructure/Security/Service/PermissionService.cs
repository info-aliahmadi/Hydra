using Hydra.Infrastructure.Security.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Hydra.Infrastructure.Data.Interface;
using Hydra.Infrastructure.Security.Interface;
using Hydra.Infrastructure.GeneralModels;
using Microsoft.Extensions.Localization;

namespace Hydra.Infrastructure.Security.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly IStringLocalizer<SharedResource> _sharedlocalizer;

        public PermissionService(IQueryRepository queryRepository, ICommandRepository commandRepository, IStringLocalizer<SharedResource> sharedlocalizer)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _sharedlocalizer = sharedlocalizer;
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
        /// <returns></returns>
        public async Task<Result<List<PermissionModel>>> GetPermissionsByName(string name)
        {
            var result = new Result<List<PermissionModel>>();

            var list = await _queryRepository.Table<Permission>().Where(x => x.Name.Contains(name) || x.NormalizedName.Contains(name)).Take(10).Select(x => new PermissionModel()
            {
                Id = x.Id,
                Name = x.Name,
                NormalizedName = x.NormalizedName
            }).ToListAsync();

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
                result.Errors.Add(new Error(nameof(permissionModel.Name), _sharedlocalizer["The permission name existed"]));
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
                result.Message = _sharedlocalizer["The permission not found"];
                return result;
            }

            var isExist = await _queryRepository.Table<Permission>().AnyAsync(x => x.Id != permissionModel.Id && (x.Name == permissionModel.Name || (x.NormalizedName == permissionModel.NormalizedName && x.NormalizedName != null)));
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(permissionModel.Name), _sharedlocalizer["The permission name existed"]));
                result.Message = _sharedlocalizer["The permission existed"];
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
            var permission = await _queryRepository.Table<Permission>().Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
            if (permission == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = _sharedlocalizer["The permission not found"];
                return result;
            }

            if (permission.Roles.Any())
            {
                result.Status = ResultStatusEnum.IsNotAllowed;
                result.Message = _sharedlocalizer["Is Not Allowed. because this permission have role"];
                return result;
            }

            _commandRepository.DeleteAsync(permission);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}