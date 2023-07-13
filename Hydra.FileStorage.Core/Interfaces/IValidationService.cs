using Hydra.FileStorage.Core.Settings;

namespace Hydra.FileStorage.Core.Interfaces
{
    public interface IValidationService
    {
        ValidationFileEnum ValidateFileWhiteList(string fileName);

        ValidationFileEnum ValidateFileSignature(byte[] file, string fileExtension);

        ValidationFileEnum ValidateFileMaxLength(long lengthOfFile,
            FileSizeEnum fileSize = FileSizeEnum.Small);

        ValidationFileEnum ValidateFileMinLength(long lengthOfFile,
            FileSizeEnum fileSize = FileSizeEnum.Small);

        ValidationFileEnum ValidateFileLength(long lengthOfFile,
            FileSizeEnum fileSize = FileSizeEnum.Small);

        ValidationFileEnum ValidateFile(byte[] file, string? fileName, long? lengthOfFile = null,
            FileSizeEnum fileSize = FileSizeEnum.Small, CancellationToken cancellationToken = default);

        string GetValidationMessage(ValidationFileEnum validationFileEnum);
    }
}