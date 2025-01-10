using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Hydra.Infrastructure.Filters
{
    public class TodoIsValidFilter : IEndpointFilter
    {
        private ILogger _logger;

        public TodoIsValidFilter(ILoggerFactory loggerFactory)
        {
            //_logger = loggerFactory.CreateLogger<TodoIsValidFilter>();
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext,
            EndpointFilterDelegate next)
        {
            var todo = efiContext.GetArgument<string>(0);

            var validationError = "";

            if (!string.IsNullOrEmpty(validationError))
            {
                _logger.LogWarning(validationError);
                return Results.Problem(validationError);
            }
            // before filter
            return await next(efiContext);
            // after filter
        }
    }
}
