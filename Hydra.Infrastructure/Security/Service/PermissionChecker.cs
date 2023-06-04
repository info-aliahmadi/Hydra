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

            //SuperAdmin Role Have All Permissions
            if (permissionsList.Any(s => s.UserId == userId && s.Permissions.RoleName == "SuperAdmin"))
                return true;


            var userPermissions = permissionsList.Where(s => s.UserId == userId);


            var checkUserPermission = userPermissions.Any(s => s.Permissions.PermissionName == permissionName);

            return checkUserPermission;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public IList<PermissionModel> GetPermissionsOfUser(int userId)
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

            //SuperAdmin Role Have All Permissions
            if (permissionsList.Any(s => s.UserId == userId && s.Permissions.RoleName == "SuperAdmin"))
                return _queryRepository.Table<Permission>().Select(x => new PermissionModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).Cacheable().ToList();


            var userPermissions = permissionsList.Where(s => s.UserId == userId).Select(x => new PermissionModel()
            {
                Id = x.Permissions.PermissionId,
                Name = x.Permissions.PermissionName
            }).Distinct().ToList();

            return userPermissions;
        }
     
    }
}