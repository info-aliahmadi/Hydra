using Hydra.Infrastructure.Email.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Email
{
    public static class EmailStartup
    {
        public static void AddEmailConfig(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

            services.AddTransient<IEmailService, EmailService>();

        }
    }
}