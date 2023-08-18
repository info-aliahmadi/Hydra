using EFCoreSecondLevelCacheInterceptor;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Infrastructure.Setting.Service
{
    public interface ISettingService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<List<SiteSetting>>> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<SiteSetting>> GetById(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<SiteSetting>> GetByKey(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        Task<Result<SiteSetting>> Add(SiteSetting siteSetting);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        Task<Result<SiteSetting>> Update(SiteSetting siteSetting);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result> DeleteById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result> DeleteByKey(string key);

    }
}
