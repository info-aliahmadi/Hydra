namespace Hydra.Infrastructure.Security.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissionAttribute : Attribute
    {

        public string PermissionName { get; private set; }
        public bool IsAuthorized { get; private set; }

        /// <summary>
        /// Set permission name for the endpoint(api)
        /// </summary>
        /// <param name="permissionName"></param>
        public PermissionAttribute(string permissionName)
        {
            PermissionName = permissionName;
            int hour = DateTime.UtcNow.Hour;

            IsAuthorized = permissionName == "AUTH_GET.ONE.PERMISSION" ? true : false;

        }

    }
}