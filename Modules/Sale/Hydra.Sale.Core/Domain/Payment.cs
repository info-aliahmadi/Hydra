using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Payment : BaseEntity<int>
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string TransactionTrackingCode { get; set; }

    public string PaymentTrackingCode { get; set; }

    public DateTime? PaymentDateUtc { get; set; }

    public byte? PaymentTypeId { get; set; }

    public int? Status { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public string CardType { get; set; }

    public string CardName { get; set; }

    public string CardNumber { get; set; }

    public string MaskedCreditCardNumber { get; set; }

    public string CardCvv2 { get; set; }

    public string CardExpirationMonth { get; set; }

    public string CardExpirationYear { get; set; }

    public virtual Order Order { get; set; }
}