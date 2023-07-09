using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Cms.Api.Services
{
    public class ContentService : IContentService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public ContentService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ContentModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ContentModel>>();

            var list = await (from content in _queryRepository.Table<Content>().Include(x => x.Writer).Include(x => x.Editor)
                              select new ContentModel()
                              {
                                  Id = content.Id,
                                  Subject = content.Subject,
                                  Body = content.Body,
                                  SmallThumbnail = content.SmallThumbnail,
                                  LargeThumbnail = content.LargeThumbnail,
                                  PublishDate = content.PublishDate,
                                  RegisterDate = content.RegisterDate,
                                  WriterId = content.WriterId,
                                  EditorId = content.EditorId,
                                  Writer = new UserInfoModel()
                                  {
                                      Id = content.Writer.Id,
                                      Name = content.Writer.Name,
                                      UserName = content.Writer.UserName,
                                      Avatar = content.Writer.Avatar
                                  },
                                  Editor = new UserInfoModel()
                                  {
                                      Id = content.Editor.Id,
                                      Name = content.Editor.Name??"",
                                      UserName = content.Editor.UserName,
                                      Avatar = content.Editor.Avatar
                                  },
                                  Categories = content.Categories.Select(x => x.Id).ToList()

                              }).ToPaginatedListAsync(dataGrid);

            //var userIds = list.Items.Select(x => x.Id);

            //var userRoleTable = from userRole in _queryRepository.Table<UserRole>()
            //                    join role in _queryRepository.Table<Role>() on userRole.RoleId equals role.Id
            //                    where userIds.Contains(userRole.UserId)
            //                    select new
            //                    {
            //                        role.Id,
            //                        userRole.UserId,
            //                    };
            //foreach (var item in list.Items)
            //{
            //    item.RoleIds = userRoleTable.Where(x => x.UserId == item.Id).Select(x => x.Id).ToList();
            //}

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ContentModel>> GetById(int id)
        {
            var result = new Result<ContentModel>();
            var content = await _queryRepository.Table<Content>().Include(x => x.Writer).Include(x => x.Editor).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var contentModel = new ContentModel()
            {
                Id = content.Id,
                Subject = content.Subject,
                Body = content.Body,
                SmallThumbnail = content.SmallThumbnail,
                LargeThumbnail = content.LargeThumbnail,
                PublishDate = content.PublishDate,
                RegisterDate = content.RegisterDate,
                WriterId = content.WriterId,
                EditorId = content.EditorId,
                Writer = new UserInfoModel()
                {
                    Id = content.Writer.Id,
                    Name = content.Writer.Name,
                    UserName = content.Writer.UserName,
                    Avatar = content.Writer.Avatar
                },
                Editor = new UserInfoModel()
                {
                    Id = content.Editor?.Id ?? 0,
                    Name = content.Editor?.Name,
                    UserName = content.Editor?.UserName,
                    Avatar = content.Editor?.Avatar
                },
                Categories = content.Categories.Select(x => x.Id).ToList()
            };
            result.Data = contentModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        public async Task<Result<ContentModel>> Add(ContentModel contentModel)
        {
            var result = new Result<ContentModel>();

            bool isExist = await _queryRepository.Table<Content>().AnyAsync(x => x.Subject == contentModel.Subject);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Subject already exist";
                result.Errors.Add(new Error(nameof(contentModel.Subject), "The Subject already exist"));
                return result;
            }

            var content = new Content()
            {
                Subject = contentModel.Subject,
                Body = contentModel.Body,
                PublishDate = contentModel.PublishDate,
                RegisterDate = DateTime.UtcNow,
                WriterId = contentModel.WriterId,
                Categories = _queryRepository.Table<Category>().Where(x => contentModel.Categories.Contains(x.Id)).ToList()
            };

            await _commandRepository.InsertAsync(content);

            await _commandRepository.SaveChangesAsync();

            if (!string.IsNullOrEmpty(contentModel.SmallThumbnailFile))
            {
                var saveFileResult = SaveThumbnailFile(contentModel.SmallThumbnailFile, content.Id, "small");
                if (saveFileResult.Succeeded)
                {
                    content.SmallThumbnail = saveFileResult.Data;
                }
            }

            if (!string.IsNullOrEmpty(contentModel.LargeThumbnailFile))
            {
                var saveFileResult = SaveThumbnailFile(contentModel.LargeThumbnailFile, content.Id, "large");
                if (saveFileResult.Succeeded)
                {
                    content.LargeThumbnail = saveFileResult.Data;
                }
            }
            _commandRepository.UpdateAsync(content);

            await _commandRepository.SaveChangesAsync();

            contentModel.Id = content.Id;

            result.Data = contentModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        public async Task<Result<ContentModel>> Update(ContentModel contentModel)
        {
            var result = new Result<ContentModel>();

            var content = await _queryRepository.Table<Content>().FirstOrDefaultAsync(x => x.Id == contentModel.Id);
            if (content is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Content not found";
                return result;
            }

            bool isExist = await _queryRepository.Table<Content>().AnyAsync(x => x.Id != contentModel.Id && x.Subject == contentModel.Subject);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Subject already exist";
                result.Errors.Add(new Error(nameof(contentModel.Subject), "The Subject already exist"));
                return result;
            }

            content.Subject = contentModel.Subject;
            content.Body = contentModel.Body;
            content.EditorId = contentModel.EditorId;
            content.EditDate = DateTime.UtcNow;
            content.Categories = _queryRepository.Table<Category>().Where(x => contentModel.Categories.Contains(x.Id)).ToList();

            if (string.IsNullOrEmpty(contentModel.SmallThumbnail) && !string.IsNullOrEmpty(content.SmallThumbnail))
            {
                DeleteThumbnailFile(content.SmallThumbnail);
                content.SmallThumbnail = null;
            }
            if (!string.IsNullOrEmpty(contentModel.SmallThumbnailFile))
            {
                var saveFileResult = SaveThumbnailFile(contentModel.SmallThumbnail, content.Id, "small", content.SmallThumbnail);
                if (saveFileResult.Succeeded)
                {
                    content.SmallThumbnail = saveFileResult.Data;
                }
            }

            if (string.IsNullOrEmpty(contentModel.LargeThumbnail) && !string.IsNullOrEmpty(content.LargeThumbnail))
            {
                DeleteThumbnailFile(content.LargeThumbnail);
                content.LargeThumbnail = null;
            }
            if (!string.IsNullOrEmpty(contentModel.LargeThumbnailFile))
            {
                var saveFileResult = SaveThumbnailFile(content.LargeThumbnail, content.Id, "large", content.LargeThumbnail);
                if (saveFileResult.Succeeded)
                {
                    content.LargeThumbnail = saveFileResult.Data;
                }
            }

            _commandRepository.UpdateAsync(content);

            await _commandRepository.SaveChangesAsync();

            result.Data = contentModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var content = await _queryRepository.Table<Content>().FirstOrDefaultAsync(x => x.Id == id);
            if (content is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Content not found";
                return result;
            }

            _commandRepository.DeleteAsync(content);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thumbnailFile"></param>
        /// <param name="contentId"></param>
        /// <param name="size"></param>
        /// <param name="oldthumbnailName"></param>
        /// <returns></returns>
        public Result<string> SaveThumbnailFile(string thumbnailFile, int contentId, string size, string oldthumbnailName = null)
        {
            var result = new Result();
            try
            {
                if (!string.IsNullOrEmpty(thumbnailFile))
                {
                    var fileBytes = thumbnailFile.Base64FileToBytes();
                    var fileName = contentId + "-" + size + "." + fileBytes.Extension;
                    var thumbnailPath = HydraHelper.GetThumbnailDirectory() + "{0}";
                    File.WriteAllBytes(string.Format(thumbnailPath, fileName), fileBytes.FileBytes);
                    if (!string.IsNullOrEmpty(oldthumbnailName))
                    {
                        if (File.Exists(string.Format(thumbnailPath, oldthumbnailName)))
                        {
                            File.Delete(string.Format(thumbnailPath, oldthumbnailName));
                        }
                    }
                    result.Data = fileName;
                    return result;
                }
                result.Status = ResultStatusEnum.NotFound;
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
        /// <param name="thumbnailName"></param>
        /// <returns></returns>
        public Result<string> DeleteThumbnailFile(string thumbnailName)
        {
            var result = new Result();
            try
            {
                if (!string.IsNullOrEmpty(thumbnailName))
                {
                    var thumbnailPath = HydraHelper.GetThumbnailDirectory() + "{0}";
                    if (File.Exists(string.Format(thumbnailPath, thumbnailName)))
                    {
                        File.Delete(string.Format(thumbnailPath, thumbnailName));
                    }
                    return result;
                }
                result.Status = ResultStatusEnum.NotFound;
                return result;

            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }
    }
}