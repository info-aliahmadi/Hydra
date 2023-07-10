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
        public IList<Article> Articles { get; set; }
    }
}
