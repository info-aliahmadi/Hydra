namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Doc : FileType
    {
        public Doc()
        {
            Name = "DOC";
            Description = "DOC MICROSOFT OFFICE DOCUMENT";
            AddExtensions("doc");
            AddSignatures(
                new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                new byte[] { 0x0D, 0x44, 0x4F, 0x43 },
                new byte[] { 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1, 0x00 },
                new byte[] { 0xDB, 0xA5, 0x2D, 0x00 },
                new byte[] { 0xEC, 0xA5, 0xC1, 0x00 }
            );
        }
    }
}
