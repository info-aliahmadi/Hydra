
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Page : BaseEntity<int>
    {

        /// <summary>
        /// 
        /// </summary>
        public string PageTitle { get; set; }

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
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User Writer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int WriterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User? Editor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? EditorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Tag> Tags { get; set; } = new();
        /// <summary>
        /// 
        /// </summary>
        public List<PageTag> PageTags { get; set; } = new();


    }

}
