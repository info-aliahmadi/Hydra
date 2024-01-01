using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductInventoryService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductInventoryModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductInventoryModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productInventoryModel"></param>
        /// <returns></returns>
        Task<Result<ProductInventoryModel>> Add(ProductInventoryModel productInventoryModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productInventoryModel"></param>
        /// <returns></returns>
        Task<Result<ProductInventoryModel>> Update(ProductInventoryModel productInventoryModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}