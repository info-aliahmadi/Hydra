using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Hydra.Infrastructure.Security.Filters
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

        public Task InvokeAsync(HttpContext context)
        {
            // get the endpoint 
            var endPoint = context.GetEndpoint();

            // if it exists 
            if (null != endPoint)
            {
                // obtain the Permission attribute 
                var perAttr = endPoint.Metadata.GetMetadata<PermissionAttribute>();

                // if it is not serving, redirect 
                if (null != perAttr && !perAttr.IsAuthorized)
                {
                    context.Response.StatusCode = 401;

                    // and short circuit 
                    return Task.CompletedTask;
                }
            }

            // pass to the next component 
            return _next(context);

        }
    }
}