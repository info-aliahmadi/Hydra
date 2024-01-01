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
    public class ProductPictureService : IProductPictureService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductPictureService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductPictureModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductPictureModel>>();

            var list = await (from productPicture in _queryRepository.Table<ProductPicture>()
                              select new ProductPictureModel()
                              {
                                  Id = productPicture.Id,
                                  PictureId = productPicture.PictureId,
                                  ProductId = productPicture.ProductId,
                                  DisplayOrder = productPicture.DisplayOrder,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductPictureModel>> GetById(int id)
        {
            var result = new Result<ProductPictureModel>();
            var productPicture = await _queryRepository.Table<ProductPicture>().FirstOrDefaultAsync(x => x.Id == id);

            var productPictureModel = new ProductPictureModel()
            {
                Id = productPicture.Id,
                PictureId = productPicture.PictureId,
                ProductId = productPicture.ProductId,
                DisplayOrder = productPicture.DisplayOrder,

            };
            result.Data = productPictureModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productPictureModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductPictureModel>> Add(ProductPictureModel productPictureModel)
        {
            var result = new Result<ProductPictureModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ProductPicture>().AnyAsync(x => x.Id == productPictureModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productPictureModel.Id), "The Id already exist"));
                    return result;
                }
                var productPicture = new ProductPicture()
                {
                    PictureId = productPictureModel.PictureId,
                    ProductId = productPictureModel.ProductId,
                    DisplayOrder = productPictureModel.DisplayOrder,

                };

                await _commandRepository.InsertAsync(productPicture);
                await _commandRepository.SaveChangesAsync();

                productPictureModel.Id = productPicture.Id;

                result.Data = productPictureModel;

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
        /// <param name="productPictureModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductPictureModel>> Update(ProductPictureModel productPictureModel)
        {
            var result = new Result<ProductPictureModel>();
            try
            {
                var productPicture = await _queryRepository.Table<ProductPicture>().FirstAsync(x => x.Id == productPictureModel.Id);
                if (productPicture is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ProductPicture not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ProductPicture>().AnyAsync(x => x.Id != productPictureModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productPictureModel.Id), "The Id already exist"));
                    return result;
                }
                productPicture.PictureId = productPictureModel.PictureId;
                productPicture.ProductId = productPictureModel.ProductId;
                productPicture.DisplayOrder = productPictureModel.DisplayOrder;

                _commandRepository.UpdateAsync(productPicture);
                await _commandRepository.SaveChangesAsync();

                result.Data = productPictureModel;

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
            var productPicture = await _queryRepository.Table<ProductPicture>().FirstOrDefaultAsync(x => x.Id == id);
            if (productPicture is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ProductPicture not found";
                return result;
            }

            _commandRepository.DeleteAsync(productPicture);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}