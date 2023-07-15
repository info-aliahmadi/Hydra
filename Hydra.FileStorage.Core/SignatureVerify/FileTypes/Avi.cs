namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Avi : FileType
    {
        public Avi()
        {
            Name = "AVI";
            Description = "AVI Video File";
            AddExtensions("AVI");
            AddSignatures(
                new byte[] { 0x52, 0x49, 0x46, 0x46 },
                new byte[] { 0x41, 0x56, 0x49, 0x20, 0x4C, 0x49, 0x53, 0x54 }
            );
        }
    }
}