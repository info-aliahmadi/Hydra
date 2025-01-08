namespace Hydra.Infrastructure.Security.Interface
{
    public interface IPermissionChecker
    {
        bool IsAuthorized(int userId, string permissionName);
        IList<string> GetPermissionsOfUser(int userId);
        IList<string> GetPermissions();
    }
}
