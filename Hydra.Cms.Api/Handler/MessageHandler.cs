using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class MessageHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageService"></param>
        /// <param name="messageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
            ClaimsPrincipal userClaim,
             IMessageService _messageService, GridDataBound dataGrid)
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);

                var result = await _messageService.GetList(dataGrid, userId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageService"></param>
        /// <param name="messageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetMessageById(
            IMessageService _messageService,
            int messageId
            )
        {
            var result = await _messageService.GetById(messageId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageService"></param>
        /// <param name="messageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddMessage(
            ClaimsPrincipal userClaim,
            IMessageService _messageService,
            [FromBody] MessageModel messageModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            if (userId > 0)
                messageModel.WriterId = userId;
            
            var result = await _messageService.Add(messageModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageService"></param>
        /// <param name="messageModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateMessage(
            ClaimsPrincipal userClaim,
            IMessageService _messageService,
            [FromBody] MessageModel messageModel
            )
        {
            var result = await _messageService.Update(messageModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageService"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteMessage(
            IMessageService _messageService,
            int messageId
            )
        {
            try
            {
                var result = await _messageService.Delete(messageId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}