
namespace Hydra.Cms.Core.Domain
{
    public class PageTag
    {
        /// <summary>
        /// 
        /// </summary>
        public int PageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Page Page { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Tag Tag { get; set; } = null!;

    }
}
