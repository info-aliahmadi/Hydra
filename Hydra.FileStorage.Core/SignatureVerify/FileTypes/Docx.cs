namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Docx : FileType
    {
        public Docx()
        {
            Name = "DOCX";
            Description = "DOCX MICROSOFT OFFICE DOCUMENT";
            AddExtensions("docx");
            AddSignatures(
                new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 },
                new byte[] { 0x50, 0x4B, 0x03, 0x04 }
            );
        }
    }
}
