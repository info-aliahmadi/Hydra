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
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductInventoryService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductInventoryModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductInventoryModel>>();

            var list = await (from productInventory in _queryRepository.Table<ProductInventory>()
                              select new ProductInventoryModel()
                              {
                                  Id = productInventory.Id,
                                  ProductId = productInventory.ProductId,
                                  StockQuantity = productInventory.StockQuantity,
                                  ReservedQuantity = productInventory.ReservedQuantity,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductInventoryModel>> GetById(int id)
        {
            var result = new Result<ProductInventoryModel>();
            //var productInventory = await _queryRepository.Table<ProductInventory>().FirstOrDefaultAsync(x => x.Id == id);

            //var productInventoryModel = new ProductInventoryModel()
            //{
            //    Id = productInventory.Id,
            //    ProductId = productInventory.ProductId,
            //    StockQuantity = productInventory.StockQuantity,
            //    ReservedQuantity = productInventory.ReservedQuantity,

            //};
            //result.Data = productInventoryModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productInventoryModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductInventoryModel>> Add(ProductInventoryModel productInventoryModel)
        {
            var result = new Result<ProductInventoryModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ProductInventory>().AnyAsync(x => x.Id == productInventoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productInventoryModel.Id), "The Id already exist"));
                    return result;
                }
                var productInventory = new ProductInventory()
                {
                    ProductId = productInventoryModel.ProductId,
                    StockQuantity = productInventoryModel.StockQuantity,
                    ReservedQuantity = productInventoryModel.ReservedQuantity,

                };

                await _commandRepository.InsertAsync(productInventory);
                await _commandRepository.SaveChangesAsync();

                productInventoryModel.Id = productInventory.Id;

                result.Data = productInventoryModel;

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
        /// <param name="productInventoryModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductInventoryModel>> Update(ProductInventoryModel productInventoryModel)
        {
            var result = new Result<ProductInventoryModel>();
            try
            {
                var productInventory = await _queryRepository.Table<ProductInventory>().FirstAsync(x => x.Id == productInventoryModel.Id);
                if (productInventory is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ProductInventory not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ProductInventory>().AnyAsync(x => x.Id != productInventoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productInventoryModel.Id), "The Id already exist"));
                    return result;
                }
                productInventory.ProductId = productInventoryModel.ProductId;
                productInventory.StockQuantity = productInventoryModel.StockQuantity;
                productInventory.ReservedQuantity = productInventoryModel.ReservedQuantity;

                _commandRepository.UpdateAsync(productInventory);
                await _commandRepository.SaveChangesAsync();

                result.Data = productInventoryModel;

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
            var productInventory = await _queryRepository.Table<ProductInventory>().FirstOrDefaultAsync(x => x.Id == id);
            if (productInventory is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ProductInventory not found";
                return result;
            }

            _commandRepository.DeleteAsync(productInventory);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}