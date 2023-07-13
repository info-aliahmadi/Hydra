namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Mp4 : FileType
    {
        public Mp4()
        {
            Name = "MP4";
            Description = "MP4 Video File";
            AddExtensions("Mp4");
            AddSignatures(
                new byte[] { 0x66, 0x74, 0x79, 0x70, 0x69, 0x73, 0x6F, 0x6D }
            );
        }
    }
}