using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain
{
    public class Chat : BaseEntity<long>
    {

        /// <summary>
        /// 
        /// </summary>
        public ChatSession ChatSession { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ChatSessionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ChatUser ChatUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ChatUserId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRead { get; set; }


    }

}
