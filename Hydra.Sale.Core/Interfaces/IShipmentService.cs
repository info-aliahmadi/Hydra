using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IShipmentService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ShipmentModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<ShipmentModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentModel"></param>
        /// <returns></returns>
        Task<Result<ShipmentModel>> Add(ShipmentModel shipmentModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shipmentModel"></param>
        /// <returns></returns>
        Task<Result<ShipmentModel>> Update(ShipmentModel shipmentModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}