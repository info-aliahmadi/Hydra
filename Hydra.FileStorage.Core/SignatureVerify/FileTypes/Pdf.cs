namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Pdf : FileType
    {
        public Pdf()
        {
            Name = "PDF";
            Description = "PDF FILE";
            AddExtensions("pdf");
            AddSignatures(
                new byte[] { 0x25, 0x50, 0x44, 0x46 }
            );
        }
    }
}