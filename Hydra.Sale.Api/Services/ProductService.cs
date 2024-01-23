using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
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
        private readonly IProductTagService _productTagService;
        public ProductService(IQueryRepository queryRepository, ICommandRepository commandRepository, IProductTagService productTagService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _productTagService = productTagService;
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
            var product = await _queryRepository.Table<Product>()
                .Include(x => x.ProductCategories)
                .Include(x => x.ProductManufacturers)
                .Include(x => x.ProductPictures)
                //.Include(x => x.ProductTags)
                .Include(x => x.RelatedProductProductId1Navigations).FirstOrDefaultAsync(x => x.Id == id);

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
                CategoryIds = product.ProductCategories.Select(cat => cat.CategoryId).ToList(),
                ManufacturerIds = product.ProductManufacturers.Select(cat => cat.ManufacturerId).ToList(),
                PictureIds = product.ProductPictures.Select(cat => cat.PictureId).ToList(),
                RelatedProductIds = product.RelatedProductProductId1Navigations.Select(cat => cat.ProductId1).ToList(),
                //ProductTags = product.ProductTags.Select(cat => cat.Name).ToList()
                //ProductReviews = product.ProductReviews,
                //RelatedProductProductId2Navigations = product.RelatedProductProductId2Navigations,
                //ShoppingCartItems = product.ShoppingCartItems,
                //Discounts = product.Discounts,
                //OrderItems = product.OrderItems,

            };
            result.Data = productModel;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<Result<List<ProductModel>>> GetByIds(int[] ids)
        {
            var result = new Result<List<ProductModel>>();
            if (ids.Length == 0)
                return result;

            var products = await _queryRepository.Table<Product>().Where(x => ids.Contains(x.Id)).Select(x => new ProductModel()
            {
                Id = x.Id,
                Name = x.Id + " | " + x.Name,
                PreviewImageId = x.ProductPictures.OrderBy(v => v.DisplayOrder).FirstOrDefault().PictureId,
            }).ToListAsync();
            result.Data = products;

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<ProductModel>>> GetProductsByInput(string input)
        {
            var result = new Result<List<ProductModel>>();

            var quary = _queryRepository.Table<Product>();

            var id = 0;
            int.TryParse(input, out id);

            quary = quary.Where(x => x.Name.Contains(input) || (id > 0 && x.Id == id));


            var list = await quary.Take(10).Select(x => new ProductModel()
            {
                Id = x.Id,
                Name = x.Id + " | " + x.Name,
                PreviewImageId = x.ProductPictures.OrderBy(v => v.DisplayOrder).FirstOrDefault().PictureId,
            }).ToListAsync();

            result.Data = list;

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
                var currentDateTime = DateTime.UtcNow;
                var product = new Product()
                {
                    CreateUserId = productModel.CreateUserId,
                    UpdateUserId = null,
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
                    Deleted = false,
                    CreatedOnUtc = currentDateTime,
                    UpdatedOnUtc = null
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

                for (int i = 0; i < productModel.CategoryIds.Count; i++)
                {
                    await _commandRepository.InsertAsync(new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = productModel.CategoryIds[i],
                        DisplayOrder = i
                    });
                }

                for (int i = 0; i < productModel.ManufacturerIds.Count; i++)
                {
                    await _commandRepository.InsertAsync(new ProductManufacturer()
                    {
                        ProductId = product.Id,
                        ManufacturerId = productModel.ManufacturerIds[i],
                        DisplayOrder = i
                    });
                }

                for (int i = 0; i < productModel.PictureIds.Count; i++)
                {
                    await _commandRepository.InsertAsync(new ProductPicture()
                    {
                        ProductId = product.Id,
                        PictureId = productModel.PictureIds[i],
                        DisplayOrder = i
                    });
                }

                for (int i = 0; i < productModel.RelatedProductIds.Count; i++)
                {
                    await _commandRepository.InsertAsync(new RelatedProduct()
                    {
                        ProductId1 = product.Id,
                        ProductId2 = productModel.RelatedProductIds[i],
                        DisplayOrder = i
                    });
                }

                await _commandRepository.InsertAsync(new ProductInventory()
                {
                    ProductId = product.Id,
                    StockQuantity = productModel.StockQuantity,
                    ReservedQuantity = 0
                });

                await _commandRepository.SaveChangesAsync();

                //await _productTagService.Add(productModel.ProductTags.ToArray());

                //product.ProductTags = _queryRepository.Table<ProductTag>().Where(x => productModel.ProductTags.Contains(x.Name)).ToList();

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
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task<Result<ProductModel>> Update(ProductModel productModel)
        {
            var result = new Result<ProductModel>();
            try
            {
                var product = await _queryRepository.Table<Product>().AsNoTracking().FirstAsync(x => x.Id == productModel.Id);
                if (product is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Product not found";
                    return result;
                }
                //bool isExist = await _queryRepository.Table<Product>().AnyAsync(x => x.Id != productModel.Id);
                //if (isExist)
                //{
                //    result.Status = ResultStatusEnum.ItsDuplicate;
                //    result.Message = "The Id already exist";
                //    result.Errors.Add(new Error(nameof(productModel.Id), "The Id already exist"));
                //    return result;
                //}

                var currentDateTime = DateTime.UtcNow;

                if (productModel.StockQuantity != product.StockQuantity)
                {
                    var productInventory = await _queryRepository.Table<ProductInventory>().FirstAsync(x => x.ProductId == productModel.Id);
                    productInventory.StockQuantity = productModel.StockQuantity;
                    _commandRepository.UpdateAsync(productInventory);
                }

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
                product.UpdatedOnUtc = currentDateTime;


                _commandRepository.UpdateAsync(product);

                await UpdateProductCategory(product.Id, productModel.CategoryIds.ToArray());

                await UpdateProductManufacturer(product.Id, productModel.ManufacturerIds.ToArray());

                await UpdateProductPicture(product.Id, productModel.PictureIds.ToArray());

                await UpdateRelatedProducts(product.Id, productModel.RelatedProductIds.ToArray());

                await _commandRepository.SaveChangesAsync();

                //var currentTags = product.ProductTags.Select(x => x.Name).ToArray();

                //var newTags = productModel.ProductTags.ToArray();

                //if (!currentTags.SequenceEqual(newTags))
                //{
                //    await _productTagService.Add(newTags);

                //    //change item state to modified

                //    var tagItems = _queryRepository.Table<ProductTag>().Where(x => productModel.ProductTags.Contains(x.Name)).ToList();

                //    foreach (var tag in tagItems)
                //    {
                //        product.ProductTags.(tag);
                //    }
                //    await _commandRepository.SaveChangesAsync();
                //}

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
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        private async Task<Result> UpdateProductCategory(int productId, int[] newCategories)
        {
            var result = new Result();
            try
            {
                var productCategories = _queryRepository.Table<ProductCategory>().Where(x => x.ProductId == productId).ToList();

                var currentCategories = productCategories.Select(x => x.CategoryId).ToArray();

                if (!newCategories.SequenceEqual(currentCategories))
                {
                    foreach (var cat in productCategories)
                    {
                        _commandRepository.DeleteAsync(cat);
                    }
                    foreach (var id in newCategories)
                    {
                        await _commandRepository.InsertAsync(new ProductCategory()
                        {
                            ProductId = productId,
                            CategoryId = id
                        });
                    }

                }
                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        private async Task<Result> UpdateProductManufacturer(int productId, int[] newManufacturers)
        {
            var result = new Result();
            try
            {
                var productManufacturers = _queryRepository.Table<ProductManufacturer>().Where(x => x.ProductId == productId).ToList();

                var currentManufacturers = productManufacturers.Select(x => x.ManufacturerId).ToArray();

                if (!newManufacturers.SequenceEqual(newManufacturers))
                {
                    foreach (var cat in productManufacturers)
                    {
                        _commandRepository.DeleteAsync(cat);
                    }
                    foreach (var id in newManufacturers)
                    {
                        await _commandRepository.InsertAsync(new ProductManufacturer()
                        {
                            ProductId = productId,
                            ManufacturerId = id
                        });
                    }

                }
                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        private async Task<Result> UpdateProductPicture(int productId, int[] newPictures)
        {
            var result = new Result();
            try
            {
                var productPictures = _queryRepository.Table<ProductPicture>().Where(x => x.ProductId == productId).ToList();

                var currentPictures = productPictures.Select(x => x.PictureId).ToArray();

                if (!newPictures.SequenceEqual(currentPictures))
                {
                    foreach (var cat in productPictures)
                    {
                        _commandRepository.DeleteAsync(cat);
                    }
                    foreach (var id in newPictures)
                    {
                        await _commandRepository.InsertAsync(new ProductPicture()
                        {
                            ProductId = productId,
                            PictureId = id
                        });
                    }

                }
                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        private async Task<Result> UpdateRelatedProducts(int productId, int[] newRelateds)
        {
            var result = new Result();
            try
            {
                var productRelateds = _queryRepository.Table<RelatedProduct>().Where(x => x.ProductId1 == productId).ToList();

                var currentRelateds = productRelateds.Select(x => x.ProductId2).ToArray();

                if (!newRelateds.SequenceEqual(currentRelateds))
                {
                    foreach (var cat in productRelateds)
                    {
                        _commandRepository.DeleteAsync(cat);
                    }
                    foreach (var id in newRelateds)
                    {
                        await _commandRepository.InsertAsync(new RelatedProduct()
                        {
                            ProductId1 = productId,
                            ProductId2 = id
                        });
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                result.Status = ResultStatusEnum.ExceptionThrowed;
                result.Message = e.Message;
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
            product.Deleted = true;
            _commandRepository.UpdateAsync(product);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Remove(int id)
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