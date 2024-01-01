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
    public class ShipmentService : IShipmentService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ShipmentService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ShipmentModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ShipmentModel>>();

            var list = await (from shipment in _queryRepository.Table<Shipment>()
                              select new ShipmentModel()
                              {
                                  Id = shipment.Id,
                                  OrderId = shipment.OrderId,
                                  TrackingNumber = shipment.TrackingNumber,
                                  TotalWeight = shipment.TotalWeight,
                                  ShippedDateUtc = shipment.ShippedDateUtc,
                                  DeliveryDateUtc = shipment.DeliveryDateUtc,
                                  ReadyForPickupDateUtc = shipment.ReadyForPickupDateUtc,
                                  AdminComment = shipment.AdminComment,
                                  CreatedOnUtc = shipment.CreatedOnUtc,
                                  //ShipmentItems = shipment.ShipmentItems,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ShipmentModel>> GetById(int id)
        {
            var result = new Result<ShipmentModel>();
            var shipment = await _queryRepository.Table<Shipment>().FirstOrDefaultAsync(x => x.Id == id);

            var shipmentModel = new ShipmentModel()
            {
                Id = shipment.Id,
                OrderId = shipment.OrderId,
                TrackingNumber = shipment.TrackingNumber,
                TotalWeight = shipment.TotalWeight,
                ShippedDateUtc = shipment.ShippedDateUtc,
                DeliveryDateUtc = shipment.DeliveryDateUtc,
                ReadyForPickupDateUtc = shipment.ReadyForPickupDateUtc,
                AdminComment = shipment.AdminComment,
                CreatedOnUtc = shipment.CreatedOnUtc,
                //ShipmentItems = shipment.ShipmentItems,

            };
            result.Data = shipmentModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentModel"></param>
        /// <returns></returns>
        public async Task<Result<ShipmentModel>> Add(ShipmentModel shipmentModel)
        {
            var result = new Result<ShipmentModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Shipment>().AnyAsync(x => x.Id == shipmentModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shipmentModel.Id), "The Id already exist"));
                    return result;
                }
                var shipment = new Shipment()
                {
                    OrderId = shipmentModel.OrderId,
                    TrackingNumber = shipmentModel.TrackingNumber,
                    TotalWeight = shipmentModel.TotalWeight,
                    ShippedDateUtc = shipmentModel.ShippedDateUtc,
                    DeliveryDateUtc = shipmentModel.DeliveryDateUtc,
                    ReadyForPickupDateUtc = shipmentModel.ReadyForPickupDateUtc,
                    AdminComment = shipmentModel.AdminComment,
                    CreatedOnUtc = shipmentModel.CreatedOnUtc,
                    //ShipmentItems = shipmentModel.ShipmentItems,

                };

                await _commandRepository.InsertAsync(shipment);
                await _commandRepository.SaveChangesAsync();

                shipmentModel.Id = shipment.Id;

                result.Data = shipmentModel;

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
        /// <param name="shipmentModel"></param>
        /// <returns></returns>
        public async Task<Result<ShipmentModel>> Update(ShipmentModel shipmentModel)
        {
            var result = new Result<ShipmentModel>();
            try
            {
                var shipment = await _queryRepository.Table<Shipment>().FirstAsync(x => x.Id == shipmentModel.Id);
                if (shipment is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Shipment not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Shipment>().AnyAsync(x => x.Id != shipmentModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shipmentModel.Id), "The Id already exist"));
                    return result;
                }
                shipment.OrderId = shipmentModel.OrderId;
                shipment.TrackingNumber = shipmentModel.TrackingNumber;
                shipment.TotalWeight = shipmentModel.TotalWeight;
                shipment.ShippedDateUtc = shipmentModel.ShippedDateUtc;
                shipment.DeliveryDateUtc = shipmentModel.DeliveryDateUtc;
                shipment.ReadyForPickupDateUtc = shipmentModel.ReadyForPickupDateUtc;
                shipment.AdminComment = shipmentModel.AdminComment;
                shipment.CreatedOnUtc = shipmentModel.CreatedOnUtc;
                //shipment.ShipmentItems = shipmentModel.ShipmentItems;

                _commandRepository.UpdateAsync(shipment);
                await _commandRepository.SaveChangesAsync();

                result.Data = shipmentModel;

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
            var shipment = await _queryRepository.Table<Shipment>().FirstOrDefaultAsync(x => x.Id == id);
            if (shipment is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Shipment not found";
                return result;
            }

            _commandRepository.DeleteAsync(shipment);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}