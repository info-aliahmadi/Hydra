namespace Hydra.Infrastructure.Setting.Interface
{
    public interface IUploadFileSetting
    {
        bool AllowDuplicateFile { get; set; }
        string WhiteListExtensions { get; set; }
        string SignatureValidationExtensions { get; set; }

        long MaxSizeLimitSmallFile { get; set; }

        long MinSizeLimitSmallFile { get; set; }

        long MaxSizeLimitLargeFile { get; set; }

        string ImagesExtensions { get; set; }
        string VideosExtensions { get; set; }
        string AudioExtensions { get; set; }
        string DocumentsExtensions { get; set; }
        int ImageThumbnailSize { get; set; }

    }
    public class UploadFileSetting : IUploadFileSetting
    {
        public bool AllowDuplicateFile { get; set; }
        public string WhiteListExtensions { get; set; } = null!;
        public string SignatureValidationExtensions { get; set; } = null!;

        public long MaxSizeLimitSmallFile { get; set; }

        public long MinSizeLimitSmallFile { get; set; }

        public long MaxSizeLimitLargeFile { get; set; }

        public string ImagesExtensions { get; set; }

        public string VideosExtensions { get; set; }

        public string AudioExtensions { get; set; }

        public string DocumentsExtensions { get; set; }

        public int ImageThumbnailSize { get; set; }
    }
}
