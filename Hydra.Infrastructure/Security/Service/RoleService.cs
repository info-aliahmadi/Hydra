using EFCoreSecondLevelCacheInterceptor;
using Hydra.Infrastructure.Security.Models;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Hydra.Infrastructure.Data.Interface;
using Hydra.Infrastructure.Security.Interface;
using Hydra.Infrastructure.GeneralModels;

namespace Hydra.Infrastructure.Security.Service
{
    public class RoleService : IRoleService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public RoleService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<PaginatedList<RoleModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<RoleModel>>();

            var list = await _queryRepository.Table<Role>().Include(x => x.Permissions).Select(x => new RoleModel()
            {
                Id = x.Id,
                Name = x.Name,
                ConcurrencyStamp = x.ConcurrencyStamp,
                NormalizedName = x.NormalizedName,
                Permissions = x.Permissions.Select(c => new PermissionModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    NormalizedName = c.NormalizedName
                })
            }).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<RoleModel>>> GetAllRoles()
        {
            var result = new Result<List<RoleModel>>();

            var list = await _queryRepository.Table<Role>().Select(x => new RoleModel()
            {
                Id = x.Id,
                Name = x.Name,
                ConcurrencyStamp = x.ConcurrencyStamp,
                NormalizedName = x.NormalizedName,
            }).Cacheable().ToListAsync();

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<RoleModel>> GetById(int id)
        {
            var result = new Result<RoleModel>();

            var record = await _queryRepository.Table<Role>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var role = new RoleModel();
            if (record != null)
            {
                role.Id = record!.Id;
                role.Name = record.Name;
                role.ConcurrencyStamp = record.ConcurrencyStamp;
                role.NormalizedName = record.NormalizedName;
            }
            result.Data = role;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public async Task<Result<RoleModel>> Add(RoleModel roleModel)
        {
            var result = new Result<RoleModel>();
            try
            {
                var isExist = await _queryRepository.Table<Role>().AnyAsync(x => x.Name == roleModel.Name || (x.NormalizedName == roleModel.NormalizedName && x.NormalizedName != null));
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The role existed";
                    result.Errors.Add(new Error(nameof(roleModel.Name), "The role existed"));
                    return result;
                }

                var role = new Role()
                {
                    Name = roleModel.Name,
                    ConcurrencyStamp = roleModel.ConcurrencyStamp,
                    NormalizedName = roleModel.NormalizedName
                };
                await _commandRepository.InsertAsync(role);
                await _commandRepository.SaveChangesAsync();

                roleModel.Id = role.Id;
                result.Data = roleModel;
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
        /// <param name="permissionName"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<Result> DismissPermissionToRoleAsync(int permissionId, int roleId)
        {
            var result = new Result();
            try
            {
                var permission = await _queryRepository.Table<Permission>().FirstOrDefaultAsync(x => x.Id == permissionId);
                if (permission is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The permission Not Found";
                    result.Errors.Add(new Error(nameof(roleId), "The role existed"));
                    return result;
                }

                var role = await _queryRepository.Table<Role>().Include(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == roleId);
                if (role is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The role Not Found";
                    return result;
                }

                role.Permissions.Remove(permission);

                await _queryRepository.SaveChangesAsync();

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
        /// <param name="permissionId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<Result<PermissionModel>> AssignPermissionToRoleAsync(int permissionId, int roleId)
        {
            var result = new Result<PermissionModel>();
            try
            {
                var role = await _queryRepository.Table<Role>().Include(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == roleId);

                var permission = await _queryRepository.Table<Permission>().FirstOrDefaultAsync(x => x.Id == permissionId);


                var isExist = role.Permissions.Any(x => x.Id == permissionId);

                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Errors.Add(new Error(nameof(permissionId), "The role and permission assigned already"));
                    result.Message = "The role and permission assigned already";
                    return result;
                }
                role.Permissions.Add(permission);
                await _queryRepository.SaveChangesAsync();
                result.Data = new PermissionModel()
                {
                    Name = permission.Name,
                    Id = permission.Id,
                    NormalizedName = permission.NormalizedName
                };

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
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public async Task<Result<RoleModel>> Update(RoleModel roleModel)
        {
            var result = new Result<RoleModel>();
            try
            {
                var role = await _queryRepository.Table<Role>().FirstOrDefaultAsync(x => x.Id == roleModel.Id);
                if (role is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The role not found";
                    return result;
                }


                var isExist = await _queryRepository.Table<Role>().AnyAsync(x => x.Id != roleModel.Id && (x.Name == roleModel.Name || (x.NormalizedName == roleModel.NormalizedName && x.NormalizedName != null)));
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Errors.Add(new Error(nameof(roleModel.Name), "The role name existed"));
                    result.Message = "The role name existed";
                    return result;
                }

                role.Name = roleModel.Name;
                role.ConcurrencyStamp = roleModel.ConcurrencyStamp;
                role.NormalizedName = roleModel.NormalizedName;

                _commandRepository.UpdateAsync(role);

                await _commandRepository.SaveChangesAsync();

                result.Data = roleModel;
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
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            try
            {
                var role = await _queryRepository.Table<Role>().Include(x => x.Permissions).Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Id == id);
                if (role is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The role not found";
                    return result;
                }

                if (role.Permissions.Any())
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = "Is Not Allowed. because this role have permission";
                    return result;
                }

                if (role.UserRoles.Any())
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = "Is Not Allowed. because this role have User";
                    return result;
                }

                _commandRepository.DeleteAsync(role);

                await _commandRepository.SaveChangesAsync();

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