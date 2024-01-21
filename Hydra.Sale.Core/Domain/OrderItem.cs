using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class OrderItem : BaseEntity<int>
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int? DiscountId { get; set; }

    public int Quantity { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal TotalPriceTax { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
    public virtual Discount? Discount { get; set; }

    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();
}