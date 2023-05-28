using EFCoreSecondLevelCacheInterceptor;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Interfaces.Data;

namespace Hydra.Infrastructure.Security.Service
{
    public class PermissionChecker : IPermissionChecker
    {
        private readonly IQueryRepository _queryRepository;

        public PermissionChecker(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public bool IsAuthorized(int userId, string permissionName)
        {

            var permissionRoleQuery = (from PermissionRoleTable in _queryRepository.Table<PermissionRole>()

                                       select new
                                       {
                                           PermissionRoleTable.PermissionId,
                                           PermissionName = PermissionRoleTable.Permission.Name,
                                           PermissionRoleTable.RoleId,
                                           RoleName = PermissionRoleTable.Role.Name
                                       }).Cacheable();

            var permissionsList = (from permissionRoleTable in permissionRoleQuery
                                   join userRoleTable in _queryRepository.Table<UserRole>()
                                    on permissionRoleTable.RoleId equals userRoleTable.RoleId
                                   select new
                                   {
                                       userRoleTable.UserId,
                                       Permissions = permissionRoleTable
                                   }).Cacheable().ToList();

            var userPermissions = permissionsList.Where(s => s.UserId == userId);


            var checkUserPermission = permissionsList.Any(s => s.Permissions.PermissionName == permissionName);

            return checkUserPermission;
        }

    }
}