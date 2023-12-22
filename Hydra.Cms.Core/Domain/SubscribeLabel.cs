using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class SubscribeLabel : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Subscribe> Subscribes { get; set; } = new List<Subscribe>();
    }
}