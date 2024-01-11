using Hydra.Auth.Api.Handler;
using Hydra.Auth.Api.Services;
using Hydra.Auth.Core.Interfaces;
using Hydra.Infrastructure.ModuleExtension;
using Hydra.Infrastructure.Security.Extensions;
using Hydra.Infrastructure.Security.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Auth.Api.Endpoints
{
    public class AuthModule : IModule
    {
        private const string API_SCHEMA = "/Auth";

        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionService, PermissionService>();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet(API_SCHEMA + "/initialize", AccountHandler.InitializeHandler).AllowAnonymous();

            endpoints.MapPost(API_SCHEMA + "/login", AccountHandler.LoginHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/Register", AccountHandler.RegisterHandler).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetCurrentUser", AccountHandler.GetCurrentUserHandler);
            endpoints.MapPost(API_SCHEMA + "/UpdateCurrentUser", AccountHandler.UpdateCurrentUserHandler);
            endpoints.MapPost(API_SCHEMA + "/SignOut", AccountHandler.SignOutHandler);

            endpoints.MapGet(API_SCHEMA + "/RefreshToken", AccountHandler.RefreshToken);
            endpoints.MapGet(API_SCHEMA + "/GetPermissionsOfCurrentUser", AccountHandler.GetPermissionsOfCurrentUser);
            endpoints.MapGet(API_SCHEMA + "/GetPermissions", AccountHandler.GetPermissions).AllowAnonymous();


            endpoints.MapGet(API_SCHEMA + "/GetDefaultLanguage", AccountHandler.GetDefaultLanguageHandler);
            endpoints.MapGet(API_SCHEMA + "/SetDefaultLanguage", AccountHandler.SetDefaultLanguageHandler);

            endpoints.MapGet(API_SCHEMA + "/GetDefaultTheme", AccountHandler.GetDefaultThemeHandler);
            endpoints.MapGet(API_SCHEMA + "/SetDefaultTheme", AccountHandler.SetDefaultThemeHandler);


            endpoints.MapPost(API_SCHEMA + "/ExternalLoginCallback", AccountHandler.ExternalLoginCallbackHandler).RequirePermission("AUTH.GET_EXTERNAL_LOGIN_CALLBACK");
            endpoints.MapGet(API_SCHEMA + "/ExternalLoginConfirmation", AccountHandler.ExternalLoginConfirmationHandler).RequirePermission("AUTH.EXTERNAL_LOGIN_CONFIRMATION");

            endpoints.MapGet(API_SCHEMA + "/ConfirmEmail", AccountHandler.ConfirmEmailHandler).RequirePermission("AUTH.CONFIRM_EMAIL");
            endpoints.MapPost(API_SCHEMA + "/ChangePassword", AccountHandler.ChangePasswordHandler).RequirePermission("AUTH.CHANGE_PASSWORD");
            endpoints.MapPost(API_SCHEMA + "/ForgotPassword", AccountHandler.ForgotPasswordHandler).RequirePermission("AUTH.FORGOT_PASSWORD");
            endpoints.MapPost(API_SCHEMA + "/ResetPassword", AccountHandler.ResetPasswordHandler).RequirePermission("AUTH.RESET_PASSWORD");
            endpoints.MapGet(API_SCHEMA + "/GetTwoFactorProvidersAsync", AccountHandler.GetTwoFactorProvidersAsyncHandler).RequirePermission("AUTH.GET_TWO_FACTOR_PROVIDERS_ASYNC");
            endpoints.MapPost(API_SCHEMA + "/SendCode", AccountHandler.SendCodeHandler).RequirePermission("AUTH.SEND_CODE");
            endpoints.MapPost(API_SCHEMA + "/VerifyAuthenticatorCode", AccountHandler.VerifyAuthenticatorCodeHandler).RequirePermission("AUTH.VERIFY_AUTHENTICATOR_CODE");
            endpoints.MapPost(API_SCHEMA + "/VerifyCode", AccountHandler.VerifyCodeHandler).RequirePermission("AUTH.VERIFY_CODE");
            endpoints.MapPost(API_SCHEMA + "/UseRecoveryCode", AccountHandler.UseRecoveryCodeHandler).RequirePermission("AUTH.USE_RECOVERY_CODE");

            endpoints.MapPost(API_SCHEMA + "/GetUserList", UserHandler.GetList).RequirePermission("AUTH.GET_USER_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetUserListForSelect", UserHandler.GetListForSelect).RequirePermission("AUTH.GET_USER_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetUserListForSelectByIds", UserHandler.GetListForSelectByIds).RequirePermission("AUTH.GET_USER_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetUserById", UserHandler.GetUserById).RequirePermission("AUTH.GET_USER_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddUser", UserHandler.AddUser).RequirePermission("AUTH.ADD_USER");
            endpoints.MapPost(API_SCHEMA + "/UpdateUser", UserHandler.UpdateUser).RequirePermission("AUTH.UPDATE_USER");
            endpoints.MapGet(API_SCHEMA + "/DeleteUser", UserHandler.DeleteUser).RequirePermission("AUTH.DELETE_USER");

            endpoints.MapGet(API_SCHEMA + "/AssignPermissionToRoleByRoleId", RoleHandler.AssignPermissionToRoleByRoleId).RequirePermission("AUTH.ASSIGN_PERMISSION_TO_ROLE_BY_ROLE_ID");
            endpoints.MapGet(API_SCHEMA + "/DismissPermissionToRoleByRoleId", RoleHandler.DismissPermissionToRoleByRoleId).RequirePermission("AUTH.ASSIGN_PERMISSION_TO_ROLE_BY_ROLE_ID");


            endpoints.MapPost(API_SCHEMA + "/GetRoleList", RoleHandler.GetList).RequirePermission("AUTH.GET_ROLE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetAllRoles", RoleHandler.GetAllRoles).RequirePermission("AUTH.GET_ROLE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetRoleById", RoleHandler.GetRoleById).RequirePermission("AUTH.GET_ROLE_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddRole", RoleHandler.AddRole).RequirePermission("AUTH.ADD_ROLE");
            endpoints.MapPost(API_SCHEMA + "/UpdateRole", RoleHandler.UpdateRole).RequirePermission("AUTH.UPDATE_ROLE");
            endpoints.MapGet(API_SCHEMA + "/DeleteRole", RoleHandler.DeleteRole).RequirePermission("AUTH.DELETE_ROLE");


            endpoints.MapPost(API_SCHEMA + "/GetPermissionList", PermissionHandler.GetList).RequirePermission("AUTH.GET_PERMISSION_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetPermissionsByName", PermissionHandler.GetPermissionsByName).RequirePermission("AUTH.GET_PERMISSION_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetPermissionById", PermissionHandler.GetById).RequirePermission("AUTH.GET_PERMISSION_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddPermission", PermissionHandler.AddPermission).RequirePermission("AUTH.ADD_PERMISSION");
            endpoints.MapPost(API_SCHEMA + "/UpdatePermission", PermissionHandler.UpdatePermission).RequirePermission("AUTH.UPDATE_PERMISSION");
            endpoints.MapGet(API_SCHEMA + "/DeletePermission", PermissionHandler.DeletePermission).RequirePermission("AUTH.DELETE_PERMISSION");


            return endpoints;
        }

    }
}
