namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public sealed class Mkv : FileType
    {
        public Mkv()
        {
            Name = "MKV";
            Description = "MKV Video File";
            AddExtensions("MKV");
            AddSignatures(
                new byte[] { 0x1A, 0x45, 0xDF, 0xA3}
            );
        }
    }
}