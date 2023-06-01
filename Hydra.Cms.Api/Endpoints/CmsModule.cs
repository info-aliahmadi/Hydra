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
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet(API_SCHEMA + "/GetList", AuthorHandler.GetList).RequirePermission("CMS_GET.LIST");
            endpoints.MapGet(API_SCHEMA + "/GetById", AuthorHandler.GetById).RequirePermission("CMS_GET.BY.ID");
            endpoints.MapPost(API_SCHEMA + "/AddAuthor", AuthorHandler.AddAuthor).RequirePermission("CMS_ADD.AUTHOR");
            endpoints.MapPost(API_SCHEMA + "/UpdateAuthor", AuthorHandler.UpdateAuthor).RequirePermission("CMS_UPDATE.AUTHOR");
            endpoints.MapGet(API_SCHEMA + "/DeleteAuthor", AuthorHandler.DeleteAuthor).RequirePermission("CMS_DELETE.AUTHOR");


            return endpoints;
        }

    }
}
