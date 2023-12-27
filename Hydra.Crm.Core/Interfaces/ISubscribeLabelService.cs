using Hydra.Crm.Core.Models.Subscribe;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Crm.Core.Interfaces
{
    public interface ISubscribeLabelService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<SubscribeLabelModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<SubscribeLabelModel>>> GetListForSelect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<SubscribeLabelModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeLabelModel"></param>
        /// <returns></returns>
        Task<Result<SubscribeLabelModel>> Add(SubscribeLabelModel subscribeLabelModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeLabelModel"></param>
        /// <returns></returns>
        Task<Result<SubscribeLabelModel>> Update(SubscribeLabelModel subscribeLabelModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);
    }
}