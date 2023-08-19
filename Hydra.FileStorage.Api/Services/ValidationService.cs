using Hydra.FileStorage.Core.Interfaces;
using Hydra.FileStorage.Core.Settings;
using Hydra.Infrastructure.Setting;
using Hydra.Kernel.Models;

namespace Hydra.FileStorage.Api.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IFileTypeVerifier _fileTypeVerifier;
        private readonly IUploadFileSetting _fileStorageSetting;

        public ValidationService(
            IUploadFileSetting fileStorageSetting,
            IFileTypeVerifier fileTypeVerifier)
        {
            _fileStorageSetting = fileStorageSetting;
            _fileTypeVerifier = fileTypeVerifier;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ValidationFileEnum ValidateFileWhiteList(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();

            var whiteListExtensions = _fileStorageSetting.WhiteListExtensions.Split(",");
            if (!whiteListExtensions.Contains(fileExtension))
            {
                // If the code runs to this location, it means that no files have been saved
                return ValidationFileEnum.FileNotSupported;
            }

            return ValidationFileEnum.Ok;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public ValidationFileEnum ValidateFileSignature(byte[] file, string fileExtension)
        {
            var signatureValidationExtensions = _fileStorageSetting.SignatureValidationExtensions.Split(",");

            if (signatureValidationExtensions.Contains(fileExtension))
            {
                // we will see how we can protect the integrity of our file uploads by
                // verifying the files are what the user says they are
                var verifySignature = _fileTypeVerifier.Verify(file, fileExtension);
                if (!verifySignature.IsVerified)
                {
                    return ValidationFileEnum.InvalidSignature;
                }
            }

            return ValidationFileEnum.Ok;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lengthOfFile"></param>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public ValidationFileEnum ValidateFileMaxLength(long lengthOfFile,
            FileSizeEnum fileSize = FileSizeEnum.Small)
        {
            return fileSize switch
            {
                FileSizeEnum.Small when lengthOfFile > _fileStorageSetting.MaxSizeLimitSmallFile => ValidationFileEnum
                    .FileIsTooLarge,
                FileSizeEnum.Large when lengthOfFile > _fileStorageSetting.MaxSizeLimitLargeFile => ValidationFileEnum
                    .FileIsTooLarge,
                _ => ValidationFileEnum.Ok
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lengthOfFile"></param>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public ValidationFileEnum ValidateFileMinLength(long lengthOfFile,
            FileSizeEnum fileSize = FileSizeEnum.Small)
        {
            return fileSize switch
            {
                FileSizeEnum.Small when lengthOfFile < _fileStorageSetting.MinSizeLimitSmallFile => ValidationFileEnum
                    .FileIsTooSmall,

                _ => ValidationFileEnum.Ok
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lengthOfFile"></param>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public ValidationFileEnum ValidateFileLength(long lengthOfFile,
            FileSizeEnum fileSize = FileSizeEnum.Small)
        {
            var result = ValidateFileMaxLength(lengthOfFile, fileSize);
            return result == ValidationFileEnum.Ok ? ValidateFileMinLength(lengthOfFile, fileSize) : result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="lengthOfFile"></param>
        /// <param name="fileSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ValidationFileEnum ValidateFile(byte[] file, string? fileName,
            long? lengthOfFile = null,
            FileSizeEnum fileSize = FileSizeEnum.Small, CancellationToken cancellationToken = default)
        {
            var length = lengthOfFile ?? file.Length;
            if (string.IsNullOrEmpty(fileName))
            {
                // If the code runs to this location, it means that no files have been saved
                return ValidationFileEnum.FileNotFound;
            }

            var validateFileExtenstionResult = ValidateFileWhiteList(fileName);
            if (validateFileExtenstionResult != ValidationFileEnum.Ok)
            {
                return validateFileExtenstionResult;
            }


            var validateFileLengthResult = ValidateFileLength(length, fileSize);
            if (validateFileLengthResult != ValidationFileEnum.Ok)
            {
                return validateFileLengthResult;
            }

            var fileExtension = Path.GetExtension(fileName);
            var validateFileSignatureResult = ValidateFileSignature(file, fileExtension);
            if (validateFileSignatureResult != ValidationFileEnum.Ok)
            {
                return validateFileLengthResult;
            }

            return ValidationFileEnum.Ok;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="validationFileEnum"></param>
        /// <returns></returns>
        public string GetValidationMessage(ValidationFileEnum validationFileEnum)
        {
            switch (validationFileEnum)
            {
                case ValidationFileEnum.FileNotFound:
                    // If the code runs to this location, it means that no files have been saved
                    return "No files data in the request.";

                case ValidationFileEnum.FileIsTooLarge:
                    // If the code runs to this location, it means that no files have been saved
                    return "The file is too large.";

                case ValidationFileEnum.FileIsTooSmall:
                    // If the code runs to this location, it means that no files have been saved
                    return "The file is too small.";

                case ValidationFileEnum.FileNotSupported:
                    // If the code runs to this location, it means that no files have been saved
                    return "The file is not supported.";

                case ValidationFileEnum.InvalidSignature:
                    // If the code runs to this location, it means that no files have been saved
                    return "The file extension is not trusted.";

                case ValidationFileEnum.Ok:
                default:
                    return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validationFileEnum"></param>
        /// <returns></returns>
        public ResultStatusEnum GetValidationStatus(ValidationFileEnum validationFileEnum)
        {
            switch (validationFileEnum)
            {
                case ValidationFileEnum.FileNotFound:
                    // If the code runs to this location, it means that no files have been saved
                    return ResultStatusEnum.NotFound;

                case ValidationFileEnum.FileIsTooLarge:
                    // If the code runs to this location, it means that no files have been saved
                    return ResultStatusEnum.FileIsTooLarge;

                case ValidationFileEnum.FileIsTooSmall:
                    // If the code runs to this location, it means that no files have been saved
                    return ResultStatusEnum.FileIsTooSmall;

                case ValidationFileEnum.FileNotSupported:
                    // If the code runs to this location, it means that no files have been saved
                    return ResultStatusEnum.IsNotAllowed;

                case ValidationFileEnum.InvalidSignature:
                    // If the code runs to this location, it means that no files have been saved
                    return ResultStatusEnum.InvalidValidation;

                case ValidationFileEnum.Ok:
                default:
                    return ResultStatusEnum.Succeeded;
            }
        }
    }
}