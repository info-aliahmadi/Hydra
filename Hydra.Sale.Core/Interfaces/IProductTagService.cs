using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductTagService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductTagModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<ProductTagModel>>> GetListForSelect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductTagModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productTagModel"></param>
        /// <returns></returns>
        Task<Result<ProductTagModel>> Add(ProductTagModel productTagModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task<Result<List<ProductTagModel>>> Add(string[] tags);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productTagModel"></param>
        /// <returns></returns>
        Task<Result<ProductTagModel>> Update(ProductTagModel productTagModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}