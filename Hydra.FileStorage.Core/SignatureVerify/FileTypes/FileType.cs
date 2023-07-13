namespace Hydra.FileStorage.Core.SignatureVerify.FileTypes
{
    public abstract class FileType
    {
        protected string Description { get; set; } = null!;
        protected string Name { get; set; } = null!;

        private List<string> Extensions { get; }
            = new List<string>();

        private List<byte[]> Signatures { get; }
            = new List<byte[]>();

        public int SignatureLength => Signatures.Max(m => m.Length);

        protected FileType AddSignatures(params byte[][] bytes)
        {
            Signatures.AddRange(bytes);
            return this;
        }

        protected FileType AddExtensions(params string[] extensions)
        {
            Extensions.AddRange(extensions);
            return this;
        }

        public FileTypeVerifyResult Verify(byte[] headerBytes)
        {
            //stream.Position = 0;
            //var reader = new BinaryReader(stream);
            //var headerBytes = file.ReadBytes(SignatureLength);

            return new FileTypeVerifyResult
            {
                Name = Name,
                Description = Description,
                IsVerified = Signatures.Any(signature =>
                    headerBytes.Take(signature.Length)
                        .SequenceEqual(signature)
                )
            };
        }
    }

    public class FileTypeVerifyResult
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsVerified { get; set; }
    }
}