namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class CreateOrderRequestModel
    {
        public string intent { get; set; }
        public List<PurchaseUnitModel> purchase_units { get; set; } = new();
    }

}
