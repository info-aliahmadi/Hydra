namespace Hydra.Infrastructure.Setting
{
    public class UploadFileSetting : IUploadFileSetting
    {
        public bool AllowDuplicateFile { get; set; }
        public string WhiteListExtensions { get; set; } = null!;
        public string SignatureValidationExtensions { get; set; } = null!;

        public long MaxSizeLimitSmallFile { get; set; }

        public long MinSizeLimitSmallFile { get; set; }

        public long MaxSizeLimitLargeFile { get; set; }

        public long MinSizeLimitLargeFile { get; set; }

        public string ImagesExtensions { get; set; }
        public int ImageThumbnailSize { get; set; }
    }
}
