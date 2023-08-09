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
        public IList<Article> Articles { get; set; }

    }
}
