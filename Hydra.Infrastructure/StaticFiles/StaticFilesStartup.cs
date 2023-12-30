using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Hydra.Infrastructure.StaticFiles
{
    public static class StaticFilesStartup
    {
        /// <summary>
        /// Configure the Files Request Pipeline
        /// </summary>
        /// <param name="application">Builder for configuring an Files's request pipeline</param>
        public static void UseStaticFiles(this WebApplication app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(app.Environment.ContentRootPath, "images/avatar")),
                RequestPath = "/avatar"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(app.Environment.ContentRootPath, "uploads/images")),
                RequestPath = "/images"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(app.Environment.ContentRootPath, "uploads/videos")),
                RequestPath = "/videos"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(app.Environment.ContentRootPath, "uploads/audio")),
                RequestPath = "/audio"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(app.Environment.ContentRootPath, "uploads/documents")),
                RequestPath = "/documents"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(app.Environment.ContentRootPath, "uploads/others")),
                RequestPath = "/others"
            });

        }
    }

}