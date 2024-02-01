using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Hydra.Kernel.Interfaces.Settings
{
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
