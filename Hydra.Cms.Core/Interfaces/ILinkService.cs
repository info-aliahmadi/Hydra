using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface ILinkService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<LinkModel>>> GetList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<LinkModel>> GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        Task<Result<LinkModel>> Add(LinkModel linkModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        Task<Result<LinkModel>> Update(LinkModel linkModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkModelList"></param>
        /// <returns></returns>
        Task<Result<List<LinkModel>>> UpdateOrder(List<LinkModel> linkModelList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
