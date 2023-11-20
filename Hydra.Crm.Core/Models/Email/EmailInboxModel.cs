using Hydra.Kernel;

namespace Hydra.Crm.Core.Models.Email
{
    public record EmailInboxModel
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
        public List<EmailInboxFromAddressModel> EmailInboxFromAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailInboxToAddressModel> EmailInboxToAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailInboxAttachmentModel> EmailInboxAttachments { get; set; } = new();


    }

}
