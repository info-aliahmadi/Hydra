
namespace Hydra.Cms.Core.Domain
{
    public class ArticleTag 
    {
        /// <summary>
        /// 
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Article Article { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Tag Tag { get; set; } = null!;

    }
}
