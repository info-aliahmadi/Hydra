using Hydra.Crm.Core.Domain.Message;
using Hydra.Kernel.Models;
using System.ComponentModel.DataAnnotations;

namespace Hydra.Crm.Core.Models.Message
{
    public record MessageModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Family { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FromUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthorModel? FromUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(100)] 
        public string Knowing { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MaxLength(250)] 
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
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
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageUserModel ToUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<MessageUserModel> ToUsers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> ToUserIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HaveAttachment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> Attachments { get; set; } = new();


    }

}
