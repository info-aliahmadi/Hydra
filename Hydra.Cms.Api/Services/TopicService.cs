using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Hydra.Cms.Api.Services
{
    public class TopicService : ITopicService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public TopicService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<TopicModel>>> GetHierarchy()
        {
            var result = new Result<List<TopicModel>>();

            var list = await _queryRepository.Table<Topic>().Select(x => new TopicModel()
            {
                Id = x.Id,
                Title = x.Title,
                //Parent = x.Parent != null ? new TopicModel() { Id = x.ParentId ?? 0, Title = x.Parent.Title } : new TopicModel(),
                ParentId = x.ParentId
            }).ToListAsync();

            var parents = list.Where(x => x.ParentId == null).ToList();
            foreach (var topic in parents)
            {
                var childs = GetChild(topic, list);
                if (childs != null)
                {
                    topic.Childs.AddRange(childs);
                }
            }

            result.Data = parents;

            return result;
        }
        private List<TopicModel> GetChild(TopicModel topic, List<TopicModel> topics)
        {

            var result = topics.Where(x => x.ParentId == topic.Id).ToList();
            if (result.Count == 0) return null;
            foreach (var item in result)
            {
                var childs = GetChild(item, topics);
                if (childs != null)
                    item.Childs.AddRange(childs);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<TopicModel>>> GetListForSelect()
        {
            var result = new Result<List<TopicModel>>();

            var list = await _queryRepository.Table<Topic>().Select(x => new TopicModel()
            {
                Id = x.Id,
                Title = x.Title,
                //Parent = x.Parent != null ? new TopicModel() { Id = x.ParentId ?? 0, Title = x.Parent.Title } : new TopicModel(),
                ParentId = x.ParentId
            }).ToListAsync();

            var parents = list.Where(x => x.ParentId == null).ToList();

            foreach (var topic in parents)
            {
                GetChildOfSelect(topic, "", list);
            }

            result.Data = resultList;

            return result;
        }
        List<TopicModel> resultList = new List<TopicModel>();
        private List<TopicModel> GetChildOfSelect(TopicModel topic, string space, List<TopicModel> topics)
        {
            topic.Title = space + topic.Title;
            resultList.Add(topic);

            var childs = topics.Where(x => x.ParentId == topic.Id).ToList();
            if (childs.Count == 0)
            {
                return null;
            }
            foreach (var item in childs)
            {
                GetChildOfSelect(item, space + "    ", topics);
            }
            return childs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<TopicModel>> GetById(int id)
        {
            var result = new Result<TopicModel>();

            var record = await _queryRepository.Table<Topic>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var topic = new TopicModel();
            if (record != null)
            {
                topic.Id = record.Id;
                topic.Title = record.Title;
                topic.ParentId = record.ParentId;
            }
            result.Data = topic;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        public async Task<Result<TopicModel>> Add(TopicModel topicModel)
        {
            var result = new Result<TopicModel>();

            var isExist = await _queryRepository.Table<Topic>().AnyAsync(x => x.Title == topicModel.Title);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(topicModel.Title), "The topic name existed"));
                result.Message = "The topic existed";
                return result;
            }
            var regsterDate = DateTime.UtcNow;
            var topic = new Topic()
            {
                Id = topicModel.Id,
                Title = topicModel.Title,
                ParentId = topicModel.ParentId,
                UserId = topicModel.UserId,
                RegisterDate = regsterDate
            };
            await _commandRepository.InsertAsync(topic);

            await _commandRepository.SaveChangesAsync();
            var userName = _queryRepository.Table<User>().First(x => x.Id == topicModel.UserId).UserName;
            topicModel.Id = topic.Id;
            topicModel.UserId = topic.UserId;
            topicModel.UserName = userName;
            topicModel.RegisterDate = regsterDate;
            result.Data = topicModel;
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        public async Task<Result<TopicModel>> Update(TopicModel topicModel)
        {
            var result = new Result<TopicModel>();
            var topic = await _queryRepository.Table<Topic>().FirstOrDefaultAsync(x => x.Id == topicModel.Id);
            if (topic is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The topic not found";
                return result;
            }

            var isExist = await _queryRepository.Table<Topic>().AnyAsync(x => x.Id != topicModel.Id && x.Title == topicModel.Title);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(topicModel.Title), "The topic name existed"));
                result.Message = "The topic existed";
                return result;
            }

            var regsterDate = DateTime.UtcNow;

            topic.Title = topicModel.Title;
            topic.UserId = topic.UserId;
            topic.RegisterDate = regsterDate;

            _commandRepository.UpdateAsync(topic);

            await _commandRepository.SaveChangesAsync();

            var userName = _queryRepository.Table<User>().First(x => x.Id == topicModel.UserId).UserName;

            topicModel.UserName = userName;
            topicModel.RegisterDate = regsterDate;

            result.Data = topicModel;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var topic = await _queryRepository.Table<Topic>().FirstOrDefaultAsync(x => x.Id == id);
            if (topic == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The topic not found";
                return result;
            }

            if (_queryRepository.Table<Topic>().Any(x => x.ParentId == id))
            {
                result.Status = ResultStatusEnum.IsNotAllowed;
                result.Message = "Is Not Allowed. because this topic parent of another topic";
                return result;
            }

            _commandRepository.DeleteAsync(topic);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}