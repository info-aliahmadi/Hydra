using Hydra.Crm.Core.Domain.Message;
using Hydra.Crm.Core.Interfaces;
using Hydra.Crm.Core.Models.Message;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Crm.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;


        public MessageService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetAllMessages(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<MessageModel>>();
            try
            {
                var list = await (from message in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.MessageUsers).ThenInclude(x => x.ToUser)
                                  select new MessageModel()
                                  {
                                      Id = message.Id,
                                      MessageType = message.MessageType,
                                      Name = message.Name,
                                      Subject = message.Subject,
                                      Content = message.Content,
                                      RegisterDate = message.RegisterDate,
                                      IsDraft = message.IsDraft,
                                      IsDeleted = message.IsDeleted,
                                      FromUserId = message.FromUserId,
                                      FromUser = new AuthorModel()
                                      {
                                          Id = message.FromUser.Id,
                                          Name = message.FromUser.Name,
                                          UserName = message.FromUser.UserName,
                                          Avatar = message.FromUser.Avatar
                                      },
                                      ToUsers = message.MessageUsers.Select(x => new MessageUserModel()
                                      {
                                          ToUserId = x.ToUserId,
                                          IsRead = x.IsRead,
                                          IsDeleted = x.IsDeleted,
                                          IsPin = x.IsPin,
                                          ToUser = new AuthorModel()
                                          {
                                              Id = x.ToUser.Id,
                                              Name = x.ToUser.Name,
                                              UserName = x.ToUser.UserName,
                                              Avatar = x.ToUser.Avatar
                                          }
                                      }).ToList(),
                                      //Attachments = message.MessageAttachments.Select(x => x.AttachmentId).ToList()

                                  }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


                result.Data = list;

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
        /// <param name="dataGrid"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetInbox(GridDataBound dataGrid, int toUserId)
        {
            var result = new Result<PaginatedList<MessageModel>>();

            try
            {
                var list = await (from user in _queryRepository.Table<MessageUser>().Include(x => x.ToUser)
                                  join message in _queryRepository.Table<Message>().Include(x => x.FromUser) on user.MessageId equals message.Id into messages
                                  from userMessage in messages.DefaultIfEmpty()
                                  where user.ToUserId == toUserId && user.IsDeleted == false && userMessage.IsDraft == false && userMessage.IsDeleted == false && userMessage.MessageType != MessageType.Public
                                  select new MessageModel()
                                  {
                                      Id = userMessage.Id,
                                      MessageType = userMessage.MessageType,
                                      Name = userMessage.Name,
                                      Subject = userMessage.Subject,
                                      Content = userMessage.Content,
                                      RegisterDate = userMessage.RegisterDate,
                                      IsDraft = userMessage.IsDraft,
                                      FromUserId = userMessage.FromUserId,
                                      FromUser = new AuthorModel()
                                      {
                                          Id = userMessage!.FromUser!.Id,
                                          Name = userMessage!.FromUser!.Name,
                                          UserName = userMessage!.FromUser!.UserName,
                                          Avatar = userMessage!.FromUser!.Avatar
                                      },
                                      ToUser = new MessageUserModel()
                                      {
                                          ToUserId = user.ToUserId,
                                          IsDeleted = user.IsDeleted,
                                          IsRead = user.IsRead,
                                          IsPin = user.IsPin
                                      }

                                  }).OrderByDescending(x => x.ToUser.IsPin).ThenByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


                result.Data = list;

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
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetPublicInbox(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<MessageModel>>();
            try
            {

                var list = await (from message in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.MessageAttachments)
                                  where message.IsDeleted == false && message.IsDraft == false && message.MessageType == MessageType.Public
                                  select new MessageModel()
                                  {
                                      Id = message.Id,
                                      MessageType = message.MessageType,
                                      Name = message.Name,
                                      Subject = message.Subject,
                                      Content = message.Content,
                                      RegisterDate = message.RegisterDate,
                                      IsDraft = message.IsDraft,
                                      IsDeleted = message.IsDeleted,
                                      FromUserId = message.FromUserId,
                                      FromUser = new AuthorModel()
                                      {
                                          Id = message!.FromUser!.Id,
                                          Name = message!.FromUser!.Name,
                                          UserName = message!.FromUser!.UserName,
                                          Avatar = message!.FromUser!.Avatar
                                      },

                                  }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


                result.Data = list;

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
        /// <param name="dataGrid"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetDeletedInbox(GridDataBound dataGrid, int toUserId)
        {
            var result = new Result<PaginatedList<MessageModel>>();
            try
            {

                var list = await (from user in _queryRepository.Table<MessageUser>().Include(x => x.ToUser)
                                  join message in _queryRepository.Table<Message>().Include(x => x.FromUser) on user.MessageId equals message.Id into messages
                                  from userMessage in messages.DefaultIfEmpty()
                                  where user.ToUserId == toUserId && user.IsDeleted == true && userMessage.IsDraft == false && userMessage.MessageType != MessageType.Public
                                  select new MessageModel()
                                  {
                                      Id = userMessage.Id,
                                      MessageType = userMessage.MessageType,
                                      Name = userMessage.Name,
                                      Subject = userMessage.Subject,
                                      Content = userMessage.Content,
                                      RegisterDate = userMessage.RegisterDate,
                                      IsDraft = userMessage.IsDraft,
                                      IsDeleted = userMessage.IsDeleted,
                                      FromUserId = userMessage.FromUserId,
                                      FromUser = new AuthorModel()
                                      {
                                          Id = userMessage!.FromUser!.Id,
                                          Name = userMessage!.FromUser!.Name,
                                          UserName = userMessage!.FromUser!.UserName,
                                          Avatar = userMessage!.FromUser!.Avatar
                                      },
                                      ToUser = new MessageUserModel()
                                      {
                                          ToUserId = user.ToUserId,
                                          IsDeleted = user.IsDeleted,
                                          IsRead = user.IsRead,
                                          IsPin = user.IsPin
                                      }

                                  }).OrderByDescending(x => x.ToUser.IsPin).ThenByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


                result.Data = list;

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
        /// <param name="dataGrid"></param>
        /// <param name="fromUserId"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetSent(GridDataBound dataGrid, int fromUserId)
        {
            var result = new Result<PaginatedList<MessageModel>>();
            try
            {

                var list = await (from message in _queryRepository.Table<Message>().Include(x => x.MessageUsers).ThenInclude(x => x.ToUser)
                                  where message.FromUserId == fromUserId && message.IsDeleted == false
                                  select new MessageModel()
                                  {
                                      Id = message.Id,
                                      MessageType = message.MessageType,
                                      Subject = message.Subject,
                                      Content = message.Content,
                                      RegisterDate = message.RegisterDate,
                                      IsDraft = message.IsDraft,
                                      IsDeleted = message.IsDeleted,
                                      FromUserId = message.FromUserId,
                                      //ToUsers = message.MessageUsers!.Select(x => new MessageUserModel()
                                      //{
                                      //    ToUserId = x.ToUserId,
                                      //    IsRead = x.IsRead,
                                      //    ToUser = new AuthorModel()
                                      //    {
                                      //        Id = x.ToUser.Id,
                                      //        Name = x.ToUser.Name,
                                      //        UserName = x!.ToUser!.UserName,
                                      //        Avatar = x.ToUser.Avatar
                                      //    }
                                      //}).ToList(),

                                  }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


                result.Data = list;

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
        /// <param name="dataGrid"></param>
        /// <param name="fromUserId"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<MessageModel>>> GetDeletedSent(GridDataBound dataGrid, int fromUserId)
        {
            var result = new Result<PaginatedList<MessageModel>>();
            try
            {

                var list = await (from message in _queryRepository.Table<Message>().Include(x => x.MessageUsers).ThenInclude(x => x.ToUser)
                                  where message.FromUserId == fromUserId && message.IsDeleted == true
                                  select new MessageModel()
                                  {
                                      Id = message.Id,
                                      MessageType = message.MessageType,
                                      Subject = message.Subject,
                                      Content = message.Content,
                                      RegisterDate = message.RegisterDate,
                                      IsDraft = message.IsDraft,
                                      IsDeleted = message.IsDeleted,
                                      FromUserId = message.FromUserId
                                  }).OrderByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


                result.Data = list;

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
        public async Task<Result<MessageModel>> GetByIdForPublic(int messageId)
        {
            var result = new Result<MessageModel>();
            try
            {
                var messageModel = (from user in _queryRepository.Table<MessageUser>().Include(x => x.ToUser)
                                    join msg in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.MessageAttachments) on user.MessageId equals msg.Id into messages
                                    from userMessage in messages.DefaultIfEmpty()
                                    where userMessage.MessageType == MessageType.Public && userMessage.Id == messageId
                                    select new MessageModel()
                                    {
                                        Id = userMessage.Id,
                                        MessageType = userMessage.MessageType,
                                        Name = userMessage.Name,
                                        Subject = userMessage.Subject,
                                        Content = userMessage.Content,
                                        RegisterDate = userMessage.RegisterDate,
                                        IsDraft = userMessage.IsDraft,
                                        IsDeleted = userMessage.IsDeleted,
                                        FromUserId = userMessage.FromUserId,
                                        Attachments = userMessage.MessageAttachments.Select(x => x.AttachmentId).ToList(),
                                        FromUser = new AuthorModel()
                                        {
                                            Id = userMessage!.FromUser!.Id,
                                            Name = userMessage!.FromUser!.Name,
                                            UserName = userMessage!.FromUser!.UserName,
                                            Avatar = userMessage!.FromUser!.Avatar
                                        },
                                        ToUser = new MessageUserModel()
                                        {
                                            ToUserId = user.ToUserId,
                                            IsDeleted = user.IsDeleted,
                                            IsRead = user.IsRead,
                                            IsPin = user.IsPin
                                        },

                                    }).FirstOrDefault();

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
        public async Task<Result<MessageModel>> GetByIdForSender(int messageId, int fromUserId)
        {
            var result = new Result<MessageModel>();
            try
            {
                var messageModel = await (from user in _queryRepository.Table<MessageUser>().Include(x => x.ToUser)
                                          join msg in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.MessageAttachments) on user.MessageId equals msg.Id into messages
                                          from userMessage in messages.DefaultIfEmpty()
                                          where userMessage.FromUserId == fromUserId && userMessage.Id == messageId
                                          select new MessageModel()
                                          {
                                              Id = userMessage.Id,
                                              MessageType = userMessage.MessageType,
                                              Name = userMessage.Name,
                                              Subject = userMessage.Subject,
                                              Content = userMessage.Content,
                                              RegisterDate = userMessage.RegisterDate,
                                              IsDraft = userMessage.IsDraft,
                                              IsDeleted = userMessage.IsDeleted,
                                              FromUserId = userMessage.FromUserId,
                                              Attachments = userMessage.MessageAttachments.Select(x => x.AttachmentId).ToList(),
                                              FromUser = new AuthorModel()
                                              {
                                                  Id = userMessage!.FromUser!.Id,
                                                  Name = userMessage!.FromUser!.Name,
                                                  UserName = userMessage!.FromUser!.UserName,
                                                  Avatar = userMessage!.FromUser!.Avatar
                                              },
                                              ToUser = new MessageUserModel()
                                              {
                                                  ToUserId = user.ToUserId,
                                                  IsDeleted = user.IsDeleted,
                                                  IsRead = user.IsRead,
                                                  IsPin = user.IsPin
                                              }

                                          }).FirstOrDefaultAsync();

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
        public async Task<Result<MessageModel>> GetByIdForReceiver(int messageId, int toUserId)
        {
            var result = new Result<MessageModel>();
            try
            {
                var messageModel = await (from user in _queryRepository.Table<MessageUser>().Include(x => x.ToUser)
                                          join msg in _queryRepository.Table<Message>().Include(x => x.FromUser).Include(x => x.MessageAttachments) on user.MessageId equals msg.Id into messages
                                          from userMessage in messages.DefaultIfEmpty()
                                          where user.ToUserId == toUserId && user.IsDeleted == false && userMessage.IsDraft == false && userMessage.Id == messageId
                                          select new MessageModel()
                                          {
                                              Id = userMessage.Id,
                                              MessageType = userMessage.MessageType,
                                              Name = userMessage.Name,
                                              Subject = userMessage.Subject,
                                              Content = userMessage.Content,
                                              RegisterDate = userMessage.RegisterDate,
                                              IsDraft = userMessage.IsDraft,
                                              IsDeleted = userMessage.IsDeleted,
                                              FromUserId = userMessage.FromUserId,
                                              Attachments = userMessage.MessageAttachments.Select(x => x.AttachmentId).ToList(),
                                              FromUser = new AuthorModel()
                                              {
                                                  Id = userMessage!.FromUser!.Id,
                                                  Name = userMessage!.FromUser!.Name,
                                                  UserName = userMessage!.FromUser!.UserName,
                                                  Avatar = userMessage!.FromUser!.Avatar
                                              },
                                              ToUser = new MessageUserModel()
                                              {
                                                  ToUserId = user.ToUserId,
                                                  IsDeleted = user.IsDeleted,
                                                  IsRead = user.IsRead,
                                                  IsPin = user.IsPin
                                              }

                                          }).FirstOrDefaultAsync();

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
        /// <param name="emailOutboxModel"></param>
        /// <returns></returns>
        public async Task<Result<MessageModel>> Send(MessageModel messageModel, int currentUserId)
        {
            var result = new Result<MessageModel>();
            try
            {
                messageModel.IsDraft = false;
                // Add Or Update
                if (messageModel.Id > 0)
                {
                    await Update(messageModel, currentUserId);
                }
                else
                {
                    await Add(messageModel);
                }

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
        /// <param name="emailOutboxModel"></param>
        /// <returns></returns>
        public async Task<Result<MessageModel>> SaveDraft(MessageModel messageModel, int currentUserId)
        {
            var result = new Result<MessageModel>();
            try
            {
                messageModel.IsDraft = true;
                // Add Or Update
                if (messageModel.Id > 0)
                {
                    await Update(messageModel, currentUserId);
                }
                else
                {
                    await Add(messageModel);
                }

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
        public async Task<Result<MessageModel>> Add(MessageModel messageModel)
        {
            var result = new Result<MessageModel>();
            try
            {
                var dateTime = DateTime.UtcNow;
                bool isExist = await _queryRepository.Table<Message>().AnyAsync(x => x.Name == messageModel.Name && x.Email == messageModel.Email && x.Subject == messageModel.Subject && x.Content == messageModel.Content);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Message already exist";
                    result.Errors.Add(new Error(nameof(messageModel.Subject), "The Message already exist"));
                    return result;
                }


                var message = new Message()
                {
                    MessageType = messageModel.MessageType,
                    IsDraft = messageModel.IsDraft,
                    IsDeleted = false,
                    Subject = messageModel.Subject,
                    Content = messageModel.Content,
                    RegisterDate = dateTime
                };

                if (messageModel.FromUserId != null)
                {
                    message.FromUserId = messageModel.FromUserId;
                }
                else
                {
                    message.Name = messageModel.Name;
                    message.Email = messageModel.Email;
                }


                await _commandRepository.InsertAsync(message);

                await _commandRepository.SaveChangesAsync();


                // Add Message Receivers
                var messageUsers = new List<MessageUser>();

                foreach (var userId in messageModel.ToUsers.Select(x => x.ToUserId).Distinct())
                {
                    messageUsers.Add(new MessageUser()
                    {
                        MessageId = message.Id,
                        ToUserId = userId,
                        IsRead = false,
                        IsDeleted = false,
                        IsPin = false
                    });
                }
                await _commandRepository.InsertAsync(messageUsers);

                // Add Message Attachments
                var messageAttachments = new List<MessageAttachment>();

                foreach (var attachmentId in messageModel.Attachments.Distinct())
                {
                    messageAttachments.Add(new MessageAttachment()
                    {
                        MessageId = message.Id,
                        AttachmentId = attachmentId
                    });
                }
                await _commandRepository.InsertAsync(messageAttachments);


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
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<Result<MessageModel>> Update(MessageModel messageModel, int currentUserId)
        {
            var result = new Result<MessageModel>();
            try
            {
                var dateTime = DateTime.UtcNow;
                if (messageModel.FromUserId == null)
                {
                    bool isExist = await _queryRepository.Table<Message>().AnyAsync(x => x.Email == messageModel.Email && x.Subject == messageModel.Subject && x.Name == messageModel.Name && x.Content == messageModel.Content);
                    if (isExist)
                    {
                        result.Status = ResultStatusEnum.ItsDuplicate;
                        result.Message = "The Message already exist";
                        result.Errors.Add(new Error(nameof(messageModel.Subject), "The Message already exist"));
                        return result;
                    }
                }

                var message = await _queryRepository.Table<Message>().Include(x => x.MessageUsers).FirstAsync(x => x.Id == messageModel.Id && x.FromUserId == currentUserId);
                if (message is null)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The message not found";
                    result.Errors.Add(new Error(nameof(messageModel.Subject), "The message not found"));
                    return result;
                }

                // if message was sent no longer allowed to edit
                if (!message.IsDraft)
                {

                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = "Not allowed to update message was sent";
                    return result;
                }

                bool isEdited = false;
                // Prevent Unnecessary Update
                if (message.Subject != messageModel.Subject)
                {
                    message.Subject = messageModel.Subject;
                    isEdited = true;
                }
                if (message.Content != messageModel.Content)
                {
                    message.Content = messageModel.Content;
                    isEdited = true;
                }

                if (isEdited)
                    _commandRepository.UpdateAsync(message);


                // Update Users Receive Message
                var existedUsersIds = message.MessageUsers.Select(x => x.ToUserId);

                var newUsersIds = messageModel.ToUsers.Select(x => x.ToUserId);

                if (existedUsersIds != newUsersIds)
                {

                    foreach (var user in message.MessageUsers)
                    {
                        _commandRepository.DeleteAsync(user);
                    }

                    foreach (var user in messageModel.ToUsers)
                    {
                        await _commandRepository.InsertAsync(new MessageUser()
                        {
                            MessageId = message.Id,
                            ToUserId = user.ToUserId,
                            IsRead = false,
                            IsDeleted = false,
                            IsPin = false
                        });
                    }

                    await _commandRepository.SaveChangesAsync();
                }

                // Update Attachments
                var existedAttachmentIds = message.MessageAttachments.Select(x => x.AttachmentId);

                if (existedAttachmentIds != messageModel.Attachments)
                {
                    foreach (var attachment in message.MessageAttachments)
                    {
                        _commandRepository.DeleteAsync(attachment);
                    }

                    foreach (var attachmentId in messageModel.Attachments)
                    {
                        await _commandRepository.InsertAsync(new MessageAttachment()
                        {
                            MessageId = message.Id,
                            AttachmentId = attachmentId
                        });
                    }

                    await _commandRepository.SaveChangesAsync();
                }


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
        public async Task<Result> DeleteDraft(int messageId, int currentUserId)
        {
            var result = new Result();
            try
            {
                var message = await _queryRepository.Table<Message>().FirstOrDefaultAsync(x => x.Id == messageId && x.FromUserId == currentUserId);
                if (message is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Message not found";
                    return result;
                }
                if (!message.IsDraft)
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = "Not allowed to delete message was sent";
                    return result;
                }
                message.IsDeleted = true;

                _commandRepository.SaveChanges();

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
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int messageId, int currentUserId)
        {
            var result = new Result();
            try
            {
                var messageUser = await _queryRepository.Table<MessageUser>().FirstOrDefaultAsync(x => x.MessageId == messageId && x.ToUserId == currentUserId);
                if (messageUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Message not found";
                    return result;
                }
                messageUser.IsDeleted = true;

                _commandRepository.SaveChanges();

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
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<Result> Pin(int messageId, int currentUserId)
        {
            var result = new Result();
            try
            {
                var messageUser = await _queryRepository.Table<MessageUser>().FirstOrDefaultAsync(x => x.MessageId == messageId && x.ToUserId == currentUserId);
                if (messageUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Message not found";
                    return result;
                }
                messageUser.IsPin = !messageUser.IsPin;

                _commandRepository.SaveChanges();

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
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<Result> Read(int messageId, int currentUserId)
        {
            var result = new Result();
            try
            {
                var messageUser = await _queryRepository.Table<MessageUser>().FirstOrDefaultAsync(x => x.MessageId == messageId && x.ToUserId == currentUserId);
                if (messageUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Message not found";
                    return result;
                }
                messageUser.IsRead = true;

                _commandRepository.SaveChanges();

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
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<Result> Remove(int messageId, int currentUserId)
        {
            var result = new Result();
            try
            {
                var message = await _queryRepository.Table<Message>().FirstOrDefaultAsync(x => x.Id == messageId && x.FromUserId == currentUserId);
                if (message is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Message not found";
                    return result;
                }
                if (!message.IsDraft)
                {
                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = "Not allowed to delete message was sent";
                    return result;
                }


                var messageUser = _queryRepository.Table<MessageUser>().Where(x => x.Id == messageId);

                foreach (var user in messageUser)
                {
                    _commandRepository.DeleteAsync(user);
                }

                var messageAttachment = _queryRepository.Table<MessageAttachment>().Where(x => x.Id == messageId);

                foreach (var attachment in messageAttachment)
                {
                    _commandRepository.DeleteAsync(attachment);
                }

                _commandRepository.DeleteAsync(message);

                await _commandRepository.SaveChangesAsync();

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

    }
}