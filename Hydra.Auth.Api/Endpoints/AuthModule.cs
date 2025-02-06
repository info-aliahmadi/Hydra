using Hydra.Auth.Api.Handler;
using Hydra.Auth.Constants;
using Hydra.Auth.Interface;
using Hydra.Auth.Service;
using Hydra.Infrastructure.ModuleExtension;
using Hydra.Infrastructure.Security.Extension;
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

            endpoints.MapGet(API_SCHEMA + "/ApiTest", AccountHandler.ApiTest).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/initialize", AccountHandler.InitializeHandler).AllowAnonymous();

            endpoints.MapPost(API_SCHEMA + "/login", AccountHandler.LoginHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/Register", AccountHandler.RegisterHandler).AllowAnonymous();

            endpoints.MapPost(API_SCHEMA + "/ExternalLoginCallback", AccountHandler.ExternalLoginCallbackHandler).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/ExternalLoginConfirmation", AccountHandler.ExternalLoginConfirmationHandler).AllowAnonymous();

            endpoints.MapGet(API_SCHEMA + "/ConfirmEmail", AccountHandler.ConfirmEmailHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/ForgotPassword", AccountHandler.ForgotPasswordHandler).AllowAnonymous();

            endpoints.MapGet(API_SCHEMA + "/GetTwoFactorProvidersAsync", AccountHandler.GetTwoFactorProvidersAsyncHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/SendCode", AccountHandler.SendCodeHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/VerifyAuthenticatorCode", AccountHandler.VerifyAuthenticatorCodeHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/VerifyCode", AccountHandler.VerifyCodeHandler).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/UseRecoveryCode", AccountHandler.UseRecoveryCodeHandler).AllowAnonymous();

            endpoints.MapPost(API_SCHEMA + "/ResetPassword", AccountHandler.ResetPasswordHandler).AllowAnonymous();


            endpoints.MapGet(API_SCHEMA + "/GetCurrentUser", AccountHandler.GetCurrentUserHandler).RequireAuthorization();
            endpoints.MapPost(API_SCHEMA + "/UpdateCurrentUser", AccountHandler.UpdateCurrentUserHandler).RequireAuthorization();
            endpoints.MapPost(API_SCHEMA + "/SignOut", AccountHandler.SignOutHandler).RequireAuthorization();

            endpoints.MapGet(API_SCHEMA + "/RefreshToken", AccountHandler.RefreshToken).RequireAuthorization();
            endpoints.MapGet(API_SCHEMA + "/GetPermissionsOfCurrentUser", AccountHandler.GetPermissionsOfCurrentUser).RequireAuthorization();
            endpoints.MapGet(API_SCHEMA + "/GetPermissions", AccountHandler.GetPermissions).RequireAuthorization();


            endpoints.MapGet(API_SCHEMA + "/GetDefaultLanguage", AccountHandler.GetDefaultLanguageHandler).RequireAuthorization();
            endpoints.MapGet(API_SCHEMA + "/SetDefaultLanguage", AccountHandler.SetDefaultLanguageHandler).RequireAuthorization();

            endpoints.MapGet(API_SCHEMA + "/GetDefaultTheme", AccountHandler.GetDefaultThemeHandler).RequireAuthorization();
            endpoints.MapGet(API_SCHEMA + "/SetDefaultTheme", AccountHandler.SetDefaultThemeHandler).RequireAuthorization();


            endpoints.MapPost(API_SCHEMA + "/ChangePassword", AccountHandler.ChangePasswordHandler).RequireAuthorization();

            endpoints.MapPost(API_SCHEMA + "/GetUserList", UserHandler.GetList).RequirePermission(AuthPermissionTypes.AUTH_USER_MANAGEMENT);
            endpoints.MapPost(API_SCHEMA + "/GetUserListForSelect", UserHandler.GetListForSelect).RequireAuthorization();
            endpoints.MapPost(API_SCHEMA + "/GetUserListForSelectByIds", UserHandler.GetListForSelectByIds).RequireAuthorization();
            endpoints.MapGet(API_SCHEMA + "/GetUserById", UserHandler.GetUserById).RequireAuthorization();
            endpoints.MapPost(API_SCHEMA + "/AddUser", UserHandler.AddUser).RequirePermission(AuthPermissionTypes.AUTH_USER_MANAGEMENT);
            endpoints.MapPost(API_SCHEMA + "/UpdateUser", UserHandler.UpdateUser).RequirePermission(AuthPermissionTypes.AUTH_USER_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/DeleteUser", UserHandler.DeleteUser).RequirePermission(AuthPermissionTypes.AUTH_USER_MANAGEMENT);

            endpoints.MapGet(API_SCHEMA + "/AssignPermissionToRoleByRoleId", RoleHandler.AssignPermissionToRoleByRoleId).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/DismissPermissionToRoleByRoleId", RoleHandler.DismissPermissionToRoleByRoleId).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);


            endpoints.MapPost(API_SCHEMA + "/GetRoleList", RoleHandler.GetList).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/GetAllRoles", RoleHandler.GetAllRoles).RequireAuthorization();
            endpoints.MapGet(API_SCHEMA + "/GetRoleById", RoleHandler.GetRoleById).RequireAuthorization();
            endpoints.MapPost(API_SCHEMA + "/AddRole", RoleHandler.AddRole).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapPost(API_SCHEMA + "/UpdateRole", RoleHandler.UpdateRole).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/DeleteRole", RoleHandler.DeleteRole).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);


            endpoints.MapPost(API_SCHEMA + "/GetPermissionList", PermissionHandler.GetList).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/GetPermissionsByName", PermissionHandler.GetPermissionsByName).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/GetPermissionById", PermissionHandler.GetById).RequireAuthorization();
            endpoints.MapPost(API_SCHEMA + "/AddPermission", PermissionHandler.AddPermission).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapPost(API_SCHEMA + "/UpdatePermission", PermissionHandler.UpdatePermission).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);
            endpoints.MapGet(API_SCHEMA + "/DeletePermission", PermissionHandler.DeletePermission).RequirePermission(AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT);


            return endpoints;
        }

    }
}
