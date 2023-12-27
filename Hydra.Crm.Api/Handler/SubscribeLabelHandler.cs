
using System.Security.Claims;
using Hydra.Crm.Core.Interfaces;
using Hydra.Crm.Core.Models.Subscribe;
using Hydra.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Crm.Api.Handler
{
    public static class SubscribeLabelHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeLabelService"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(ISubscribeLabelService subscribeLabelService, GridDataBound dataGrid)
        {
            try
            {
                var result = await subscribeLabelService.GetList(dataGrid);
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
        /// <param name="labelService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetListForSelect(ISubscribeLabelService labelService)
        {
            try
            {
                var result = await labelService.GetListForSelect();
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
        /// <param name="subscribeLabelService"></param>
        /// <param name="subscribeLabelId"></param>
        /// <returns></returns>
        public static async Task<IResult> GetSubscribeLabelById(ISubscribeLabelService subscribeLabelService, int subscribeLabelId)
        {
            var result = await subscribeLabelService.GetById(subscribeLabelId);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="subscribeLabelService"></param>
        /// <param name="subscribelabelModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddSubscribeLabel(ClaimsPrincipal userClaim, ISubscribeLabelService subscribeLabelService, [FromBody] SubscribeLabelModel subscribelabelModel)
        {
            var result = await subscribeLabelService.Add(subscribelabelModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userClaim"></param>
        /// <param name="subscribeLabelService"></param>
        /// <param name="subscribelabelModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateSubscribeLabel(ClaimsPrincipal userClaim, ISubscribeLabelService subscribeLabelService, [FromBody] SubscribeLabelModel subscribelabelModel)
        {
            var result = await subscribeLabelService.Update(subscribelabelModel);
            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeLabelService"></param>
        /// <param name="subscribeLabelId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteSubscribeLabel(ISubscribeLabelService subscribeLabelService, int subscribeLabelId)
        {
            try
            {
                var result = await subscribeLabelService.Delete(subscribeLabelId);
                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}