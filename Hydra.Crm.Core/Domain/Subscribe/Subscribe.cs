using Hydra.Kernel;

namespace Hydra.Crm.Core.Domain.Subscribe
{
    public class Subscribe : BaseEntity<long>
    {
        /// <summary>
        /// 
        /// </summary>
        public int SubscribeLabelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual SubscribeLabel SubscribeLabel { get; set; }
    }
}

