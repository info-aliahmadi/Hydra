using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductCategoryService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductCategoryModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductCategoryModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCategoryModel"></param>
        /// <returns></returns>
        Task<Result<ProductCategoryModel>> Add(ProductCategoryModel productCategoryModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCategoryModel"></param>
        /// <returns></returns>
        Task<Result<ProductCategoryModel>> Update(ProductCategoryModel productCategoryModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}