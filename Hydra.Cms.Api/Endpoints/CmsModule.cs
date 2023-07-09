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
    public class CmsModule : IModule
    {
        private const string API_SCHEMA = "/Cms";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            services.AddScoped<IContentService, ContentService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapPost(API_SCHEMA + "/GetContentList", ContentHandler.GetList).RequirePermission("CMS.GET_CONTENT_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetContentById", ContentHandler.GetContentById).RequirePermission("CMS.GET_CONTENT_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddContent", ContentHandler.AddContent).RequirePermission("CMS.ADD_CONTENT");
            endpoints.MapPost(API_SCHEMA + "/UpdateContent", ContentHandler.UpdateContent).RequirePermission("CMS.UPDATE_CONTENT");
            endpoints.MapGet(API_SCHEMA + "/DeleteContent", ContentHandler.DeleteContent).RequirePermission("v.DELETE_CONTENT");

            return endpoints;
        }

    }
}
