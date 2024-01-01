using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class OrderItem : BaseEntity<int>
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPriceTax { get; set; }

    public decimal PriceTax { get; set; }

    public decimal DiscountAmountTax { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }

    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();
}