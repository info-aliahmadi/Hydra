using Hydra.FileStorage.Api.Handler;
using Hydra.FileStorage.Api.Services;
using Hydra.FileStorage.Core.Interfaces;
using Hydra.FileStorage.Core.SignatureVerify;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Security.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.FileStorage.Api.Endpoints
{
    public class FileStorageModule : IModule
    {
        private const string API_SCHEMA = "/FileStorage";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {

            services.AddScoped<IFileTypeVerifier, FileTypeVerifier>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IQueryRepository, QueryRepository>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet(API_SCHEMA + "/GetFileInfo", FileStorageHandler.GetFileInfo).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/GetFileInfoByName", FileStorageHandler.GetFileInfoByName).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/GetFilesList", FileStorageHandler.GetFilesList).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/GetGalleyFiles", FileStorageHandler.GetGalleyFiles).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapPost(API_SCHEMA + "/UploadFile", FileStorageHandler.UploadFile).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadBase64File", FileStorageHandler.UploadBase64File).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadSmallFile", FileStorageHandler.UploadSmallFile).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadLargeFile", FileStorageHandler.UploadLargeFile).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapGet(API_SCHEMA + "/DeleteFile", FileStorageHandler.DeleteFile).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapGet(API_SCHEMA + "/DownloadFile", FileStorageHandler.DownloadFile).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/DownloadFileStream", FileStorageHandler.DownloadFileStream).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/DownloadFileByName", FileStorageHandler.DownloadFileByName).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/DownloadFileStreamByName", FileStorageHandler.DownloadFileStreamByName).RequirePermission("CMS.DELETE_ARTICLE");

            return endpoints;
        }

    }
}
