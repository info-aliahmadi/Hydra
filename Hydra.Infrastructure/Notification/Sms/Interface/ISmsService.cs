using Hydra.Infrastructure.Notification.Sms.Models;

namespace Hydra.Infrastructure.Notification.Sms.Interface
{
    public interface ISmsService
    {
        bool IsEnabled();
        void Send(SmsMessage smsMessage);
        List<SmsMessage> ReceiveSms();
    }
}
