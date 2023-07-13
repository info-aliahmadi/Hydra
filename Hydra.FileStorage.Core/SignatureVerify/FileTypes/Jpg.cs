namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Jpg : FileType
    {
        public Jpg()
        {
            Name = "JPG";
            Description = "JPG IMAGE";
            AddExtensions("jpg");
            AddSignatures(
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }
            );
        }
    }
}