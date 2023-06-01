namespace Hydra.Infrastructure.Security.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PermissionAttribute : Attribute
    {

        public string PermissionName { get; private set; }

        /// <summary>
        /// Set permission name for the endpoint(api)
        /// </summary>
        /// <param name="permissionName"></param>
        public PermissionAttribute(string permissionName)
        {
            PermissionName = permissionName;
        }

    }
}