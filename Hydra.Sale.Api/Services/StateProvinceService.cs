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
    public class StateProvinceService : IStateProvinceService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public StateProvinceService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<StateProvinceModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<StateProvinceModel>>();

            var list = await (from stateProvince in _queryRepository.Table<StateProvince>()
                              select new StateProvinceModel()
                              {
                                  Id = stateProvince.Id,
                                  Name = stateProvince.Name,
                                  Abbreviation = stateProvince.Abbreviation,
                                  CountryId = stateProvince.CountryId,
                                  Published = stateProvince.Published,
                                  DisplayOrder = stateProvince.DisplayOrder,
                                  //Addresses = stateProvince.Addresses,
                                  //TaxRates = stateProvince.TaxRates,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<StateProvinceModel>> GetById(int id)
        {
            var result = new Result<StateProvinceModel>();
            var stateProvince = await _queryRepository.Table<StateProvince>().FirstOrDefaultAsync(x => x.Id == id);

            var stateProvinceModel = new StateProvinceModel()
            {
                Id = stateProvince.Id,
                Name = stateProvince.Name,
                Abbreviation = stateProvince.Abbreviation,
                CountryId = stateProvince.CountryId,
                Published = stateProvince.Published,
                DisplayOrder = stateProvince.DisplayOrder,
                //Addresses = stateProvince.Addresses,
                //TaxRates = stateProvince.TaxRates,

            };
            result.Data = stateProvinceModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stateProvinceModel"></param>
        /// <returns></returns>
        public async Task<Result<StateProvinceModel>> Add(StateProvinceModel stateProvinceModel)
        {
            var result = new Result<StateProvinceModel>();
            try
            {
                bool isExist = await _queryRepository.Table<StateProvince>().AnyAsync(x => x.Id == stateProvinceModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(stateProvinceModel.Id), "The Id already exist"));
                    return result;
                }
                var stateProvince = new StateProvince()
                {
                    Name = stateProvinceModel.Name,
                    Abbreviation = stateProvinceModel.Abbreviation,
                    CountryId = stateProvinceModel.CountryId,
                    Published = stateProvinceModel.Published,
                    DisplayOrder = stateProvinceModel.DisplayOrder,
                    //Addresses = stateProvinceModel.Addresses,
                    //TaxRates = stateProvinceModel.TaxRates,

                };

                await _commandRepository.InsertAsync(stateProvince);
                await _commandRepository.SaveChangesAsync();

                stateProvinceModel.Id = stateProvince.Id;

                result.Data = stateProvinceModel;

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
        /// <param name="stateProvinceModel"></param>
        /// <returns></returns>
        public async Task<Result<StateProvinceModel>> Update(StateProvinceModel stateProvinceModel)
        {
            var result = new Result<StateProvinceModel>();
            try
            {
                var stateProvince = await _queryRepository.Table<StateProvince>().FirstAsync(x => x.Id == stateProvinceModel.Id);
                if (stateProvince is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The StateProvince not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<StateProvince>().AnyAsync(x => x.Id != stateProvinceModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(stateProvinceModel.Id), "The Id already exist"));
                    return result;
                }
                stateProvince.Name = stateProvinceModel.Name;
                stateProvince.Abbreviation = stateProvinceModel.Abbreviation;
                stateProvince.CountryId = stateProvinceModel.CountryId;
                stateProvince.Published = stateProvinceModel.Published;
                stateProvince.DisplayOrder = stateProvinceModel.DisplayOrder;
                //stateProvince.Addresses = stateProvinceModel.Addresses;
                //stateProvince.TaxRates = stateProvinceModel.TaxRates;

                _commandRepository.UpdateAsync(stateProvince);
                await _commandRepository.SaveChangesAsync();

                result.Data = stateProvinceModel;

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
            var stateProvince = await _queryRepository.Table<StateProvince>().FirstOrDefaultAsync(x => x.Id == id);
            if (stateProvince is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The StateProvince not found";
                return result;
            }

            _commandRepository.DeleteAsync(stateProvince);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}