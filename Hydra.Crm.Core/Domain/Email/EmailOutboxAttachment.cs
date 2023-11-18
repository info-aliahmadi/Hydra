using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Email
{
    public class EmailOutboxAttachment : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmailOutboxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmailOutbox EmailOutbox { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AttachmentId { get; set; }

    }
}
