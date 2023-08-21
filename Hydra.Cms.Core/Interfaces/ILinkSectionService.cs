using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface ILinkSectionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<LinkSectionModel>>> GetList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<LinkSectionModel>> GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        Task<Result<LinkSectionModel>> Add(LinkSectionModel linkSectionModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkModel"></param>
        /// <returns></returns>
        Task<Result<LinkSectionModel>> Update(LinkSectionModel linkSectionModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Visible(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
