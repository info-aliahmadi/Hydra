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
}
