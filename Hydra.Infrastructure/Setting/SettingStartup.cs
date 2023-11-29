using Hydra.Infrastructure.Setting.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Setting
{

    public static class SettingStartup
    {
        public static void AddSettingConfig(this IServiceCollection services)
        {
            services.AddTransient<ISettingService, SettingService>();

        }

    }
}
