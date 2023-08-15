using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Cms.Api.Services
{
    public class PageService : IPageService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly ITagService _tagService;

        public PageService(IQueryRepository queryRepository, ICommandRepository commandRepository, ITagService tagService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _tagService = tagService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<PageModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<PageModel>>();

            var list = await (from page in _queryRepository.Table<Page>().Include(x => x.Writer).Include(x => x.Editor)
                              select new PageModel()
                              {
                                  Id = page.Id,
                                  Subject = page.Subject,
                                  Body = page.Body,
                                  PageTitle = page.PageTitle,
                                  EditDate = page.EditDate,
                                  RegisterDate = page.RegisterDate,
                                  WriterId = page.WriterId,
                                  EditorId = page.EditorId,
                                  Writer = new AuthorModel()
                                  {
                                      Id = page.Writer.Id,
                                      Name = page.Writer.Name,
                                      UserName = page.Writer.UserName,
                                      Avatar = page.Writer.Avatar
                                  },
                                  Editor = new AuthorModel()
                                  {
                                      Id = page.Editor!.Id,
                                      Name = page.Editor!.Name ?? "",
                                      UserName = page.Editor!.UserName ?? "",
                                      Avatar = page.Editor!.Avatar ?? ""
                                  },
                                  Tags = page.Tags.Select(x => x.Title).ToList(),

                              }).OrderByDescending(x=>x.RegisterDate).ToPaginatedListAsync(dataGrid);


            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<PageModel>> GetById(int id)
        {
            var result = new Result<PageModel>();
            var page = await _queryRepository.Table<Page>().Include(x => x.Writer).Include(x => x.Editor).Include(x => x.Tags).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var pageModel = new PageModel()
            {
                Id = page.Id,
                PageTitle = page.PageTitle,
                Subject = page.Subject,
                Body = page.Body,
                RegisterDate = page.RegisterDate,
                EditDate = page.EditDate,
                WriterId = page.WriterId,
                EditorId = page.EditorId,
                Writer = new AuthorModel()
                {
                    Id = page.Writer.Id,
                    Name = page.Writer.Name,
                    UserName = page.Writer.UserName,
                    Avatar = page.Writer.Avatar
                },
                Editor = new AuthorModel()
                {
                    Id = page.Editor?.Id ?? 0,
                    Name = page.Editor?.Name,
                    UserName = page.Editor?.UserName,
                    Avatar = page.Editor?.Avatar
                },
                Tags = page.Tags.Select(x => x.Title).ToList(),
            };
            result.Data = pageModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public async Task<Result<PageModel>> Add(PageModel pageModel)
        {
            var result = new Result<PageModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Page>().AnyAsync(x => x.PageTitle == pageModel.PageTitle);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Subject already exist";
                    result.Errors.Add(new Error(nameof(pageModel.Subject), "The Subject already exist"));
                    return result;
                }
                var tags = pageModel.Tags.ToArray();
                await _tagService.Add(tags);

                var page = new Page()
                {
                    PageTitle = pageModel.PageTitle,
                    Subject = pageModel.Subject,
                    Body = pageModel.Body,
                    RegisterDate = DateTime.UtcNow,
                    WriterId = pageModel.WriterId,
                };

                await _commandRepository.InsertAsync(page);

                await _commandRepository.SaveChangesAsync();

                page.Tags = _queryRepository.Table<Tag>().Where(x => pageModel.Tags.Contains(x.Title)).ToList();


                await _commandRepository.SaveChangesAsync();

                pageModel.Id = page.Id;

                result.Data = pageModel;

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
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public async Task<Result<PageModel>> Update(PageModel pageModel)
        {
            var result = new Result<PageModel>();
            try
            {
                var page = await _queryRepository.Table<Page>().AsNoTracking().FirstAsync(x => x.Id == pageModel.Id);
                if (page is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Page not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Page>().AnyAsync(x => x.Id != pageModel.Id && x.PageTitle == pageModel.PageTitle);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Subject already exist";
                    result.Errors.Add(new Error(nameof(pageModel.Subject), "The Subject already exist"));
                    return result;
                }
                var tags = pageModel.Tags.ToArray();

                await _tagService.Add(tags);

                page.PageTitle = pageModel.PageTitle;
                page.Subject = pageModel.Subject;
                page.Body = pageModel.Body;
                page.EditorId = pageModel.EditorId;
                page.EditDate = DateTime.UtcNow;

                var newTagIds = (await _tagService.GetListByTitle(pageModel.Tags.ToArray())).Data.Select(x => x.Id).ToArray();

                // remove then add new relationship
                await UpdatePageTags(page.Id, newTagIds);

                _commandRepository.UpdateAsync(page);
                await _commandRepository.SaveChangesAsync();


                result.Data = pageModel;

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
        public async Task<Result> UpdatePageTags(int pageId, int[] newTags)
        {
            var result = new Result();
            try
            {
                var pageTags = _queryRepository.Table<PageTag>().Where(x => x.PageId == pageId).ToList();

                var currentTags = pageTags.Select(x => x.TagId).ToArray();

                if (!(newTags == currentTags))
                {
                    foreach (var pageTag in pageTags)
                    {
                        _commandRepository.DeleteAsync(pageTag);
                    }
                    foreach (var tag in newTags)
                    {
                        await _commandRepository.InsertAsync(new PageTag()
                        {
                            PageId = pageId,
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
            var page = await _queryRepository.Table<Page>().FirstOrDefaultAsync(x => x.Id == id);
            if (page is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Page not found";
                return result;
            }

            _commandRepository.DeleteAsync(page);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}