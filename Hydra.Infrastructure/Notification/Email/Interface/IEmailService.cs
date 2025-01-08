using Hydra.Infrastructure.Notification.Email.Models;

namespace Hydra.Infrastructure.Notification.Email.Interface
{
    public interface IEmailService
    {
        bool IsEnabled();
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail();
    }
}
