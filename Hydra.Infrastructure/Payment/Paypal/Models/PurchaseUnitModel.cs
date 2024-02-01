namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class PurchaseUnitModel
    {
        public AmountModel amount { get; set; }
        public string reference_id { get; set; }
        public ShippingModel shipping { get; set; }
        public PaymentsModel payments { get; set; }
    }

}
