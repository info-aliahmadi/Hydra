using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Domain;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Hydra.Sale.Core.Models.Enums;
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
                    .Include(x => x.OrderNotes)
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
                                  UserCurrency = order.UserCurrency.CurrencyCode,
                                  ShippingTax = order.ShippingTax,
                                  ShippingAmount = order.ShippingAmount,
                                  ShippingAmountTax = order.ShippingAmountTax,
                                  TaxAmount = order.TaxAmount,
                                  DiscountAmount = order.DiscountAmount,
                                  TotalAmount = order.TotalAmount,
                                  FinalPrice = order.FinalPrice,
                                  RefundedAmount = order.RefundedAmount,
                                  CustomerIp = order.CustomerIp,
                                  AllowStoringCreditCardNumber = order.AllowStoringCreditCardNumber,
                                  PaidDateUtc = order.PaidDateUtc,
                                  Deleted = order.Deleted,
                                  CreatedOnUtc = order.CreatedOnUtc,
                                  OrderNotes = order.OrderNotes.Select(x => x.Note).ToList()

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
                ShippingTax = order.ShippingTax,
                ShippingAmount = order.ShippingAmount,
                ShippingAmountTax = order.ShippingAmountTax,
                TaxAmount = order.TaxAmount,
                DiscountAmount = order.DiscountAmount,
                TotalAmount = order.TotalAmount,
                FinalPrice = order.FinalPrice,
                RefundedAmount = order.RefundedAmount,
                CustomerIp = order.CustomerIp,
                AllowStoringCreditCardNumber = order.AllowStoringCreditCardNumber,
                PaidDateUtc = order.PaidDateUtc,
                Deleted = order.Deleted,
                CreatedOnUtc = order.CreatedOnUtc
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
                    ShippingTax = orderModel.ShippingTax,
                    ShippingAmount = orderModel.ShippingAmount,
                    ShippingAmountTax = orderModel.ShippingAmountTax,
                    TaxAmount = orderModel.TaxAmount,
                    DiscountAmount = orderModel.DiscountAmount,
                    TotalAmount = orderModel.TotalAmount,
                    FinalPrice = orderModel.FinalPrice,
                    RefundedAmount = orderModel.RefundedAmount,
                    CustomerIp = orderModel.CustomerIp,
                    AllowStoringCreditCardNumber = orderModel.AllowStoringCreditCardNumber,
                    PaidDateUtc = orderModel.PaidDateUtc,
                    Deleted = orderModel.Deleted,
                    CreatedOnUtc = orderModel.CreatedOnUtc,
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
                order.ShippingTax = order.ShippingTax;
                order.ShippingAmount = order.ShippingAmount;
                order.ShippingAmountTax = order.ShippingAmountTax;
                order.TaxAmount = order.TaxAmount;
                order.DiscountAmount = order.DiscountAmount;
                order.TotalAmount = order.TotalAmount;
                order.FinalPrice = order.FinalPrice;
                order.RefundedAmount = orderModel.RefundedAmount;
                order.CustomerIp = orderModel.CustomerIp;
                order.AllowStoringCreditCardNumber = orderModel.AllowStoringCreditCardNumber;
                order.PaidDateUtc = orderModel.PaidDateUtc;
                order.Deleted = orderModel.Deleted;
                order.CreatedOnUtc = orderModel.CreatedOnUtc;

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

        public async Task<Result<List<OrderStatusModel>>> GetAllOrderStatus()
        {
            return await Task.Run(() =>
            {
                var result = new Result<List<OrderStatusModel>>();

                var orderStatus = Enum.GetValues(typeof(OrderStatus)).Cast<Enum>()
                    .Select(x => new OrderStatusModel
                    {
                        Id = Convert.ToInt32(x),
                        Title = x.ToString()
                    }).ToList();

                result.Data = orderStatus;

                return result;
            });
        }        
        
        public async Task<Result<List<ShippingStatusModel>>> GetAllShippingStatus()
        {
            return await Task.Run(() =>
            {
                var result = new Result<List<ShippingStatusModel>>();

                var shippingStatus = Enum.GetValues(typeof(ShippingStatus)).Cast<Enum>()
                    .Select(x => new ShippingStatusModel
                    {
                        Id = Convert.ToInt32(x),
                        Title = x.ToString()
                    }).ToList();

                result.Data = shippingStatus;

                return result;
            });
        }
    }
}