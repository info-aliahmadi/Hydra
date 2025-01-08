using Hydra.Infrastructure.Payment.Paypal.Interface;
using Hydra.Infrastructure.Payment.Paypal.Service;
using Hydra.Infrastructure.Setting.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Infrastructure.Payment.Paypal
{
    public static class PaypalStartup
    {
        public static void AddPaypalConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // paypal client configuration
            services.AddSingleton(new PaypalSetting(
                    configuration["PayPalOptions:ClientId"],
                    configuration["PayPalOptions:ClientSecret"],
                    configuration["PayPalOptions:Mode"]
                )
            );

            services.AddTransient<IPaypalClientService, PaypalClientService>();
        }
    }
}
