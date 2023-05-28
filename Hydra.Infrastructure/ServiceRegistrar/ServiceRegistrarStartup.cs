using Microsoft.Extensions.DependencyInjection;
using Hydra.Infrastructure.Data;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Infrastructure.Security.Service;

namespace Hydra.Infrastructure.ServiceRegistrar
{
    public static class ServiceRegistrarStartup
    {
        public static void AddServices(this IServiceCollection services)
        {


            // services
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPermissionChecker, PermissionChecker>();

            //services.AddAllServices();


        }
    }
}
