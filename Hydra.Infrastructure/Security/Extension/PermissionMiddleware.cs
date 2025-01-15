using Hydra.Infrastructure.Security.Constants;
using Hydra.Infrastructure.Security.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Hydra.Infrastructure.Security.Extension
{
    public static class PermissionStartup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UsePermission(this WebApplication app)
        {
            app.UseMiddleware<PermissionMiddleware>();
        }
    }

    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context, IPermissionChecker _permissionChecker)
        {
            // get the endpoint 
            var endPoint = context.GetEndpoint();

            // if it exists 
            if (null != endPoint)
            {
                // obtain the Permission attribute 
                var perAttr = endPoint.Metadata.GetMetadata<PermissionAttribute>();

                // if it is not serving, redirect 
                if (null != perAttr && !string.IsNullOrEmpty(perAttr.PermissionName))
                {
                    var identity = context.User.FindFirst(CustomClaimTypes.Identity).Value;
                    if (identity == null)
                    {
                        context.Response.StatusCode = 405;
                        return Task.CompletedTask;
                    }

                    var userId = int.Parse(identity);

                    if (!_permissionChecker.IsAuthorized(userId, perAttr.PermissionName))
                    {
                        context.Response.StatusCode = 403;
                        // and short circuit 
                        return Task.CompletedTask;
                    }
                }
            }

            // pass to the next component 
            return _next(context);

        }
    }
}