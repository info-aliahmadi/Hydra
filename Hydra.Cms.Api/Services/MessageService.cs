using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Cms.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly ITagService _tagService;

        public MessageService(IQueryRepository queryRepository, ICommandRepository commandRepository, ITagService tagService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _tagService = tagService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetInbox(GridDataBound dataGrid, int toUser,bool showAll)
        {
            var result = new Result<PaginatedList<MessageModel>>();

            var userService = new UserManager<User>();

            var list = await (from message in _queryRepository.Table<Message>().Include(x => x.Writer)
                              where message.to
                              select new MessageModel()
                              {
                                  Id = message.Id,
                                  Name = message.Name,
                                  Subject = message.Subject,
                                  Body = message.Body,
                                  RegisterDate = message.RegisterDate,
                                  IsRead = message.IsRead,
                                  WriterId = message.WriterId,
                                  Writer = new AuthorModel()
                                  {
                                      Id = message.Writer.Id,
                                      Name = message.Writer.Name,
                                      UserName = message.Writer.UserName,
                                      Avatar = message.Writer.Avatar
                                  }

                              }).OrderByDescending(x=>x.RegisterDate).ToPaginatedListAsync(dataGrid);


            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<MessageModel>> GetById(int id)
        {
            var result = new Result<MessageModel>();
            var message = await _queryRepository.Table<Message>().Include(x => x.Writer).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var messageModel = new MessageModel()
            {
                Id = message.Id,
                Name = message.Name,
                Subject = message.Subject,
                Body = message.Body,
                RegisterDate = message.RegisterDate,
                IsRead = message.IsRead,
                WriterId = message.WriterId,
                Writer = new AuthorModel()
                {
                    Id = message.Writer.Id,
                    Name = message.Writer.Name,
                    UserName = message.Writer.UserName,
                    Avatar = message.Writer.Avatar
                }
            };
            result.Data = messageModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageModel"></param>
        /// <returns></returns>
        public async Task<Result<MessageModel>> Add(MessageModel messageModel)
        {
            var result = new Result<MessageModel>();
            try
            {
                var dateTime =  DateTime.UtcNow;  
                if (messageModel.WriterId == null) {
                    var toTime = DateTime.UtcNow.AddSeconds(7);
                bool isExist = await _queryRepository.Table<Message>().AnyAsync(x => x.Email == messageModel.Email && x.RegisterDate >= dateTime && x.RegisterDate <= toTime);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Message already exist";
                    result.Errors.Add(new Error(nameof(messageModel.Subject), "The Message already exist"));
                    return result;
                }
                
                }
                var message = new Message()
                {
                    Name = messageModel.Name,
                    Subject = messageModel.Subject,
                    Body = messageModel.Body,
                    Email = messageModel.Email,
                    IsRead = false,
                    WriterId = messageModel.WriterId,
                    RegisterDate = dateTime
                };
                await _commandRepository.InsertAsync(message);

                await _commandRepository.SaveChangesAsync();

                messageModel.Id = message.Id;

                result.Data = messageModel;

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
        /// <param name="messageModel"></param>
        /// <returns></returns>
        public async Task<Result<MessageModel>> Update(MessageModel messageModel)
        {
            var result = new Result<MessageModel>();
            try
            {
                var dateTime = DateTime.UtcNow;
                if (messageModel.WriterId == null)
                {
                    var toTime = DateTime.UtcNow.AddSeconds(7);
                    bool isExist = await _queryRepository.Table<Message>().AnyAsync(x => x.Email == messageModel.Email && x.RegisterDate >= dateTime && x.RegisterDate <= toTime);
                    if (isExist)
                    {
                        result.Status = ResultStatusEnum.ItsDuplicate;
                        result.Message = "The Message already exist";
                        result.Errors.Add(new Error(nameof(messageModel.Subject), "The Message already exist"));
                        return result;
                    }

                }
                var message = await _queryRepository.Table<Message>().FirstAsync(x=>x.Id == messageModel.Id);

                message.Subject = messageModel.Subject;
                message.Body = messageModel.Body;

                await _commandRepository.InsertAsync(message);

                await _commandRepository.SaveChangesAsync();

                result.Data = messageModel;

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
            var message = await _queryRepository.Table<Message>().FirstOrDefaultAsync(x => x.Id == id);
            if (message is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Message not found";
                return result;
            }

            _commandRepository.DeleteAsync(message);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}