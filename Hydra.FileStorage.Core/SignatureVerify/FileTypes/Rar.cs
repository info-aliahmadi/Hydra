namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Rar : FileType
    {
        public Rar()
        {
            Name = "RAR";
            Description = "RAR ARCHIVE FILE";
            AddExtensions("rar");
            AddSignatures(
                new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 }
            );
        }
    }
}

