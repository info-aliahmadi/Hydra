using Hydra.Crm.Core.Models.Email;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Crm.Core.Interfaces
{
    public interface IEmailInboxService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Result> LoadEmailInbox(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<EmailInboxModel>>> GetAllEmailInbox(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<EmailInboxModel>>> GetInbox(GridDataBound dataGrid, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<EmailInboxModel>>> GetDeletedInbox(GridDataBound dataGrid, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<EmailInboxModel>> GetById(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result<EmailInboxModel>> GetByIdForReceiver(int id, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailInboxId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result> Delete(int emailInboxId, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailInboxId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result> Pin(int emailInboxId, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailInboxId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result> Read(int emailInboxId, string emailAddress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailInboxId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Result> Remove(int emailInboxId, string emailAddress);

      

    }
}
