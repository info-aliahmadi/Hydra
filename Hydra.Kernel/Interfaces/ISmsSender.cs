
using Hydra.Kernel.Models;

namespace Hydra.Kernel.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(SmsRequestRecord requestRecord);
    }
}
