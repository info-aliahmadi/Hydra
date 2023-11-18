using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Email
{
    public class EmailOutbox : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public EmailInbox? ReplayTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ReplayToId { get; set; }

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
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutboxFromAddress> EmailOutboxFromAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutboxToAddress> EmailOutboxToAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutboxAttachment> EmailOutboxAttachments { get; set; } = new();


    }

}
