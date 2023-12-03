using EFCoreSecondLevelCacheInterceptor;
using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;


namespace Hydra.Cms.Api.Services
{
    public class LinkSectionService : ILinkSectionService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly ILinkService _linkService;

        public LinkSectionService(IQueryRepository queryRepository, ICommandRepository commandRepository, ILinkService linkService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _linkService = linkService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<List<LinkSectionModel>>> GetList()
        {
            var result = new Result<List<LinkSectionModel>>();

            //var linkList = (await _linkService.GetList()).Data;

            var linkSectionList = await _queryRepository.Table<LinkSection>().Include(x=>x.Links).Select(linkSection => new LinkSectionModel()
            {
                Id = linkSection.Id,
                Key = linkSection.Key,
                Title = linkSection.Title,
                IsVisible = linkSection.IsVisible,
                Links = linkSection.Links.OrderByDescending(x => x.Order).Select(link => new LinkModel()
                {
                    Id = link.Id,
                    Description = link.Description,
                    Url = link.Url,
                    Title = link.Title,
                    ImagePreviewId = link.ImagePreviewId,
                    LinkSectionId = link.LinkSectionId,
                    Order = link.Order,
                }).ToList()
            }).Cacheable().ToListAsync();

            //foreach (var linkSection in linkSectionList)
            //{

            //    linkSection.Links = linkList.Where(x => x.LinkSectionId == linkSection.Id).OrderByDescending(x => x.Order).ToList();
            //}

            result.Data = linkSectionList;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<LinkSectionModel>> GetById(int id)
        {
            var result = new Result<LinkSectionModel>();

            var linkSection = await _queryRepository.Table<LinkSection>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var linkSectionModel = new LinkSectionModel()
            {
                Id = linkSection.Id,
                Key = linkSection.Key,
                Title = linkSection.Title,
                IsVisible = linkSection.IsVisible
            };
            result.Data = linkSectionModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkSectionModel"></param>
        /// <returns></returns>
        public async Task<Result<LinkSectionModel>> Add(LinkSectionModel linkSectionModel)
        {
            var result = new Result<LinkSectionModel>();
            try
            {
                bool isExist = await _queryRepository.Table<LinkSection>().AnyAsync(x => x.Key == linkSectionModel.Key);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Key already exist";
                    result.Errors.Add(new Error(nameof(linkSectionModel.Key), "The Key already exist"));
                    return result;
                }

                var linkSection = new LinkSection()
                {
                    Id = linkSectionModel.Id,
                    Key = linkSectionModel.Key,
                    Title = linkSectionModel.Title,
                    IsVisible = true
                };

                await _commandRepository.InsertAsync(linkSection);

                await _commandRepository.SaveChangesAsync();

                linkSectionModel.Id = linkSection.Id;

                result.Data = linkSectionModel;

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
        /// <param name="linkSectionModel"></param>
        /// <returns></returns>
        public async Task<Result<LinkSectionModel>> Update(LinkSectionModel linkSectionModel)
        {
            var result = new Result<LinkSectionModel>();
            try
            {
                var linkSection = await _queryRepository.Table<LinkSection>().AsNoTracking().FirstAsync(x => x.Id == linkSectionModel.Id);
                if (linkSection == null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Link Section not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<LinkSection>().AnyAsync(x => x.Id != linkSectionModel.Id && x.Key == linkSectionModel.Key);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Key already exist";
                    result.Errors.Add(new Error(nameof(linkSectionModel.Key), "The Key already exist"));
                    return result;
                }

                linkSection.Id = linkSectionModel.Id;
                linkSection.Key = linkSectionModel.Key;
                linkSection.Title = linkSectionModel.Title;

                _commandRepository.UpdateAsync(linkSection);
                await _commandRepository.SaveChangesAsync();

                result.Data = linkSectionModel;

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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Visible(int id)
        {
            var result = new Result();
            var linkSection = await _queryRepository.Table<LinkSection>().FirstOrDefaultAsync(x => x.Id == id);
            if (linkSection == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Article not found";
                return result;
            }

            linkSection.IsVisible = !linkSection.IsVisible;

            _commandRepository.UpdateAsync(linkSection);
            await _commandRepository.SaveChangesAsync();

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
            var linkSection = await _queryRepository.Table<LinkSection>().FirstOrDefaultAsync(x => x.Id == id);
            if (linkSection == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Link Section not found";
                return result;
            }


            if (_queryRepository.Table<Link>().Any(x => x.LinkSectionId == id))
            {
                result.Status = ResultStatusEnum.IsNotAllowed;
                result.Message = "Is Not Allowed. because this Section is parent of some link";
                return result;
            }

            _commandRepository.DeleteAsync(linkSection);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}