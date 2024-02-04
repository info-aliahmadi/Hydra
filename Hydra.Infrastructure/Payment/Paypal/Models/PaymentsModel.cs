namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class PaymentsModel
    {
        public List<CaptureModel> captures { get; set; }
    }

}
