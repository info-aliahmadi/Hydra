using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain
{
    public class ChatUser : BaseEntity<int>
    {

        /// <summary>
        /// 
        /// </summary>
        public User? User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? UserId { get; set; }

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
