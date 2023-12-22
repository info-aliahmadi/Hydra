
using System.Security.Claims;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Cms.Api.Handler
{
    public static class SubscribeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ISubscribeService subscribeService, GridDataBound dataGrid)
        {
            try
            {
                var result = await subscribeService.GetList(dataGrid);
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
        /// <param name="subscribeService"></param>
        /// <param name="subscribeId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetSubscribeById(ISubscribeService subscribeService, long subscribeId)
        {
            var result = await subscribeService.GetById(subscribeId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="subscribeService"></param>
        /// <param name="subscribeModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddSubscribe(ClaimsPrincipal userClaim, ISubscribeService subscribeService, [FromBody] SubscribeModel subscribeModel)
        {
            var result = await subscribeService.Add(subscribeModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="subscribeService"></param>
        /// <param name="subscribeModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateSubscribe(ClaimsPrincipal userClaim, ISubscribeService subscribeService, [FromBody] SubscribeModel subscribeModel)
        {
            var result = await subscribeService.Update(subscribeModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeService"></param>
        /// <param name="subscribeId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteSubscribe(ISubscribeService subscribeService, long subscribeId)
        {
            try
            {
                var result = await subscribeService.Delete(subscribeId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}