using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IShippingMethodService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ShippingMethodModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ShippingMethodModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shippingMethodModel"></param>
        /// <returns></returns>
        Task<Result<ShippingMethodModel>> Add(ShippingMethodModel shippingMethodModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shippingMethodModel"></param>
        /// <returns></returns>
        Task<Result<ShippingMethodModel>> Update(ShippingMethodModel shippingMethodModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}