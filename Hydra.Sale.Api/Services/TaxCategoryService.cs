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
    public class TaxCategoryService : ITaxCategoryService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public TaxCategoryService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<List<TaxCategoryModel>>> GetList()
        {
            var result = new Result<List<TaxCategoryModel>>();

            var list = await (from taxCategory in _queryRepository.Table<TaxCategory>()
                              select new TaxCategoryModel()
                              {
                                  Id = taxCategory.Id,
                                  Name = taxCategory.Name,
                                  DisplayOrder = taxCategory.DisplayOrder,
                                  //Products = taxCategory.Products,
                                  //TaxRates = taxCategory.TaxRates,

                              }).OrderByDescending(x => x.Id).ToListAsync();

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<TaxCategoryModel>> GetById(int id)
        {
            var result = new Result<TaxCategoryModel>();
            var taxCategory = await _queryRepository.Table<TaxCategory>().FirstOrDefaultAsync(x => x.Id == id);

            var taxCategoryModel = new TaxCategoryModel()
            {
                Id = taxCategory.Id,
                Name = taxCategory.Name,
                DisplayOrder = taxCategory.DisplayOrder,
                //Products = taxCategory.Products,
                //TaxRates = taxCategory.TaxRates,

            };
            result.Data = taxCategoryModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="taxCategoryModel"></param>
        /// <returns></returns>
        public async Task<Result<TaxCategoryModel>> Add(TaxCategoryModel taxCategoryModel)
        {
            var result = new Result<TaxCategoryModel>();
            try
            {
                bool isExist = await _queryRepository.Table<TaxCategory>().AnyAsync(x => x.Id == taxCategoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(taxCategoryModel.Id), "The Id already exist"));
                    return result;
                }
                var taxCategory = new TaxCategory()
                {
                    Name = taxCategoryModel.Name,
                    DisplayOrder = taxCategoryModel.DisplayOrder,
                    //Products = taxCategoryModel.Products,
                    //TaxRates = taxCategoryModel.TaxRates,

                };

                await _commandRepository.InsertAsync(taxCategory);
                await _commandRepository.SaveChangesAsync();

                taxCategoryModel.Id = taxCategory.Id;

                result.Data = taxCategoryModel;

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
        /// <param name="taxCategoryModel"></param>
        /// <returns></returns>
        public async Task<Result<TaxCategoryModel>> Update(TaxCategoryModel taxCategoryModel)
        {
            var result = new Result<TaxCategoryModel>();
            try
            {
                var taxCategory = await _queryRepository.Table<TaxCategory>().FirstAsync(x => x.Id == taxCategoryModel.Id);
                if (taxCategory is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The TaxCategory not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<TaxCategory>().AnyAsync(x => x.Id != taxCategoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(taxCategoryModel.Id), "The Id already exist"));
                    return result;
                }
                taxCategory.Name = taxCategoryModel.Name;
                taxCategory.DisplayOrder = taxCategoryModel.DisplayOrder;
                //taxCategory.Products = taxCategoryModel.Products;
                //taxCategory.TaxRates = taxCategoryModel.TaxRates;

                _commandRepository.UpdateAsync(taxCategory);
                await _commandRepository.SaveChangesAsync();

                result.Data = taxCategoryModel;

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
            var taxCategory = await _queryRepository.Table<TaxCategory>().FirstOrDefaultAsync(x => x.Id == id);
            if (taxCategory is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The TaxCategory not found";
                return result;
            }

            _commandRepository.DeleteAsync(taxCategory);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}