using Microsoft.Extensions.DependencyInjection;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Scheduler.Service;
using Hydra.Kernel.Interface;
using Hydra.Auth.Interface;
using Hydra.Auth.Service;
using Hydra.Kernel.Setting.Service;

namespace Hydra.Infrastructure.ServiceRegistrar
{
    public static class ServiceRegistrarStartup
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services
            services.AddTransient<ICommandRepository, CommandRepository>();
            services.AddTransient<IQueryRepository, QueryRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPermissionChecker, PermissionChecker>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IScheduleService, ScheduleService>();

        }
    }
}
