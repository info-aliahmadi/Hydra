using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface ITagService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<TagModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task<Result<List<TagModel>>> GetListByTitle(string[] tags);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<TagModel>>> GetListForSelect();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<TagModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        Task<Result<TagModel>> Add(TagModel tagModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task<Result> Add(string[] tags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        Task<Result<TagModel>> Update(TagModel tagModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}
