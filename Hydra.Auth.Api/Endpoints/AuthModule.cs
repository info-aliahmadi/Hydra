using Hydra.Auth.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Endpoints;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace Hydra.Cms.Api.Endpoints
{
    public class AuthModule : IModule
    {

        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            //services.AddSingleton(new OrderConfig());
            services.AddScoped<IQueryRepository, QueryRepository>();
            //services.AddScoped<IPayment, PaymentService>();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet("/signup", async (IQueryRepository _repository, UserManager<User> _userManager, SignInManager<User> _signInManager, IStringLocalizer<SharedResource> _sharedlocalizer) =>
            {
                try
                {

                    var result = new AccountResult();

                    var user = new User
                    { DOB = DateTime.Now, Name = "admin", UserName = "admin", Email = "admin@admin.com" };

                    var isExist = _repository.Table<User>().Any(x => x.UserName == "admin");
                    if (!isExist)
                    {
                        var identityResult = await _userManager.CreateAsync(user, "admin");
                        if (identityResult.Succeeded)
                        {
                            if (_userManager.Options.SignIn.RequireConfirmedEmail)
                            {
                                result.Status = AccountStatusEnum.RequireConfirmedEmail;
                                var emailRequest = new EmailRequestRecord();
                                //For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                                //Send an email with this link
                                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                var callbackUrl = string.Format("ConfirmEmail/Account/{0}/{1}/{2}", user.Id, code, "");

                                emailRequest.Subject = _sharedlocalizer["ConfirmEmail"];
                                emailRequest.Body =
                                    string.Format(
                                        _sharedlocalizer[
                                            "Please confirm your account by clicking this link: <a href='{0}'>link</a>"],
                                        callbackUrl);
                                emailRequest.ToEmail = "admin@admin.com";
                                try
                                {
                                    //await _emailSender.SendEmailAsync(emailRequest);

                                    result.Status = AccountStatusEnum.Succeeded;
                                    Results.Ok(result);
                                }
                                catch (Exception e)
                                {
                                    //_logger.LogError(e.InnerException + "_" + e.Message);
                                    result.Errors.Add(string.Format(_sharedlocalizer["{0} action throws an error"]));
                                    Results.BadRequest(result);
                                }
                            }
                        }
                        if (identityResult.Errors.Any())
                        {
                            foreach (var error in identityResult.Errors)
                            {
                                //_logger.LogError(_sharedlocalizer["{0}; Requested By: {1}"], error.Description,
                                //    "admin@admin.com");
                                result.Errors.Add(error.Description);
                            }

                            //_logger.LogError(_sharedlocalizer["The user could not create a new account.; Requested By: {0}"],
                            //    "admin@admin.com");
                            result.Status = AccountStatusEnum.Failed;

                            Results.BadRequest(result);

                        }
                        else
                        {
                            Results.Ok(result);
                        }
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation(3,
                    //    _sharedlocalizer["The user created a new account with the password."]);
                    result.Status = AccountStatusEnum.Succeeded;
                    Results.Ok(result);

                }
                catch (Exception)
                {

                    throw;
                }

            }).AllowAnonymous();

            endpoints.MapGet("/login", async (IQueryRepository _repository, UserManager<User> _userManager, SignInManager<User> _signInManager, IStringLocalizer<SharedResource> _sharedlocalizer) =>
            {
                try
                {
                    var result = new AccountResult();
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var signInResult = await _signInManager.PasswordSignInAsync("admin", "admin",
                        true, lockoutOnFailure: false);
                    if (signInResult.Succeeded)
                    {
                        result.Status = AccountStatusEnum.Succeeded;
                        Results.Ok(result);
                    }

                    if (signInResult.RequiresTwoFactor)
                    {
                        result.Status = AccountStatusEnum.RequiresTwoFactor;
                        Results.Ok(result);
                    }

                    if (signInResult.IsLockedOut)
                    {
                        result.Status = AccountStatusEnum.IsLockedOut;
                        Results.Ok(result);
                    }
                }
                catch (Exception e)
                {
                    Results.BadRequest("BadRequest");
                }

            });

            endpoints.MapPost("/username", (ClaimsPrincipal user) =>
            {
                return user.Identity.Name;
            }).AllowAnonymous();


            return endpoints;
        }

    }
}
