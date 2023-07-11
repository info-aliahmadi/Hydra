using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;

namespace Hydra.Cms.Core.Interfaces
{
    public interface IDriveService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GalleryResultModel> GetFiles(HttpContext context);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<Result<TopicModel>> GetByName(string fileName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        Task<Result> Add(IFormFile formFile);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<Result> Delete(int id);


    }
}
