
namespace Hydra.Cms.Core.Domain
{
    public class ArticleTopic
    {
        /// <summary>
        /// 
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Article Article { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public Topic Topic { get; set; } = null!;

    }
}
