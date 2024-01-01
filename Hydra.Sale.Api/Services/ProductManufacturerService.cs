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
    public class ProductManufacturerService : IProductManufacturerService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductManufacturerService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductManufacturerModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductManufacturerModel>>();

            var list = await (from productManufacturer in _queryRepository.Table<ProductManufacturer>()
                              select new ProductManufacturerModel()
                              {
                                  Id = productManufacturer.Id,
                                  ManufacturerId = productManufacturer.ManufacturerId,
                                  ProductId = productManufacturer.ProductId,
                                  DisplayOrder = productManufacturer.DisplayOrder,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductManufacturerModel>> GetById(int id)
        {
            var result = new Result<ProductManufacturerModel>();
            var productManufacturer = await _queryRepository.Table<ProductManufacturer>().FirstOrDefaultAsync(x => x.Id == id);

            var productManufacturerModel = new ProductManufacturerModel()
            {
                Id = productManufacturer.Id,
                ManufacturerId = productManufacturer.ManufacturerId,
                ProductId = productManufacturer.ProductId,
                DisplayOrder = productManufacturer.DisplayOrder,

            };
            result.Data = productManufacturerModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productManufacturerModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductManufacturerModel>> Add(ProductManufacturerModel productManufacturerModel)
        {
            var result = new Result<ProductManufacturerModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ProductManufacturer>().AnyAsync(x => x.Id == productManufacturerModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productManufacturerModel.Id), "The Id already exist"));
                    return result;
                }
                var productManufacturer = new ProductManufacturer()
                {
                    ManufacturerId = productManufacturerModel.ManufacturerId,
                    ProductId = productManufacturerModel.ProductId,
                    DisplayOrder = productManufacturerModel.DisplayOrder,

                };

                await _commandRepository.InsertAsync(productManufacturer);
                await _commandRepository.SaveChangesAsync();

                productManufacturerModel.Id = productManufacturer.Id;

                result.Data = productManufacturerModel;

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
        /// <param name="productManufacturerModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductManufacturerModel>> Update(ProductManufacturerModel productManufacturerModel)
        {
            var result = new Result<ProductManufacturerModel>();
            try
            {
                var productManufacturer = await _queryRepository.Table<ProductManufacturer>().FirstAsync(x => x.Id == productManufacturerModel.Id);
                if (productManufacturer is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ProductManufacturer not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ProductManufacturer>().AnyAsync(x => x.Id != productManufacturerModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productManufacturerModel.Id), "The Id already exist"));
                    return result;
                }
                productManufacturer.ManufacturerId = productManufacturerModel.ManufacturerId;
                productManufacturer.ProductId = productManufacturerModel.ProductId;
                productManufacturer.DisplayOrder = productManufacturerModel.DisplayOrder;

                _commandRepository.UpdateAsync(productManufacturer);
                await _commandRepository.SaveChangesAsync();

                result.Data = productManufacturerModel;

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
            var productManufacturer = await _queryRepository.Table<ProductManufacturer>().FirstOrDefaultAsync(x => x.Id == id);
            if (productManufacturer is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ProductManufacturer not found";
                return result;
            }

            _commandRepository.DeleteAsync(productManufacturer);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}