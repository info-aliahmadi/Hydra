using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductAttributeService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductAttributeModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Result<List<ProductAttributeModel>> GetListForSelect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<ProductAttributeModel> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productAttributeModel"></param>
        /// <returns></returns>
        Task<Result<ProductAttributeModel>> Add(ProductAttributeModel productAttributeModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productAttributeModel"></param>
        /// <returns></returns>
        Task<Result<ProductAttributeModel>> Update(ProductAttributeModel productAttributeModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}