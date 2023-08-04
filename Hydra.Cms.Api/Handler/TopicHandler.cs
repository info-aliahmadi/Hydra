using Hydra.Auth.Core.Interfaces;
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class TopicHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_topicService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetTopicsHierarchy(ITopicService _topicService)
        {
            try
            {
                var result = await _topicService.GetHierarchy();

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
        /// <param name="_topicService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetListForSelect(ITopicService _topicService)
        {
            try
            {
                var result = await _topicService.GetListForSelect();

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
        /// <param name="_topicService"></param>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetTopicById(
            ITopicService _topicService,
            int topicId
            )
        {
            var result = await _topicService.GetById(topicId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_topicService"></param>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddTopic(ClaimsPrincipal userClaim,
            ITopicService _topicService,
            [FromBody] TopicModel topicModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            topicModel.UserId = userId;
            var result = await _topicService.Add(topicModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_topicService"></param>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateTopic(ClaimsPrincipal userClaim,
            ITopicService _topicService,
            [FromBody] TopicModel topicModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            topicModel.UserId = userId;
            var result = await _topicService.Update(topicModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_topicService"></param>
        /// <param name="topicId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteTopic(ClaimsPrincipal userClaim,
            ITopicService _topicService,
            int topicId
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            try
            {
                var result = await _topicService.Delete(topicId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}