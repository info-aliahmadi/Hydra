using Hydra.FileStorage.Core.SignatureVerify.FileTypes;

namespace Hydra.FileStorage.Core.Interfaces
{
    public interface IFileTypeVerifier
    {
        FileTypeVerifyResult Verify(byte[] file, string extension);
    }
}