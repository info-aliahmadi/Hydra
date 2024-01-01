using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Shipment : BaseEntity<int>
{
    public int OrderId { get; set; }

    public string TrackingNumber { get; set; }

    public decimal? TotalWeight { get; set; }

    public DateTime? ShippedDateUtc { get; set; }

    public DateTime? DeliveryDateUtc { get; set; }

    public DateTime? ReadyForPickupDateUtc { get; set; }

    public string AdminComment { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Order Order { get; set; }

    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();
}