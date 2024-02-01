namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class SellerReceivableBreakdownModel
    {
        public AmountModel gross_amount { get; set; }
        public PaypalFeeModel paypal_fee { get; set; }
        public AmountModel net_amount { get; set; }
    }

}
