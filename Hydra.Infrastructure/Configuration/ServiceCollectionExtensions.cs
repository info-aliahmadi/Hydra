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
using Microsoft.OpenApi.Models;

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

            //services.AddSwaggerGenConfig();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerGenConfig(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                           Reference = new OpenApiReference
                           {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                           }
                        },
                        new string[] {}
                     }
                 });
            });

        }



    }

}
