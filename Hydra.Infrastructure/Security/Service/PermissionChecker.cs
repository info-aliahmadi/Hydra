using EFCoreSecondLevelCacheInterceptor;
using Hydra.Infrastructure.Data.Interface;
using Hydra.Infrastructure.Security.Constants;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Infrastructure.Security.Interface;

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
            var permissionsList = (from userRoleTable in _queryRepository.Table<UserRole>()
                                   join role in _queryRepository.Table<Role>()
                                   on userRoleTable.RoleId equals role.Id
                                   select new
                                   {
                                       userRoleTable.UserId,
                                       RoleNormalizedName = role.NormalizedName,
                                       role.Permissions
                                   }).Cacheable().ToList();

            //SuperAdmin Role Have All Permissions
            if (permissionsList.Any(s => s.UserId == userId && s.RoleNormalizedName == RoleTypes.SUPERADMIN))
                return true;

            var userPermissions = permissionsList.Where(s => s.UserId == userId).SelectMany(x => x.Permissions);

            var checkUserPermission = userPermissions.Any(s => s.NormalizedName == permissionName);

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
                                       RoleNormalizedName = role.NormalizedName,
                                       role.Permissions
                                   }).Cacheable().ToList();

            //SuperAdmin Role Have All Permissions
            if (permissionsList.Any(s => s.UserId == userId && s.RoleNormalizedName == RoleTypes.SUPERADMIN))
                return _queryRepository.Table<Permission>().Select(x => x.NormalizedName).Cacheable().ToList();


            var userPermissions = permissionsList.Where(s => s.UserId == userId).SelectMany(x => x.Permissions).Select(x => x.NormalizedName).Distinct().ToList();

            return userPermissions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<string> GetPermissions()
        {
            var permissionsList = (from userRoleTable in _queryRepository.Table<UserRole>()
                                   join role in _queryRepository.Table<Role>()
                                   on userRoleTable.RoleId equals role.Id
                                   select new
                                   {
                                       userRoleTable.UserId,
                                       RoleName = role.NormalizedName,
                                       role.Permissions
                                   }).Cacheable().ToList();


            var userPermissions = permissionsList.SelectMany(x => x.Permissions).Select(x => x.NormalizedName).Distinct().ToList();

            return userPermissions;
        }
    }
}