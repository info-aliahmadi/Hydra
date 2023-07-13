namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Xml : FileType
    {
        public Xml()
        {
            Name = "XML";
            Description = "XML IMAGE";
            AddExtensions("xml");
            AddSignatures(
                new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73,
                    0x69, 0x6F ,0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E }
            );
        }
    }
}
