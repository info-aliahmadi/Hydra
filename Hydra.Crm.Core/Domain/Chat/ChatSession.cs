using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Chat
{
    public class ChatSession : BaseEntity<int>
    {

        /// <summary>
        /// 
        /// </summary>
        public User ToUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ToUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GuestName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GuestEmail { get; set; }


    }

}
