using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Discount : BaseEntity<int>
{
    public string Name { get; set; }

    public string CouponCode { get; set; }

    public string AdminComment { get; set; }

    public DiscountType DiscountTypeId { get; set; }

    public bool UsePercentage { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal? MaximumDiscountAmount { get; set; }

    public DateTime? StartDateUtc { get; set; }

    public DateTime? EndDateUtc { get; set; }

    public bool RequiresCouponCode { get; set; }

    public DiscountLimitationType DiscountLimitationId { get; set; }

    public int LimitationTimes { get; set; }

    public int? MaximumDiscountedQuantity { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
/// <summary>
/// Represents a discount type
/// </summary>
public enum DiscountType
{
    /// <summary>
    /// Assigned to order total 
    /// </summary>
    AssignedToOrderTotal = 1,

    /// <summary>
    /// Assigned to products (SKUs)
    /// </summary>
    AssignedToSkus = 2,

    /// <summary>
    /// Assigned to categories (all products in a category)
    /// </summary>
    AssignedToCategories = 5,

    /// <summary>
    /// Assigned to manufacturers (all products of a manufacturer)
    /// </summary>
    AssignedToManufacturers = 6,

    /// <summary>
    /// Assigned to shipping
    /// </summary>
    AssignedToShipping = 10,

    /// <summary>
    /// Assigned to order subtotal
    /// </summary>
    AssignedToOrderSubTotal = 20
}
/// <summary>
/// Represents a discount limitation type
/// </summary>
public enum DiscountLimitationType
{
    /// <summary>
    /// None
    /// </summary>
    Unlimited = 0,

    /// <summary>
    /// N Times Only
    /// </summary>
    NTimesOnly = 15,

    /// <summary>
    /// N Times Per Customer
    /// </summary>
    NTimesPerCustomer = 25
}