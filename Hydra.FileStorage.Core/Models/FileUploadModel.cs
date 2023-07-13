

namespace Hydra.FileStorage.Core.Models
{
    public class FileUploadModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string? Thumbnail { get; set; }

        public string Extension { get; set; }

        public string Size { get; set; }

        public string? Tags { get; set; }

        public string? Alt { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
