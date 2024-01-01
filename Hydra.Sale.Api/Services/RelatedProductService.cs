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
    public class RelatedProductService : IRelatedProductService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public RelatedProductService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<RelatedProductModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<RelatedProductModel>>();

            var list = await (from relatedProduct in _queryRepository.Table<RelatedProduct>()
                              select new RelatedProductModel()
                              {
                                  Id = relatedProduct.Id,
                                  ProductId1 = relatedProduct.ProductId1,
                                  ProductId2 = relatedProduct.ProductId2,
                                  DisplayOrder = relatedProduct.DisplayOrder,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<RelatedProductModel>> GetById(int id)
        {
            var result = new Result<RelatedProductModel>();
            var relatedProduct = await _queryRepository.Table<RelatedProduct>().FirstOrDefaultAsync(x => x.Id == id);

            var relatedProductModel = new RelatedProductModel()
            {
                Id = relatedProduct.Id,
                ProductId1 = relatedProduct.ProductId1,
                ProductId2 = relatedProduct.ProductId2,
                DisplayOrder = relatedProduct.DisplayOrder,

            };
            result.Data = relatedProductModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="relatedProductModel"></param>
        /// <returns></returns>
        public async Task<Result<RelatedProductModel>> Add(RelatedProductModel relatedProductModel)
        {
            var result = new Result<RelatedProductModel>();
            try
            {
                bool isExist = await _queryRepository.Table<RelatedProduct>().AnyAsync(x => x.Id == relatedProductModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(relatedProductModel.Id), "The Id already exist"));
                    return result;
                }
                var relatedProduct = new RelatedProduct()
                {
                    ProductId1 = relatedProductModel.ProductId1,
                    ProductId2 = relatedProductModel.ProductId2,
                    DisplayOrder = relatedProductModel.DisplayOrder,

                };

                await _commandRepository.InsertAsync(relatedProduct);
                await _commandRepository.SaveChangesAsync();

                relatedProductModel.Id = relatedProduct.Id;

                result.Data = relatedProductModel;

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
        /// <param name="relatedProductModel"></param>
        /// <returns></returns>
        public async Task<Result<RelatedProductModel>> Update(RelatedProductModel relatedProductModel)
        {
            var result = new Result<RelatedProductModel>();
            try
            {
                var relatedProduct = await _queryRepository.Table<RelatedProduct>().FirstAsync(x => x.Id == relatedProductModel.Id);
                if (relatedProduct is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The RelatedProduct not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<RelatedProduct>().AnyAsync(x => x.Id != relatedProductModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(relatedProductModel.Id), "The Id already exist"));
                    return result;
                }
                relatedProduct.ProductId1 = relatedProductModel.ProductId1;
                relatedProduct.ProductId2 = relatedProductModel.ProductId2;
                relatedProduct.DisplayOrder = relatedProductModel.DisplayOrder;

                _commandRepository.UpdateAsync(relatedProduct);
                await _commandRepository.SaveChangesAsync();

                result.Data = relatedProductModel;

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
            var relatedProduct = await _queryRepository.Table<RelatedProduct>().FirstOrDefaultAsync(x => x.Id == id);
            if (relatedProduct is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The RelatedProduct not found";
                return result;
            }

            _commandRepository.DeleteAsync(relatedProduct);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}