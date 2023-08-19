using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hydra.Cms.Api.Handler
{
    public static class SettingsHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_settingService"></param>
        /// <returns></returns>
        public static IResult GetSettings(
             ISiteSettingsService _settingService)
        {
            try
            {
                var result = _settingService.GetSettings();

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
        /// <param name="_settingService"></param>
        /// <returns></returns>
        public static IResult AddOrUpdateSettings(ISiteSettingsService _settingService, [FromBody] SiteSettingsModel siteSettingsModel)
        {
            try
            {
                var result = _settingService.AddOrUpdate(siteSettingsModel);

                return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }

    }
}