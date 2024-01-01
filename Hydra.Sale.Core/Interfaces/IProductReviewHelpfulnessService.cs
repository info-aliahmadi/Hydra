using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductReviewHelpfulnessService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductReviewHelpfulnessModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductReviewHelpfulnessModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewHelpfulnessModel"></param>
        /// <returns></returns>
        Task<Result<ProductReviewHelpfulnessModel>> Add(ProductReviewHelpfulnessModel productReviewHelpfulnessModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewHelpfulnessModel"></param>
        /// <returns></returns>
        Task<Result<ProductReviewHelpfulnessModel>> Update(ProductReviewHelpfulnessModel productReviewHelpfulnessModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}