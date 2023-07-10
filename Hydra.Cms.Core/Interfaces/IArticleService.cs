using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ArticleModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ArticleModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        Task<Result<ArticleModel>> Add(ArticleModel articleModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        Task<Result<ArticleModel>> Update(ArticleModel articleModel);

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
        /// <param name="articleId"></param>
        /// <param name="size"></param>
        /// <param name="oldthumbnailName"></param>
        /// <returns></returns>
        Result<string> SaveThumbnailFile(string thumbnailFile, int articleId, string size, string oldthumbnailName = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thumbnailName"></param>
        /// <returns></returns>
        Result<string> DeleteThumbnailFile(string thumbnailName);


    }
}
