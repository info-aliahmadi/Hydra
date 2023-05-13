


namespace Nitro.Core.Interfaces.Settings
{
    public class SmsSetting : ISmsSetting
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string FromNumber { get; set; }
    }
}
