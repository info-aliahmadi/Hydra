namespace Hydra.Infrastructure.Security.Interfaces
{
    public interface IPermissionChecker
    {
        bool IsAuthorized(int userId, string permissionName);
        IList<string> GetPermissionsOfUser(int userId);
        IList<string> GetPermissions();
    }
}
