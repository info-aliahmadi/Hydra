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
    public class ShippingMethodService : IShippingMethodService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ShippingMethodService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ShippingMethodModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ShippingMethodModel>>();

            var list = await (from shippingMethod in _queryRepository.Table<ShippingMethod>()
                              select new ShippingMethodModel()
                              {
                                  Id = shippingMethod.Id,
                                  Name = shippingMethod.Name,
                                  Description = shippingMethod.Description,
                                  DisplayOrder = shippingMethod.DisplayOrder,
                                  //Orders = shippingMethod.Orders,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ShippingMethodModel>> GetById(int id)
        {
            var result = new Result<ShippingMethodModel>();
            var shippingMethod = await _queryRepository.Table<ShippingMethod>().FirstOrDefaultAsync(x => x.Id == id);

            var shippingMethodModel = new ShippingMethodModel()
            {
                Id = shippingMethod.Id,
                Name = shippingMethod.Name,
                Description = shippingMethod.Description,
                DisplayOrder = shippingMethod.DisplayOrder,
                //Orders = shippingMethod.Orders,

            };
            result.Data = shippingMethodModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="shippingMethodModel"></param>
        /// <returns></returns>
        public async Task<Result<ShippingMethodModel>> Add(ShippingMethodModel shippingMethodModel)
        {
            var result = new Result<ShippingMethodModel>();
            try
            {
                bool isExist = await _queryRepository.Table<ShippingMethod>().AnyAsync(x => x.Id == shippingMethodModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shippingMethodModel.Id), "The Id already exist"));
                    return result;
                }
                var shippingMethod = new ShippingMethod()
                {
                    Name = shippingMethodModel.Name,
                    Description = shippingMethodModel.Description,
                    DisplayOrder = shippingMethodModel.DisplayOrder,
                    //Orders = shippingMethodModel.Orders,

                };

                await _commandRepository.InsertAsync(shippingMethod);
                await _commandRepository.SaveChangesAsync();

                shippingMethodModel.Id = shippingMethod.Id;

                result.Data = shippingMethodModel;

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
        /// <param name="shippingMethodModel"></param>
        /// <returns></returns>
        public async Task<Result<ShippingMethodModel>> Update(ShippingMethodModel shippingMethodModel)
        {
            var result = new Result<ShippingMethodModel>();
            try
            {
                var shippingMethod = await _queryRepository.Table<ShippingMethod>().FirstAsync(x => x.Id == shippingMethodModel.Id);
                if (shippingMethod is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The ShippingMethod not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<ShippingMethod>().AnyAsync(x => x.Id != shippingMethodModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(shippingMethodModel.Id), "The Id already exist"));
                    return result;
                }
                shippingMethod.Name = shippingMethodModel.Name;
                shippingMethod.Description = shippingMethodModel.Description;
                shippingMethod.DisplayOrder = shippingMethodModel.DisplayOrder;
                //shippingMethod.Orders = shippingMethodModel.Orders;

                _commandRepository.UpdateAsync(shippingMethod);
                await _commandRepository.SaveChangesAsync();

                result.Data = shippingMethodModel;

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
            var shippingMethod = await _queryRepository.Table<ShippingMethod>().FirstOrDefaultAsync(x => x.Id == id);
            if (shippingMethod is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The ShippingMethod not found";
                return result;
            }

            _commandRepository.DeleteAsync(shippingMethod);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<ShippingMethodPairModel>>> GetAllShippingMethods()
        {
            return await Task.Run(() =>
            {
                var result = new Result<List<ShippingMethodPairModel>>();

                var paymentStatus = _queryRepository.Table<ShippingMethod>()
                    .Select(x => new ShippingMethodPairModel
                    {
                        Id = x.Id,
                        Title = x.Description
                    }).ToList();

                result.Data = paymentStatus;

                return result;
            });
        }
    }
}