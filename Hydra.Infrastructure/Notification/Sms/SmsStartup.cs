using Hydra.Infrastructure.Notification.Sms.Interface;
using Hydra.Infrastructure.Notification.Sms.Service;
using Hydra.Infrastructure.Notification.Sms.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Notification.Sms
{
    public static class SmsStartup
    {
        public static void AddSmsConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<ISmsSetting>(configuration.GetSection("NotificationSetting.SmsSetting").Get<SmsSetting>());

            services.AddTransient<ISmsService, SmsService>();
        }
    }
}