using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface ISlideshowService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<SlideshowModel>>> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<SlideshowModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        Task<Result<SlideshowModel>> Add(SlideshowModel slideshowModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slideshowModel"></param>
        /// <returns></returns>
        Task<Result<SlideshowModel>> Update(SlideshowModel slideshowModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slideshowModelList"></param>
        /// <returns></returns>
        Task<Result<List<SlideshowModel>>> UpdateOrder(List<SlideshowModel> slideshowModelList);

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
