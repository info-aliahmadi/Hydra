using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IShipmentItemService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ShipmentItemModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ShipmentItemModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentItemModel"></param>
        /// <returns></returns>
        Task<Result<ShipmentItemModel>> Add(ShipmentItemModel shipmentItemModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentItemModel"></param>
        /// <returns></returns>
        Task<Result<ShipmentItemModel>> Update(ShipmentItemModel shipmentItemModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}