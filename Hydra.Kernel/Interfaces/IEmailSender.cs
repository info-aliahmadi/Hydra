
using Hydra.Kernel.Models;

namespace Hydra.Kernel.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailRequestRecord requestRecord);
    }
}
