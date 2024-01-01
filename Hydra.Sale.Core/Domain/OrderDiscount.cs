using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class OrderDiscount : BaseEntity<int>
{
    public int DiscountId { get; set; }

    public int OrderId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Discount Discount { get; set; }

    public virtual Order Order { get; set; }
}