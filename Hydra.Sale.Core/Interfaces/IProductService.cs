using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<Result<List<ProductModel>>> GetProductsByInput(string input);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        Task<Result<ProductModel>> Add(ProductModel productModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        Task<Result<ProductModel>> Update(ProductModel productModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Remove(int id);

    }
}