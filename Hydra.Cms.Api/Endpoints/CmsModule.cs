using Hydra.Cms.Api.Handler;
using Hydra.Cms.Api.Services;
using Hydra.Cms.Core.Interfaces;
using Hydra.Infrastructure.ModuleExtension;
using Hydra.Infrastructure.Security.Extensions;
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
            services.AddScoped<ISiteSettingsService, SiteSettingsService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<ILinkSectionService, LinkSectionService>();
            services.AddScoped<ILinkService, LinkService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<ISlideshowService, SlideshowService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            // Anonymous Endpoints

            endpoints.MapGet(API_SCHEMA + "/GetSettings", SettingsHandler.GetSettings).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetMenu", MenuHandler.GetMenu).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetArticlesList", ArticleHandler.GetListForVisitors).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetRelatedArticlesList", ArticleHandler.GetRelatedArticlesForVisitors).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetTopArticle", ArticleHandler.GetTopArticleForVisitors).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetArticle", ArticleHandler.GetArticleByIdForVisitors).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetPage", PageHandler.GetPageByIdForVisitors).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetTopicsList", TopicHandler.GetList).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetTagsList", TagHandler.GetAllList).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetLinksByKeyList", LinkHandler.GetLinksByKeyList).AllowAnonymous();



            endpoints.MapPost(API_SCHEMA + "/AddOrUpdateSettings", SettingsHandler.AddOrUpdateSettings).RequirePermission("CMS.ADD_OR_UPDATE_SETTINGS");

            endpoints.MapGet(API_SCHEMA + "/GetTopicsHierarchy", TopicHandler.GetTopicsHierarchy).RequirePermission("CMS.GET_TOPIC_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetTopicListForSelect", TopicHandler.GetListForSelect).RequirePermission("CMS.GET_TOPIC_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetTopicById", TopicHandler.GetTopicById).RequirePermission("CMS.GET_TOPIC_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddTopic", TopicHandler.AddTopic).RequirePermission("CMS.ADD_TOPIC");
            endpoints.MapPost(API_SCHEMA + "/UpdateTopic", TopicHandler.UpdateTopic).RequirePermission("CMS.UPDATE_TOPIC");
            endpoints.MapGet(API_SCHEMA + "/DeleteTopic", TopicHandler.DeleteTopic).RequirePermission("CMS.DELETE_TOPIC");

            endpoints.MapPost(API_SCHEMA + "/GetTagList", TagHandler.GetList).RequirePermission("CMS.GET_TAG_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetTagListForSelect", TagHandler.GetListForSelect).RequirePermission("CMS_GET.TAG.LIST");
            endpoints.MapGet(API_SCHEMA + "/GetTagById", TagHandler.GetTagById).RequirePermission("CMS.GET_TAG_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddTag", TagHandler.AddTag).RequirePermission("CMS.ADD_TAG");
            endpoints.MapPost(API_SCHEMA + "/UpdateTag", TagHandler.UpdateTag).RequirePermission("CMS.UPDATE_TAG");
            endpoints.MapGet(API_SCHEMA + "/DeleteTag", TagHandler.DeleteTag).RequirePermission("CMS.DELETE_TAG");

            endpoints.MapPost(API_SCHEMA + "/GetArticleList", ArticleHandler.GetList).RequirePermission("CMS.GET_ARTICLE_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetArticleTrashList", ArticleHandler.GetTrashList).RequirePermission("CMS.GET_TRASH_ARTICLE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetArticleById", ArticleHandler.GetArticleById).RequirePermission("CMS.GET_ARTICLE_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddArticle", ArticleHandler.AddArticle).RequirePermission("CMS.ADD_ARTICLE");
            endpoints.MapPost(API_SCHEMA + "/UpdateArticle", ArticleHandler.UpdateArticle).RequirePermission("CMS.UPDATE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/PinArticle", ArticleHandler.PinArticle).RequirePermission("CMS.PINNED_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/DeleteArticle", ArticleHandler.DeleteArticle).RequirePermission("CMS.DELETE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/RestoreArticle", ArticleHandler.RestoreArticle).RequirePermission("CMS.RESTORE_ARTICLE");
            endpoints.MapGet(API_SCHEMA + "/RemoveArticle", ArticleHandler.RemoveArticle).RequirePermission("CMS.REMOVE_ARTICLE");

            endpoints.MapPost(API_SCHEMA + "/GetPageList", PageHandler.GetList).RequirePermission("CMS.GET_PAGE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetPageById", PageHandler.GetPageById).RequirePermission("CMS.GET_PAGE_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddPage", PageHandler.AddPage).RequirePermission("CMS.ADD_PAGE");
            endpoints.MapPost(API_SCHEMA + "/UpdatePage", PageHandler.UpdatePage).RequirePermission("CMS.UPDATE_PAGE");
            endpoints.MapGet(API_SCHEMA + "/DeletePage", PageHandler.DeletePage).RequirePermission("CMS.DELETE_PAGE");

            endpoints.MapGet(API_SCHEMA + "/GetLinkSectionList", LinkSectionHandler.GetList).RequirePermission("CMS.GET_PAGE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetLinkSectionById", LinkSectionHandler.GetLinkSectionById).RequirePermission("CMS.GET_PAGE_BY_ID");
            endpoints.MapGet(API_SCHEMA + "/VisibleLinkSection", LinkSectionHandler.VisibleLinkSection).RequirePermission("CMS.UPDATE_PAGE");
            endpoints.MapPost(API_SCHEMA + "/AddLinkSection", LinkSectionHandler.AddLinkSection).RequirePermission("CMS.ADD_PAGE");
            endpoints.MapPost(API_SCHEMA + "/UpdateLinkSection", LinkSectionHandler.UpdateLinkSection).RequirePermission("CMS.UPDATE_PAGE");
            endpoints.MapGet(API_SCHEMA + "/DeleteLinkSection", LinkSectionHandler.DeleteLinkSection).RequirePermission("CMS.DELETE_PAGE");

            endpoints.MapGet(API_SCHEMA + "/GetLinkList", LinkHandler.GetList).RequirePermission("CMS.GET_PAGE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetLinkById", LinkHandler.GetLinkById).RequirePermission("CMS.GET_PAGE_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/UpdateLinkOrders", LinkHandler.UpdateOrders).RequirePermission("CMS.UPDATE_MENU");
            endpoints.MapPost(API_SCHEMA + "/AddLink", LinkHandler.AddLink).RequirePermission("CMS.ADD_PAGE");
            endpoints.MapPost(API_SCHEMA + "/UpdateLink", LinkHandler.UpdateLink).RequirePermission("CMS.UPDATE_PAGE");
            endpoints.MapGet(API_SCHEMA + "/DeleteLink", LinkHandler.DeleteLink).RequirePermission("CMS.DELETE_PAGE");


            endpoints.MapGet(API_SCHEMA + "/GetMenusHierarchy", MenuHandler.GetMenusHierarchy).RequirePermission("CMS.GET_MENU_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetMenuById", MenuHandler.GetMenuById).RequirePermission("CMS.GET_MENU_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddMenu", MenuHandler.AddMenu).RequirePermission("CMS.ADD_MENU");
            endpoints.MapPost(API_SCHEMA + "/UpdateMenu", MenuHandler.UpdateMenu).RequirePermission("CMS.UPDATE_MENU");
            endpoints.MapPost(API_SCHEMA + "/UpdateMenuOrders", MenuHandler.UpdateOrders).RequirePermission("CMS.UPDATE_MENU");
            endpoints.MapGet(API_SCHEMA + "/DeleteMenu", MenuHandler.DeleteMenu).RequirePermission("CMS.DELETE_MENU");

            endpoints.MapGet(API_SCHEMA + "/GetSlideshowList", SlideshowHandler.GetList).RequirePermission("CMS.GET_SLIDESHOW_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetSlideshowById", SlideshowHandler.GetSlideshowById).RequirePermission("CMS.GET_SLIDESHOW_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddSlideshow", SlideshowHandler.AddSlideshow).RequirePermission("CMS.ADD_SLIDESHOW");
            endpoints.MapPost(API_SCHEMA + "/UpdateSlideshow", SlideshowHandler.UpdateSlideshow).RequirePermission("CMS.UPDATE_SLIDESHOW");
            endpoints.MapPost(API_SCHEMA + "/UpdateSlideshowOrders", SlideshowHandler.UpdateOrders).RequirePermission("CMS.UPDATE_SLIDESHOW");
            endpoints.MapGet(API_SCHEMA + "/VisibleSlideshow", SlideshowHandler.VisibleSlideshow).RequirePermission("CMS.VISIBLE_SLIDESHOW");
            endpoints.MapGet(API_SCHEMA + "/DeleteSlideshow", SlideshowHandler.DeleteSlideshow).RequirePermission("CMS.DELETE_SLIDESHOW");

            return endpoints;
        }

    }
}
