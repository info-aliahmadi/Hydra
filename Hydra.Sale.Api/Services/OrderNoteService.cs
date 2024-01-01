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
    public class OrderNoteService : IOrderNoteService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public OrderNoteService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<OrderNoteModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<OrderNoteModel>>();

            var list = await (from orderNote in _queryRepository.Table<OrderNote>()
                              select new OrderNoteModel()
                              {
                                  Id = orderNote.Id,
                                  Note = orderNote.Note,
                                  UserId = orderNote.UserId,
                                  OrderId = orderNote.OrderId,
                                  IsRead = orderNote.IsRead,
                                  CreatedOnUtc = orderNote.CreatedOnUtc,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<OrderNoteModel>> GetById(int id)
        {
            var result = new Result<OrderNoteModel>();
            var orderNote = await _queryRepository.Table<OrderNote>().FirstOrDefaultAsync(x => x.Id == id);

            var orderNoteModel = new OrderNoteModel()
            {
                Id = orderNote.Id,
                Note = orderNote.Note,
                UserId = orderNote.UserId,
                OrderId = orderNote.OrderId,
                IsRead = orderNote.IsRead,
                CreatedOnUtc = orderNote.CreatedOnUtc,

            };
            result.Data = orderNoteModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderNoteModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderNoteModel>> Add(OrderNoteModel orderNoteModel)
        {
            var result = new Result<OrderNoteModel>();
            try
            {
                bool isExist = await _queryRepository.Table<OrderNote>().AnyAsync(x => x.Id == orderNoteModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderNoteModel.Id), "The Id already exist"));
                    return result;
                }
                var orderNote = new OrderNote()
                {
                    Note = orderNoteModel.Note,
                    UserId = orderNoteModel.UserId,
                    OrderId = orderNoteModel.OrderId,
                    IsRead = orderNoteModel.IsRead,
                    CreatedOnUtc = orderNoteModel.CreatedOnUtc,

                };

                await _commandRepository.InsertAsync(orderNote);
                await _commandRepository.SaveChangesAsync();

                orderNoteModel.Id = orderNote.Id;

                result.Data = orderNoteModel;

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
        /// <param name="orderNoteModel"></param>
        /// <returns></returns>
        public async Task<Result<OrderNoteModel>> Update(OrderNoteModel orderNoteModel)
        {
            var result = new Result<OrderNoteModel>();
            try
            {
                var orderNote = await _queryRepository.Table<OrderNote>().FirstAsync(x => x.Id == orderNoteModel.Id);
                if (orderNote is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The OrderNote not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<OrderNote>().AnyAsync(x => x.Id != orderNoteModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(orderNoteModel.Id), "The Id already exist"));
                    return result;
                }
                orderNote.Note = orderNoteModel.Note;
                orderNote.UserId = orderNoteModel.UserId;
                orderNote.OrderId = orderNoteModel.OrderId;
                orderNote.IsRead = orderNoteModel.IsRead;
                orderNote.CreatedOnUtc = orderNoteModel.CreatedOnUtc;

                _commandRepository.UpdateAsync(orderNote);
                await _commandRepository.SaveChangesAsync();

                result.Data = orderNoteModel;

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
            var orderNote = await _queryRepository.Table<OrderNote>().FirstOrDefaultAsync(x => x.Id == id);
            if (orderNote is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The OrderNote not found";
                return result;
            }

            _commandRepository.DeleteAsync(orderNote);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}