using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Cms.Api.Services
{
    public class SlideshowService : ISlideshowService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly ITagService _tagService;

        public SlideshowService(IQueryRepository queryRepository, ICommandRepository commandRepository, ITagService tagService)
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
        public async Task<Result<List<SlideshowModel>>> GetList()
        {
            var result = new Result<List<SlideshowModel>>();

            var list = await (from slideshow in _queryRepository.Table<Slideshow>().Include(x => x.User)
                              select new SlideshowModel()
                              {
                                  Id = slideshow.Id,
                                  Header = slideshow.Header,
                                  Description = slideshow.Description,
                                  PreviewImageId = slideshow.PreviewImageId,
                                  PreviewImageUrl = slideshow.PreviewImageUrl,
                                  IsVisible = slideshow.IsVisible,
                                  Order = slideshow.Order,
                                  CreateDate = slideshow.CreateDate,
                                  UserId = slideshow.UserId,
                                  User = new AuthorModel()
                                  {
                                      Id = slideshow.User.Id,
                                      Name = slideshow.User.Name,
                                      UserName = slideshow.User.UserName,
                                      Avatar = slideshow.User.Avatar
                                  }
                              }).OrderByDescending(x => x.IsVisible).ThenByDescending(x => x.Order).ToListAsync();


            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<SlideshowModel>> GetById(int id)
        {
            var result = new Result<SlideshowModel>();
            var slideshow = await _queryRepository.Table<Slideshow>().Include(x => x.User).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var slideshowModel = new SlideshowModel()
            {
                Id = slideshow.Id,
                Header = slideshow.Header,
                Description = slideshow.Description,
                PreviewImageId = slideshow.PreviewImageId,
                PreviewImageUrl = slideshow.PreviewImageUrl,
                IsVisible = slideshow.IsVisible,
                Order = slideshow.Order,
                CreateDate = slideshow.CreateDate,
                UserId = slideshow.UserId,
                User = new AuthorModel()
                {
                    Id = slideshow.User.Id,
                    Name = slideshow.User.Name,
                    UserName = slideshow.User.UserName,
                    Avatar = slideshow.User.Avatar
                }
            };
            result.Data = slideshowModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        public async Task<Result<SlideshowModel>> Add(SlideshowModel slideshowModel)
        {
            var result = new Result<SlideshowModel>();
            try
            {
                var maxOrder = _queryRepository.Table<Slideshow>().OrderByDescending(x => x.Order).FirstOrDefault()?.Order ?? 0;

                var slideshow = new Slideshow()
                {
                    Header = slideshowModel.Header,
                    Description = slideshowModel.Description,
                    PreviewImageId = slideshowModel.PreviewImageId,
                    PreviewImageUrl = slideshowModel.PreviewImageUrl,
                    IsVisible = true,
                    Order = maxOrder + 1,
                    CreateDate = DateTime.UtcNow,
                    UserId = slideshowModel.UserId,
                };

                await _commandRepository.InsertAsync(slideshow);

                await _commandRepository.SaveChangesAsync();

                slideshowModel.Id = slideshow.Id;

                result.Data = slideshowModel;

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
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        public async Task<Result<SlideshowModel>> Update(SlideshowModel slideshowModel)
        {
            var result = new Result<SlideshowModel>();
            try
            {
                var slideshow = await _queryRepository.Table<Slideshow>().AsNoTracking().FirstAsync(x => x.Id == slideshowModel.Id);


                slideshow.Header = slideshowModel.Header;
                slideshow.Description = slideshowModel.Description;
                slideshow.PreviewImageId = slideshowModel.PreviewImageId;
                slideshow.PreviewImageUrl = slideshowModel.PreviewImageUrl;
                slideshow.UserId = slideshowModel.UserId;

                _commandRepository.UpdateAsync(slideshow);
                await _commandRepository.SaveChangesAsync();


                result.Data = slideshowModel;

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
        /// <param name="menuModel"></param>
        /// <returns></returns>
        public async Task<Result<List<SlideshowModel>>> UpdateOrder(List<SlideshowModel> slideshowModelList)
        {
            var result = new Result<List<SlideshowModel>>();


            var visibleModelList = slideshowModelList.Where(x => x.IsVisible);
            var visibleIds = visibleModelList.Select(x => x.Id).ToArray();


            var visibleList = _queryRepository.Table<Slideshow>().Where(x => visibleIds.Contains(x.Id)).ToList();

            foreach (var item in visibleList)
            {
                var model = visibleModelList.First(x => x.Id == item.Id);
                item.Order = model.Order;
                _commandRepository.UpdateAsync(item);
            }

            await _commandRepository.SaveChangesAsync();

            result.Data = slideshowModelList;
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Visible(int id)
        {
            var result = new Result();
            var slideshow = await _queryRepository.Table<Slideshow>().FirstOrDefaultAsync(x => x.Id == id);
            if (slideshow is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Article not found";
                return result;
            }

            slideshow.IsVisible = !slideshow.IsVisible;

            _commandRepository.UpdateAsync(slideshow);
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
            var slideshow = await _queryRepository.Table<Slideshow>().FirstOrDefaultAsync(x => x.Id == id);
            if (slideshow is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Slideshow not found";
                return result;
            }

            _commandRepository.DeleteAsync(slideshow);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}