using Hydra.Infrastructure.Payment.Paypal.Models;

namespace Hydra.Infrastructure.Payment.Paypal.Interface
{
    public interface IPaypalClientService
    {
        Task<AuthResponseModel> Authenticate();
        Task<CaptureOrderResponseModel> CaptureOrder(string orderId);
        Task<CreateOrderResponseModel> CreateOrder(string value, string currency, string reference);
    }
}
