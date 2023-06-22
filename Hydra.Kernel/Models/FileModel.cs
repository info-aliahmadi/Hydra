using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Kernel.Models
{
    public class FileModel
    {
        public string ContentType { get; set; }

        public byte[] FileBytes { get; set; }

        public string Extension
        {
            get
            {
                return ContentType.Split('/').Last();
            }
        }
        public string RandomFileName
        {
            get
            {
                return Guid.NewGuid().ToString() + "." + this.Extension;
            }
        }
    }
}
