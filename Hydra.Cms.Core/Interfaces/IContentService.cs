using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface IContentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ContentModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ContentModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        Task<Result<ContentModel>> Add(ContentModel contentModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentModel"></param>
        /// <returns></returns>
        Task<Result<ContentModel>> Update(ContentModel contentModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thumbnailFile"></param>
        /// <param name="contentId"></param>
        /// <param name="size"></param>
        /// <param name="oldthumbnailName"></param>
        /// <returns></returns>
        Result<string> SaveThumbnailFile(string thumbnailFile, int contentId, string size, string oldthumbnailName = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thumbnailName"></param>
        /// <returns></returns>
        Result<string> DeleteThumbnailFile(string thumbnailName);


    }
}
