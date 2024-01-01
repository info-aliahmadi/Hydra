using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ShipmentItem : BaseEntity<int>
{
    public int ShipmentId { get; set; }

    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public virtual OrderItem OrderItem { get; set; }

    public virtual Shipment Shipment { get; set; }
}