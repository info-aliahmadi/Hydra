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
    public class ProductService : IProductService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public ProductService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ProductModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ProductModel>>();

            var list = await (from product in _queryRepository.Table<Product>()
                              select new ProductModel()
                              {
                                  Id = product.Id,
                                  CreateUserId = product.CreateUserId,
                                  UpdateUserId = product.UpdateUserId,
                                  Name = product.Name,
                                  MetaKeywords = product.MetaKeywords,
                                  MetaTitle = product.MetaTitle,
                                  ShortDescription = product.ShortDescription,
                                  FullDescription = product.FullDescription,
                                  AdminComment = product.AdminComment,
                                  MetaDescription = product.MetaDescription,
                                  DeliveryDateId = product.DeliveryDateId,
                                  TaxCategoryId = product.TaxCategoryId,
                                  StockQuantity = product.StockQuantity,
                                  MinStockQuantity = product.MinStockQuantity,
                                  NotifyAdminForQuantityBelow = product.NotifyAdminForQuantityBelow,
                                  OrderMinimumQuantity = product.OrderMinimumQuantity,
                                  OrderMaximumQuantity = product.OrderMaximumQuantity,
                                  Price = product.Price,
                                  OldPrice = product.OldPrice,
                                  Weight = product.Weight,
                                  Length = product.Length,
                                  Width = product.Width,
                                  Height = product.Height,
                                  AvailableStartDateTimeUtc = product.AvailableStartDateTimeUtc,
                                  AvailableEndDateTimeUtc = product.AvailableEndDateTimeUtc,
                                  DisplayOrder = product.DisplayOrder,
                                  ApprovedRatingSum = product.ApprovedRatingSum,
                                  NotApprovedRatingSum = product.NotApprovedRatingSum,
                                  ApprovedTotalReviews = product.ApprovedTotalReviews,
                                  NotApprovedTotalReviews = product.NotApprovedTotalReviews,
                                  HasDiscountsApplied = product.HasDiscountsApplied,
                                  MarkAsNew = product.MarkAsNew,
                                  MarkAsNewStartDateTimeUtc = product.MarkAsNewStartDateTimeUtc,
                                  MarkAsNewEndDateTimeUtc = product.MarkAsNewEndDateTimeUtc,
                                  NotReturnable = product.NotReturnable,
                                  AllowedQuantities = product.AllowedQuantities,
                                  IsTaxExempt = product.IsTaxExempt,
                                  ShowOnHomepage = product.ShowOnHomepage,
                                  IsFreeShipping = product.IsFreeShipping,
                                  AllowCustomerReviews = product.AllowCustomerReviews,
                                  DisplayStockQuantity = product.DisplayStockQuantity,
                                  DisableBuyButton = product.DisableBuyButton,
                                  DisableWishlistButton = product.DisableWishlistButton,
                                  AvailableForPreOrder = product.AvailableForPreOrder,
                                  CallForPrice = product.CallForPrice,
                                  Published = product.Published,
                                  Deleted = product.Deleted,
                                  CreatedOnUtc = product.CreatedOnUtc,
                                  UpdatedOnUtc = product.UpdatedOnUtc,
                                  //OrderItems = product.OrderItems,
                                  //ProductCategories = product.ProductCategories,
                                  //ProductInventories = product.ProductInventories,
                                  //ProductManufacturers = product.ProductManufacturers,
                                  //ProductPictures = product.ProductPictures,
                                  //ProductReviews = product.ProductReviews,
                                  //RelatedProductProductId1Navigations = product.RelatedProductProductId1Navigations,
                                  //RelatedProductProductId2Navigations = product.RelatedProductProductId2Navigations,
                                  //ShoppingCartItems = product.ShoppingCartItems,
                                  //Discounts = product.Discounts,
                                  //ProductTags = product.ProductTags,

                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ProductModel>> GetById(int id)
        {
            var result = new Result<ProductModel>();
            var product = await _queryRepository.Table<Product>().FirstOrDefaultAsync(x => x.Id == id);

            var productModel = new ProductModel()
            {
                Id = product.Id,
                CreateUserId = product.CreateUserId,
                UpdateUserId = product.UpdateUserId,
                Name = product.Name,
                MetaKeywords = product.MetaKeywords,
                MetaTitle = product.MetaTitle,
                ShortDescription = product.ShortDescription,
                FullDescription = product.FullDescription,
                AdminComment = product.AdminComment,
                MetaDescription = product.MetaDescription,
                DeliveryDateId = product.DeliveryDateId,
                TaxCategoryId = product.TaxCategoryId,
                StockQuantity = product.StockQuantity,
                MinStockQuantity = product.MinStockQuantity,
                NotifyAdminForQuantityBelow = product.NotifyAdminForQuantityBelow,
                OrderMinimumQuantity = product.OrderMinimumQuantity,
                OrderMaximumQuantity = product.OrderMaximumQuantity,
                Price = product.Price,
                OldPrice = product.OldPrice,
                Weight = product.Weight,
                Length = product.Length,
                Width = product.Width,
                Height = product.Height,
                AvailableStartDateTimeUtc = product.AvailableStartDateTimeUtc,
                AvailableEndDateTimeUtc = product.AvailableEndDateTimeUtc,
                DisplayOrder = product.DisplayOrder,
                ApprovedRatingSum = product.ApprovedRatingSum,
                NotApprovedRatingSum = product.NotApprovedRatingSum,
                ApprovedTotalReviews = product.ApprovedTotalReviews,
                NotApprovedTotalReviews = product.NotApprovedTotalReviews,
                HasDiscountsApplied = product.HasDiscountsApplied,
                MarkAsNew = product.MarkAsNew,
                MarkAsNewStartDateTimeUtc = product.MarkAsNewStartDateTimeUtc,
                MarkAsNewEndDateTimeUtc = product.MarkAsNewEndDateTimeUtc,
                NotReturnable = product.NotReturnable,
                AllowedQuantities = product.AllowedQuantities,
                IsTaxExempt = product.IsTaxExempt,
                ShowOnHomepage = product.ShowOnHomepage,
                IsFreeShipping = product.IsFreeShipping,
                AllowCustomerReviews = product.AllowCustomerReviews,
                DisplayStockQuantity = product.DisplayStockQuantity,
                DisableBuyButton = product.DisableBuyButton,
                DisableWishlistButton = product.DisableWishlistButton,
                AvailableForPreOrder = product.AvailableForPreOrder,
                CallForPrice = product.CallForPrice,
                Published = product.Published,
                Deleted = product.Deleted,
                CreatedOnUtc = product.CreatedOnUtc,
                UpdatedOnUtc = product.UpdatedOnUtc,
                //OrderItems = product.OrderItems,
                //ProductCategories = product.ProductCategories,
                //ProductInventories = product.ProductInventories,
                //ProductManufacturers = product.ProductManufacturers,
                //ProductPictures = product.ProductPictures,
                //ProductReviews = product.ProductReviews,
                //RelatedProductProductId1Navigations = product.RelatedProductProductId1Navigations,
                //RelatedProductProductId2Navigations = product.RelatedProductProductId2Navigations,
                //ShoppingCartItems = product.ShoppingCartItems,
                //Discounts = product.Discounts,
                //ProductTags = product.ProductTags,

            };
            result.Data = productModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductModel>> Add(ProductModel productModel)
        {
            var result = new Result<ProductModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Product>().AnyAsync(x => x.Id == productModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productModel.Id), "The Id already exist"));
                    return result;
                }
                var product = new Product()
                {
                    CreateUserId = productModel.CreateUserId,
                    UpdateUserId = productModel.UpdateUserId,
                    Name = productModel.Name,
                    MetaKeywords = productModel.MetaKeywords,
                    MetaTitle = productModel.MetaTitle,
                    ShortDescription = productModel.ShortDescription,
                    FullDescription = productModel.FullDescription,
                    AdminComment = productModel.AdminComment,
                    MetaDescription = productModel.MetaDescription,
                    DeliveryDateId = productModel.DeliveryDateId,
                    TaxCategoryId = productModel.TaxCategoryId,
                    StockQuantity = productModel.StockQuantity,
                    MinStockQuantity = productModel.MinStockQuantity,
                    NotifyAdminForQuantityBelow = productModel.NotifyAdminForQuantityBelow,
                    OrderMinimumQuantity = productModel.OrderMinimumQuantity,
                    OrderMaximumQuantity = productModel.OrderMaximumQuantity,
                    Price = productModel.Price,
                    OldPrice = productModel.OldPrice,
                    Weight = productModel.Weight,
                    Length = productModel.Length,
                    Width = productModel.Width,
                    Height = productModel.Height,
                    AvailableStartDateTimeUtc = productModel.AvailableStartDateTimeUtc,
                    AvailableEndDateTimeUtc = productModel.AvailableEndDateTimeUtc,
                    DisplayOrder = productModel.DisplayOrder,
                    ApprovedRatingSum = productModel.ApprovedRatingSum,
                    NotApprovedRatingSum = productModel.NotApprovedRatingSum,
                    ApprovedTotalReviews = productModel.ApprovedTotalReviews,
                    NotApprovedTotalReviews = productModel.NotApprovedTotalReviews,
                    HasDiscountsApplied = productModel.HasDiscountsApplied,
                    MarkAsNew = productModel.MarkAsNew,
                    MarkAsNewStartDateTimeUtc = productModel.MarkAsNewStartDateTimeUtc,
                    MarkAsNewEndDateTimeUtc = productModel.MarkAsNewEndDateTimeUtc,
                    NotReturnable = productModel.NotReturnable,
                    AllowedQuantities = productModel.AllowedQuantities,
                    IsTaxExempt = productModel.IsTaxExempt,
                    ShowOnHomepage = productModel.ShowOnHomepage,
                    IsFreeShipping = productModel.IsFreeShipping,
                    AllowCustomerReviews = productModel.AllowCustomerReviews,
                    DisplayStockQuantity = productModel.DisplayStockQuantity,
                    DisableBuyButton = productModel.DisableBuyButton,
                    DisableWishlistButton = productModel.DisableWishlistButton,
                    AvailableForPreOrder = productModel.AvailableForPreOrder,
                    CallForPrice = productModel.CallForPrice,
                    Published = productModel.Published,
                    Deleted = productModel.Deleted,
                    CreatedOnUtc = productModel.CreatedOnUtc,
                    UpdatedOnUtc = productModel.UpdatedOnUtc,
                    //OrderItems = productModel.OrderItems,
                    //ProductCategories = productModel.ProductCategories,
                    //ProductInventories = productModel.ProductInventories,
                    //ProductManufacturers = productModel.ProductManufacturers,
                    //ProductPictures = productModel.ProductPictures,
                    //ProductReviews = productModel.ProductReviews,
                    //RelatedProductProductId1Navigations = productModel.RelatedProductProductId1Navigations,
                    //RelatedProductProductId2Navigations = productModel.RelatedProductProductId2Navigations,
                    //ShoppingCartItems = productModel.ShoppingCartItems,
                    //Discounts = productModel.Discounts,
                    //ProductTags = productModel.ProductTags,

                };

                await _commandRepository.InsertAsync(product);
                await _commandRepository.SaveChangesAsync();

                productModel.Id = product.Id;

                result.Data = productModel;

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
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductModel>> Update(ProductModel productModel)
        {
            var result = new Result<ProductModel>();
            try
            {
                var product = await _queryRepository.Table<Product>().FirstAsync(x => x.Id == productModel.Id);
                if (product is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Product not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Product>().AnyAsync(x => x.Id != productModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(productModel.Id), "The Id already exist"));
                    return result;
                }
                product.CreateUserId = productModel.CreateUserId;
                product.UpdateUserId = productModel.UpdateUserId;
                product.Name = productModel.Name;
                product.MetaKeywords = productModel.MetaKeywords;
                product.MetaTitle = productModel.MetaTitle;
                product.ShortDescription = productModel.ShortDescription;
                product.FullDescription = productModel.FullDescription;
                product.AdminComment = productModel.AdminComment;
                product.MetaDescription = productModel.MetaDescription;
                product.DeliveryDateId = productModel.DeliveryDateId;
                product.TaxCategoryId = productModel.TaxCategoryId;
                product.StockQuantity = productModel.StockQuantity;
                product.MinStockQuantity = productModel.MinStockQuantity;
                product.NotifyAdminForQuantityBelow = productModel.NotifyAdminForQuantityBelow;
                product.OrderMinimumQuantity = productModel.OrderMinimumQuantity;
                product.OrderMaximumQuantity = productModel.OrderMaximumQuantity;
                product.Price = productModel.Price;
                product.OldPrice = productModel.OldPrice;
                product.Weight = productModel.Weight;
                product.Length = productModel.Length;
                product.Width = productModel.Width;
                product.Height = productModel.Height;
                product.AvailableStartDateTimeUtc = productModel.AvailableStartDateTimeUtc;
                product.AvailableEndDateTimeUtc = productModel.AvailableEndDateTimeUtc;
                product.DisplayOrder = productModel.DisplayOrder;
                product.ApprovedRatingSum = productModel.ApprovedRatingSum;
                product.NotApprovedRatingSum = productModel.NotApprovedRatingSum;
                product.ApprovedTotalReviews = productModel.ApprovedTotalReviews;
                product.NotApprovedTotalReviews = productModel.NotApprovedTotalReviews;
                product.HasDiscountsApplied = productModel.HasDiscountsApplied;
                product.MarkAsNew = productModel.MarkAsNew;
                product.MarkAsNewStartDateTimeUtc = productModel.MarkAsNewStartDateTimeUtc;
                product.MarkAsNewEndDateTimeUtc = productModel.MarkAsNewEndDateTimeUtc;
                product.NotReturnable = productModel.NotReturnable;
                product.AllowedQuantities = productModel.AllowedQuantities;
                product.IsTaxExempt = productModel.IsTaxExempt;
                product.ShowOnHomepage = productModel.ShowOnHomepage;
                product.IsFreeShipping = productModel.IsFreeShipping;
                product.AllowCustomerReviews = productModel.AllowCustomerReviews;
                product.DisplayStockQuantity = productModel.DisplayStockQuantity;
                product.DisableBuyButton = productModel.DisableBuyButton;
                product.DisableWishlistButton = productModel.DisableWishlistButton;
                product.AvailableForPreOrder = productModel.AvailableForPreOrder;
                product.CallForPrice = productModel.CallForPrice;
                product.Published = productModel.Published;
                product.Deleted = productModel.Deleted;
                product.CreatedOnUtc = productModel.CreatedOnUtc;
                product.UpdatedOnUtc = productModel.UpdatedOnUtc;
                //product.OrderItems = productModel.OrderItems;
                //product.ProductCategories = productModel.ProductCategories;
                //product.ProductInventories = productModel.ProductInventories;
                //product.ProductManufacturers = productModel.ProductManufacturers;
                //product.ProductPictures = productModel.ProductPictures;
                //product.ProductReviews = productModel.ProductReviews;
                //product.RelatedProductProductId1Navigations = productModel.RelatedProductProductId1Navigations;
                //product.RelatedProductProductId2Navigations = productModel.RelatedProductProductId2Navigations;
                //product.ShoppingCartItems = productModel.ShoppingCartItems;
                //product.Discounts = productModel.Discounts;
                //product.ProductTags = productModel.ProductTags;

                _commandRepository.UpdateAsync(product);
                await _commandRepository.SaveChangesAsync();

                result.Data = productModel;

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
            var product = await _queryRepository.Table<Product>().FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Product not found";
                return result;
            }

            _commandRepository.DeleteAsync(product);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}