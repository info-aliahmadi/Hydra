namespace Hydra.Kernel.Interfaces.Settings
{
    public class SmtpSetting : ISmtpSetting
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
