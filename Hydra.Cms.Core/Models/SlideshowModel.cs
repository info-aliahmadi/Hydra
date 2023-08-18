
using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Domain;
using Hydra.FileStorage.Core.Models;
using Hydra.Infrastructure.Security.Domain;

namespace Hydra.Cms.Core.Models
{
    public record SlideshowModel
    {

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? PreviewImageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FileUploadModel? PreviewImage { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string? PreviewImageUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthorModel User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }


    }

}
