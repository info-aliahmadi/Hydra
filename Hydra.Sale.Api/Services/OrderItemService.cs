using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Domain;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Sale.Api.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public OrderItemService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Result<List<OrderItemModel>>> GetListByOrderId(int orderId)
        {
            var result = new Result<List<OrderItemModel>>();
            var list = await (from orderItem in _queryRepository.Table<OrderItem>()
                              .Include(x => x.Product)
                              where orderItem.OrderId == orderId
                              select new OrderItemModel()
                              {
                                  Id = orderItem.Id,
                                  OrderId = orderItem.OrderId,
                                  ProductId = orderItem.ProductId,
                                  ProductName = orderItem.Product.Name,
                                  Quantity = orderItem.Quantity,
                                  UnitPriceTax = orderItem.UnitPriceTax,
                                  PriceTax = orderItem.PriceTax,
                                  DiscountAmountTax = orderItem.DiscountAmountTax,
                                  UnitPrice = orderItem.UnitPrice,
                              }).OrderByDescending(x => x.Id).ToListAsync();

            result.Data = list;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<OrderItemModel>> GetById(int id)
        {
            var result = new Result<OrderItemModel>();
            var orderItem = await _queryRepository.Table<OrderItem>().FirstOrDefaultAsync(x => x.Id == id);

            var orderItemModel = new OrderItemModel()
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                UnitPriceTax = orderItem.UnitPriceTax,
                PriceTax = orderItem.PriceTax,
                DiscountAmountTax = orderItem.DiscountAmountTax,
                UnitPrice = orderItem.UnitPrice,
                //ShipmentItems = orderItem.ShipmentItems,

            };
            result.Data = orderItemModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderItemModel>> Add(OrderItemModel orderItemModel)
        {
            var result = new Result<OrderItemModel>();
            try
            {
                bool isExist = await _queryRepository.Table<OrderItem>().AnyAsync(x => x.Id == orderItemModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderItemModel.Id), "The Id already exist"));
                    return result;
                }
                var orderItem = new OrderItem()
                {
                    OrderId = orderItemModel.OrderId,
                    ProductId = orderItemModel.ProductId,
                    Quantity = orderItemModel.Quantity,
                    UnitPriceTax = orderItemModel.UnitPriceTax,
                    PriceTax = orderItemModel.PriceTax,
                    DiscountAmountTax = orderItemModel.DiscountAmountTax,
                    UnitPrice = orderItemModel.UnitPrice,
                    //ShipmentItems = orderItemModel.ShipmentItems,

                };

                await _commandRepository.InsertAsync(orderItem);
                await _commandRepository.SaveChangesAsync();

                orderItemModel.Id = orderItem.Id;

                result.Data = orderItemModel;

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
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderItemModel>> Update(OrderItemModel orderItemModel)
        {
            var result = new Result<OrderItemModel>();
            try
            {
                var orderItem = await _queryRepository.Table<OrderItem>().FirstAsync(x => x.Id == orderItemModel.Id);
                if (orderItem is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The OrderItem not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<OrderItem>().AnyAsync(x => x.Id != orderItemModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderItemModel.Id), "The Id already exist"));
                    return result;
                }
                orderItem.OrderId = orderItemModel.OrderId;
                orderItem.ProductId = orderItemModel.ProductId;
                orderItem.Quantity = orderItemModel.Quantity;
                orderItem.UnitPriceTax = orderItemModel.UnitPriceTax;
                orderItem.PriceTax = orderItemModel.PriceTax;
                orderItem.DiscountAmountTax = orderItemModel.DiscountAmountTax;
                orderItem.UnitPrice = orderItemModel.UnitPrice;
                //orderItem.ShipmentItems = orderItemModel.ShipmentItems;

                _commandRepository.UpdateAsync(orderItem);
                await _commandRepository.SaveChangesAsync();

                result.Data = orderItemModel;

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
            var orderItem = await _queryRepository.Table<OrderItem>().FirstOrDefaultAsync(x => x.Id == id);
            if (orderItem is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The OrderItem not found";
                return result;
            }

            _commandRepository.DeleteAsync(orderItem);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}