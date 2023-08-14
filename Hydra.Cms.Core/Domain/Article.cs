
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Article : BaseEntity<int>
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
        public int? PreviewImageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? PreviewImageUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime PublishDate { get; set; }

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
        public bool IsDraft { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public List<Tag> Tags { get; set; } = new();
        /// <summary>
        /// 
        /// </summary>
        public List<ArticleTag> ArticleTags { get; set; } = new();


        /// <summary>
        /// 
        /// </summary>
        public List<Topic> Topics { get; set; } = new();
        /// <summary>
        /// 
        /// </summary>
        public List<ArticleTopic> ArticleTopics { get; set; } = new();
    }

}
