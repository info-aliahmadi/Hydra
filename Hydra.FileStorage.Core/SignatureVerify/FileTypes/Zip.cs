namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Zip : FileType
    {
        public Zip()
        {
            Name = "ZIP";
            Description = "ZIP ARCHIVE FILE";
            AddExtensions("zip");
            AddSignatures(
                new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                new byte[] { 0x50, 0x4B, 0x4C, 0x49, 0x54, 0x45 },
                new byte[] { 0x50, 0x4B, 0x53, 0x70, 0x58 },
                new byte[] { 0x50, 0x4B, 0x05, 0x06 },
                new byte[] { 0x50, 0x4B, 0x07, 0x08 },
                new byte[] { 0x57, 0x69, 0x6E, 0x5A, 0x69, 0x70 },
                new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x01, 0x00 }
            );
        }
    }
}
