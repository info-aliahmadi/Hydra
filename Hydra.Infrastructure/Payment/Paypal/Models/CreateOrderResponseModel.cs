namespace Hydra.Infrastructure.Payment.Paypal.Models
{
    public sealed class CreateOrderResponseModel
    {
        public string id { get; set; }
        public string status { get; set; }
        public List<LinkModel> links { get; set; }
    }

}
