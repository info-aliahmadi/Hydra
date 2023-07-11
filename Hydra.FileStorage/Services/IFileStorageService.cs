using Hydra.FileStorage.Infrastructure.Settings;
using Nitro.FileStorage.Models;

namespace Nitro.FileStorage.Services
{
    public interface IFileStorageService
    {

        Task<GridFSFileInfo?> GetFileInfoById(int fileId);

        string GetMd5HashCode(byte[] bytes);

        Task<FileUploadResultModel> UploadFromBytesAsync(string? fileName, string? contentType, byte[] bytes,
            CancellationToken cancellationToken = default);

        Task<FileUploadResultModel> UploadSmallFileFromStreamAsync(string? fileName, string? contentType, Stream stream,
            CancellationToken cancellationToken = default);

        Task<FileUploadResultModel> UploadLargeFileFromStreamAsync(string? fileName, string? contentType, Stream stream,
            CancellationToken cancellationToken = default);

        Task<FileUploadResultModel> UploadFromStreamAsync(
            string? fileName,
            string newFileName,
            FileSizeEnum fileSize,
            Stream source,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<byte[]> DownloadAsBytesAsync(int fileId, CancellationToken cancellationToken = default);

        Task DownloadToStreamAsync(int fileId, Stream destination,
            CancellationToken cancellationToken = default);


    }
}