using Hydra.Auth.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace Hydra.Auth.Core.Filters
{
    public class PermissionFilter : IEndpointFilter
    {
        private IPermissionService _permissionService;

        public PermissionFilter(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }


        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var userId = context.HttpContext.User.Identity.Name;

            var validationError = "";

            // before filter
            return await next(context);
            // after filter
        }
    }
    public static class AuthorizationEndpointConventionBuilderExtensions
    {
        private static readonly IAllowAnonymous _allowAnonymousMetadata = new AllowAnonymousAttribute();

        /// <summary>
        /// Adds the default authorization policy to the endpoint(s).
        /// </summary>
        /// <param name="builder">The endpoint convention builder.</param>
        /// <returns>The original convention builder parameter.</returns>
        public static TBuilder RequirePermission<TBuilder>(this RouteHandlerBuilder endpoints, string permissionName)
        {
            endpoints.AddEndpointFilter<AddPermissionMiddleware>();
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            var httpContext = builder..RequireScope<IHttpContextAccessor>();
            return builder.RequireAuthorization(new AuthorizeAttribute());
        }
    }
    public class AddPermission2Middleware
    {
        public AddPermission2Middleware(RequestDelegate next) { }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var configuration = httpContext.RequestServices.GetService<IConfiguration>();
            var config = (configuration as IConfigurationRoot).GetDebugView();
            await httpContext.Response.WriteAsync(config);
        }
    }
}