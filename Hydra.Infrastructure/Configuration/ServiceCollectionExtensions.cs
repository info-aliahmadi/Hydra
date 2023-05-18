using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Hydra.Infrastructure.Logs;
using Hydra.Infrastructure.localization;
using Hydra.Infrastructure.ServiceRegistrar;
using Hydra.Infrastructure.Setting;
using Hydra.Infrastructure.Cache;
using Hydra.Infrastructure.ModuleExtension;

namespace Hydra.Infrastructure.Configuration
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="builder">A builder for web applications and services</param>
        public static void ConfigureApplicationServices(this IServiceCollection services,
            WebApplicationBuilder builder)
        {

            builder.AddSerilogConfig();

            services.AddServices();

            // Collect the services from Modules
            services.AddModulesService();

            services.AddCacheProvider(builder.Configuration);

            services.AddDbContextConfig(builder.Configuration);

            services.AddIdentityConfig(builder.Configuration);

            services.AddlocalizationConfig();

            builder.AddSettingConfig();

            services.AddSwaggerGenConfig();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerGenConfig(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }



    }

}
