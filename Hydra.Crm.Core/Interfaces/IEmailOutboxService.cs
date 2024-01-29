using Hydra.Crm.Core.Models.Email;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;

namespace Hydra.Crm.Core.Interfaces
{
    public interface IEmailOutboxService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<EmailOutboxModel>>> GetAllEmailOutbox(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<EmailOutboxModel>>> GetOutbox(GridDataBound dataGrid, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Result<List<string>> GetAddressForSelect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailOutboxId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result<EmailOutboxModel>> GetByIdForSender(int emailOutboxId, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailOutboxModel"></param>
        /// <param name="fromUser"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<Result<EmailOutboxModel>> Send(EmailOutboxModel emailOutboxModel, AuthorModel fromUser, HttpContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailOutboxModel"></param>
        /// <param name="fromUser"></param>
        /// <returns></returns>
        Task<Result<EmailOutboxModel>> SaveDraft(EmailOutboxModel emailOutboxModel, AuthorModel fromUser);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailOutboxModel"></param>
        /// <returns></returns>
        Task<Result<EmailOutboxModel>> Add(EmailOutboxModel emailOutboxModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailOutboxModel"></param>
        /// <param name="fromEmail"></param>
        /// <returns></returns>
        Task<Result<EmailOutboxModel>> Update(EmailOutboxModel emailOutboxModel, string fromEmail);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailOutboxId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result> Remove(int emailOutboxId, string emailAddress);

    }
}
