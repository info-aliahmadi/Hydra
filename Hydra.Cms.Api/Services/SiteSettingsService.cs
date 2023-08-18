using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Infrastructure.Setting.Service;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;


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
        public async Task<Result<List<SiteSettingsModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<SiteSettingsModel>>();

            var list = await (from siteSettings in _queryRepository.Table<SiteSettings>().Include(x => x.Writer).Include(x => x.Editor)
                              select new SiteSettingsModel()
                              {
                                  Id = siteSettings.Id,
                                  Subject = siteSettings.Subject,
                                  Body = siteSettings.Body,
                                  SiteSettingsTitle = siteSettings.SiteSettingsTitle,
                                  EditDate = siteSettings.EditDate,
                                  RegisterDate = siteSettings.RegisterDate,
                                  WriterId = siteSettings.WriterId,
                                  EditorId = siteSettings.EditorId,
                                  Writer = new AuthorModel()
                                  {
                                      Id = siteSettings.Writer.Id,
                                      Name = siteSettings.Writer.Name,
                                      UserName = siteSettings.Writer.UserName,
                                      Avatar = siteSettings.Writer.Avatar
                                  },
                                  Editor = new AuthorModel()
                                  {
                                      Id = siteSettings.Editor!.Id,
                                      Name = siteSettings.Editor!.Name ?? "",
                                      UserName = siteSettings.Editor!.UserName ?? "",
                                      Avatar = siteSettings.Editor!.Avatar ?? ""
                                  },
                                  Tags = siteSettings.Tags.Select(x => x.Title).ToList(),

                              }).OrderByDescending(x=>x.RegisterDate).ToPaginatedListAsync(dataGrid);


            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<SiteSetting>> GetById(int id)
        {
            return await _settingService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSettingsModel"></param>
        /// <returns></returns>
        public async Task<Result<SiteSettingsModel>> Add(SiteSettingsModel siteSettingsModel)
        {
            var result = new Result<SiteSettingsModel>();
            try
            {
                bool isExist = await _queryRepository.Table<SiteSettings>().AnyAsync(x => x.SiteSettingsTitle == siteSettingsModel.SiteSettingsTitle);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Subject already exist";
                    result.Errors.Add(new Error(nameof(siteSettingsModel.Subject), "The Subject already exist"));
                    return result;
                }
                var tags = siteSettingsModel.Tags.ToArray();
                await _tagService.Add(tags);

                var siteSettings = new SiteSettings()
                {
                    SiteSettingsTitle = siteSettingsModel.SiteSettingsTitle,
                    Subject = siteSettingsModel.Subject,
                    Body = siteSettingsModel.Body,
                    RegisterDate = DateTime.UtcNow,
                    WriterId = siteSettingsModel.WriterId,
                };

                await _commandRepository.InsertAsync(siteSettings);

                await _commandRepository.SaveChangesAsync();

                siteSettings.Tags = _queryRepository.Table<Tag>().Where(x => siteSettingsModel.Tags.Contains(x.Title)).ToList();


                await _commandRepository.SaveChangesAsync();

                siteSettingsModel.Id = siteSettings.Id;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSettingsModel"></param>
        /// <returns></returns>
        public async Task<Result<SiteSettingsModel>> Update(SiteSettingsModel siteSettingsModel)
        {
            var result = new Result<SiteSettingsModel>();
            try
            {
                var siteSettings = await _queryRepository.Table<SiteSettings>().AsNoTracking().FirstAsync(x => x.Id == siteSettingsModel.Id);
                if (siteSettings is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The SiteSettings not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<SiteSettings>().AnyAsync(x => x.Id != siteSettingsModel.Id && x.SiteSettingsTitle == siteSettingsModel.SiteSettingsTitle);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Subject already exist";
                    result.Errors.Add(new Error(nameof(siteSettingsModel.Subject), "The Subject already exist"));
                    return result;
                }
                var tags = siteSettingsModel.Tags.ToArray();

                await _tagService.Add(tags);

                siteSettings.SiteSettingsTitle = siteSettingsModel.SiteSettingsTitle;
                siteSettings.Subject = siteSettingsModel.Subject;
                siteSettings.Body = siteSettingsModel.Body;
                siteSettings.EditorId = siteSettingsModel.EditorId;
                siteSettings.EditDate = DateTime.UtcNow;

                var newTagIds = (await _tagService.GetListByTitle(siteSettingsModel.Tags.ToArray())).Data.Select(x => x.Id).ToArray();

                // remove then add new relationship
                await UpdateSiteSettingsTags(siteSettings.Id, newTagIds);

                _commandRepository.UpdateAsync(siteSettings);
                await _commandRepository.SaveChangesAsync();


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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<Result> UpdateSiteSettingsTags(int siteSettingsId, int[] newTags)
        {
            var result = new Result();
            try
            {
                var siteSettingsTags = _queryRepository.Table<SiteSettingsTag>().Where(x => x.SiteSettingsId == siteSettingsId).ToList();

                var currentTags = siteSettingsTags.Select(x => x.TagId).ToArray();

                if (!(newTags == currentTags))
                {
                    foreach (var siteSettingsTag in siteSettingsTags)
                    {
                        _commandRepository.DeleteAsync(siteSettingsTag);
                    }
                    foreach (var tag in newTags)
                    {
                        await _commandRepository.InsertAsync(new SiteSettingsTag()
                        {
                            SiteSettingsId = siteSettingsId,
                            TagId = tag
                        });
                    }
                    await _commandRepository.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var siteSettings = await _queryRepository.Table<SiteSettings>().FirstOrDefaultAsync(x => x.Id == id);
            if (siteSettings is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The SiteSettings not found";
                return result;
            }

            _commandRepository.DeleteAsync(siteSettings);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}