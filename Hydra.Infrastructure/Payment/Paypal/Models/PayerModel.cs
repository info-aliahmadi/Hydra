namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class PayerModel
    {
        public NameModel name { get; set; }
        public string email_address { get; set; }
        public string payer_id { get; set; }
    }

}
