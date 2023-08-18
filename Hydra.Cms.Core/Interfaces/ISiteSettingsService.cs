using Hydra.Cms.Core.Models;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Cms.Core.Interfaces
{
    public interface ISiteSettingsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<SiteSettingsModel>>> GetALL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<SiteSettingsModel>> GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<SiteSettingsModel>> GetByKey(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        Task<Result<SiteSettingsModel>> Add(SiteSettingsModel menuModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        Task<Result<SiteSettingsModel>> Update(SiteSettingsModel menuModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);


    }
}
