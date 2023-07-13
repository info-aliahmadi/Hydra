namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Gif : FileType
    {
        public Gif()
        {
            Name = "GIF";
            Description = "GIF IMAGE";
            AddExtensions("gif");
            AddSignatures(
                new byte[] { 0x47, 0x49, 0x46, 0x38 }
            );
        }
    }
}