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
        /// <param name="searchInput"></param>
        /// <param name="categoryName"></param>
        /// <param name="tagName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ArticleModel>>> GetListForVisitors(string? searchInput, string? categoryName, string? tagName, int pageIndex, int pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ArticleModel>> GetByIdForVisitors(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ArticleModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ArticleModel>>> GetTrashList(GridDataBound dataGrid);

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
        Task<Result> Pin(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Restore(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Remove(int id);

    }
}
