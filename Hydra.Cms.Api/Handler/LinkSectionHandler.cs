using Hydra.Cms.Api.Services;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hydra.Cms.Api.Handler
{
    public static class LinkSectionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkSectionService"></param>
        /// <param name="linkSectionModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetList(
             ILinkSectionService _linkSectionService)
        {
            try
            {
                var result = await _linkSectionService.GetList();

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
        /// <param name="_linkSectionService"></param>
        /// <param name="linkSectionModel"></param>
        /// <returns></returns>
        public static async Task<IResult> GetLinkSectionById(
            ILinkSectionService _linkSectionService,
            int linkSectionId
            )
        {
            var result = await _linkSectionService.GetById(linkSectionId);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkSectionService"></param>
        /// <param name="linkSectionModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddLinkSection(
            ClaimsPrincipal userClaim,
            ILinkSectionService _linkSectionService,
            [FromBody] LinkSectionModel linkSectionModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            var result = await _linkSectionService.Add(linkSectionModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkSectionService"></param>
        /// <param name="linkSectionModel"></param>
        /// <returns></returns>
        public static async Task<IResult> UpdateLinkSection(
            ClaimsPrincipal userClaim,
            ILinkSectionService _linkSectionService,
            [FromBody] LinkSectionModel linkSectionModel
            )
        {
            var userId = int.Parse(userClaim?.FindFirst("identity")?.Value);
            var result = await _linkSectionService.Update(linkSectionModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_linkSectionService"></param>
        /// <param name="linkSectionId"></param>
        /// <returns></returns>
        public static async Task<IResult> VisibleLinkSection(ILinkSectionService _linkSectionService, int linkSectionId)
        {
            try
            {
                var result = await _linkSectionService.Visible(linkSectionId);

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
        /// <param name="_linkSectionService"></param>
        /// <param name="linkSectionId"></param>
        /// <returns></returns>
        public static async Task<IResult> DeleteLinkSection(
            ILinkSectionService _linkSectionService,
            int linkSectionId
            )
        {
            try
            {
                var result = await _linkSectionService.Delete(linkSectionId);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}