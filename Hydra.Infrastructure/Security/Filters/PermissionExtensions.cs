using Microsoft.AspNetCore.Builder;

namespace Hydra.Infrastructure.Security.Filters
{
    public static class PermissionEndpointConventionBuilderExtensions
    {
        /// <summary>
        /// Adds a permission name with the specified name to the endpoint(s).
        /// </summary>
        /// <param name="builder">The endpoint convention builder.</param>
        /// <param name="permissionName">The permission name.</param>
        /// <returns>The original convention builder parameter.</returns>
        public static TBuilder RequirePermission<TBuilder>(this TBuilder builder, string permissionName) where TBuilder : IEndpointConventionBuilder
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Add(endpointBuilder =>
            {
                endpointBuilder.Metadata.Add(new PermissionAttribute(permissionName));
            });
            return builder;
        }
    }
}