using EFCoreSecondLevelCacheInterceptor;
using Hydra.Infrastructure.Setting.Domain;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Result<List<SiteSetting>>> GetAll()
        {
            var result = new Result<List<SiteSetting>>();

            var list = _queryRepository.Table<SiteSetting>().Cacheable().ToList();

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<SiteSetting>> GetById(int id)
        {
            var result = new Result<SiteSetting>();

            var record = await _queryRepository.Table<SiteSetting>().Where(x => x.Id == id).FirstOrDefaultAsync();

            result.Data = record;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<SiteSetting>> GetByKey(string key)
        {
            var result = new Result<SiteSetting>();

            var record = await _queryRepository.Table<SiteSetting>().Where(x => x.Key == key).FirstOrDefaultAsync();

            result.Data = record;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSetting"></param>
        /// <returns></returns>
        public async Task<Result<SiteSetting>> Add(SiteSetting siteSetting)
        {
            var result = new Result<SiteSetting>();

            var isExist = await _queryRepository.Table<SiteSetting>().Where(x => x.Key == siteSetting.Key).AnyAsync();
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(siteSetting.Key), "The Key Name existed"));
                result.Message = "The row existed";
                return result;
            }

            await _commandRepository.InsertAsync(siteSetting);

            await _commandRepository.SaveChangesAsync();

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteSetting"></param>
        /// <returns></returns>
        public async Task<Result<SiteSetting>> Update(SiteSetting siteSetting)
        {
            var result = new Result<SiteSetting>();
            var row = await _queryRepository.Table<SiteSetting>().Where(x => x.Id == siteSetting.Id).FirstOrDefaultAsync();
            if (row is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The row not found";
                return result;
            }

            var isExist = await _queryRepository.Table<SiteSetting>().Where(x => x.Id != siteSetting.Id && x.Key == siteSetting.Key).AnyAsync();
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(siteSetting.Key), "The Key name existed"));
                result.Message = "The tag existed";
                return result;
            }
            row.Value = siteSetting.Value;
            row.ValueType = siteSetting.ValueType;

            _commandRepository.UpdateAsync(row);

            await _commandRepository.SaveChangesAsync();

            result.Data = row;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteById(int id)
        {
            var result = new Result();
            var row = await _queryRepository.Table<SiteSetting>().FirstOrDefaultAsync(x => x.Id == id);
            if (row == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The row not found";
                return result;
            }

            _commandRepository.DeleteAsync(row);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteByKey(string key)
        {
            var result = new Result();
            var row = await _queryRepository.Table<SiteSetting>().FirstOrDefaultAsync(x => x.Key == key);
            if (row == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The row not found";
                return result;
            }

            _commandRepository.DeleteAsync(row);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}
