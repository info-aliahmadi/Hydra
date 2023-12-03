using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.FileStorage.Core.Domain
{
    public class FileUpload : BaseEntity<int>
    {
        public string FileName { get; set; }

        public string Directory { get; set; }

        public string? Thumbnail { get; set; }

        public string Extension { get; set; }

        public long Size { get; set; }

        public string? Tags { get; set; }

        public string? Alt { get; set; }

        public DateTime UploadDate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }


    }
}
