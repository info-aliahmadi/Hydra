using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Message
{
    public class MessageAttachment : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public Message Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MessageId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int AttachmentId { get; set; }


    }

}
