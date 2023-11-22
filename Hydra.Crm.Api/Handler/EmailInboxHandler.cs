
using Hydra.Crm.Core.Interfaces;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Crm.Api.Handler
{
    public static class EmailInboxHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> LoadEmailInbox(IEmailInboxService _emailInboxService, ClaimsPrincipal userClaim)
        {

            var currentUserId = int.Parse(userClaim.FindFirst("identity")!.Value);

            var result = await _emailInboxService.LoadEmailInbox(currentUserId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetAllEmailInbox(IEmailInboxService _emailInboxService, GridDataBound dataGrid)
        {
            var result = await _emailInboxService.GetAllEmailInbox(dataGrid);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetEmailInbox(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, GridDataBound dataGrid)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.GetInbox(dataGrid, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetDeletedInbox(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, GridDataBound dataGrid)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.GetDeletedInbox(dataGrid, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetEmailInboxById(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, int emailInboxId)
        {
            var result = await _emailInboxService.GetById(emailInboxId);


            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetEmailInboxByIdForReceiver(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, int emailInboxId)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.GetByIdForReceiver(emailInboxId, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteEmailInbox(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, int emailInboxId)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.Delete(emailInboxId, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> PinEmailInbox(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, int emailInboxId)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.Pin(emailInboxId, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> ReadEmailInbox(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, int emailInboxId)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.Read(emailInboxId, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailInboxService"></param>
        /// <param name="emailInboxModel"></param>
        /// <returns></returns>
        public static async Task<IResult> RemoveEmailInbox(
            ClaimsPrincipal userClaim,
             IEmailInboxService _emailInboxService, int emailInboxId)
        {
            var currentEmail = userClaim.FindFirst(ClaimTypes.Email)!.Value;

            var result = await _emailInboxService.Remove(emailInboxId, currentEmail);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }
    }
}