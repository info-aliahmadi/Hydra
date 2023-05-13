using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nitro.Core.Interfaces.Settings;

namespace Hydra.Infrastructure.Setting
{

    public static class SettingStartup
    {
        public static void AddSettingConfig(this WebApplicationBuilder builder)
        {
            // Add Email Setting to the container.
            builder.Services.AddSingleton<ISmtpSetting>((serviceProvider) =>
                builder.Configuration.GetSection("SmtpSetting").Get<SmtpSetting>());

            // Add Sms Setting to the container.
            builder.Services.AddSingleton<ISmsSetting>((serviceProvider) =>
                builder.Configuration.GetSection("SmsSetting").Get<SmsSetting>());


        }
        
    }
}
