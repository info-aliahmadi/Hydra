namespace Hydra.FileStorage.Core.Models
{
    public record GalleryResultModel
    {
        /// <summary>
        /// Url of the image
        /// </summary>
        public int statusCode { get; set; }

        /// <summary>
        /// file name
        /// </summary>
        public List<ImageModel> Result { get; set; } = new List<ImageModel>();

    }
}