using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Cms.Api.Services
{
    public class SubscribeLabelService : ISubscribeLabelService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public SubscribeLabelService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<SubscribeLabelModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<SubscribeLabelModel>>();

            var list = await (from subscribeLabel in _queryRepository.Table<SubscribeLabel>()
                              select new SubscribeLabelModel()
                              {
                                  Id = subscribeLabel.Id,
                                  Title = subscribeLabel.Title,
                                  InsertDate = subscribeLabel.InsertDate,
                              }).OrderByDescending(x => x.Id).ToPaginatedListAsync(dataGrid);

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<SubscribeLabelModel>>> GetListForSelect()
        {
            var result = new Result<List<SubscribeLabelModel>>();

            var list = await _queryRepository.Table<SubscribeLabel>().Select(x => new SubscribeLabelModel()
            {
                Id = x.Id,
                Title = x.Title,
                InsertDate = x.InsertDate,
            }).ToListAsync();

            result.Data = list;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<SubscribeLabelModel>> GetById(int id)
        {
            var result = new Result<SubscribeLabelModel>();
            var subscribeLabel = await _queryRepository.Table<SubscribeLabel>().FirstAsync(x => x.Id == id);

            var subscribeLabelModel = new SubscribeLabelModel()
            {
                Id = subscribeLabel.Id,
                Title = subscribeLabel.Title,
                InsertDate = subscribeLabel.InsertDate
            };
            result.Data = subscribeLabelModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeLabelModel"></param>
        /// <returns></returns>
        public async Task<Result<SubscribeLabelModel>> Add(SubscribeLabelModel subscribeLabelModel)
        {
            var result = new Result<SubscribeLabelModel>();
            try
            {
                var isExist = await _queryRepository.Table<SubscribeLabel>().AnyAsync(x => x.Title == subscribeLabelModel.Title);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Title already exist";
                    result.Errors.Add(new Error(nameof(subscribeLabelModel.Id), "The Title already exist"));
                    return result;
                }
                var subscribeLabel = new SubscribeLabel
                {
                    Title = subscribeLabelModel.Title,
                    InsertDate = DateTime.Now
                };

                await _commandRepository.InsertAsync(subscribeLabel);
                await _commandRepository.SaveChangesAsync();

                subscribeLabelModel.Id = subscribeLabel.Id;

                result.Data = subscribeLabelModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribeLabelModel"></param>
        /// <returns></returns>
        public async Task<Result<SubscribeLabelModel>> Update(SubscribeLabelModel subscribeLabelModel)
        {
            var result = new Result<SubscribeLabelModel>();
            try
            {
                var subscribeLabel = await _queryRepository.Table<SubscribeLabel>().FirstOrDefaultAsync(x => x.Id == subscribeLabelModel.Id);
                if (subscribeLabel is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The SubscribeLabel not found";
                    return result;
                }
                var isExist = await _queryRepository.Table<SubscribeLabel>().AnyAsync(x => x.Id != subscribeLabelModel.Id && x.Title == subscribeLabelModel.Title);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Title already exist";
                    result.Errors.Add(new Error(nameof(subscribeLabelModel.Id), "The Title already exist"));
                    return result;
                }

                subscribeLabel.Title = subscribeLabelModel.Title;
                _commandRepository.UpdateAsync(subscribeLabel);

                await _commandRepository.SaveChangesAsync();

                result.Data = subscribeLabelModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var subscribeLabel = await _queryRepository.Table<SubscribeLabel>().Include(x => x.Subscribes).FirstOrDefaultAsync(x => x.Id == id);
            if (subscribeLabel is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The SubscribeLabel not found";
                return result;
            }

            if (subscribeLabel.Subscribes.Any())
            {
                result.Status = ResultStatusEnum.InvalidValidation;
                result.Message = "The SubscribeLabel Has Any Child";
                return result;
            }
            _commandRepository.DeleteAsync(subscribeLabel);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}