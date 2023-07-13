using Hydra.FileStorage.Handler;
using Hydra.FileStorage.Infrastructure.SignatureVerify;
using Hydra.FileStorage.Services;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Security.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Nitro.FileStorage.Services;

namespace Hydra.FileStorage.Endpoints
{
    public class FileStorageModule : IModule
    {
        private const string API_SCHEMA = "/FileStorage";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {

            services.AddScoped<IFileTypeVerifier, FileTypeVerifier>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IFileStorageService, FileStorageService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet(API_SCHEMA + "/GetFileInfo", FileStorageHandler.GetFileInfo).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/GetFilesList", FileStorageHandler.GetFilesList).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/GetGalleyFiles", FileStorageHandler.GetGalleyFiles).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapPost(API_SCHEMA + "/UploadFile", FileStorageHandler.UploadFile).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadFileAsStream", FileStorageHandler.UploadFileAsStream).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadLargeFile", FileStorageHandler.UploadLargeFile).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapGet(API_SCHEMA + "/DeleteFile", FileStorageHandler.DeleteFile).RequirePermission("CMS.DELETE_ARTICLE");

            return endpoints;
        }

    }
}
