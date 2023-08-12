using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Tag : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Article> Articles { get; set; } = new();
        /// <summary>
        /// 
        /// </summary>
        public List<ArticleTag> ArticleTags { get; set; } = new();

    }
}
