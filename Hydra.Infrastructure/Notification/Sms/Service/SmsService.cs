using Hydra.Infrastructure.Notification.Sms.Interface;
using Hydra.Infrastructure.Notification.Sms.Models;
using Hydra.Infrastructure.Notification.Sms.Setting;

namespace Hydra.Infrastructure.Notification.Sms.Service
{
    public class SmsService : ISmsService
    {
        private readonly ISmsSetting _smsSetting;

        public SmsService(ISmsSetting smsSetting)
        {
            _smsSetting = smsSetting;
        }

        public bool IsEnabled()
        {
            return _smsSetting.Enabled;
        }

        public List<SmsMessage> ReceiveSms()
        {
            throw new NotImplementedException();
        }

        public void Send(SmsMessage emailMessage)
        {
            throw new NotImplementedException();
        }
    }
}
