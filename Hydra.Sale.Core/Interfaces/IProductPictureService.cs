using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IProductPictureService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ProductPictureModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ProductPictureModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productPictureModel"></param>
        /// <returns></returns>
        Task<Result<ProductPictureModel>> Add(ProductPictureModel productPictureModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productPictureModel"></param>
        /// <returns></returns>
        Task<Result<ProductPictureModel>> Update(ProductPictureModel productPictureModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}