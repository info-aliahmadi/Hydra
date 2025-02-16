using Hydra.Kernel.Setting.Domain;
using Hydra.Kernel.GeneralModels;

namespace Hydra.Kernel.Setting.Service
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
