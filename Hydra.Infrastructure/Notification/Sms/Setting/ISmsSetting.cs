namespace Hydra.Infrastructure.Notification.Sms.Setting
{
    public interface ISmsSetting
    {
        bool IsEnabled { get; set; }
        string AccountSid { get; set; }
        string AuthToken { get; set; }
        string FromNumber { get; set; }
    }
    public class SmsSetting : ISmsSetting
    {
        public bool IsEnabled { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string FromNumber { get; set; }
    }
}
