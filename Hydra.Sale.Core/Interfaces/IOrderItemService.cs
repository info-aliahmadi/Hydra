using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IOrderItemService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<OrderItemModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<OrderItemModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        Task<Result<OrderItemModel>> Add(OrderItemModel orderItemModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        Task<Result<OrderItemModel>> Update(OrderItemModel orderItemModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}