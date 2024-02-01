namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public class CaptureModel
    {
        public string id { get; set; }
        public string status { get; set; }
        public AmountModel amount { get; set; }
        public SellerProtectionModel seller_protection { get; set; }
        public bool final_capture { get; set; }
        public string disbursement_mode { get; set; }
        public SellerReceivableBreakdownModel seller_receivable_breakdown { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public List<LinkModel> links { get; set; }
    }

}
