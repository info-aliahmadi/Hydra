
using Hydra.Crm.Core.Domain.Email;
using Hydra.Crm.Core.Interfaces;
using Hydra.Crm.Core.Models.Email;
using Hydra.FileStorage.Core.Interfaces;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Email.Models;
using Hydra.Infrastructure.Email.Service;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Hydra.Crm.Api.Services
{
    public class EmailOutboxService : IEmailOutboxService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly IEmailService _emailService;
        private readonly IFileStorageService _fileStorageService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryRepository"></param>
        /// <param name="commandRepository"></param>
        /// <param name="emailService"></param>
        /// <param name="fileStorageService"></param>
        public EmailOutboxService(IQueryRepository queryRepository, ICommandRepository commandRepository, IEmailService emailService, IFileStorageService fileStorageService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _emailService = emailService;
            _fileStorageService = fileStorageService;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<EmailOutboxModel>>> GetAllEmailOutbox(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<EmailOutboxModel>>();
            try
            {
                var list = await (from emailInbox in _queryRepository.Table<EmailOutbox>().Include(x => x.EmailOutboxToAddress).Include(x => x.EmailOutboxFromAddress)
                                  select new EmailOutboxModel()
                                  {
                                      Id = emailInbox.Id,
                                      Subject = emailInbox.Subject,
                                      Content = emailInbox.Content,
                                      RegisterDate = emailInbox.RegisterDate,
                                      IsDraft = emailInbox.IsDraft,
                                      FromAddress = emailInbox.EmailOutboxFromAddress.Select(x => x.Address).ToList(),
                                      ToAddress = emailInbox.EmailOutboxFromAddress.Select(x => x.Address).ToList(),

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
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<EmailOutboxModel>>> GetOutbox(GridDataBound dataGrid, string emailAddress)
        {
            var result = new Result<PaginatedList<EmailOutboxModel>>();

            try
            {
                var list = await (from fromAddress in _queryRepository.Table<EmailOutboxFromAddress>()
                                  join emailInbox in _queryRepository.Table<EmailOutbox>().Include(x => x.EmailOutboxToAddress).Include(x => x.EmailOutboxFromAddress)
                                  on fromAddress.EmailOutboxId equals emailInbox.Id into emailInboxs
                                  from userEmailInbox in emailInboxs.DefaultIfEmpty()
                                  where fromAddress.Address == emailAddress
                                  select new EmailOutboxModel()
                                  {
                                      Id = userEmailInbox.Id,
                                      Subject = userEmailInbox.Subject,
                                      ReplayToId = userEmailInbox.ReplayToId,
                                      Content = userEmailInbox.Content,
                                      RegisterDate = userEmailInbox.RegisterDate,
                                      IsDraft = userEmailInbox.IsDraft,
                                      FromAddress = userEmailInbox.EmailOutboxFromAddress.Select(x => x.Address).ToList(),
                                      ToAddress = userEmailInbox.EmailOutboxFromAddress.Select(x => x.Address).ToList(),

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
        /// <returns></returns>
        public Result<List<string>> GetAddressForSelect()
        {
            var result = new Result<List<string>>();

            var list = _queryRepository.Table<EmailOutboxToAddress>().Select(x => x.Address).Distinct().ToList();

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<EmailOutboxModel>> GetByIdForSender(int emailOutboxId, string emailAddress)
        {
            var result = new Result<EmailOutboxModel>();
            try
            {
                var emailOutboxModel = await (from fromAddress in _queryRepository.Table<EmailOutboxFromAddress>()
                                              join emailInbox in _queryRepository.Table<EmailOutbox>().Include(x => x.EmailOutboxToAddress).Include(x => x.EmailOutboxFromAddress)
                                              on fromAddress.EmailOutboxId equals emailInbox.Id into emailInboxs
                                              from userEmailInbox in emailInboxs.DefaultIfEmpty()
                                              where fromAddress.Address == emailAddress && userEmailInbox.Id == emailOutboxId
                                              select new EmailOutboxModel()
                                              {
                                                  Id = userEmailInbox.Id,
                                                  Subject = userEmailInbox.Subject,
                                                  ReplayToId = userEmailInbox.ReplayToId,
                                                  Content = userEmailInbox.Content,
                                                  RegisterDate = userEmailInbox.RegisterDate,
                                                  IsDraft = userEmailInbox.IsDraft,
                                                  FromAddress = userEmailInbox.EmailOutboxFromAddress.Select(x => x.Address).ToList(),
                                                  ToAddress = userEmailInbox.EmailOutboxToAddress.Select(x => x.Address).ToList(),

                                              }).FirstOrDefaultAsync();

                result.Data = emailOutboxModel;

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
        /// <param name="fromUser"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<Result<EmailOutboxModel>> Send(EmailOutboxModel emailOutboxModel, AuthorModel fromUser, HttpContext context)
        {
            var result = new Result<EmailOutboxModel>();
            try
            {
                var dateTime = DateTime.UtcNow;

                // Add Current User Email to Senders if not Exist
                if (!emailOutboxModel.FromAddress.Any(x => x == fromUser.Email))
                {
                    emailOutboxModel.FromAddress.Add(fromUser.Email);
                }

                try
                {
                    // SMTP Operation
                    var email = new EmailMessage()
                    {
                        Date = dateTime.Date,
                        Subject = emailOutboxModel.Subject,
                        Content = emailOutboxModel.Content,
                        FromAddresses = emailOutboxModel.FromAddress.Distinct().Select(x => new EmailAddress()
                        {
                            Name = x,
                            Address = x
                        }).ToList(),
                        ToAddresses = emailOutboxModel.ToAddress.Distinct().Select(x => new EmailAddress()
                        {
                            Name = x,
                            Address = x
                        }).ToList(),
                    };
                    if (emailOutboxModel.Attachments.Any())
                    {
                        foreach (var attach in emailOutboxModel.Attachments)
                        {
                            var fileInfo = _fileStorageService.GetFileInfoById(attach).Result.Data;
                            var path = HydraHelper.GetUploadsDirectory() + fileInfo.Directory + "/" + fileInfo.FileName;
                            email.AttachmentPaths.Add(path);
                        }
                    }

                    _emailService.Send(email);


                    // Add Or Update
                    if (emailOutboxModel.Id > 0)
                    {
                        await Update(emailOutboxModel, fromUser.Email);
                    }
                    else
                    {
                        await Add(emailOutboxModel);
                    }

                }
                catch
                {
                    // If SMTP Operation failed take another chance to try again send the message
                    //var emailOutbox = await _queryRepository.Table<EmailOutbox>().FirstAsync(x => x.Id == emailOutboxModel.Id);
                    //emailOutbox.IsDraft = true;
                    //await _commandRepository.SaveChangesAsync();

                    result.Message = "SMTP Operation Failed";
                    result.Status = ResultStatusEnum.ExceptionThrowed;
                    return result;
                }



                result.Data = emailOutboxModel;

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
        /// <param name="fromUser"></param>
        /// <returns></returns>
        public async Task<Result<EmailOutboxModel>> SaveDraft(EmailOutboxModel emailOutboxModel, AuthorModel fromUser)
        {
            var result = new Result<EmailOutboxModel>();
            try
            {
                var dateTime = DateTime.UtcNow;

                // Add Current User Email to Senders if not Exist
                if (!emailOutboxModel.FromAddress.Any(x => x == fromUser.Email))
                {
                    emailOutboxModel.FromAddress.Add(fromUser.Email);
                }

                // Add Or Update
                if (emailOutboxModel.Id > 0)
                {
                    await Update(emailOutboxModel, fromUser.Email);
                }
                else
                {
                    await Add(emailOutboxModel);
                }

                result.Data = emailOutboxModel;

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
        public async Task<Result<EmailOutboxModel>> Add(EmailOutboxModel emailOutboxModel)
        {
            var result = new Result<EmailOutboxModel>();
            try
            {
                var dateTime = DateTime.UtcNow;

                // Save in Database Operation
                var emailOutbox = new EmailOutbox()
                {
                    IsDraft = emailOutboxModel.IsDraft,
                    Subject = emailOutboxModel.Subject,
                    Content = emailOutboxModel.Content,
                    RegisterDate = dateTime,
                    ReplayToId = emailOutboxModel.ReplayToId
                };


                await _commandRepository.InsertAsync(emailOutbox);

                await _commandRepository.SaveChangesAsync();


                // Add Email Senders
                foreach (var address in emailOutboxModel.FromAddress.Distinct())
                {
                    await _commandRepository.InsertAsync(new EmailOutboxFromAddress()
                    {
                        EmailOutboxId = emailOutbox.Id,
                        Name = address,
                        Address = address
                    });
                }
                // Add Email Receivers
                foreach (var address in emailOutboxModel.ToAddress.Distinct())
                {
                    await _commandRepository.InsertAsync(new EmailOutboxToAddress()
                    {
                        EmailOutboxId = emailOutbox.Id,
                        Name = address,
                        Address = address
                    });
                }

                // Add Email Attachments
                foreach (var attachment in emailOutboxModel.Attachments.Distinct())
                {
                    await _commandRepository.InsertAsync(new EmailOutboxAttachment()
                    {
                        EmailOutboxId = emailOutbox.Id,
                        AttachmentId = attachment
                    });
                }

                await _commandRepository.SaveChangesAsync();

                emailOutboxModel.Id = emailOutbox.Id;

                result.Data = emailOutboxModel;

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
        public async Task<Result<EmailOutboxModel>> Update(EmailOutboxModel emailOutboxModel, string fromEmail)
        {
            var result = new Result<EmailOutboxModel>();
            try
            {
                var dateTime = DateTime.UtcNow;

                var emailOutboxUser = await _queryRepository.Table<EmailOutboxFromAddress>().FirstOrDefaultAsync(x => x.EmailOutboxId == emailOutboxModel.Id && x.Address == fromEmail);
                if (emailOutboxUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Email not found";
                    return result;
                }

                var emailOutbox = await _queryRepository.Table<EmailOutbox>().Include(x => x.EmailOutboxFromAddress).Include(x => x.EmailOutboxToAddress).Include(x => x.EmailOutboxAttachments).FirstAsync(x => x.Id == emailOutboxModel.Id);

                // if emailOutbox was sent no longer allowed to delete
                if (!emailOutbox.IsDraft)
                {

                    result.Status = ResultStatusEnum.IsNotAllowed;
                    result.Message = "Not allowed to update email was sent";
                    return result;
                }

                bool isEdited = false;
                // Prevent Unnecessary Update
                if (emailOutbox.Subject != emailOutboxModel.Subject)
                {
                    emailOutbox.Subject = emailOutboxModel.Subject;
                    isEdited = true;
                }
                if (emailOutbox.Content != emailOutboxModel.Content)
                {
                    emailOutbox.Content = emailOutboxModel.Content;
                    isEdited = true;
                }

                if (isEdited)
                    _commandRepository.UpdateAsync(emailOutbox);


                // Update Email Senders
                var existedFromAddresses = emailOutbox.EmailOutboxFromAddress.Select(x => x.Address);

                var newFromAddresses = emailOutboxModel.FromAddress.Select(x => x);

                if (!existedFromAddresses.SequenceEqual(newFromAddresses))
                {

                    foreach (var fromAddress in emailOutbox.EmailOutboxFromAddress)
                    {
                        _commandRepository.DeleteAsync(fromAddress);
                    }

                    foreach (var fromAddress in emailOutboxModel.FromAddress)
                    {
                        await _commandRepository.InsertAsync(new EmailOutboxFromAddress()
                        {
                            EmailOutboxId = emailOutbox.Id,
                            Name = fromAddress,
                            Address = fromAddress
                        });
                    }
                }

                // Update Email Receiver
                var existedToAddresses = emailOutbox.EmailOutboxToAddress.Select(x => x.Address);

                var newToAddresses = emailOutboxModel.ToAddress.Select(x => x);

                if (!existedToAddresses.SequenceEqual(newToAddresses))
                {

                    foreach (var toAddress in emailOutbox.EmailOutboxToAddress)
                    {
                        _commandRepository.DeleteAsync(toAddress);
                    }

                    foreach (var toAddress in emailOutboxModel.ToAddress)
                    {
                        await _commandRepository.InsertAsync(new EmailOutboxToAddress()
                        {
                            EmailOutboxId = emailOutbox.Id,
                            Name = toAddress,
                            Address = toAddress
                        });
                    }
                }
                // Update Attachments
                var existedAttachments = emailOutbox.EmailOutboxAttachments.Select(x => x.AttachmentId);

                var newAttachments = emailOutboxModel.Attachments.Select(x => x);

                if (!existedAttachments.SequenceEqual(newAttachments))
                {

                    foreach (var attachment in emailOutbox.EmailOutboxAttachments)
                    {
                        _commandRepository.DeleteAsync(attachment);
                    }

                    foreach (var attachment in emailOutboxModel.Attachments)
                    {
                        await _commandRepository.InsertAsync(new EmailOutboxAttachment()
                        {
                            EmailOutboxId = emailOutbox.Id,
                            AttachmentId = attachment
                        });
                    }
                }

                await _commandRepository.SaveChangesAsync();

                result.Data = emailOutboxModel;

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
        /// <param name="emailOutboxId"></param>
        /// <returns></returns>
        public async Task<Result> Remove(int emailOutboxId, string emailAddress)
        {
            var result = new Result();
            try
            {
                var emailOutboxUser = await _queryRepository.Table<EmailOutboxToAddress>().FirstOrDefaultAsync(x => x.EmailOutboxId == emailOutboxId && x.Address == emailAddress);
                if (emailOutboxUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Email not found";
                    return result;
                }


                var emailOutboxAttachment = _queryRepository.Table<EmailOutboxAttachment>().Where(x => x.Id == emailOutboxId);

                foreach (var attachment in emailOutboxAttachment)
                {
                    _commandRepository.DeleteAsync(attachment);
                }
                var emailOutboxToAddresses = _queryRepository.Table<EmailOutboxToAddress>().Where(x => x.Id == emailOutboxId);

                foreach (var emailOutboxToAddress in emailOutboxToAddresses)
                {
                    _commandRepository.DeleteAsync(emailOutboxToAddress);
                }
                var emailOutboxFromAddresses = _queryRepository.Table<EmailOutboxFromAddress>().Where(x => x.Id == emailOutboxId);

                foreach (var emailOutboxFromAddress in emailOutboxFromAddresses)
                {
                    _commandRepository.DeleteAsync(emailOutboxFromAddress);
                }


                var emailOutbox = _queryRepository.Table<EmailOutbox>().FirstOrDefault(x => x.Id == emailOutboxId);

                if (emailOutbox is not null)
                    _commandRepository.DeleteAsync(emailOutbox);


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