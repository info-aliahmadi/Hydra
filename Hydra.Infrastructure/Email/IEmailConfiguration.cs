

namespace Hydra.Infrastructure.Email
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }

        string ImapServer { get; }
        int ImapPort { get; }
        string ImapUsername { get; }
        string ImapPassword { get; }
    }
}
