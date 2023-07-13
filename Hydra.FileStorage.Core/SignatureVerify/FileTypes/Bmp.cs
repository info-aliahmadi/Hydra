namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Bmp : FileType
    {
        public Bmp()
        {
            Name = "BMP";
            Description = "BMP IMAGE";
            AddExtensions("bmp");
            AddSignatures(
                new byte[] { 0x42, 0x4D }
            );
        }
    }
}