namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Txt : FileType
    {
        public Txt()
        {
            Name = "TXT";
            Description = "TXT TEXT FILE";
            AddExtensions("txt");
            AddSignatures(
                new byte[] { 0xEF, 0xBB, 0xBF },
                new byte[] { 0xFF, 0xFE },
                new byte[] { 0xFE, 0xFF },
                new byte[] { 0xFF, 0xFE, 0x00, 0x00 },
                new byte[] { 0x00, 0x00, 0xFE, 0xFF },
                new byte[] { 0x0E, 0xFE, 0xFF }
            );
        }
    }
}
