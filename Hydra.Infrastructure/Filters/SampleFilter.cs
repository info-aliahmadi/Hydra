using CacheManager.Core.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _logger.LogWarn(validationError);
                return Results.Problem(validationError);
            }
            // before filter
            return await next(efiContext);
            // after filter
        }
    }
}
