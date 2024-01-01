using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductReviewService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductReviewModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductReviewModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewModel"></param>
        /// <returns></returns>
        Task<Result<ProductReviewModel>> Add(ProductReviewModel productReviewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewModel"></param>
        /// <returns></returns>
        Task<Result<ProductReviewModel>> Update(ProductReviewModel productReviewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}