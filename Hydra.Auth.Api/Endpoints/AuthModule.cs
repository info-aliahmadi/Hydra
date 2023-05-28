using Hydra.Auth.Api.Handler;
using Hydra.Auth.Api.Services;
using Hydra.Auth.Core.Interfaces;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Filters;
using Hydra.Infrastructure.Security.Filters;
using Hydra.Kernel.Interfaces;
using Hydra.Kernel.Interfaces.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Nitro.Service.MessageSender;
using System.Security.Claims;

namespace Hydra.Cms.Api.Endpoints
{
    public class AuthModule : IModule
    {

        private const string API_SCHEMA = "/Auth";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailSender, MessageSender>();
            services.AddScoped<ISmsSender, MessageSender>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet(API_SCHEMA + "/initialize", AccountHandler.InitializeHandler).AllowAnonymous();

            endpoints.MapGet(API_SCHEMA + "/login", AccountHandler.LoginHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/Register", AccountHandler.RegisterHandler);
            endpoints.MapPost(API_SCHEMA + "/SignOut", AccountHandler.SignOutHandler);
            endpoints.MapPost(API_SCHEMA + "/ExternalLoginCallback", AccountHandler.ExternalLoginCallbackHandler);
            endpoints.MapGet(API_SCHEMA + "/ExternalLoginConfirmation", AccountHandler.ExternalLoginConfirmationHandler);

            endpoints.MapGet(API_SCHEMA + "/ConfirmEmail", AccountHandler.ConfirmEmailHandler);
            endpoints.MapPost(API_SCHEMA + "/ForgotPassword", AccountHandler.ForgotPasswordHandler);
            endpoints.MapPost(API_SCHEMA + "/ResetPassword", AccountHandler.ResetPasswordHandler);
            endpoints.MapGet(API_SCHEMA + "/GetTwoFactorProvidersAsync", AccountHandler.GetTwoFactorProvidersAsyncHandler);
            endpoints.MapPost(API_SCHEMA + "/SendCode", AccountHandler.SendCodeHandler);
            endpoints.MapPost(API_SCHEMA + "/VerifyAuthenticatorCode", AccountHandler.VerifyAuthenticatorCodeHandler);
            endpoints.MapPost(API_SCHEMA + "/VerifyCode", AccountHandler.VerifyCodeHandler);
            endpoints.MapPost(API_SCHEMA + "/UseRecoveryCode", AccountHandler.UseRecoveryCodeHandler);


            endpoints.MapGet(API_SCHEMA + "/AssignRoleToUserByRoleName", UserHandler.AssignRoleToUserByRoleName);
            endpoints.MapGet(API_SCHEMA + "/AssignRoleToUserByRoleId", UserHandler.AssignRoleToUserByRoleId);

            endpoints.MapGet(API_SCHEMA + "/AssignPermissionToRoleByRoleName", RoleHandler.AssignPermissionToRoleByRoleName);
            endpoints.MapGet(API_SCHEMA + "/AssignPermissionToRoleByRoleId", RoleHandler.AssignPermissionToRoleByRoleId);


            endpoints.MapGet(API_SCHEMA + "/GetRoleList", RoleHandler.GetList);
            endpoints.MapGet(API_SCHEMA + "/GetRoleById", RoleHandler.GetRoleById);
            endpoints.MapPost(API_SCHEMA + "/AddRole", RoleHandler.AddRole);
            endpoints.MapPost(API_SCHEMA + "/UpdateRole", RoleHandler.UpdateRole);
            endpoints.MapGet(API_SCHEMA + "/DeleteRole", RoleHandler.DeleteRole);


            endpoints.MapGet(API_SCHEMA + "/GetPermissionList", PermissionHandler.GetList).AddEndpointFilter<BeforeEndpointExecution>();
            endpoints.MapGet(API_SCHEMA + "/GetPermissionById", PermissionHandler.GetById);
            endpoints.MapPost(API_SCHEMA + "/AddPermission", PermissionHandler.AddPermission);
            endpoints.MapPost(API_SCHEMA + "/UpdatePermission", PermissionHandler.UpdatePermission).RequireAuthorization("roleName");
            endpoints.MapGet(API_SCHEMA + "/DeletePermission", PermissionHandler.DeletePermission);


            endpoints.MapGet(API_SCHEMA + "/username", async (ClaimsPrincipal user, HttpContext context) =>
            {
                return user.Identity.Name;

            }).AllowAnonymous();


            return endpoints;
        }

    }
}
