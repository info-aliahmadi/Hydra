using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain
{
    public class Message : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageType MessageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Email { get; set; }

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
        public User? FromUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FromUserId { get; set; }

    }

    public enum MessageType
    {
        Private= 0,
        Public = 1,
        Contact = 2,
        Request = 3,
    }
}
