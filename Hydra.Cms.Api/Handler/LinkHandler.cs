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
    public static class LinkHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkService"></param>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             ILinkService _linkService)
        {
            try
            {
                var result = await _linkService.GetList();

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
        /// <param name="_linkService"></param>
        /// <param name="sectionKey"></param>
        /// <returns></returns>
        public static async Task<IResult> GetLinksByKeyList(
             ILinkService _linkService,
            string sectionKey)
        {
            try
            {
                var result = await _linkService.GetByKeyList(sectionKey);

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
        /// <param name="_linkService"></param>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetLinkById(
            ILinkService _linkService,
            int linkId
            )
        {
            var result = await _linkService.GetById(linkId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkService"></param>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddLink(
            ClaimsPrincipal userClaim,
            ILinkService _linkService,
            [FromBody] LinkModel linkModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            linkModel.UserId = userId;
            var result = await _linkService.Add(linkModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkService"></param>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateLink(
            ClaimsPrincipal userClaim,
            ILinkService _linkService,
            [FromBody] LinkModel linkModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            linkModel.UserId = userId;
            var result = await _linkService.Update(linkModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkService"></param>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateOrders(ClaimsPrincipal userClaim,
            ILinkService _linkService,
            [FromBody] List<LinkModel> linkModelList
            )
        {
            try
            {
                var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);

                var result = await _linkService.UpdateOrder(linkModelList);

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
        /// <param name="_linkService"></param>
        /// <param name="linkId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteLink(
            ILinkService _linkService,
            int linkId
            )
        {
            try
            {
                var result = await _linkService.Delete(linkId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}