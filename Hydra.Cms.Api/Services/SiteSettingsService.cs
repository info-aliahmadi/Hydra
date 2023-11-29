using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Infrastructure.Setting.Service;
using Hydra.Kernel.Models;


namespace Hydra.Cms.Api.Services
{
    public class SiteSettingsService : ISiteSettingsService
    {
        private readonly ISettingService _settingService;

        public SiteSettingsService(ISettingService settingService)
        {
            _settingService = settingService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public Result<SiteSettingsModel> GetSettings()
        {
            var result = new Result<SiteSettingsModel>();

            var setting = new SiteSettingsModel();

            setting.SiteTitle = _settingService.GetByKey(key: nameof(setting.SiteTitle))?.Value ?? "";
            setting.SiteDescription = _settingService.GetByKey(key: nameof(setting.SiteDescription))?.Value ?? "";
            setting.SiteKeywords = _settingService.GetByKey(key: nameof(setting.SiteKeywords))?.Value ?? "";
            setting.HeaderHtml = _settingService.GetByKey(key: nameof(setting.HeaderHtml))?.Value ?? "";
            setting.FooterHtml = _settingService.GetByKey(key: nameof(setting.FooterHtml))?.Value ?? "";

            var numberOfPostsPerList = _settingService.GetByKey(key: nameof(setting.NumberOfPostsPerList))?.Value ?? null;
            setting.NumberOfPostsPerList = numberOfPostsPerList != null ? int.Parse(numberOfPostsPerList) : 0;

            result.Data = setting;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSettingsModel"></param>
        /// <returns></returns>
        public Result<SiteSettingsModel> AddOrUpdate(SiteSettingsModel siteSettingsModel)
        {
            var result = new Result<SiteSettingsModel>();
            try
            {
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(siteSettingsModel.SiteTitle),
                    Value = siteSettingsModel.SiteTitle,
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.String
                });
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(siteSettingsModel.SiteDescription),
                    Value = siteSettingsModel.SiteDescription,
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.String
                });
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(siteSettingsModel.SiteKeywords),
                    Value = siteSettingsModel.SiteKeywords,
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.String
                });
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(siteSettingsModel.HeaderHtml),
                    Value = siteSettingsModel.HeaderHtml,
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.String
                });
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(siteSettingsModel.FooterHtml),
                    Value = siteSettingsModel.FooterHtml,
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.String
                });
                _settingService.AddOrUpdate(new SiteSetting()
                {
                    Key = nameof(siteSettingsModel.NumberOfPostsPerList),
                    Value = siteSettingsModel.NumberOfPostsPerList.ToString(),
                    ValueType = Infrastructure.Setting.SettingValueTypeEnum.Integer
                });

                result.Data = siteSettingsModel;

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