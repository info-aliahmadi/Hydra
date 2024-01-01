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
    public class AddressService : IAddressService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public AddressService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<AddressModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<AddressModel>>();

            var list = await (from address in _queryRepository.Table<Address>()
                              select new AddressModel()
                              {
                                  Id = address.Id,
                                  UserId = address.UserId,
                                  CountryId = address.CountryId,
                                  StateProvinceId = address.StateProvinceId,
                                  City = address.City,
                                  County = address.County,
                                  FirstName = address.FirstName,
                                  LastName = address.LastName,
                                  PhoneNumber = address.PhoneNumber,
                                  Email = address.Email,
                                  Company = address.Company,
                                  Address1 = address.Address1,
                                  Address2 = address.Address2,
                                  ZipPostalCode = address.ZipPostalCode,
                                  FaxNumber = address.FaxNumber,
                                  CreatedOnUtc = address.CreatedOnUtc,
                                  //Orders = address.Orders,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<AddressModel>> GetById(int id)
        {
            var result = new Result<AddressModel>();
            var address = await _queryRepository.Table<Address>().FirstOrDefaultAsync(x => x.Id == id);

            var addressModel = new AddressModel()
            {
                Id = address.Id,
                UserId = address.UserId,
                CountryId = address.CountryId,
                StateProvinceId = address.StateProvinceId,
                City = address.City,
                County = address.County,
                FirstName = address.FirstName,
                LastName = address.LastName,
                PhoneNumber = address.PhoneNumber,
                Email = address.Email,
                Company = address.Company,
                Address1 = address.Address1,
                Address2 = address.Address2,
                ZipPostalCode = address.ZipPostalCode,
                FaxNumber = address.FaxNumber,
                CreatedOnUtc = address.CreatedOnUtc,
                //Orders = address.Orders,

            };
            result.Data = addressModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="addressModel"></param>
        /// <returns></returns>
        public async Task<Result<AddressModel>> Add(AddressModel addressModel)
        {
            var result = new Result<AddressModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Address>().AnyAsync(x => x.Id == addressModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(addressModel.Id), "The Id already exist"));
                    return result;
                }
                var address = new Address()
                {
                    UserId = addressModel.UserId,
                    CountryId = addressModel.CountryId,
                    StateProvinceId = addressModel.StateProvinceId,
                    City = addressModel.City,
                    County = addressModel.County,
                    FirstName = addressModel.FirstName,
                    LastName = addressModel.LastName,
                    PhoneNumber = addressModel.PhoneNumber,
                    Email = addressModel.Email,
                    Company = addressModel.Company,
                    Address1 = addressModel.Address1,
                    Address2 = addressModel.Address2,
                    ZipPostalCode = addressModel.ZipPostalCode,
                    FaxNumber = addressModel.FaxNumber,
                    CreatedOnUtc = addressModel.CreatedOnUtc,
                    //Orders = addressModel.Orders,

                };

                await _commandRepository.InsertAsync(address);
                await _commandRepository.SaveChangesAsync();

                addressModel.Id = address.Id;

                result.Data = addressModel;

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
        /// <param name="addressModel"></param>
        /// <returns></returns>
        public async Task<Result<AddressModel>> Update(AddressModel addressModel)
        {
            var result = new Result<AddressModel>();
            try
            {
                var address = await _queryRepository.Table<Address>().FirstAsync(x => x.Id == addressModel.Id);
                if (address is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Address not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Address>().AnyAsync(x => x.Id != addressModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(addressModel.Id), "The Id already exist"));
                    return result;
                }
                address.UserId = addressModel.UserId;
                address.CountryId = addressModel.CountryId;
                address.StateProvinceId = addressModel.StateProvinceId;
                address.City = addressModel.City;
                address.County = addressModel.County;
                address.FirstName = addressModel.FirstName;
                address.LastName = addressModel.LastName;
                address.PhoneNumber = addressModel.PhoneNumber;
                address.Email = addressModel.Email;
                address.Company = addressModel.Company;
                address.Address1 = addressModel.Address1;
                address.Address2 = addressModel.Address2;
                address.ZipPostalCode = addressModel.ZipPostalCode;
                address.FaxNumber = addressModel.FaxNumber;
                address.CreatedOnUtc = addressModel.CreatedOnUtc;
                //address.Orders = addressModel.Orders;

                _commandRepository.UpdateAsync(address);
                await _commandRepository.SaveChangesAsync();

                result.Data = addressModel;

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
            var address = await _queryRepository.Table<Address>().FirstOrDefaultAsync(x => x.Id == id);
            if (address is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Address not found";
                return result;
            }

            _commandRepository.DeleteAsync(address);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}