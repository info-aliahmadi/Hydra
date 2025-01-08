namespace Hydra.Infrastructure.Notification.Email.Setting
{
    public interface IEmailSetting
    {
        bool Enabled { get; set; }
        string SmtpServer { get; set; }
        string SmtpUsername { get; set; }
        int SmtpPort { get; set; }
        string SmtpPassword { get; set; }
        string ImapServer { get; set; }
        int ImapPort { get; set; }
        string ImapUsername { get; set; }
        string ImapPassword { get; set; }
    }
    public class EmailSetting : IEmailSetting
    {
        public bool Enabled { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string ImapServer { get; set; }
        public int ImapPort { get; set; }
        public string ImapUsername { get; set; }
        public string ImapPassword { get; set; }
    }
}
