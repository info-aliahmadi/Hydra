using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Hydra.Infrastructure.Payment.Paypal.Models;
using System.Text.Json;
using Hydra.Kernel.Interfaces.Settings;

namespace Hydra.Infrastructure.Payment.Paypal.Service
{
    public class PaypalClientService : IPaypalClientService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly PaypalSetting _paypalSetting;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paypalSetting"></param>
        public PaypalClientService(PaypalSetting paypalSetting)
        {
            _paypalSetting = paypalSetting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<AuthResponseModel> Authenticate()
        {
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_paypalSetting.ClientId}:{_paypalSetting.ClientSecret}"));

            var content = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "client_credentials")
            };

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{_paypalSetting.BaseUrl}/v1/oauth2/token"),
                Method = HttpMethod.Post,
                Headers =
                {
                    { "Authorization", $"Basic {auth}" }
                },
                Content = new FormUrlEncodedContent(content)
            };

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.SendAsync(request);
            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<AuthResponseModel>(jsonResponse);

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currency"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<CreateOrderResponseModel> CreateOrder(string value, string currency, string reference)
        {
            var auth = await Authenticate();

            var request = new CreateOrderRequestModel
            {
                intent = "CAPTURE",
                purchase_units = new List<PurchaseUnitModel>
                {
                    new()
                    {
                        reference_id = reference,
                        amount = new AmountModel
                        {
                            currency_code = currency,
                            value = value
                        }
                    }
                }
            };

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {auth.access_token}");

            var httpResponse = await httpClient.PostAsJsonAsync($"{_paypalSetting.BaseUrl}/v2/checkout/orders", request);

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<CreateOrderResponseModel>(jsonResponse);

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CaptureOrderResponseModel> CaptureOrder(string orderId)
        {
            var auth = await Authenticate();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {auth.access_token}");

            var httpContent = new StringContent("", Encoding.Default, "application/json");

            var httpResponse = await httpClient.PostAsync($"{_paypalSetting.BaseUrl}/v2/checkout/orders/{orderId}/capture", httpContent);

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<CaptureOrderResponseModel>(jsonResponse);

            return response;
        }
    }
}
