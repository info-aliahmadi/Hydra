
using MimeKit;

namespace Hydra.Infrastructure.Email.Models
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
            Attachments = new List<MimeEntity>();
        }

        public uint UID { get; set; }
        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Content { get; set; }
        public List<MimeEntity> Attachments { get; set; }
    }
}
