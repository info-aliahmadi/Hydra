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

            var avatarPath = Path.Combine(app.Environment.ContentRootPath, "images/avatar");
            if (!Directory.Exists(avatarPath))
            {
                Directory.CreateDirectory(avatarPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                avatarPath),
                RequestPath = "/avatar"
            });


            var imagesPath = Path.Combine(app.Environment.ContentRootPath, "uploads/images");
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               imagesPath),
                RequestPath = "/images"
            });


            var videosPath = Path.Combine(app.Environment.ContentRootPath, "uploads/videos");
            if (!Directory.Exists(videosPath))
            {
                Directory.CreateDirectory(videosPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               videosPath),
                RequestPath = "/videos"
            });


            var audioPath = Path.Combine(app.Environment.ContentRootPath, "uploads/audio");
            if (!Directory.Exists(audioPath))
            {
                Directory.CreateDirectory(audioPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               audioPath),
                RequestPath = "/audio"
            });


            var documentsPath = Path.Combine(app.Environment.ContentRootPath, "uploads/documents");
            if (!Directory.Exists(documentsPath))
            {
                Directory.CreateDirectory(documentsPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               documentsPath),
                RequestPath = "/documents"
            });


            var othersPath = Path.Combine(app.Environment.ContentRootPath, "uploads/others");
            if (!Directory.Exists(othersPath))
            {
                Directory.CreateDirectory(othersPath);
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               othersPath),
                RequestPath = "/others"
            });

        }
    }

}