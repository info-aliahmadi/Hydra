using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Hydra.Infrastructure.localization;
using Hydra.Infrastructure.ModuleExtension;
using Hydra.Infrastructure.Security.Extensions;
using Microsoft.Extensions.FileProviders;
using Hydra.Infrastructure.StaticFiles;

namespace Hydra.Infrastructure.Configuration
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// </summary>
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Configure the application HTTP request pipeline
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void ConfigureRequestPipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("ReactOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UsePermission();

            // Collect all Endpoints from Modules
            app.MapModulesEndpoints();

            

            app.UseLocalization();

        }
    }
}
