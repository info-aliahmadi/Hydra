using Hydra.Infrastructure.Email.Service;
using Hydra.Kernel.Interfaces.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Email
{
    public static class EmailStartup
    {
        public static void AddEmailConfig(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddSingleton<ISmtpSetting>(configuration.GetSection("SmtpSetting").Get<SmtpSetting>());
            services.AddSingleton<IImapSetting>(configuration.GetSection("ImapSetting").Get<ImapSetting>());

            services.AddTransient<IEmailService, EmailService>();

        }
    }
}