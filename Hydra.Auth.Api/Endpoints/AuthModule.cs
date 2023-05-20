using Hydra.Auth.Api.Handler;
using Hydra.Auth.Api.Services;
using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Interfaces;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Nitro.Service.MessageSender;
using System.Security.Claims;

namespace Hydra.Cms.Api.Endpoints
{
    public class AuthModule : IModule
    {

        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            //services.AddSingleton(new OrderConfig());
            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailSender, MessageSender>();
            services.AddScoped<ISmsSender, MessageSender>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddHttpContextAccessor();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet("/initialize", AccountHandler.InitializeHandler).AllowAnonymous();

            endpoints.MapGet("/login", AccountHandler.LoginHandler);
            endpoints.MapPost("/Register", AccountHandler.RegisterHandler);
            endpoints.MapPost("/SignOut", AccountHandler.SignOutHandler);
            endpoints.MapPost("/ExternalLoginCallback", AccountHandler.ExternalLoginCallbackHandler);
            endpoints.MapGet("/ExternalLoginConfirmation", AccountHandler.ExternalLoginConfirmationHandler);

            endpoints.MapGet("/ConfirmEmail", AccountHandler.ConfirmEmailHandler);
            endpoints.MapPost("/ForgotPassword", AccountHandler.ForgotPasswordHandler);
            endpoints.MapPost("/ResetPassword", AccountHandler.ResetPasswordHandler);
            endpoints.MapGet("/GetTwoFactorProvidersAsync", AccountHandler.GetTwoFactorProvidersAsyncHandler);
            endpoints.MapPost("/SendCode", AccountHandler.SendCodeHandler);
            endpoints.MapPost("/VerifyAuthenticatorCode", AccountHandler.VerifyAuthenticatorCodeHandler);
            endpoints.MapPost("/VerifyCode", AccountHandler.VerifyCodeHandler);
            endpoints.MapPost("/UseRecoveryCode", AccountHandler.UseRecoveryCodeHandler);


            endpoints.MapGet("/username",  async (ClaimsPrincipal user, HttpContext context) =>
            {
                var bbb = Results.Created(HydraHelper.GetCurrentDomain(context) + "ExternalLoginConfirmation/Account/{0}", "asdasd");
                var email = "emailsss";
                var ccc = bbb.ToString();

                var vvv = Results.LocalRedirect(HydraHelper.GetCurrentDomain(context) + $"ExternalLoginConfirmation/Account/{email}");

                var bbbb = vvv.ToString();

                var mmm = Results.RedirectToRoute(HydraHelper.GetCurrentDomain(context) + "ExternalLoginConfirmation/Account/{0}", "asdasd");

                var fff = mmm.ToString();

                var redirectUrl = TypedResults.Created(context.Request.GetDisplayUrl() + "ExternalLoginConfirmation/Account/{0}", "asdasd");


                var sss = new EndpointNameMetadata("get_product");
                return user.Identity.Name;
            }).AllowAnonymous();


            return endpoints;
        }

    }
}
