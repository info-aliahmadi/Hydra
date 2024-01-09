using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Security;
using Hydra.Infrastructure.Logs;
using Hydra.Infrastructure.localization;
using Hydra.Infrastructure.ServiceRegistrar;
using Hydra.Infrastructure.Setting;
using Hydra.Infrastructure.Cache;
using Hydra.Infrastructure.ModuleExtension;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Hydra.Infrastructure.Email;
using Hydra.Kernel.Interfaces.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;

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

            //builder.AddSerilogConfig();

            // Allow large file upload
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxRequestBodySize = null;
            });
            services.AddSingleton<IUploadFileSetting>((serviceProvider) =>
                    builder.Configuration.GetSection("UploadFileSetting").Get<UploadFileSetting>());

            services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"/"));

            services.AddlocalizationConfig();

            services.AddServices();

            services.AddEmailConfig(builder.Configuration);



            // Collect all services from Modules
            services.AddModulesService();

            services.AddCacheProvider(builder.Configuration);

            services.AddDbContextConfig(builder.Configuration);

            services.AddIdentityConfig(builder.Configuration);



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
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jiuejbhfkuhredjkhbvfd\"",
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
