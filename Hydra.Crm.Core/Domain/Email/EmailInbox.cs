using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Email
{
    public class EmailInbox : BaseEntity<int>
    {

        /// <summary>
        /// 
        /// </summary>
        public long UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EmailInboxFromAddress> EmailInboxFromAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailInboxToAddress> EmailInboxToAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailInboxAttachment> EmailInboxAttachments { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutbox> EmailOutboxs { get; set; } = new();

    }

}
