using Hydra.FileStorage.Core.Models;
using Hydra.FileStorage.Core.Settings;
using Hydra.Infrastructure.GeneralModels;
using Microsoft.AspNetCore.Http;


namespace Hydra.FileStorage.Core.Interfaces
{
    public interface IFileStorageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool IsExist(string fileName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        string ConvertSizeToString(long bytes);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<FileUploadModel>>> GetFilesList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryname"></param>
        /// <returns></returns>
        Task<Result<List<FileUploadModel>>> GetFilesListByDirectory(string directoryname);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<DirectoryModel>>> GetDirectoryList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> GetFileInfoById(int fileId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileIds"></param>
        /// <returns></returns>
        Task<Result<List<FileUploadModel>>> GetFilesInfoByIds(int[] fileIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> GetFileInfoByName(string fileName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<GalleryResultModel> GetGalleyFiles(HttpContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uploadModel"></param>
        /// <param name="bytes"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadFromBytesAsync(int userId, FileUploadModel uploadModel, string uploadAction, byte[] bytes, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileForm"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> Upload(int userId, IFormFile fileForm,string uploadAction, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadSmallFileStreamAsync(int userId, string? fileName, string uploadAction, string? contentType, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadLargeFileStreamAsync(int userId, string? fileName, string uploadAction, string? contentType, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64File"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadBase64File(int userId, Base64FileUploadModel base64File, string uploadAction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="fileStream"></param>
        /// <param name="contentType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadFromStreamAsync(int userId,
            string? fileName, string uploadAction,
            FileSizeEnum fileSize,
            Stream fileStream,
            string contentType,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        string? GenerateThumbnail(FileInfo fileInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<Result> Delete(int userId, int fileId);


    }
}