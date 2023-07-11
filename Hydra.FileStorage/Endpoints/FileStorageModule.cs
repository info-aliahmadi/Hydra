using Hydra.Cms.Api.Handler;
using Hydra.Cms.Api.Services;
using Hydra.Cms.Core.Interfaces;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Security.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Cms.Api.Endpoints
{
    public class FileStorageModule : IModule
    {
        private const string API_SCHEMA = "/Cms";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {


            endpoints.MapGet(API_SCHEMA + "/GetDriveFiles", FileStorageHandler.GetFiles).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/AddFileToDrive", FileStorageHandler.Add).RequirePermission("CMS.DELETE_ARTICLE");

            return endpoints;
        }

    }
}
