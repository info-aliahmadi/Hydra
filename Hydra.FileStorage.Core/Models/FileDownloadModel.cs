namespace Hydra.FileStorage.Core.Models
{
    public class FileDownloadModel
    {
        public int FileId { get; set; }
        public byte[] FileBytes { get; set; } = null!;
        public FileUploadModel FileInfo { get; set; } = null!;
    }

}
