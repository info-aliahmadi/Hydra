using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Email
{
    public class EmailInboxAttachment : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmailInboxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmailInbox EmailInbox { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AttachmentId { get; set; }

    }
}
