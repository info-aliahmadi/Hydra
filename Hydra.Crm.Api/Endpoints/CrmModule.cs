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
            services.AddScoped<IEmailInboxService, EmailInboxService>();
            services.AddScoped<IEmailOutboxService, EmailOutboxService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost(API_SCHEMA + "/SendPublicMessage", MessageHandler.SendPublicMessage).RequirePermission("CRM.SEND_PUBLIC_MESSAGE");
            endpoints.MapPost(API_SCHEMA + "/SendPrivateMessage", MessageHandler.SendPrivateMessage).RequirePermission("CRM.SEND_PRIVATE_MESSAGE");
            endpoints.MapPost(API_SCHEMA + "/SendRequestMessage", MessageHandler.SendRequestMessage).RequirePermission("CRM.SEND_REQUEST_MESSAGE");
            endpoints.MapPost(API_SCHEMA + "/SendContactMessage", MessageHandler.SendContactMessage).RequirePermission("CRM.SEND_CONTACT_MESSAGE");
            endpoints.MapPost(API_SCHEMA + "/SaveDraftMessage", MessageHandler.SaveDraftMessage).RequirePermission("CRM.SAVE_DRAFT_MESSAGE");

            endpoints.MapGet(API_SCHEMA + "/GetAllMessages", MessageHandler.GetAllMessages).RequirePermission("CRM.GET_ALLMESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetInboxMessages", MessageHandler.GetInboxMessages).RequirePermission("CRM.GET_INBOX_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetSentMessages", MessageHandler.GetSentMessages).RequirePermission("CRM.GET_SENT_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetPublicInboxMessages", MessageHandler.GetPublicInboxMessages).RequirePermission("CRM.GET_PUBLIC_INBOX_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetDeletedInboxMessages", MessageHandler.GetDeletedInboxMessages).RequirePermission("CRM.GET_DELETED_INBOX_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetDeletedSentMessages", MessageHandler.GetDeletedSentMessages).RequirePermission("CRM.GET_DELETED_SENT_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetMessageByIdForPublic", MessageHandler.GetMessageByIdForPublic).RequirePermission("CRM.GET_MESSAGE_BY_ID_FOR_PUBLIC");
            endpoints.MapGet(API_SCHEMA + "/GetMessageByIdForSender", MessageHandler.GetMessageByIdForSender).RequirePermission("CRM.GET_MESSAGE_BY_ID_FOR_SENDER");
            endpoints.MapGet(API_SCHEMA + "/GetMessageByIdForReceiver", MessageHandler.GetMessageByIdForReceiver).RequirePermission("CRM.GET_MESSAGE_BY_ID_FOR_RECEIVER");
            endpoints.MapGet(API_SCHEMA + "/DeleteDraftMessage", MessageHandler.DeleteDraftMessage).RequirePermission("CRM.DELETE_DRAFT_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/DeleteMessage", MessageHandler.DeleteMessage).RequirePermission("CRM.DELETE_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/PinMessage", MessageHandler.PinMessage).RequirePermission("CRM.PIN_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/ReadMessage", MessageHandler.ReadMessage).RequirePermission("CRM.READ_MESSAGE");
            endpoints.MapGet(API_SCHEMA + "/RemoveMessage", MessageHandler.RemoveMessage).RequirePermission("CRM.REMOVE_MESSAGE");



            endpoints.MapGet(API_SCHEMA + "/LoadEmailInbox", EmailInboxHandler.LoadEmailInbox).RequirePermission("CRM.LOAD_EMAIL_INBOX");
            endpoints.MapGet(API_SCHEMA + "/GetInboxMessages", EmailInboxHandler.GetAllEmailInbox).RequirePermission("CRM.GET_INBOX_MESSAGES");
            endpoints.MapGet(API_SCHEMA + "/GetInboxEmailInbox", EmailInboxHandler.GetEmailInbox).RequirePermission("CRM.GET_INBOX_EMAIL_INBOX");
            endpoints.MapGet(API_SCHEMA + "/GetDeletedEmailInbox", EmailInboxHandler.GetDeletedInbox).RequirePermission("CRM.GET_DELETED_EMAIL_INBOX");
            endpoints.MapGet(API_SCHEMA + "/GetEmailInboxById", EmailInboxHandler.GetEmailInboxById).RequirePermission("CRM.GET_EMAIL_INBOX_BY_ID");
            endpoints.MapGet(API_SCHEMA +  "/GetEmailInboxByIdForReceiver", EmailInboxHandler.GetEmailInboxByIdForReceiver).RequirePermission("CRM.GET_EMAIL_INBOX_BY_ID_FOR_RECEIVER");
            endpoints.MapGet(API_SCHEMA + "/DeleteEmailInbox", EmailInboxHandler.DeleteEmailInbox).RequirePermission("CRM.DELETE_EMAIL_INBOX");
            endpoints.MapGet(API_SCHEMA + "/PinEmailInbox", EmailInboxHandler.PinEmailInbox).RequirePermission("CRM.PIN_EMAIL_INBOX");
            endpoints.MapGet(API_SCHEMA + "/ReadEmailInbox", EmailInboxHandler.ReadEmailInbox).RequirePermission("CRM.READ_EMAIL_INBOX");
            endpoints.MapGet(API_SCHEMA + "/RemoveEmailInbox", EmailInboxHandler.RemoveEmailInbox).RequirePermission("CRM.REMOVE_EMAIL_INBOX");



            endpoints.MapPost(API_SCHEMA + "/SendEmailOutbox", EmailOutboxHandler.SendEmailOutbox).RequirePermission("CRM.SEND_EMAIL_OUTBOX");
            endpoints.MapPost(API_SCHEMA + "/SaveDraftEmailOutbox", EmailOutboxHandler.SaveDraftEmailOutbox).RequirePermission("CRM.SAVE_DRAFT_EMAIL_OUTBOX");

            endpoints.MapGet(API_SCHEMA + "/GetAllEmailOutbox", EmailOutboxHandler.GetAllEmailOutbox).RequirePermission("CRM.GET_ALL_EMAIL_OUTBOX");
            endpoints.MapGet(API_SCHEMA + "/GetEmailOutbox", EmailOutboxHandler.GetEmailOutbox).RequirePermission("CRM.GET_EMAIL_OUTBOX");
            endpoints.MapGet(API_SCHEMA + "/GetEmailOutboxByIdForSender", EmailOutboxHandler.GetEmailOutboxByIdForSender).RequirePermission("CRM.GET_EMAIL_OUTBOX_BY_ID_FOR_SENDER");
            endpoints.MapGet(API_SCHEMA + "/RemoveEmailOutbox", EmailOutboxHandler.RemoveEmailOutbox).RequirePermission("CRM.REMOVE_EMAIL_OUTBOX");



            return endpoints;
        }

    }
}
