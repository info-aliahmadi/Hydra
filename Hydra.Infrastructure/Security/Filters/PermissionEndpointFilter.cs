using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Hydra.Infrastructure.Security.Filters
{
    public class BeforeEndpointExecution : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next
        )
        {
            if (context.HttpContext.GetRouteValue("name") is string name)
            {
                return Results.Ok($"Hi {name}, this is from the filter!");
            }

            return await next(context);
        }
    }

}