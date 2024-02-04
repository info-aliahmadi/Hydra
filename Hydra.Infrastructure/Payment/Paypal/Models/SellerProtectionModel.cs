namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class SellerProtectionModel
    {
        public string status { get; set; }
        public List<string> dispute_categories { get; set; }
    }

}
