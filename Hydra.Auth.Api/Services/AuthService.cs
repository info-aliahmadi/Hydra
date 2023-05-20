using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Hydra.Auth.Api.Services
{
    public class AuthService
    {


        public static async Task<IResult> LoginHandler(ITokenService tokenService, UserManager<User> _userManager, SignInManager<User> _signInManager,bool rememberMe)
        {
            try
            {
                var result = new AccountResult();
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                var user = await _userManager.FindByNameAsync("admin");

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, "admin", true);
                if (signInResult.Succeeded)
                {
                    var token = tokenService.CreateToken( user, rememberMe);
                    result.Status = AccountStatusEnum.Succeeded;


                    if (signInResult.RequiresTwoFactor)
                    {
                        result.Status = AccountStatusEnum.RequiresTwoFactor;
                        return Results.Ok(result);
                    }

                    if (signInResult.IsLockedOut)
                    {
                        result.Status = AccountStatusEnum.IsLockedOut;
                        return Results.Ok(result);
                    }

                    return Results.Ok(token);
                }
                else
                {
                    return Results.BadRequest("BadRequest");
                }

            }
            catch (Exception e)
            {
                return Results.BadRequest("BadRequest");
            }
        }
    }
}
