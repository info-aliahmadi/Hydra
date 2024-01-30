using EFCoreSecondLevelCacheInterceptor;
using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Hydra.Cms.Api.Services
{
    public class TagService : ITagService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public TagService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<TagModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<TagModel>>();

            var list = await (from article in _queryRepository.Table<Tag>()
                              select new TagModel()
                              {
                                  Id = article.Id,
                                  Title = article.Title

                              }).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<List<TagModel>>> GetAllList()
        {
            var result = new Result<List<TagModel>>();

            var list = await (from article in _queryRepository.Table<Tag>()
                              select new TagModel()
                              {
                                  Id = article.Id,
                                  Title = article.Title

                              }).Cacheable().ToListAsync();

            result.Data = list;

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<List<TagModel>>> GetListByTitle(string[] tags)
        {
            var result = new Result<List<TagModel>>();

            var list = await _queryRepository.Table<Tag>().Where(x => tags.Contains(x.Title)).Select(tag => new TagModel()
            {
                Id = tag.Id,
                Title = tag.Title,
            }).ToListAsync();

            result.Data = list;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<TagModel>>> GetListForSelect()
        {
            var result = new Result<List<TagModel>>();

            var list = await _queryRepository.Table<Tag>().Select(x => new TagModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            result.Data = list;

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<TagModel>> GetById(int id)
        {
            var result = new Result<TagModel>();

            var record = await _queryRepository.Table<Tag>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var tag = new TagModel();
            if (record != null)
            {
                tag.Id = record.Id;
                tag.Title = record.Title;
            }
            else
            {
                result.Status = ResultStatusEnum.NotFound;
            }
            result.Data = tag;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<TagModel>> GetByTitle(string title)
        {
            var result = new Result<TagModel>();

            var record = await _queryRepository.Table<Tag>().Where(x => x.Title == title)
                .FirstOrDefaultAsync();
            var tag = new TagModel();
            if (record != null)
            {
                tag.Id = record.Id;
                tag.Title = record.Title;
            }
            else
            {
                result.Status = ResultStatusEnum.NotFound;
            }
            result.Data = tag;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public async Task<Result<TagModel>> Add(TagModel tagModel)
        {
            var result = new Result<TagModel>();

            var isExist = await _queryRepository.Table<Tag>().AnyAsync(x => x.Title == tagModel.Title);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(tagModel.Title), "The tag name existed"));
                result.Message = "The tag existed";
                return result;
            }
            var tag = new Tag()
            {
                Title = tagModel.Title
            };

            await _commandRepository.InsertAsync(tag);

            await _commandRepository.SaveChangesAsync();

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public async Task<Result> Add(string[] tags)
        {
            var result = new Result();

            var existedTags = _queryRepository.Table<Tag>().AsNoTracking().Where(x => tags.Contains(x.Title)).ToList();

            var newTags = tags.Where(x => !existedTags.Select(s => s.Title).ToArray().Contains(x)).Select(tagName => new Tag()
            {
                Title = tagName
            });

            foreach (var tag in newTags)
            {
                await _commandRepository.InsertAsync(tag);
            }

            await _commandRepository.SaveChangesAsync();
            _commandRepository.ResetContextState();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public async Task<Result<TagModel>> Update(TagModel tagModel)
        {
            var result = new Result<TagModel>();
            var tag = await _queryRepository.Table<Tag>().FirstOrDefaultAsync(x => x.Id == tagModel.Id);
            if (tag is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The tag not found";
                return result;
            }

            var isExist = await _queryRepository.Table<Tag>().AnyAsync(x => x.Id != tagModel.Id && x.Title == tagModel.Title);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(tagModel.Title), "The tag name existed"));
                result.Message = "The tag existed";
                return result;
            }

            var regsterDate = DateTime.UtcNow;

            tag.Title = tagModel.Title;

            _commandRepository.UpdateAsync(tag);

            await _commandRepository.SaveChangesAsync();

            result.Data = tagModel;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var tag = await _queryRepository.Table<Tag>().FirstOrDefaultAsync(x => x.Id == id);
            if (tag == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The tag not found";
                return result;
            }

            _commandRepository.DeleteAsync(tag);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}