using Hydra.Infrastructure.Email.Models;

namespace Hydra.Infrastructure.Email.Service
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail();
    }
}
