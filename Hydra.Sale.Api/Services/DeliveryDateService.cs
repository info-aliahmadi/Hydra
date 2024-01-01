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
    public class DeliveryDateService : IDeliveryDateService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public DeliveryDateService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<DeliveryDateModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<DeliveryDateModel>>();

            var list = await (from deliveryDate in _queryRepository.Table<DeliveryDate>()
                              select new DeliveryDateModel()
                              {
                                  Id = deliveryDate.Id,
                                  Name = deliveryDate.Name,
                                  DisplayOrder = deliveryDate.DisplayOrder,
                                  //Products = deliveryDate.Products,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<DeliveryDateModel>> GetById(int id)
        {
            var result = new Result<DeliveryDateModel>();
            var deliveryDate = await _queryRepository.Table<DeliveryDate>().FirstOrDefaultAsync(x => x.Id == id);

            var deliveryDateModel = new DeliveryDateModel()
            {
                Id = deliveryDate.Id,
                Name = deliveryDate.Name,
                DisplayOrder = deliveryDate.DisplayOrder,
                //Products = deliveryDate.Products,

            };
            result.Data = deliveryDateModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="deliveryDateModel"></param>
        /// <returns></returns>
        public async Task<Result<DeliveryDateModel>> Add(DeliveryDateModel deliveryDateModel)
        {
            var result = new Result<DeliveryDateModel>();
            try
            {
                bool isExist = await _queryRepository.Table<DeliveryDate>().AnyAsync(x => x.Id == deliveryDateModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(deliveryDateModel.Id), "The Id already exist"));
                    return result;
                }
                var deliveryDate = new DeliveryDate()
                {
                    Name = deliveryDateModel.Name,
                    DisplayOrder = deliveryDateModel.DisplayOrder,
                    //Products = deliveryDateModel.Products,

                };

                await _commandRepository.InsertAsync(deliveryDate);
                await _commandRepository.SaveChangesAsync();

                deliveryDateModel.Id = deliveryDate.Id;

                result.Data = deliveryDateModel;

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
        /// <param name="deliveryDateModel"></param>
        /// <returns></returns>
        public async Task<Result<DeliveryDateModel>> Update(DeliveryDateModel deliveryDateModel)
        {
            var result = new Result<DeliveryDateModel>();
            try
            {
                var deliveryDate = await _queryRepository.Table<DeliveryDate>().FirstAsync(x => x.Id == deliveryDateModel.Id);
                if (deliveryDate is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The DeliveryDate not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<DeliveryDate>().AnyAsync(x => x.Id != deliveryDateModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(deliveryDateModel.Id), "The Id already exist"));
                    return result;
                }
                deliveryDate.Name = deliveryDateModel.Name;
                deliveryDate.DisplayOrder = deliveryDateModel.DisplayOrder;
                //deliveryDate.Products = deliveryDateModel.Products;

                _commandRepository.UpdateAsync(deliveryDate);
                await _commandRepository.SaveChangesAsync();

                result.Data = deliveryDateModel;

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
            var deliveryDate = await _queryRepository.Table<DeliveryDate>().FirstOrDefaultAsync(x => x.Id == id);
            if (deliveryDate is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The DeliveryDate not found";
                return result;
            }

            _commandRepository.DeleteAsync(deliveryDate);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}