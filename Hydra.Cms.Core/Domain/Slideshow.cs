
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Slideshow : BaseEntity<int>
    {
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
        public User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

    }

}
