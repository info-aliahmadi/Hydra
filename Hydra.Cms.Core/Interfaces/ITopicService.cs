using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface ITopicService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<TopicModel>>> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<TopicModel>> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        Task<Result<TopicModel>> Add(TopicModel topicModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        Task<Result<TopicModel>> Update(TopicModel topicModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
