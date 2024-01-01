using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductManufacturerService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductManufacturerModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductManufacturerModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productManufacturerModel"></param>
        /// <returns></returns>
        Task<Result<ProductManufacturerModel>> Add(ProductManufacturerModel productManufacturerModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productManufacturerModel"></param>
        /// <returns></returns>
        Task<Result<ProductManufacturerModel>> Update(ProductManufacturerModel productManufacturerModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}