using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Discount : BaseEntity<int>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string CouponCode { get; set; }

    public string AdminComment { get; set; }

    public int DiscountTypeId { get; set; }

    public bool UsePercentage { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal? MaximumDiscountAmount { get; set; }

    public DateTime? StartDateUtc { get; set; }

    public DateTime? EndDateUtc { get; set; }

    public bool RequiresCouponCode { get; set; }

    public int DiscountLimitationId { get; set; }

    public int LimitationTimes { get; set; }

    public int? MaximumDiscountedQuantity { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}