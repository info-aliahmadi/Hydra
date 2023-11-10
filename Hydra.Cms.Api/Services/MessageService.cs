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
        public async Task<Result<PaginatedList<MessageModel>>> GetAllMessages(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<MessageModel>>();

            var list = await (from message in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.ToUser)
                              select new MessageModel()
                              {
                                  Id = message.Id,
                                  Name = message.Name,
                                  Subject = message.Subject,
                                  Body = message.Body,
                                  RegisterDate = message.RegisterDate,
                                  IsRead = message.IsRead,
                                  FromUserId = message.FromUserId,
                                  FromUser = new AuthorModel()
                                  {
                                      Id = message.FromUser.Id,
                                      Name = message.FromUser.Name,
                                      UserName = message.FromUser.UserName,
                                      Avatar = message.FromUser.Avatar
                                  },
                                  ToUserId = message.ToUserId,
                                  ToUser = new AuthorModel()
                                  {
                                      Id = message.ToUser.Id,
                                      Name = message.ToUser.Name,
                                      UserName = message.ToUser.UserName,
                                      Avatar = message.ToUser.Avatar
                                  }

                              }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetInbox(GridDataBound dataGrid, int toUserId)
        {
            var result = new Result<PaginatedList<MessageModel>>();

            var list = await (from message in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.ToUser)
                              where message.ToUserId == toUserId
                              select new MessageModel()
                              {
                                  Id = message.Id,
                                  Name = message.Name,
                                  Subject = message.Subject,
                                  Body = message.Body,
                                  RegisterDate = message.RegisterDate,
                                  IsRead = message.IsRead,
                                  FromUserId = message.FromUserId,
                                  FromUser = new AuthorModel()
                                  {
                                      Id = message.FromUser.Id,
                                      Name = message.FromUser.Name,
                                      UserName = message.FromUser.UserName,
                                      Avatar = message.FromUser.Avatar
                                  },
                                  ToUserId = message.ToUserId,
                                  ToUser = new AuthorModel()
                                  {
                                      Id = message.ToUser.Id,
                                      Name = message.ToUser.Name,
                                      UserName = message.ToUser.UserName,
                                      Avatar = message.ToUser.Avatar
                                  }

                              }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetSent(GridDataBound dataGrid, int fromUserId)
        {
            var result = new Result<PaginatedList<MessageModel>>();

            var list = await (from message in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.ToUser)
                              where message.FromUserId == fromUserId
                              select new MessageModel()
                              {
                                  Id = message.Id,
                                  Name = message.Name,
                                  Subject = message.Subject,
                                  Body = message.Body,
                                  RegisterDate = message.RegisterDate,
                                  IsRead = message.IsRead,
                                  FromUserId = message.FromUserId,
                                  FromUser = new AuthorModel()
                                  {
                                      Id = message.FromUser.Id,
                                      Name = message.FromUser.Name,
                                      UserName = message.FromUser.UserName,
                                      Avatar = message.FromUser.Avatar
                                  },
                                  ToUserId = message.ToUserId,
                                  ToUser = new AuthorModel()
                                  {
                                      Id = message.ToUser.Id,
                                      Name = message.ToUser.Name,
                                      UserName = message.ToUser.UserName,
                                      Avatar = message.ToUser.Avatar
                                  }

                              }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


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
            var message = await _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.ToUser).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var messageModel = new MessageModel()
            {
                Id = message.Id,
                Name = message.Name,
                Subject = message.Subject,
                Body = message.Body,
                RegisterDate = message.RegisterDate,
                IsRead = message.IsRead,
                FromUserId = message.FromUserId,
                FromUser = new AuthorModel()
                {
                    Id = message.FromUser.Id,
                    Name = message.FromUser.Name,
                    UserName = message.FromUser.UserName,
                    Avatar = message.FromUser.Avatar
                },
                ToUserId = message.ToUserId,
                ToUser = new AuthorModel()
                {
                    Id = message.ToUser.Id,
                    Name = message.ToUser.Name,
                    UserName = message.ToUser.UserName,
                    Avatar = message.ToUser.Avatar
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
        public async Task<Result<MessageModel>> Send(MessageModel messageModel, bool isContactPage, int? fromUserId)
        {
            var result = new Result<MessageModel>();
            try
            {
                var dateTime = DateTime.UtcNow;
                bool isExist = await _queryRepository.Table<Message>().AnyAsync(x => x.Email == messageModel.Email && x.Subject == messageModel.Subject && x.Name == messageModel.Name && x.Body == messageModel.Body);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Message already exist";
                    result.Errors.Add(new Error(nameof(messageModel.Subject), "The Message already exist"));
                    return result;
                }


                var message = new Message()
                {
                    Name = messageModel.Name,
                    Subject = messageModel.Subject,
                    Body = messageModel.Body,
                    Email = messageModel.Email,
                    IsRead = false,
                    RegisterDate = dateTime
                };

                if (isContactPage)
                {
                    var adminUser

                }


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
                var message = await _queryRepository.Table<Message>().FirstAsync(x => x.Id == messageModel.Id);

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