namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class PaypalFeeModel
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

}
