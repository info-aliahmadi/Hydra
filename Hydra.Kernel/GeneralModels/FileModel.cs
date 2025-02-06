namespace Hydra.Kernel.GeneralModels
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
                return Guid.NewGuid().ToString() + "." + Extension;
            }
        }
    }
}
