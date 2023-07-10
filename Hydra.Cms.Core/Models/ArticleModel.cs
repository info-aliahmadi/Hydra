
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Domain;
using Hydra.Infrastructure.Security.Domain;

namespace Hydra.Cms.Core.Models
{
    public record ArticleModel
    {

        public int Id { get; set; }

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
        public string SmallThumbnail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SmallThumbnailFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LargeThumbnail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LargeThumbnailFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tags { get; set; }

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
        public AuthorModel Writer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int WriterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthorModel? Editor { get; set; }

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
        public List<int> TopicsIds { get; set; } = new List<int>();


    }

}
