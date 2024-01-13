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
    public class OrderService : IOrderService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public OrderService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<OrderModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<OrderModel>>();

            var list = await (from order in _queryRepository.Table<Order>()
                    .Include(x => x.User)
                    .Include(x => x.ShippingMethod)
                    .Include(x => x.UserCurrency)
                              select new OrderModel()
                              {
                                  Id = order.Id,
                                  UserId = order.UserId,
                                  UserName = order.User.Name,
                                  ShipmentId = order.ShipmentId,
                                  AddressId = order.AddressId,
                                  ShippingMethodId = order.ShippingMethodId,
                                  ShippingMethodTitle = order.ShippingMethod.Name,
                                  OrderStatusId = order.OrderStatusId,
                                  ShippingStatusId = order.ShippingStatusId,
                                  PaymentStatusId = order.PaymentStatusId,
                                  PaymentMethodId = order.PaymentMethodId,
                                  UserCurrencyId = order.UserCurrencyId,
                                  UserCurrencyTitle = order.UserCurrency.CurrencyCode,
                                  OrderShippingTax = order.OrderShippingTax,
                                  OrderTax = order.OrderTax,
                                  OrderDiscount = order.OrderDiscount,
                                  OrderTotal = order.OrderTotal,
                                  RefundedAmount = order.RefundedAmount,
                                  CustomerIp = order.CustomerIp,
                                  AllowStoringCreditCardNumber = order.AllowStoringCreditCardNumber,
                                  PaidDateUtc = order.PaidDateUtc,
                                  Deleted = order.Deleted,
                                  CreatedOnUtc = order.CreatedOnUtc

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<OrderModel>> GetById(int id)
        {
            var result = new Result<OrderModel>();
            var order = await _queryRepository.Table<Order>().FirstOrDefaultAsync(x => x.Id == id);

            var orderModel = new OrderModel()
            {
                Id = order.Id,
                UserId = order.UserId,
                ShipmentId = order.ShipmentId,
                AddressId = order.AddressId,
                ShippingMethodId = order.ShippingMethodId,
                OrderStatusId = order.OrderStatusId,
                ShippingStatusId = order.ShippingStatusId,
                PaymentStatusId = order.PaymentStatusId,
                PaymentMethodId = order.PaymentMethodId,
                UserCurrencyId = order.UserCurrencyId,
                OrderShippingTax = order.OrderShippingTax,
                OrderTax = order.OrderTax,
                OrderDiscount = order.OrderDiscount,
                OrderTotal = order.OrderTotal,
                RefundedAmount = order.RefundedAmount,
                CustomerIp = order.CustomerIp,
                AllowStoringCreditCardNumber = order.AllowStoringCreditCardNumber,
                PaidDateUtc = order.PaidDateUtc,
                Deleted = order.Deleted,
                CreatedOnUtc = order.CreatedOnUtc,
                //OrderDiscounts = order.OrderDiscounts,
                //OrderItems = order.OrderItems,
                //OrderNotes = order.OrderNotes,
                //Payments = order.Payments,
                //Shipments = order.Shipments,

            };
            result.Data = orderModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderModel>> Add(OrderModel orderModel)
        {
            var result = new Result<OrderModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Order>().AnyAsync(x => x.Id == orderModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderModel.Id), "The Id already exist"));
                    return result;
                }
                var order = new Order()
                {
                    UserId = orderModel.UserId,
                    ShipmentId = orderModel.ShipmentId,
                    AddressId = orderModel.AddressId,
                    ShippingMethodId = orderModel.ShippingMethodId,
                    OrderStatusId = orderModel.OrderStatusId,
                    ShippingStatusId = orderModel.ShippingStatusId,
                    PaymentStatusId = orderModel.PaymentStatusId,
                    PaymentMethodId = orderModel.PaymentMethodId,
                    UserCurrencyId = orderModel.UserCurrencyId,
                    OrderShippingTax = orderModel.OrderShippingTax,
                    OrderTax = orderModel.OrderTax,
                    OrderDiscount = orderModel.OrderDiscount,
                    OrderTotal = orderModel.OrderTotal,
                    RefundedAmount = orderModel.RefundedAmount,
                    CustomerIp = orderModel.CustomerIp,
                    AllowStoringCreditCardNumber = orderModel.AllowStoringCreditCardNumber,
                    PaidDateUtc = orderModel.PaidDateUtc,
                    Deleted = orderModel.Deleted,
                    CreatedOnUtc = orderModel.CreatedOnUtc,
                    //OrderDiscounts = orderModel.OrderDiscounts,
                    //OrderItems = orderModel.OrderItems,
                    //OrderNotes = orderModel.OrderNotes,
                    //Payments = orderModel.Payments,
                    //Shipments = orderModel.Shipments,

                };

                await _commandRepository.InsertAsync(order);
                await _commandRepository.SaveChangesAsync();

                orderModel.Id = order.Id;

                result.Data = orderModel;

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
        /// <param name="orderModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderModel>> Update(OrderModel orderModel)
        {
            var result = new Result<OrderModel>();
            try
            {
                var order = await _queryRepository.Table<Order>().FirstOrDefaultAsync(x => x.Id == orderModel.Id);
                if (order is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Order not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Order>().AnyAsync(x => x.Id != orderModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderModel.Id), "The Id already exist"));
                    return result;
                }
                order.UserId = orderModel.UserId;
                order.ShipmentId = orderModel.ShipmentId;
                order.AddressId = orderModel.AddressId;
                order.ShippingMethodId = orderModel.ShippingMethodId;
                order.OrderStatusId = orderModel.OrderStatusId;
                order.ShippingStatusId = orderModel.ShippingStatusId;
                order.PaymentStatusId = orderModel.PaymentStatusId;
                order.PaymentMethodId = orderModel.PaymentMethodId;
                order.UserCurrencyId = orderModel.UserCurrencyId;
                order.OrderShippingTax = orderModel.OrderShippingTax;
                order.OrderTax = orderModel.OrderTax;
                order.OrderDiscount = orderModel.OrderDiscount;
                order.OrderTotal = orderModel.OrderTotal;
                order.RefundedAmount = orderModel.RefundedAmount;
                order.CustomerIp = orderModel.CustomerIp;
                order.AllowStoringCreditCardNumber = orderModel.AllowStoringCreditCardNumber;
                order.PaidDateUtc = orderModel.PaidDateUtc;
                order.Deleted = orderModel.Deleted;
                order.CreatedOnUtc = orderModel.CreatedOnUtc;
                //order.OrderDiscounts = orderModel.OrderDiscounts;
                //order.OrderItems = orderModel.OrderItems;
                //order.OrderNotes = orderModel.OrderNotes;
                //order.Payments = orderModel.Payments;
                //order.Shipments = orderModel.Shipments;

                _commandRepository.UpdateAsync(order);
                await _commandRepository.SaveChangesAsync();

                result.Data = orderModel;

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
            var order = await _queryRepository.Table<Order>().FirstOrDefaultAsync(x => x.Id == id);
            if (order is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Order not found";
                return result;
            }

            _commandRepository.DeleteAsync(order);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}