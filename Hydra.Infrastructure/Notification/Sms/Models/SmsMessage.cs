using MimeKit;

namespace Hydra.Infrastructure.Notification.Sms.Models
{
    public class SmsMessage
    {
        public SmsMessage()
        {
            ToNumbers = new List<string>();
            AttachmentPaths = new List<string>();
        }

        public string UID { get; set; }
        public List<string> ToNumbers { get; set; }
        public string FromAddress { get; set; }
        public string Text { get; set; }
        public List<string> AttachmentPaths { get; set; }
    }
}
