using Hydra.Kernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Kernel.Extensions
{
    public static class ConvertExtension
    {
        public static FileModel Base64FileToBytes(this string fileString)
        {
            if (string.IsNullOrEmpty(fileString))
            {
                throw new ArgumentNullException(nameof(fileString));
            }

            int indexOfSemiColon = fileString.IndexOf(";", StringComparison.OrdinalIgnoreCase);

            string dataLabel = fileString.Substring(0, indexOfSemiColon);

            string contentType = dataLabel.Split(':').Last();

            var startIndex = fileString.IndexOf("base64,", StringComparison.OrdinalIgnoreCase) + 7;

            var fileContents = fileString.Substring(startIndex);

            var bytes = Convert.FromBase64String(fileContents);

            return new FileModel()
            {
                ContentType = contentType,
                FileBytes = bytes
            };
        }
    }
}
