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
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IDriveService, DriveService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet(API_SCHEMA + "/GetTopicList", TopicHandler.GetList).RequirePermission("CMS.GET_TOPIC_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetTopicById", TopicHandler.GetTopicById).RequirePermission("CMS.GET_TOPIC_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddTopic", TopicHandler.AddTopic).RequirePermission("CMS.ADD_TOPIC");
            endpoints.MapPost(API_SCHEMA + "/UpdateTopic", TopicHandler.UpdateTopic).RequirePermission("CMS.UPDATE_TOPIC");
            endpoints.MapGet(API_SCHEMA + "/DeleteTopic", TopicHandler.DeleteTopic).RequirePermission("CMS.DELETE_TOPIC");

            endpoints.MapPost(API_SCHEMA + "/GetArticleList", ArticleHandler.GetList).RequirePermission("CMS.GET_ARTICLE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetArticleById", ArticleHandler.GetArticleById).RequirePermission("CMS.GET_ARTICLE_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddArticle", ArticleHandler.AddArticle).RequirePermission("CMS.ADD_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UpdateArticle", ArticleHandler.UpdateArticle).RequirePermission("CMS.UPDATE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/DeleteArticle", ArticleHandler.DeleteArticle).RequirePermission("CMS.DELETE_ARTICLE");

            endpoints.MapGet(API_SCHEMA + "/GetDriveFiles", DriveHandler.GetFiles).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/AddFileToDrive", DriveHandler.Add).RequirePermission("CMS.DELETE_ARTICLE");

            return endpoints;
        }

    }
}
