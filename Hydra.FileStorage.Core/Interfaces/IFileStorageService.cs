﻿using Hydra.FileStorage.Core.Models;
using Hydra.FileStorage.Core.Settings;
using Hydra.Kernel.Models;
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
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<FileUploadModel> GetFileInfoById(int fileId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<FileUploadModel>>> GetFilesList();

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
        Task<Result<FileUploadModel>> UploadFromBytesAsync(FileUploadModel uploadModel, byte[] bytes, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileForm"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadSmallFileFromFormFile(IFormFile fileForm, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadSmallFileFromStreamAsync(string? fileName, string? contentType, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadLargeFileFromStreamAsync(string? fileName, string? contentType, Stream stream, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileSize"></param>
        /// <param name="fileStream"></param>
        /// <param name="contentType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<FileUploadModel>> UploadFromStreamAsync(
            string? fileName,
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
        Task<Result> Delete(int fileId);


    }
}