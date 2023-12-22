
namespace Hydra.Cms.Core.Models
{
    public class SubscribeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SubscribeLabelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubscribeLabeTitle { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertDate { get; set; }
    }
}