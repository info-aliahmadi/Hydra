using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IManufacturerService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<ManufacturerModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Result<List<ManufacturerModel>> GetListForSelect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<ManufacturerModel> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="manufacturerModel"></param>
        /// <returns></returns>
        Task<Result<ManufacturerModel>> Add(ManufacturerModel manufacturerModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="manufacturerModel"></param>
        /// <returns></returns>
        Task<Result<ManufacturerModel>> Update(ManufacturerModel manufacturerModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}