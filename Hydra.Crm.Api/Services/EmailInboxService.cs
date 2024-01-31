
using Hydra.Crm.Core.Domain.Email;
using Hydra.Crm.Core.Interfaces;
using Hydra.Crm.Core.Models.Email;
using Hydra.FileStorage.Core.Interfaces;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Email.Service;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using static System.Net.Mime.MediaTypeNames;


namespace Hydra.Crm.Api.Services
{
    public class EmailInboxService : IEmailInboxService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        private readonly IEmailService _emailService;
        private readonly IFileStorageService _fileStorageService;


        public EmailInboxService(IQueryRepository queryRepository, ICommandRepository commandRepository, IEmailService emailService, IFileStorageService fileStorageService)
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
        public async Task<Result> LoadEmailInbox(int userId)
        {
            var result = new Result();
            try
            {
                var list = _emailService.ReceiveEmail();

                var UIDsList = list.Select(c => c.UID).ToArray();


                var existedUIDs = _queryRepository.Table<EmailInbox>().Where(x => UIDsList.Contains(x.UID)).Select(x=>x.UID);

                list = list.Where(x => !existedUIDs.Contains(x.UID)).ToList();

                var dateTime = DateTime.Now;
                foreach (var email in list)
                {
                    var emailInbox = new EmailInbox()
                    {
                        UID = email.UID,
                        Date = email.Date,
                        Subject = email.Subject,
                        Content = email.Content,
                        RegisterDate = dateTime
                    };

                    await _commandRepository.InsertAsync(emailInbox);

                    await _commandRepository.SaveChangesAsync();


                    // From Address
                    var fromAddresses = email.FromAddresses.Select(x => new EmailInboxFromAddress()
                    {
                        EmailInboxId = emailInbox.Id,
                        Name = x.Name,
                        Address = x.Address
                    });
                    foreach (var address in fromAddresses)
                    {
                        await _commandRepository.InsertAsync(address);
                    }

                    // To Address
                    var toAddresses = email.ToAddresses.Select(x => new EmailInboxToAddress()
                    {
                        EmailInboxId = emailInbox.Id,
                        Name = x.Name,
                        Address = x.Address
                    });
                    foreach (var address in toAddresses)
                    {
                        await _commandRepository.InsertAsync(address);
                    }

                    // Attachments
                    foreach (var attachment in email.Attachments)
                    {
                        var stream = new MemoryStream();
                        await ((MimePart)attachment).Content.DecodeToAsync(stream);
                        var attachmentUploaded = await _fileStorageService.UploadFromStreamAsync(userId, attachment.ContentType.Name, "Rename", FileStorage.Core.Settings.FileSizeEnum.Small, stream, attachment.ContentType.Name);
                        if (attachmentUploaded.Succeeded)
                        {
                            await _commandRepository.InsertAsync(new EmailInboxAttachment()
                            {
                                EmailInboxId = emailInbox.Id,
                                AttachmentId = attachmentUploaded.Data.Id,
                            });
                        }
                    }
                }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<EmailInboxModel>>> GetAllEmailInbox(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<EmailInboxModel>>();
            try
            {
                var list = await (from emailInbox in _queryRepository.Table<EmailInbox>().Include(x => x.EmailOutboxs).Include(x => x.EmailInboxToAddress).Include(x => x.EmailInboxFromAddress)
                                  where emailInbox.IsDeleted == false
                                  select new EmailInboxModel()
                                  {
                                      Id = emailInbox.Id,
                                      Subject = emailInbox.Subject,
                                      Content = emailInbox.Content,
                                      RegisterDate = emailInbox.RegisterDate,
                                      IsDeleted = emailInbox.IsDeleted,
                                      IsRead = emailInbox.IsRead,
                                      IsPin = emailInbox.IsPin,
                                      ReplayedOutboxId = emailInbox.EmailOutboxs.FirstOrDefault()!.Id,
                                      FromAddress = emailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxFromAddressModel()
                                      {
                                          Name = fromAddress.Name,
                                          Address = fromAddress.Address
                                      }).ToList(),
                                      ToAddress = emailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxToAddressModel()
                                      {
                                          Name = fromAddress.Name,
                                          Address = fromAddress.Address
                                      }).ToList(),
                                      HaveAttachment = emailInbox.EmailInboxAttachments.Any()

                                  }).OrderByDescending(x => x.IsPin).ThenByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


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
        public async Task<Result<PaginatedList<EmailInboxModel>>> GetInbox(GridDataBound dataGrid, string emailAddress)
        {
            var result = new Result<PaginatedList<EmailInboxModel>>();

            try
            {
                var list = await (from address in _queryRepository.Table<EmailInboxToAddress>()
                                  join emailInbox in _queryRepository.Table<EmailInbox>().Include(x => x.EmailOutboxs).Include(x => x.EmailInboxToAddress).Include(x => x.EmailInboxFromAddress)
                                  on address.EmailInboxId equals emailInbox.Id into emailInboxs
                                  from userEmailInbox in emailInboxs.DefaultIfEmpty()
                                  where userEmailInbox.IsDeleted == false && address.Address == emailAddress
                                  select new EmailInboxModel()
                                  {
                                      Id = userEmailInbox.Id,
                                      Subject = userEmailInbox.Subject,
                                      Content = userEmailInbox.Content,
                                      Date = userEmailInbox.Date,
                                      RegisterDate = userEmailInbox.RegisterDate,
                                      IsDeleted = userEmailInbox.IsDeleted,
                                      IsRead = userEmailInbox.IsRead,
                                      IsPin = userEmailInbox.IsPin,
                                      ReplayedOutboxId = userEmailInbox.EmailOutboxs.FirstOrDefault()!.Id,
                                      FromAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxFromAddressModel()
                                      {
                                          Name = fromAddress.Name,
                                          Address = fromAddress.Address
                                      }).ToList(),
                                      ToAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxToAddressModel()
                                      {
                                          Name = fromAddress.Name,
                                          Address = fromAddress.Address
                                      }).ToList(),
                                      HaveAttachment = userEmailInbox.EmailInboxAttachments.Any()

                                  }).OrderByDescending(x => x.IsPin).ThenByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


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
        public async Task<Result<PaginatedList<EmailInboxModel>>> GetDeletedInbox(GridDataBound dataGrid, string emailAddress)
        {
            var result = new Result<PaginatedList<EmailInboxModel>>();
            try
            {

                var list = await (from address in _queryRepository.Table<EmailInboxToAddress>()
                                  join emailInbox in _queryRepository.Table<EmailInbox>().Include(x => x.EmailOutboxs).Include(x => x.EmailInboxToAddress).Include(x => x.EmailInboxAttachments)
                                  on address.EmailInboxId equals emailInbox.Id into emailInboxs
                                  from userEmailInbox in emailInboxs.DefaultIfEmpty()
                                  where userEmailInbox.IsDeleted == true && address.Address == emailAddress
                                  select new EmailInboxModel()
                                  {
                                      Id = userEmailInbox.Id,
                                      Subject = userEmailInbox.Subject,
                                      Content = userEmailInbox.Content,
                                      Date = userEmailInbox.Date,
                                      RegisterDate = userEmailInbox.RegisterDate,
                                      IsDeleted = userEmailInbox.IsDeleted,
                                      IsRead = userEmailInbox.IsRead,
                                      IsPin = userEmailInbox.IsPin,
                                      ReplayedOutboxId = userEmailInbox.EmailOutboxs.FirstOrDefault()!.Id,
                                      FromAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxFromAddressModel()
                                      {
                                          Name = fromAddress.Name,
                                          Address = fromAddress.Address
                                      }).ToList(),
                                      ToAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxToAddressModel()
                                      {
                                          Name = fromAddress.Name,
                                          Address = fromAddress.Address
                                      }).ToList(),
                                      HaveAttachment = userEmailInbox.EmailInboxAttachments.Any()

                                  }).OrderByDescending(x => x.IsPin).ThenByDescending(x => x.RegisterDate).ToPaginatedListAsync(dataGrid);


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
        public async Task<Result<EmailInboxModel>> GetById(int id)
        {
            var result = new Result<EmailInboxModel>();
            try
            {
                var emailInboxModel = await (from address in _queryRepository.Table<EmailInboxToAddress>()
                                             join emailInbox in _queryRepository.Table<EmailInbox>().Include(x => x.EmailOutboxs).Include(x => x.EmailInboxToAddress).Include(x => x.EmailInboxFromAddress).Include(x => x.EmailInboxAttachments)
                                             on address.EmailInboxId equals emailInbox.Id into emailInboxs
                                             from userEmailInbox in emailInboxs.DefaultIfEmpty()
                                             where userEmailInbox.Id == id
                                             select new EmailInboxModel()
                                             {
                                                 Id = userEmailInbox.Id,
                                                 Subject = userEmailInbox.Subject,
                                                 Content = userEmailInbox.Content,
                                                 Date = userEmailInbox.Date,
                                                 RegisterDate = userEmailInbox.RegisterDate,
                                                 IsDeleted = userEmailInbox.IsDeleted,
                                                 IsRead = userEmailInbox.IsRead,
                                                 IsPin = userEmailInbox.IsPin,
                                                 ReplayedOutboxId = userEmailInbox.EmailOutboxs.FirstOrDefault()!.Id,
                                                 FromAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxFromAddressModel()
                                                 {
                                                     Name = fromAddress.Name,
                                                     Address = fromAddress.Address
                                                 }).ToList(),
                                                 ToAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxToAddressModel()
                                                 {
                                                     Name = fromAddress.Name,
                                                     Address = fromAddress.Address
                                                 }).ToList(),
                                                 Attachments = userEmailInbox.EmailInboxAttachments.Select(x => x.AttachmentId).ToList()

                                             }).FirstOrDefaultAsync();

                result.Data = emailInboxModel;

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
        public async Task<Result<EmailInboxModel>> GetByIdForReceiver(int id, string emailAddress)
        {
            var result = new Result<EmailInboxModel>();
            try
            {
                var emailInboxModel = await (from address in _queryRepository.Table<EmailInboxToAddress>()
                                             join emailInbox in _queryRepository.Table<EmailInbox>().Include(x => x.EmailOutboxs).Include(x => x.EmailInboxToAddress).Include(x => x.EmailInboxFromAddress).Include(x => x.EmailInboxAttachments)
                                             on address.EmailInboxId equals emailInbox.Id into emailInboxs
                                             from userEmailInbox in emailInboxs.DefaultIfEmpty()
                                             where userEmailInbox.Id == id && address.Address == emailAddress
                                             select new EmailInboxModel()
                                             {
                                                 Id = userEmailInbox.Id,
                                                 Subject = userEmailInbox.Subject,
                                                 Content = userEmailInbox.Content,
                                                 Date = userEmailInbox.Date,
                                                 RegisterDate = userEmailInbox.RegisterDate,
                                                 IsDeleted = userEmailInbox.IsDeleted,
                                                 IsRead = userEmailInbox.IsRead,
                                                 IsPin = userEmailInbox.IsPin,
                                                 ReplayedOutboxId = userEmailInbox.EmailOutboxs.FirstOrDefault()!.Id,
                                                 FromAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxFromAddressModel()
                                                 {
                                                     Name = fromAddress.Name,
                                                     Address = fromAddress.Address
                                                 }).ToList(),
                                                 ToAddress = userEmailInbox.EmailInboxFromAddress.Select(fromAddress => new EmailInboxToAddressModel()
                                                 {
                                                     Name = fromAddress.Name,
                                                     Address = fromAddress.Address
                                                 }).ToList(),
                                                 Attachments = userEmailInbox.EmailInboxAttachments.Select(x => x.AttachmentId).ToList()

                                             }).FirstOrDefaultAsync();

                result.Data = emailInboxModel;

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
        /// <param name="emailInboxId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int emailInboxId, string emailAddress)
        {
            var result = new Result();
            try
            {
                var emailInboxUser = await _queryRepository.Table<EmailInboxToAddress>().FirstOrDefaultAsync(x => x.EmailInboxId == emailInboxId && x.Address == emailAddress);
                if (emailInboxUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Email not found";
                    return result;
                }

                var emailInbox = await _queryRepository.Table<EmailInbox>().FirstOrDefaultAsync(x => x.Id == emailInboxId);
                emailInbox.IsDeleted = true;

                _commandRepository.UpdateAsync(emailInbox);
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
        /// <param name="emailInboxId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<Result> Pin(int emailInboxId, string emailAddress)
        {
            var result = new Result();
            try
            {
                var emailInboxUser = await _queryRepository.Table<EmailInboxToAddress>().FirstOrDefaultAsync(x => x.EmailInboxId == emailInboxId && x.Address == emailAddress);
                if (emailInboxUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Email not found";
                    return result;
                }
                var emailInbox = await _queryRepository.Table<EmailInbox>().FirstOrDefaultAsync(x => x.Id == emailInboxId);
                emailInbox.IsPin = !emailInbox.IsPin;

                _commandRepository.UpdateAsync(emailInbox);
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
        /// <param name="emailInboxId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<Result> Read(int emailInboxId, string emailAddress)
        {
            var result = new Result();
            try
            {
                var emailInboxUser = await _queryRepository.Table<EmailInboxToAddress>().FirstOrDefaultAsync(x => x.EmailInboxId == emailInboxId && x.Address == emailAddress);
                if (emailInboxUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Email not found";
                    return result;
                }
                var emailInbox = await _queryRepository.Table<EmailInbox>().FirstOrDefaultAsync(x => x.Id == emailInboxId);
                emailInbox.IsRead = true;

                _commandRepository.UpdateAsync(emailInbox);
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
        /// <param name="emailInboxId"></param>
        /// <returns></returns>
        public async Task<Result> Remove(int emailInboxId, string emailAddress)
        {
            var result = new Result();
            try
            {
                var emailInboxUser = await _queryRepository.Table<EmailInboxToAddress>().FirstOrDefaultAsync(x => x.EmailInboxId == emailInboxId && x.Address == emailAddress);
                if (emailInboxUser is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Email not found";
                    return result;
                }


                var emailInboxAttachment = _queryRepository.Table<EmailInboxAttachment>().Where(x => x.Id == emailInboxId);

                foreach (var attachment in emailInboxAttachment)
                {
                    _commandRepository.DeleteAsync(attachment);
                }
                var emailInboxToAddresses = _queryRepository.Table<EmailInboxToAddress>().Where(x => x.Id == emailInboxId);

                foreach (var emailInboxToAddress in emailInboxToAddresses)
                {
                    _commandRepository.DeleteAsync(emailInboxToAddress);
                }
                var emailInboxFromAddresses = _queryRepository.Table<EmailInboxFromAddress>().Where(x => x.Id == emailInboxId);

                foreach (var emailInboxFromAddress in emailInboxFromAddresses)
                {
                    _commandRepository.DeleteAsync(emailInboxFromAddress);
                }


                var emailInbox = _queryRepository.Table<EmailInbox>().FirstOrDefault(x => x.Id == emailInboxId);

                if (emailInbox is not null)
                    _commandRepository.DeleteAsync(emailInbox);


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