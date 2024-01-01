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
    public class CountryService : ICountryService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public CountryService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<CountryModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<CountryModel>>();

            var list = await (from country in _queryRepository.Table<Country>()
                              select new CountryModel()
                              {
                                  Id = country.Id,
                                  Name = country.Name,
                                  TwoLetterIsoCode = country.TwoLetterIsoCode,
                                  ThreeLetterIsoCode = country.ThreeLetterIsoCode,
                                  AllowsBilling = country.AllowsBilling,
                                  AllowsShipping = country.AllowsShipping,
                                  NumericIsoCode = country.NumericIsoCode,
                                  SubjectToVat = country.SubjectToVat,
                                  Published = country.Published,
                                  DisplayOrder = country.DisplayOrder,
                                  LimitedToStores = country.LimitedToStores,
                                  //Addresses = country.Addresses,
                                  //StateProvinces = country.StateProvinces,
                                  //TaxRates = country.TaxRates,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<CountryModel>> GetById(int id)
        {
            var result = new Result<CountryModel>();
            var country = await _queryRepository.Table<Country>().FirstOrDefaultAsync(x => x.Id == id);

            var countryModel = new CountryModel()
            {
                Id = country.Id,
                Name = country.Name,
                TwoLetterIsoCode = country.TwoLetterIsoCode,
                ThreeLetterIsoCode = country.ThreeLetterIsoCode,
                AllowsBilling = country.AllowsBilling,
                AllowsShipping = country.AllowsShipping,
                NumericIsoCode = country.NumericIsoCode,
                SubjectToVat = country.SubjectToVat,
                Published = country.Published,
                DisplayOrder = country.DisplayOrder,
                LimitedToStores = country.LimitedToStores,
                //Addresses = country.Addresses,
                //StateProvinces = country.StateProvinces,
                //TaxRates = country.TaxRates,

            };
            result.Data = countryModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="countryModel"></param>
        /// <returns></returns>
        public async Task<Result<CountryModel>> Add(CountryModel countryModel)
        {
            var result = new Result<CountryModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Country>().AnyAsync(x => x.Id == countryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(countryModel.Id), "The Id already exist"));
                    return result;
                }
                var country = new Country()
                {
                    Name = countryModel.Name,
                    TwoLetterIsoCode = countryModel.TwoLetterIsoCode,
                    ThreeLetterIsoCode = countryModel.ThreeLetterIsoCode,
                    AllowsBilling = countryModel.AllowsBilling,
                    AllowsShipping = countryModel.AllowsShipping,
                    NumericIsoCode = countryModel.NumericIsoCode,
                    SubjectToVat = countryModel.SubjectToVat,
                    Published = countryModel.Published,
                    DisplayOrder = countryModel.DisplayOrder,
                    LimitedToStores = countryModel.LimitedToStores,
                    //Addresses = countryModel.Addresses,
                    //StateProvinces = countryModel.StateProvinces,
                    //TaxRates = countryModel.TaxRates,

                };

                await _commandRepository.InsertAsync(country);
                await _commandRepository.SaveChangesAsync();

                countryModel.Id = country.Id;

                result.Data = countryModel;

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
        /// <param name="countryModel"></param>
        /// <returns></returns>
        public async Task<Result<CountryModel>> Update(CountryModel countryModel)
        {
            var result = new Result<CountryModel>();
            try
            {
                var country = await _queryRepository.Table<Country>().FirstAsync(x => x.Id == countryModel.Id);
                if (country is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Country not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Country>().AnyAsync(x => x.Id != countryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(countryModel.Id), "The Id already exist"));
                    return result;
                }
                country.Name = countryModel.Name;
                country.TwoLetterIsoCode = countryModel.TwoLetterIsoCode;
                country.ThreeLetterIsoCode = countryModel.ThreeLetterIsoCode;
                country.AllowsBilling = countryModel.AllowsBilling;
                country.AllowsShipping = countryModel.AllowsShipping;
                country.NumericIsoCode = countryModel.NumericIsoCode;
                country.SubjectToVat = countryModel.SubjectToVat;
                country.Published = countryModel.Published;
                country.DisplayOrder = countryModel.DisplayOrder;
                country.LimitedToStores = countryModel.LimitedToStores;
                //country.Addresses = countryModel.Addresses;
                //country.StateProvinces = countryModel.StateProvinces;
                //country.TaxRates = countryModel.TaxRates;

                _commandRepository.UpdateAsync(country);
                await _commandRepository.SaveChangesAsync();

                result.Data = countryModel;

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
            var country = await _queryRepository.Table<Country>().FirstOrDefaultAsync(x => x.Id == id);
            if (country is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Country not found";
                return result;
            }

            _commandRepository.DeleteAsync(country);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}