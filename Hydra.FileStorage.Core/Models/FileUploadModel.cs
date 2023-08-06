

namespace Hydra.FileStorage.Core.Models
{
    public class FileUploadModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string Directory { get; set; }

        public string? Thumbnail { get; set; }

        public string Extension { get; set; }

        public long Size { get; set; }

        public string? Tags { get; set; }

        public string? Alt { get; set; }
        public DateTime UploadDate { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
