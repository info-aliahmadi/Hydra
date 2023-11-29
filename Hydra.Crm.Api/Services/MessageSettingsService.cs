using Hydra.Crm.Core.Interfaces;
using Hydra.Crm.Core.Models;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Infrastructure.Setting.Service;
using Hydra.Kernel.Models;
using System.Text.Json;

namespace Hydra.Cms.Api.Services
{
    public class MessageSettingsService : IMessageSettingsService
    {
        private readonly ISettingService _settingService;


        public MessageSettingsService(ISettingService settingService)
        {
            _settingService = settingService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public Result<MessageSettingModel> GetSettings()
        {
            var result = new Result<MessageSettingModel>();
            var setting = new MessageSettingModel();

            var recipientIdsForContactMessageValue = _settingService.GetByKey(key: nameof(setting.RecipientIdsForContactMessage))?.Value;
            var recipientIdsForRequestMessage = _settingService.GetByKey(key: nameof(setting.RecipientIdsForRequestMessage))?.Value;

            setting.RecipientIdsForContactMessage = recipientIdsForContactMessageValue != null ? recipientIdsForContactMessageValue.Split(';').Select(int.Parse).ToArray() : new int[0];
            setting.RecipientIdsForRequestMessage = recipientIdsForRequestMessage != null ? recipientIdsForRequestMessage.Split(';').Select(int.Parse).ToArray() : new int[0];


            result.Data = setting;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageSettingModel"></param>
        /// <returns></returns>
        public Result<MessageSettingModel> AddOrUpdate(MessageSettingModel messageSettingModel)
        {
            var result = new Result<MessageSettingModel>();
            try
            {
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(messageSettingModel.RecipientIdsForContactMessage),
                    Value = string.Join(";", messageSettingModel.RecipientIdsForContactMessage) ,
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.IntegerArray
                });
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(messageSettingModel.RecipientIdsForRequestMessage),
                    Value = string.Join(";", messageSettingModel.RecipientIdsForRequestMessage),
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.IntegerArray
                });

                result.Data = messageSettingModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

    }
}