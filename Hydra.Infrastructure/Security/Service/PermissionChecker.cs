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

            //var permissionRoleQuery = (from PermissionRoleTable in _queryRepository.Table<PermissionRole>()

            //                           select new
            //                           {
            //                               PermissionRoleTable.PermissionId,
            //                               PermissionName = PermissionRoleTable.Permission.Name,
            //                               PermissionRoleTable.RoleId,
            //                               RoleName = PermissionRoleTable.Role.Name
            //                           }).Cacheable();

            var permissionsList = (from userRoleTable in _queryRepository.Table<UserRole>()
                                   join role in _queryRepository.Table<Role>()
                                   on userRoleTable.RoleId equals role.Id
                                   select new
                                   {
                                       userRoleTable.UserId,
                                       RoleName = role.Name,
                                       role.Permissions
                                   }).Cacheable().ToList();

            //SuperAdmin Role Have All Permissions
            if (permissionsList.Any(s => s.UserId == userId && s.RoleName == "SuperAdmin"))
                return true;


            var userPermissions = permissionsList.Where(s => s.UserId == userId).SelectMany(x => x.Permissions);


            var checkUserPermission = userPermissions.Any(s => s.Name == permissionName);

            return checkUserPermission;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public IList<string> GetPermissionsOfUser(int userId)
        {


            var permissionsList = (from userRoleTable in _queryRepository.Table<UserRole>()
                                   join role in _queryRepository.Table<Role>()
                                   on userRoleTable.RoleId equals role.Id
                                   select new
                                   {
                                       userRoleTable.UserId,
                                       RoleName = role.Name,
                                       role.Permissions
                                   }).Cacheable().ToList();

            //SuperAdmin Role Have All Permissions
            if (permissionsList.Any(s => s.UserId == userId && s.RoleName == "SuperAdmin"))
                return _queryRepository.Table<Permission>().Select(x => x.Name).Cacheable().ToList();


            var userPermissions = permissionsList.Where(s => s.UserId == userId).SelectMany(x => x.Permissions).Select(x => x.Name).Distinct().ToList();

            return userPermissions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public IList<string> GetPermissions()
        {


            var permissionsList = (from userRoleTable in _queryRepository.Table<UserRole>()
                                   join role in _queryRepository.Table<Role>()
                                   on userRoleTable.RoleId equals role.Id
                                   select new
                                   {
                                       userRoleTable.UserId,
                                       RoleName = role.Name,
                                       role.Permissions
                                   }).Cacheable().ToList();


            var userPermissions = permissionsList.SelectMany(x => x.Permissions).Select(x => x.Name).Distinct().ToList();

            return userPermissions;
        }

    }
}