using Hydra.Cms.Api.Handler;
using Hydra.Cms.Api.Services;
using Hydra.Cms.Core.Interfaces;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Endpoints;
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

            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IAuthorService, AuthorService>();


            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet(API_SCHEMA + "/GetList", AuthorHandler.GetList);
            endpoints.MapGet(API_SCHEMA + "/GetById", AuthorHandler.GetById);
            endpoints.MapPost(API_SCHEMA + "/AddAuthor", AuthorHandler.AddAuthor);
            endpoints.MapPost(API_SCHEMA + "/UpdateAuthor", AuthorHandler.UpdateAuthor);
            endpoints.MapGet(API_SCHEMA + "/DeleteAuthor", AuthorHandler.DeleteAuthor);


            return endpoints;
        }

    }
}
