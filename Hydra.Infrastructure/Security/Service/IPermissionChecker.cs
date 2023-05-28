namespace Hydra.Infrastructure.Security.Service
{
    public interface IPermissionChecker
    {
        bool IsAuthorized(int userId, string permissionName);
    }
}
