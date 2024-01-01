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
    public class OrderDiscountService : IOrderDiscountService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public OrderDiscountService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<OrderDiscountModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<OrderDiscountModel>>();

            var list = await (from orderDiscount in _queryRepository.Table<OrderDiscount>()
                              select new OrderDiscountModel()
                              {
                                  Id = orderDiscount.Id,
                                  DiscountId = orderDiscount.DiscountId,
                                  OrderId = orderDiscount.OrderId,
                                  CreatedOnUtc = orderDiscount.CreatedOnUtc,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<OrderDiscountModel>> GetById(int id)
        {
            var result = new Result<OrderDiscountModel>();
            var orderDiscount = await _queryRepository.Table<OrderDiscount>().FirstOrDefaultAsync(x => x.Id == id);

            var orderDiscountModel = new OrderDiscountModel()
            {
                Id = orderDiscount.Id,
                DiscountId = orderDiscount.DiscountId,
                OrderId = orderDiscount.OrderId,
                CreatedOnUtc = orderDiscount.CreatedOnUtc,

            };
            result.Data = orderDiscountModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderDiscountModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderDiscountModel>> Add(OrderDiscountModel orderDiscountModel)
        {
            var result = new Result<OrderDiscountModel>();
            try
            {
                bool isExist = await _queryRepository.Table<OrderDiscount>().AnyAsync(x => x.Id == orderDiscountModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderDiscountModel.Id), "The Id already exist"));
                    return result;
                }
                var orderDiscount = new OrderDiscount()
                {
                    DiscountId = orderDiscountModel.DiscountId,
                    OrderId = orderDiscountModel.OrderId,
                    CreatedOnUtc = orderDiscountModel.CreatedOnUtc,

                };

                await _commandRepository.InsertAsync(orderDiscount);
                await _commandRepository.SaveChangesAsync();

                orderDiscountModel.Id = orderDiscount.Id;

                result.Data = orderDiscountModel;

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
        /// <param name="orderDiscountModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderDiscountModel>> Update(OrderDiscountModel orderDiscountModel)
        {
            var result = new Result<OrderDiscountModel>();
            try
            {
                var orderDiscount = await _queryRepository.Table<OrderDiscount>().FirstAsync(x => x.Id == orderDiscountModel.Id);
                if (orderDiscount is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The OrderDiscount not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<OrderDiscount>().AnyAsync(x => x.Id != orderDiscountModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderDiscountModel.Id), "The Id already exist"));
                    return result;
                }
                orderDiscount.DiscountId = orderDiscountModel.DiscountId;
                orderDiscount.OrderId = orderDiscountModel.OrderId;
                orderDiscount.CreatedOnUtc = orderDiscountModel.CreatedOnUtc;

                _commandRepository.UpdateAsync(orderDiscount);
                await _commandRepository.SaveChangesAsync();

                result.Data = orderDiscountModel;

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
            var orderDiscount = await _queryRepository.Table<OrderDiscount>().FirstOrDefaultAsync(x => x.Id == id);
            if (orderDiscount is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The OrderDiscount not found";
                return result;
            }

            _commandRepository.DeleteAsync(orderDiscount);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}