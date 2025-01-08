using Hydra.Infrastructure.Notification.Email.Interface;
using Hydra.Infrastructure.Notification.Email.Service;
using Hydra.Infrastructure.Notification.Email.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Notification.Email
{
    public static class EmailStartup
    {
        public static void AddEmailConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IEmailSetting>(configuration.GetSection("NotificationSetting.EmailSetting").Get<EmailSetting>());

            services.AddTransient<IEmailService, EmailService>();
        }
    }
}