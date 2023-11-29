using EFCoreSecondLevelCacheInterceptor;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;

namespace Hydra.Infrastructure.Setting.Service
{
    public class SettingService : ISettingService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public SettingService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SiteSetting> GetAll()
        {
            var list = _queryRepository.Table<SiteSetting>().Cacheable().ToList();

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SiteSetting GetById(int id)
        {
            var record = GetAll().Where(x => x.Id == id).FirstOrDefault();

            return record;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SiteSetting GetByKey(string key)
        {
            var record = GetAll().Where(x => x.Key == key).FirstOrDefault();
            return record;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSetting"></param>
        /// <returns></returns>
        public SiteSetting AddOrUpdate(SiteSetting siteSetting)
        {
            var record = _queryRepository.Table<SiteSetting>().Where(x => x.Key == siteSetting.Key).FirstOrDefault();
            if (record == null)
            {

                _commandRepository.InsertAsync(siteSetting);
                _commandRepository.SaveChangesAsync();

                return siteSetting;
            }

            record.Value = siteSetting.Value;
            record.ValueType = siteSetting.ValueType;

            _commandRepository.UpdateAsync(record);
            _commandRepository.SaveChanges();

            return siteSetting;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result DeleteById(int id)
        {
            var result = new Result();
            var row = _queryRepository.Table<SiteSetting>().FirstOrDefault(x => x.Id == id);
            if (row == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The row not found";
                return result;
            }

            _commandRepository.DeleteAsync(row);

            _commandRepository.SaveChanges();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result DeleteByKey(string key)
        {
            var result = new Result();
            var row = _queryRepository.Table<SiteSetting>().FirstOrDefault(x => x.Key == key);
            if (row == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The row not found";
                return result;
            }

            _commandRepository.DeleteAsync(row);

            _commandRepository.SaveChanges();

            return result;
        }
    }
}
