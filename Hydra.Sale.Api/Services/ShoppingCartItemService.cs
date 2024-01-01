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
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ShoppingCartItemService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ShoppingCartItemModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ShoppingCartItemModel>>();

            var list = await (from shoppingCartItem in _queryRepository.Table<ShoppingCartItem>()
                              select new ShoppingCartItemModel()
                              {
                                  Id = shoppingCartItem.Id,
                                  UserId = shoppingCartItem.UserId,
                                  ProductId = shoppingCartItem.ProductId,
                                  ShoppingCartTypeId = shoppingCartItem.ShoppingCartTypeId,
                                  Quantity = shoppingCartItem.Quantity,
                                  CreatedOnUtc = shoppingCartItem.CreatedOnUtc,
                                  UpdatedOnUtc = shoppingCartItem.UpdatedOnUtc,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ShoppingCartItemModel>> GetById(int id)
        {
            var result = new Result<ShoppingCartItemModel>();
            var shoppingCartItem = await _queryRepository.Table<ShoppingCartItem>().FirstOrDefaultAsync(x => x.Id == id);

            var shoppingCartItemModel = new ShoppingCartItemModel()
            {
                Id = shoppingCartItem.Id,
                UserId = shoppingCartItem.UserId,
                ProductId = shoppingCartItem.ProductId,
                ShoppingCartTypeId = shoppingCartItem.ShoppingCartTypeId,
                Quantity = shoppingCartItem.Quantity,
                CreatedOnUtc = shoppingCartItem.CreatedOnUtc,
                UpdatedOnUtc = shoppingCartItem.UpdatedOnUtc,

            };
            result.Data = shoppingCartItemModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shoppingCartItemModel"></param>
        /// <returns></returns>
        public async Task<Result<ShoppingCartItemModel>> Add(ShoppingCartItemModel shoppingCartItemModel)
        {
            var result = new Result<ShoppingCartItemModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ShoppingCartItem>().AnyAsync(x => x.Id == shoppingCartItemModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shoppingCartItemModel.Id), "The Id already exist"));
                    return result;
                }
                var shoppingCartItem = new ShoppingCartItem()
                {
                    UserId = shoppingCartItemModel.UserId,
                    ProductId = shoppingCartItemModel.ProductId,
                    ShoppingCartTypeId = shoppingCartItemModel.ShoppingCartTypeId,
                    Quantity = shoppingCartItemModel.Quantity,
                    CreatedOnUtc = shoppingCartItemModel.CreatedOnUtc,
                    UpdatedOnUtc = shoppingCartItemModel.UpdatedOnUtc,

                };

                await _commandRepository.InsertAsync(shoppingCartItem);
                await _commandRepository.SaveChangesAsync();

                shoppingCartItemModel.Id = shoppingCartItem.Id;

                result.Data = shoppingCartItemModel;

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
        /// <param name="shoppingCartItemModel"></param>
        /// <returns></returns>
        public async Task<Result<ShoppingCartItemModel>> Update(ShoppingCartItemModel shoppingCartItemModel)
        {
            var result = new Result<ShoppingCartItemModel>();
            try
            {
                var shoppingCartItem = await _queryRepository.Table<ShoppingCartItem>().FirstAsync(x => x.Id == shoppingCartItemModel.Id);
                if (shoppingCartItem is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ShoppingCartItem not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ShoppingCartItem>().AnyAsync(x => x.Id != shoppingCartItemModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shoppingCartItemModel.Id), "The Id already exist"));
                    return result;
                }
                shoppingCartItem.UserId = shoppingCartItemModel.UserId;
                shoppingCartItem.ProductId = shoppingCartItemModel.ProductId;
                shoppingCartItem.ShoppingCartTypeId = shoppingCartItemModel.ShoppingCartTypeId;
                shoppingCartItem.Quantity = shoppingCartItemModel.Quantity;
                shoppingCartItem.CreatedOnUtc = shoppingCartItemModel.CreatedOnUtc;
                shoppingCartItem.UpdatedOnUtc = shoppingCartItemModel.UpdatedOnUtc;

                _commandRepository.UpdateAsync(shoppingCartItem);
                await _commandRepository.SaveChangesAsync();

                result.Data = shoppingCartItemModel;

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
            var shoppingCartItem = await _queryRepository.Table<ShoppingCartItem>().FirstOrDefaultAsync(x => x.Id == id);
            if (shoppingCartItem is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ShoppingCartItem not found";
                return result;
            }

            _commandRepository.DeleteAsync(shoppingCartItem);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}