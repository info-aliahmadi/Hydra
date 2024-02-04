using Microsoft.AspNetCore.Http;
using Hydra.Infrastructure.Payment.Paypal.Service;

namespace Hydra.Sale.Api.Handler
{
    public static class PaypalHandler
    {
        public static async Task<IResult> Order(IPaypalClientService paypalClientService)
        {
            try
            {
                // set the transaction price and currency
                var price = "100.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await paypalClientService.CreateOrder(price, currency, reference);

                return Results.Ok(response);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static async Task<IResult> Capture(IPaypalClientService paypalClientService, string orderId)
        {
            try
            {
                var response = await paypalClientService.CaptureOrder(orderId);

                var reference = response.purchase_units[0].reference_id;

                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key

                return Results.Ok(response);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

    }
}
