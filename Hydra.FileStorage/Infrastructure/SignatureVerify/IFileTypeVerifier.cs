

using Hydra.FileStorage.Infrastructure.SignatureVerify.FileTypes;

namespace Hydra.FileStorage.Infrastructure.SignatureVerify
{
    public interface IFileTypeVerifier
    {
        FileTypeVerifyResult Verify(byte[] file, string extension);
    }
}