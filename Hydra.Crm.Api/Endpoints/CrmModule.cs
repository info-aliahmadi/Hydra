using Hydra.Crm.Api.Handler;
using Hydra.Crm.Api.Services;
using Hydra.Crm.Core.Interfaces;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Security.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Crm.Api.Endpoints
{
    public class CrmModule : IModule
    {
        private const string API_SCHEMA = "/Crm";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapPost(API_SCHEMA + "/GetAllMessages", MessageHandler.GetAllMessages).RequirePermission("CRM.GET_ALLMESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetInboxMessages", MessageHandler.GetInboxMessages).RequirePermission("CRM.GET_INBOX_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetSentMessages", MessageHandler.GetSentMessages).RequirePermission("CRM.GET_SENT_MESSAGES");
            endpoints.MapPost(API_SCHEMA + "/GetPublicInboxMessages", MessageHandler.GetPublicInboxMessages).RequirePermission("CRM.GET_PUBLIC_INBOX_MESSAGES");
            endpoints.MapPost(API_SCHEMA + "/GetDeletedInboxMessages", MessageHandler.GetDeletedInboxMessages).RequirePermission("CRM.GET_DELETED_INBOX_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetDeletedSentMessages", MessageHandler.GetDeletedSentMessages).RequirePermission("CRM.GET_DELETED_SENT_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetMessageById", MessageHandler.GetMessageById).RequirePermission("CRM.GET_MESSAGE_BY_ID");
            endpoints.MapGet(API_SCHEMA + "/SendPublicMessage", MessageHandler.SendPublicMessage).RequirePermission("CRM.SEND_PUBLIC_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/SendPrivateMessage", MessageHandler.SendPrivateMessage).RequirePermission("CRM.SEND_PRIVATE_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/SendRequestMessage", MessageHandler.SendRequestMessage).RequirePermission("CRM.SEND_REQUEST_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/SendContactMessage", MessageHandler.SendContactMessage).RequirePermission("CRM.SEND_CONTACT_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/UpdateDraftMessage", MessageHandler.UpdateDraftMessage).RequirePermission("CRM.UPDATE_DRAFT_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/DeleteDraftMessage", MessageHandler.DeleteDraftMessage).RequirePermission("CRM.DELETE_DRAFT_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/DeleteMessage", MessageHandler.DeleteMessage).RequirePermission("CRM.DELETE_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/PinMessage", MessageHandler.PinMessage).RequirePermission("CRM.PIN_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/ReadMessage", MessageHandler.ReadMessage).RequirePermission("CRM.READ_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/RemoveMessage", MessageHandler.RemoveMessage).RequirePermission("CRM.REMOVE_MESSAGE");

            return endpoints;
        }

    }
}
