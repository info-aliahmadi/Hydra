using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Topic : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Topic? Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public List<Article> Articles { get; set; } = new();
        /// <summary>
        /// 
        /// </summary>
        public List<ArticleTopic> ArticleTopics { get; set; } = new();

    }
}
