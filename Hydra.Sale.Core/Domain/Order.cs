using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Order : BaseEntity<int>
{
    public int UserId { get; set; }

    public int? ShipmentId { get; set; }

    public int? AddressId { get; set; }

    public int? ShippingMethodId { get; set; }

    public byte OrderStatusId { get; set; }

    public byte ShippingStatusId { get; set; }

    public byte PaymentStatusId { get; set; }

    public byte? PaymentMethodId { get; set; }

    public int? UserCurrencyId { get; set; }

    public decimal OrderShippingTax { get; set; }

    public decimal OrderTax { get; set; }

    public decimal OrderDiscount { get; set; }

    public decimal OrderTotal { get; set; }

    public decimal RefundedAmount { get; set; }

    public string CustomerIp { get; set; }

    public bool AllowStoringCreditCardNumber { get; set; }

    public DateTime? PaidDateUtc { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderNote> OrderNotes { get; set; } = new List<OrderNote>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual ShippingMethod ShippingMethod { get; set; }

    public virtual User User { get; set; }

    public virtual Currency UserCurrency { get; set; }
}