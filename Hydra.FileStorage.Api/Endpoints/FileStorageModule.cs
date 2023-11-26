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

            endpoints.MapGet(API_SCHEMA + "/GetFileInfo", FileStorageHandler.GetFileInfo).RequirePermission("CMS.GET_FILE_INFO");
            endpoints.MapPost(API_SCHEMA + "/GetFilesInfo", FileStorageHandler.GetFilesInfo).RequirePermission("CMS.GET_FILE_INFO");
            endpoints.MapGet(API_SCHEMA + "/GetFileInfoByName", FileStorageHandler.GetFileInfoByName).RequirePermission("CMS.GET_FILE_INFO_BY_NAME");
            endpoints.MapGet(API_SCHEMA + "/GetFilesList", FileStorageHandler.GetFilesList).RequirePermission("CMS.GET_FILES_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetGalleyFiles", FileStorageHandler.GetGalleyFiles).RequirePermission("CMS.GET_GALLEY_FILES");
            endpoints.MapGet(API_SCHEMA + "/GetDirectories", FileStorageHandler.GetDirectories).RequirePermission("CMS.GET_DIRECTORIES");
            endpoints.MapGet(API_SCHEMA + "/GetFilesByDirectory", FileStorageHandler.GetFilesByDirectory).RequirePermission("CMS.GET_FILES_BY_DIRECTORY");

            endpoints.MapPost(API_SCHEMA + "/UploadFile", FileStorageHandler.UploadFile).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadBase64File", FileStorageHandler.UploadBase64File).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadSmallFile", FileStorageHandler.UploadSmallFile).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UploadLargeFile", FileStorageHandler.UploadLargeFile).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapGet(API_SCHEMA + "/DeleteFile", FileStorageHandler.DeleteFile).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapGet(API_SCHEMA + "/DownloadFile", FileStorageHandler.DownloadFile).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/DownloadFileStream", FileStorageHandler.DownloadFileStream).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/DownloadFileByName", FileStorageHandler.DownloadFileByName).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/DownloadFileStreamByName", FileStorageHandler.DownloadFileStreamByName).AllowAnonymous();

            return endpoints;
        }

    }
}
