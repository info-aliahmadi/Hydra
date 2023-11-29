namespace Hydra.Kernel.Interfaces.Settings
{
    public interface ISmtpSetting
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
    }
}
