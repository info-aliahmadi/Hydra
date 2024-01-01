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
    public class ShipmentItemService : IShipmentItemService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ShipmentItemService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ShipmentItemModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ShipmentItemModel>>();

            var list = await (from shipmentItem in _queryRepository.Table<ShipmentItem>()
                              select new ShipmentItemModel()
                              {
                                  Id = shipmentItem.Id,
                                  ShipmentId = shipmentItem.ShipmentId,
                                  OrderItemId = shipmentItem.OrderItemId,
                                  Quantity = shipmentItem.Quantity,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ShipmentItemModel>> GetById(int id)
        {
            var result = new Result<ShipmentItemModel>();
            var shipmentItem = await _queryRepository.Table<ShipmentItem>().FirstOrDefaultAsync(x => x.Id == id);

            var shipmentItemModel = new ShipmentItemModel()
            {
                Id = shipmentItem.Id,
                ShipmentId = shipmentItem.ShipmentId,
                OrderItemId = shipmentItem.OrderItemId,
                Quantity = shipmentItem.Quantity,

            };
            result.Data = shipmentItemModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentItemModel"></param>
        /// <returns></returns>
        public async Task<Result<ShipmentItemModel>> Add(ShipmentItemModel shipmentItemModel)
        {
            var result = new Result<ShipmentItemModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ShipmentItem>().AnyAsync(x => x.Id == shipmentItemModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shipmentItemModel.Id), "The Id already exist"));
                    return result;
                }
                var shipmentItem = new ShipmentItem()
                {
                    ShipmentId = shipmentItemModel.ShipmentId,
                    OrderItemId = shipmentItemModel.OrderItemId,
                    Quantity = shipmentItemModel.Quantity,

                };

                await _commandRepository.InsertAsync(shipmentItem);
                await _commandRepository.SaveChangesAsync();

                shipmentItemModel.Id = shipmentItem.Id;

                result.Data = shipmentItemModel;

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
        /// <param name="shipmentItemModel"></param>
        /// <returns></returns>
        public async Task<Result<ShipmentItemModel>> Update(ShipmentItemModel shipmentItemModel)
        {
            var result = new Result<ShipmentItemModel>();
            try
            {
                var shipmentItem = await _queryRepository.Table<ShipmentItem>().FirstAsync(x => x.Id == shipmentItemModel.Id);
                if (shipmentItem is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ShipmentItem not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ShipmentItem>().AnyAsync(x => x.Id != shipmentItemModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shipmentItemModel.Id), "The Id already exist"));
                    return result;
                }
                shipmentItem.ShipmentId = shipmentItemModel.ShipmentId;
                shipmentItem.OrderItemId = shipmentItemModel.OrderItemId;
                shipmentItem.Quantity = shipmentItemModel.Quantity;

                _commandRepository.UpdateAsync(shipmentItem);
                await _commandRepository.SaveChangesAsync();

                result.Data = shipmentItemModel;

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
            var shipmentItem = await _queryRepository.Table<ShipmentItem>().FirstOrDefaultAsync(x => x.Id == id);
            if (shipmentItem is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ShipmentItem not found";
                return result;
            }

            _commandRepository.DeleteAsync(shipmentItem);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}