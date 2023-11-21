using Hydra.Kernel;

namespace Hydra.Crm.Core.Models.Email
{
    public record EmailInboxModel
    {

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UID { get; set; }

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
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ReplayedOutboxId { get; set; }

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
        public List<int> Attachments { get; set; } = new();


    }

}
