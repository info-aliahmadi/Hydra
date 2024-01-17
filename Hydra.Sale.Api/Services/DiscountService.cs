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
    public class DiscountService : IDiscountService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public DiscountService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<DiscountModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<DiscountModel>>();

            var list = await (from discount in _queryRepository.Table<Discount>()
                              select new DiscountModel()
                              {
                                  Id = discount.Id,
                                  Name = discount.Name,
                                  CouponCode = discount.CouponCode,
                                  AdminComment = discount.AdminComment,
                                  DiscountTypeId = discount.DiscountTypeId,
                                  UsePercentage = discount.UsePercentage,
                                  DiscountPercentage = discount.DiscountPercentage,
                                  DiscountAmount = discount.DiscountAmount,
                                  MaximumDiscountAmount = discount.MaximumDiscountAmount,
                                  StartDateUtc = discount.StartDateUtc,
                                  EndDateUtc = discount.EndDateUtc,
                                  RequiresCouponCode = discount.RequiresCouponCode,
                                  DiscountLimitationId = discount.DiscountLimitationId,
                                  LimitationTimes = discount.LimitationTimes,
                                  MaximumDiscountedQuantity = discount.MaximumDiscountedQuantity,
                                  IsActive = discount.IsActive,
                                  //OrderDiscounts = discount.OrderDiscounts,
                                  //Categories = discount.Categories,
                                  //Manufacturers = discount.Manufacturers,
                                  //Products = discount.Products,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<List<DiscountModel>>> GetListForSelect()
        {
            var result = new Result<List<DiscountModel>>();

            var list = await (from discount in _queryRepository.Table<Discount>()
                              select new DiscountModel()
                              {
                                  Id = discount.Id,
                                  Name = discount.Name + " | " + discount.CouponCode
                              }).OrderByDescending(x => x.Id).ToListAsync();

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<DiscountModel>> GetById(int id)
        {
            var result = new Result<DiscountModel>();
            var discount = await _queryRepository.Table<Discount>().FirstOrDefaultAsync(x => x.Id == id);

            var discountModel = new DiscountModel()
            {
                Id = discount.Id,
                Name = discount.Name,
                CouponCode = discount.CouponCode,
                AdminComment = discount.AdminComment,
                DiscountTypeId = discount.DiscountTypeId,
                UsePercentage = discount.UsePercentage,
                DiscountPercentage = discount.DiscountPercentage,
                DiscountAmount = discount.DiscountAmount,
                MaximumDiscountAmount = discount.MaximumDiscountAmount,
                StartDateUtc = discount.StartDateUtc,
                EndDateUtc = discount.EndDateUtc,
                RequiresCouponCode = discount.RequiresCouponCode,
                DiscountLimitationId = discount.DiscountLimitationId,
                LimitationTimes = discount.LimitationTimes,
                MaximumDiscountedQuantity = discount.MaximumDiscountedQuantity,
                IsActive = discount.IsActive,
                //OrderDiscounts = discount.OrderDiscounts,
                //Categories = discount.Categories,
                //Manufacturers = discount.Manufacturers,
                //Products = discount.Products,

            };
            result.Data = discountModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="discountModel"></param>
        /// <returns></returns>
        public async Task<Result<DiscountModel>> Add(DiscountModel discountModel)
        {
            var result = new Result<DiscountModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Discount>().AnyAsync(x => x.Id == discountModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(discountModel.Id), "The Id already exist"));
                    return result;
                }
                var discount = new Discount()
                {
                    Name = discountModel.Name,
                    CouponCode = discountModel.CouponCode,
                    AdminComment = discountModel.AdminComment,
                    DiscountTypeId = discountModel.DiscountTypeId,
                    UsePercentage = discountModel.UsePercentage,
                    DiscountPercentage = discountModel.DiscountPercentage,
                    DiscountAmount = discountModel.DiscountAmount,
                    MaximumDiscountAmount = discountModel.MaximumDiscountAmount,
                    StartDateUtc = discountModel.StartDateUtc,
                    EndDateUtc = discountModel.EndDateUtc,
                    RequiresCouponCode = discountModel.RequiresCouponCode,
                    DiscountLimitationId = discountModel.DiscountLimitationId,
                    LimitationTimes = discountModel.LimitationTimes,
                    MaximumDiscountedQuantity = discountModel.MaximumDiscountedQuantity,
                    IsActive = discountModel.IsActive,
                    //OrderDiscounts = discountModel.OrderDiscounts,
                    //Categories = discountModel.Categories,
                    //Manufacturers = discountModel.Manufacturers,
                    //Products = discountModel.Products,

                };

                await _commandRepository.InsertAsync(discount);
                await _commandRepository.SaveChangesAsync();

                discountModel.Id = discount.Id;

                result.Data = discountModel;

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
        /// <param name="discountModel"></param>
        /// <returns></returns>
        public async Task<Result<DiscountModel>> Update(DiscountModel discountModel)
        {
            var result = new Result<DiscountModel>();
            try
            {
                var discount = await _queryRepository.Table<Discount>().FirstAsync(x => x.Id == discountModel.Id);
                if (discount is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Discount not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Discount>().AnyAsync(x => x.Id != discountModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(discountModel.Id), "The Id already exist"));
                    return result;
                }
                discount.Name = discountModel.Name;
                discount.CouponCode = discountModel.CouponCode;
                discount.AdminComment = discountModel.AdminComment;
                discount.DiscountTypeId = discountModel.DiscountTypeId;
                discount.UsePercentage = discountModel.UsePercentage;
                discount.DiscountPercentage = discountModel.DiscountPercentage;
                discount.DiscountAmount = discountModel.DiscountAmount;
                discount.MaximumDiscountAmount = discountModel.MaximumDiscountAmount;
                discount.StartDateUtc = discountModel.StartDateUtc;
                discount.EndDateUtc = discountModel.EndDateUtc;
                discount.RequiresCouponCode = discountModel.RequiresCouponCode;
                discount.DiscountLimitationId = discountModel.DiscountLimitationId;
                discount.LimitationTimes = discountModel.LimitationTimes;
                discount.MaximumDiscountedQuantity = discountModel.MaximumDiscountedQuantity;
                discount.IsActive = discountModel.IsActive;
                //discount.OrderDiscounts = discountModel.OrderDiscounts;
                //discount.Categories = discountModel.Categories;
                //discount.Manufacturers = discountModel.Manufacturers;
                //discount.Products = discountModel.Products;

                _commandRepository.UpdateAsync(discount);
                await _commandRepository.SaveChangesAsync();

                result.Data = discountModel;

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
            var discount = await _queryRepository.Table<Discount>().FirstOrDefaultAsync(x => x.Id == id);
            if (discount is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Discount not found";
                return result;
            }

            _commandRepository.DeleteAsync(discount);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}