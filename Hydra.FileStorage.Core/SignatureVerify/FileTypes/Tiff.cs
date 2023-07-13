namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Tiff : FileType
    {
        public Tiff()
        {
            Name = "TIFF";
            Description = "Tiff IMAGE";
            AddExtensions("tiff");
            AddSignatures(
                new byte[] { 0x49, 0x20, 0x49 },
                new byte[] { 0x49, 0x49, 0x2A, 0x00 },
                new byte[] { 0x4D, 0x4D, 0x00, 0x2A },
                new byte[] { 0x4D, 0x4D, 0x00, 0x2B }
            );
        }
    }
}
