using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Product : BaseEntity<int>
{
    public string Name { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaTitle { get; set; }

    public string? ShortDescription { get; set; }

    public string FullDescription { get; set; }

    public string? AdminComment { get; set; }

    public string? MetaDescription { get; set; }

    public int DeliveryDateId { get; set; }

    public int TaxCategoryId { get; set; }

    public int StockQuantity { get; set; }

    public int MinStockQuantity { get; set; }

    public bool NotifyAdminForQuantityBelow { get; set; }

    public int OrderMinimumQuantity { get; set; }

    public int OrderMaximumQuantity { get; set; }

    public decimal Price { get; set; }
    
    public decimal OldPrice { get; set; }

    public int CurrencyId { get; set; }

    public virtual Currency Currency { get; set; }


    public DateTime? AvailableStartDateTimeUtc { get; set; }

    public DateTime? AvailableEndDateTimeUtc { get; set; }

    public int DisplayOrder { get; set; }

    public int ApprovedRatingSum { get; set; }

    public int NotApprovedRatingSum { get; set; }

    public int ApprovedTotalReviews { get; set; }

    public int NotApprovedTotalReviews { get; set; }

    public bool HasDiscountsApplied { get; set; }

    public bool MarkAsNew { get; set; }

    public DateTime? MarkAsNewStartDateTimeUtc { get; set; }

    public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

    public bool NotReturnable { get; set; }

    public bool AllowedQuantities { get; set; }

    public bool IsTaxExempt { get; set; }

    public bool ShowOnHomepage { get; set; }

    public bool IsFreeShipping { get; set; }

    public bool AllowCustomerReviews { get; set; }

    public bool DisplayStockQuantity { get; set; }

    public bool DisableBuyButton { get; set; }

    public bool DisableWishlistButton { get; set; }

    public bool AvailableForPreOrder { get; set; }

    public bool CallForPrice { get; set; }

    public bool Published { get; set; }

    public bool Deleted { get; set; }

    public int CreateUserId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }

    public virtual DeliveryDate DeliveryDate { get; set; }

    public virtual List<OrderItem> OrderItems { get; set; } = new();

    public virtual List<ProductCategory> ProductCategories { get; set; } = new();

    public virtual List<ProductInventory> ProductInventories { get; set; } = new();

    public virtual List<ProductManufacturer> ProductManufacturers { get; set; } = new();

    public virtual List<ProductPicture> ProductPictures { get; set; } = new();

    public virtual List<ProductReview> ProductReviews { get; set; } = new();

    public virtual List<RelatedProduct> RelatedProductProductId1Navigations { get; set; } = new();

    public virtual List<RelatedProduct> RelatedProductProductId2Navigations { get; set; } = new();

    public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();

    public virtual TaxCategory TaxCategory { get; set; }

    public virtual User CreateUser { get; set; }

    public virtual User? UpdateUser { get; set; }

    public virtual List<Discount> Discounts { get; set; } = new();

    public virtual List<ProductProductTag> ProductProductTags { get; set; } = new();

    public virtual List<ProductProductAttribute> ProductAttributes { get; set; } = new();

}