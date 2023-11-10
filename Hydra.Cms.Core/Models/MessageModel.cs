
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Domain;
using Hydra.Infrastructure.Security.Domain;

namespace Hydra.Cms.Core.Models
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
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate { get; set; }

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
        public int? ToUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthorModel? ToUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRead { get; set; }

    }

}
