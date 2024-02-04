namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class PaypalModel
    {
        public NameModel name { get; set; }
        public string email_address { get; set; }
        public string account_id { get; set; }
    }

}
