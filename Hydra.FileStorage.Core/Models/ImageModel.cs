namespace Hydra.FileStorage.Core.Models
{
    public record ImageModel
    {
        /// <summary>
        /// Url of the image
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// file name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Alt { get; set; }

        public string? Tag { get; set; }

    }
}