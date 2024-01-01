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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductCategoryService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductCategoryModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductCategoryModel>>();

            var list = await (from productCategory in _queryRepository.Table<ProductCategory>()
                              select new ProductCategoryModel()
                              {
                                  Id = productCategory.Id,
                                  CategoryId = productCategory.CategoryId,
                                  ProductId = productCategory.ProductId,
                                  DisplayOrder = productCategory.DisplayOrder,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductCategoryModel>> GetById(int id)
        {
            var result = new Result<ProductCategoryModel>();
            var productCategory = await _queryRepository.Table<ProductCategory>().FirstOrDefaultAsync(x => x.Id == id);

            var productCategoryModel = new ProductCategoryModel()
            {
                Id = productCategory.Id,
                CategoryId = productCategory.CategoryId,
                ProductId = productCategory.ProductId,
                DisplayOrder = productCategory.DisplayOrder,

            };
            result.Data = productCategoryModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCategoryModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductCategoryModel>> Add(ProductCategoryModel productCategoryModel)
        {
            var result = new Result<ProductCategoryModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ProductCategory>().AnyAsync(x => x.Id == productCategoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productCategoryModel.Id), "The Id already exist"));
                    return result;
                }
                var productCategory = new ProductCategory()
                {
                    CategoryId = productCategoryModel.CategoryId,
                    ProductId = productCategoryModel.ProductId,
                    DisplayOrder = productCategoryModel.DisplayOrder,

                };

                await _commandRepository.InsertAsync(productCategory);
                await _commandRepository.SaveChangesAsync();

                productCategoryModel.Id = productCategory.Id;

                result.Data = productCategoryModel;

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
        /// <param name="productCategoryModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductCategoryModel>> Update(ProductCategoryModel productCategoryModel)
        {
            var result = new Result<ProductCategoryModel>();
            try
            {
                var productCategory = await _queryRepository.Table<ProductCategory>().FirstAsync(x => x.Id == productCategoryModel.Id);
                if (productCategory is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ProductCategory not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ProductCategory>().AnyAsync(x => x.Id != productCategoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productCategoryModel.Id), "The Id already exist"));
                    return result;
                }
                productCategory.CategoryId = productCategoryModel.CategoryId;
                productCategory.ProductId = productCategoryModel.ProductId;
                productCategory.DisplayOrder = productCategoryModel.DisplayOrder;

                _commandRepository.UpdateAsync(productCategory);
                await _commandRepository.SaveChangesAsync();

                result.Data = productCategoryModel;

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
            var productCategory = await _queryRepository.Table<ProductCategory>().FirstOrDefaultAsync(x => x.Id == id);
            if (productCategory is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ProductCategory not found";
                return result;
            }

            _commandRepository.DeleteAsync(productCategory);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}