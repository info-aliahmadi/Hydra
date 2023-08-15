using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface IPageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<PageModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<PageModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        Task<Result<PageModel>> Add(PageModel pageModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        Task<Result<PageModel>> Update(PageModel pageModel);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
