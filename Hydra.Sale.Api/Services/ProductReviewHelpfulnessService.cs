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
    public class ProductReviewHelpfulnessService : IProductReviewHelpfulnessService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductReviewHelpfulnessService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductReviewHelpfulnessModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductReviewHelpfulnessModel>>();

            var list = await (from productReviewHelpfulness in _queryRepository.Table<ProductReviewHelpfulness>()
                              select new ProductReviewHelpfulnessModel()
                              {
                                  Id = productReviewHelpfulness.Id,
                                  UserId = productReviewHelpfulness.UserId,
                                  ProductReviewId = productReviewHelpfulness.ProductReviewId,
                                  WasHelpful = productReviewHelpfulness.WasHelpful,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductReviewHelpfulnessModel>> GetById(int id)
        {
            var result = new Result<ProductReviewHelpfulnessModel>();
            var productReviewHelpfulness = await _queryRepository.Table<ProductReviewHelpfulness>().FirstOrDefaultAsync(x => x.Id == id);

            var productReviewHelpfulnessModel = new ProductReviewHelpfulnessModel()
            {
                Id = productReviewHelpfulness.Id,
                UserId = productReviewHelpfulness.UserId,
                ProductReviewId = productReviewHelpfulness.ProductReviewId,
                WasHelpful = productReviewHelpfulness.WasHelpful,

            };
            result.Data = productReviewHelpfulnessModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewHelpfulnessModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductReviewHelpfulnessModel>> Add(ProductReviewHelpfulnessModel productReviewHelpfulnessModel)
        {
            var result = new Result<ProductReviewHelpfulnessModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ProductReviewHelpfulness>().AnyAsync(x => x.Id == productReviewHelpfulnessModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productReviewHelpfulnessModel.Id), "The Id already exist"));
                    return result;
                }
                var productReviewHelpfulness = new ProductReviewHelpfulness()
                {
                    UserId = productReviewHelpfulnessModel.UserId,
                    ProductReviewId = productReviewHelpfulnessModel.ProductReviewId,
                    WasHelpful = productReviewHelpfulnessModel.WasHelpful,

                };

                await _commandRepository.InsertAsync(productReviewHelpfulness);
                await _commandRepository.SaveChangesAsync();

                productReviewHelpfulnessModel.Id = productReviewHelpfulness.Id;

                result.Data = productReviewHelpfulnessModel;

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
        /// <param name="productReviewHelpfulnessModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductReviewHelpfulnessModel>> Update(ProductReviewHelpfulnessModel productReviewHelpfulnessModel)
        {
            var result = new Result<ProductReviewHelpfulnessModel>();
            try
            {
                var productReviewHelpfulness = await _queryRepository.Table<ProductReviewHelpfulness>().FirstAsync(x => x.Id == productReviewHelpfulnessModel.Id);
                if (productReviewHelpfulness is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ProductReviewHelpfulness not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ProductReviewHelpfulness>().AnyAsync(x => x.Id != productReviewHelpfulnessModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productReviewHelpfulnessModel.Id), "The Id already exist"));
                    return result;
                }
                productReviewHelpfulness.UserId = productReviewHelpfulnessModel.UserId;
                productReviewHelpfulness.ProductReviewId = productReviewHelpfulnessModel.ProductReviewId;
                productReviewHelpfulness.WasHelpful = productReviewHelpfulnessModel.WasHelpful;

                _commandRepository.UpdateAsync(productReviewHelpfulness);
                await _commandRepository.SaveChangesAsync();

                result.Data = productReviewHelpfulnessModel;

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
            var productReviewHelpfulness = await _queryRepository.Table<ProductReviewHelpfulness>().FirstOrDefaultAsync(x => x.Id == id);
            if (productReviewHelpfulness is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ProductReviewHelpfulness not found";
                return result;
            }

            _commandRepository.DeleteAsync(productReviewHelpfulness);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}