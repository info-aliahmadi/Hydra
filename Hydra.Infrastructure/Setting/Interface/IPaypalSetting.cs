namespace Hydra.Infrastructure.Setting.Interface
{
    public interface IPaypalSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public string Mode { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string BaseUrl { get; }
    }
    public class PaypalSetting //: IPaypalSetting
    {
        public PaypalSetting(string mode, string clientId, string clientSecret)
        {
            Mode = mode;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Mode { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string BaseUrl => Mode == "Live"
            ? "https://api-m.paypal.com"
            : "https://api-m.sandbox.paypal.com";
    }
}
