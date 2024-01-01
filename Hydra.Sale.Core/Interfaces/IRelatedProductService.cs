using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IRelatedProductService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<RelatedProductModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<RelatedProductModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="relatedProductModel"></param>
        /// <returns></returns>
        Task<Result<RelatedProductModel>> Add(RelatedProductModel relatedProductModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="relatedProductModel"></param>
        /// <returns></returns>
        Task<Result<RelatedProductModel>> Update(RelatedProductModel relatedProductModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}