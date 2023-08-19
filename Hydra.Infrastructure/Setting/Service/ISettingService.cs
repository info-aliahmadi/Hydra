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
        List<SiteSetting> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SiteSetting GetById(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SiteSetting GetByKey(string key);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSetting"></param>
        /// <returns></returns>
        SiteSetting AddOrUpdate(SiteSetting siteSetting);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Result DeleteById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Result DeleteByKey(string key);

    }
}
