using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Domain;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Sale.Api.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductReviewService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductReviewModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductReviewModel>>();

            var list = await (from productReview in _queryRepository.Table<ProductReview>()
                              select new ProductReviewModel()
                              {
                                  Id = productReview.Id,
                                  UserId = productReview.UserId,
                                  ProductId = productReview.ProductId,
                                  IsApproved = productReview.IsApproved,
                                  Title = productReview.Title,
                                  ReviewText = productReview.ReviewText,
                                  ReplyText = productReview.ReplyText,
                                  CustomerNotifiedOfReply = productReview.CustomerNotifiedOfReply,
                                  Rating = productReview.Rating,
                                  HelpfulYesTotal = productReview.HelpfulYesTotal,
                                  HelpfulNoTotal = productReview.HelpfulNoTotal,
                                  CreatedOnUtc = productReview.CreatedOnUtc,
                                  //ProductReviewHelpfulnesses = productReview.ProductReviewHelpfulnesses,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductReviewModel>> GetById(int id)
        {
            var result = new Result<ProductReviewModel>();
            var productReview = await _queryRepository.Table<ProductReview>().FirstOrDefaultAsync(x => x.Id == id);

            var productReviewModel = new ProductReviewModel()
            {
                Id = productReview.Id,
                UserId = productReview.UserId,
                ProductId = productReview.ProductId,
                IsApproved = productReview.IsApproved,
                Title = productReview.Title,
                ReviewText = productReview.ReviewText,
                ReplyText = productReview.ReplyText,
                CustomerNotifiedOfReply = productReview.CustomerNotifiedOfReply,
                Rating = productReview.Rating,
                HelpfulYesTotal = productReview.HelpfulYesTotal,
                HelpfulNoTotal = productReview.HelpfulNoTotal,
                CreatedOnUtc = productReview.CreatedOnUtc,
                //ProductReviewHelpfulnesses = productReview.ProductReviewHelpfulnesses,

            };
            result.Data = productReviewModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductReviewModel>> Add(ProductReviewModel productReviewModel)
        {
            var result = new Result<ProductReviewModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ProductReview>().AnyAsync(x => x.Id == productReviewModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productReviewModel.Id), "The Id already exist"));
                    return result;
                }
                var productReview = new ProductReview()
                {
                    UserId = productReviewModel.UserId,
                    ProductId = productReviewModel.ProductId,
                    IsApproved = productReviewModel.IsApproved,
                    Title = productReviewModel.Title,
                    ReviewText = productReviewModel.ReviewText,
                    ReplyText = productReviewModel.ReplyText,
                    CustomerNotifiedOfReply = productReviewModel.CustomerNotifiedOfReply,
                    Rating = productReviewModel.Rating,
                    HelpfulYesTotal = productReviewModel.HelpfulYesTotal,
                    HelpfulNoTotal = productReviewModel.HelpfulNoTotal,
                    CreatedOnUtc = productReviewModel.CreatedOnUtc,
                    //ProductReviewHelpfulnesses = productReviewModel.ProductReviewHelpfulnesses,

                };

                await _commandRepository.InsertAsync(productReview);
                await _commandRepository.SaveChangesAsync();

                productReviewModel.Id = productReview.Id;

                result.Data = productReviewModel;

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
        /// <param name="productReviewModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductReviewModel>> Update(ProductReviewModel productReviewModel)
        {
            var result = new Result<ProductReviewModel>();
            try
            {
                var productReview = await _queryRepository.Table<ProductReview>().FirstAsync(x => x.Id == productReviewModel.Id);
                if (productReview is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ProductReview not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ProductReview>().AnyAsync(x => x.Id != productReviewModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productReviewModel.Id), "The Id already exist"));
                    return result;
                }
                productReview.UserId = productReviewModel.UserId;
                productReview.ProductId = productReviewModel.ProductId;
                productReview.IsApproved = productReviewModel.IsApproved;
                productReview.Title = productReviewModel.Title;
                productReview.ReviewText = productReviewModel.ReviewText;
                productReview.ReplyText = productReviewModel.ReplyText;
                productReview.CustomerNotifiedOfReply = productReviewModel.CustomerNotifiedOfReply;
                productReview.Rating = productReviewModel.Rating;
                productReview.HelpfulYesTotal = productReviewModel.HelpfulYesTotal;
                productReview.HelpfulNoTotal = productReviewModel.HelpfulNoTotal;
                productReview.CreatedOnUtc = productReviewModel.CreatedOnUtc;
                //productReview.ProductReviewHelpfulnesses = productReviewModel.ProductReviewHelpfulnesses;

                _commandRepository.UpdateAsync(productReview);
                await _commandRepository.SaveChangesAsync();

                result.Data = productReviewModel;

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
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var productReview = await _queryRepository.Table<ProductReview>().FirstOrDefaultAsync(x => x.Id == id);
            if (productReview is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ProductReview not found";
                return result;
            }

            _commandRepository.DeleteAsync(productReview);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}