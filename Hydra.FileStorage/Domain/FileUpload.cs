using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.FileStorage.Domain
{
    public class FileUpload
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string? Thumbnail { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public string? Tags { get; set; }

        public string? Alt { get; set; }


    }
}
