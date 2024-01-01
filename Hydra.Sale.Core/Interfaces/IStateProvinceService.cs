using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IStateProvinceService
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<StateProvinceModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<StateProvinceModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="stateProvinceModel"></param>
        /// <returns></returns>
        Task<Result<StateProvinceModel>> Add(StateProvinceModel stateProvinceModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="stateProvinceModel"></param>
        /// <returns></returns>
        Task<Result<StateProvinceModel>> Update(StateProvinceModel stateProvinceModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}