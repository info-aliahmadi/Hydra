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
    public class CurrencyService : ICurrencyService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public CurrencyService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<CurrencyModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<CurrencyModel>>();

            var list = await (from currency in _queryRepository.Table<Currency>()
                              select new CurrencyModel()
                              {
                                  Id = currency.Id,
                                  Name = currency.Name,
                                  CurrencyCode = currency.CurrencyCode,
                                  DisplayLocale = currency.DisplayLocale,
                                  CustomFormatting = currency.CustomFormatting,
                                  Rate = currency.Rate,
                                  LimitedToStores = currency.LimitedToStores,
                                  Published = currency.Published,
                                  DisplayOrder = currency.DisplayOrder,
                                  CreatedOnUtc = currency.CreatedOnUtc,
                                  UpdatedOnUtc = currency.UpdatedOnUtc,
                                  RoundingTypeId = currency.RoundingTypeId,
                                  //Orders = currency.Orders,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<List<CurrencyModel>>> GetAllCurrencies()
        {
            var result = new Result<List<CurrencyModel>>();

            var list = await (from currency in _queryRepository.Table<Currency>()
                              select new CurrencyModel()
                              {
                                  Id = currency.Id,
                                  Name = currency.Name,
                                  CurrencyCode = currency.CurrencyCode
                                  //Orders = currency.Orders,

                              }).OrderByDescending(x => x.Id).ToListAsync();

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<CurrencyModel>> GetById(int id)
        {
            var result = new Result<CurrencyModel>();
            var currency = await _queryRepository.Table<Currency>().FirstOrDefaultAsync(x => x.Id == id);

            var currencyModel = new CurrencyModel()
            {
                Id = currency.Id,
                Name = currency.Name,
                CurrencyCode = currency.CurrencyCode,
                DisplayLocale = currency.DisplayLocale,
                CustomFormatting = currency.CustomFormatting,
                Rate = currency.Rate,
                LimitedToStores = currency.LimitedToStores,
                Published = currency.Published,
                DisplayOrder = currency.DisplayOrder,
                CreatedOnUtc = currency.CreatedOnUtc,
                UpdatedOnUtc = currency.UpdatedOnUtc,
                RoundingTypeId = currency.RoundingTypeId,
                //Orders = currency.Orders,

            };
            result.Data = currencyModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <returns></returns>
        public async Task<Result<CurrencyModel>> Add(CurrencyModel currencyModel)
        {
            var result = new Result<CurrencyModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Currency>().AnyAsync(x => x.Id == currencyModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(currencyModel.Id), "The Id already exist"));
                    return result;
                }
                var currency = new Currency()
                {
                    Name = currencyModel.Name,
                    CurrencyCode = currencyModel.CurrencyCode,
                    DisplayLocale = currencyModel.DisplayLocale,
                    CustomFormatting = currencyModel.CustomFormatting,
                    Rate = currencyModel.Rate,
                    LimitedToStores = currencyModel.LimitedToStores,
                    Published = currencyModel.Published,
                    DisplayOrder = currencyModel.DisplayOrder,
                    CreatedOnUtc = currencyModel.CreatedOnUtc,
                    UpdatedOnUtc = currencyModel.UpdatedOnUtc,
                    RoundingTypeId = currencyModel.RoundingTypeId,
                    //Orders = currencyModel.Orders,

                };

                await _commandRepository.InsertAsync(currency);
                await _commandRepository.SaveChangesAsync();

                currencyModel.Id = currency.Id;

                result.Data = currencyModel;

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
        /// <param name="currencyModel"></param>
        /// <returns></returns>
        public async Task<Result<CurrencyModel>> Update(CurrencyModel currencyModel)
        {
            var result = new Result<CurrencyModel>();
            try
            {
                var currency = await _queryRepository.Table<Currency>().FirstAsync(x => x.Id == currencyModel.Id);
                if (currency is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Currency not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Currency>().AnyAsync(x => x.Id != currencyModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(currencyModel.Id), "The Id already exist"));
                    return result;
                }
                currency.Name = currencyModel.Name;
                currency.CurrencyCode = currencyModel.CurrencyCode;
                currency.DisplayLocale = currencyModel.DisplayLocale;
                currency.CustomFormatting = currencyModel.CustomFormatting;
                currency.Rate = currencyModel.Rate;
                currency.LimitedToStores = currencyModel.LimitedToStores;
                currency.Published = currencyModel.Published;
                currency.DisplayOrder = currencyModel.DisplayOrder;
                currency.CreatedOnUtc = currencyModel.CreatedOnUtc;
                currency.UpdatedOnUtc = currencyModel.UpdatedOnUtc;
                currency.RoundingTypeId = currencyModel.RoundingTypeId;
                //currency.Orders = currencyModel.Orders;

                _commandRepository.UpdateAsync(currency);
                await _commandRepository.SaveChangesAsync();

                result.Data = currencyModel;

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
            var currency = await _queryRepository.Table<Currency>().FirstOrDefaultAsync(x => x.Id == id);
            if (currency is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Currency not found";
                return result;
            }

            _commandRepository.DeleteAsync(currency);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}