namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Xlsx : FileType
    {
        public Xlsx()
        {
            Name = "XLSX";
            Description = "XLSX MICROSOFT OFFICE DOCUMENT";
            AddExtensions("xlsx");
            AddSignatures(
                new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 }
            );
        }
    }
}
