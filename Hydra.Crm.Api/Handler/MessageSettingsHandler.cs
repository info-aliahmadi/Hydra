
using Hydra.Crm.Core.Interfaces;
using Hydra.Crm.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Hydra.Crm.Api.Handler
{
    public static class MessageSettingsHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageSettingsService"></param>
        /// <returns></returns>
        public static async Task<IResult> GetSettings(IMessageSettingsService _messageSettingsService)
        {
            var result = _messageSettingsService.GetSettings();

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_messageSettingsService"></param>
        /// <param name="messageSettingModel"></param>
        /// <returns></returns>
        public static async Task<IResult> AddOrUpdateSettings(IMessageSettingsService _messageSettingsService, MessageSettingModel messageSettingModel)
        {
            var result = _messageSettingsService.AddOrUpdate(messageSettingModel);

            return result.Succeeded ? Results.Ok(result) : Results.BadRequest(result);

        }
    }
}