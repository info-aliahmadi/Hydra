

namespace Nitro.Core.Interfaces.Settings
{
    public interface ISmtpSetting
    {
        string From { get; set; }
        string DisplayName { get; set; }
        string SmtpServer { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
