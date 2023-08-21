
using Hydra.Cms.Core.Domain;
using Hydra.FileStorage.Core.Models;
using Hydra.Infrastructure.Security.Domain;

namespace Hydra.Cms.Core.Models
{
    public record LinkModel 
    {

        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ImagePreviewId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadModel? ImagePreview { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LinkSectionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LinkSectionKey { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Order { get; set; }
    }
}