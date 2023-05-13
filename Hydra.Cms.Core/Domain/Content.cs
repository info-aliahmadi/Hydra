
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Content : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Category> Category { get; set; }

    }

}
