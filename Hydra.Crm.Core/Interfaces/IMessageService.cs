using Hydra.Crm.Core.Models.Message;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;

namespace Hydra.Crm.Core.Interfaces
{
    public interface IMessageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<MessageModel>>> GetAllMessages(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<MessageModel>>> GetInbox(GridDataBound dataGrid, int toUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<MessageModel>>> GetPublicInbox(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<MessageModel>>> GetDeletedInbox(GridDataBound dataGrid, int toUserId);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="fromUserId"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<MessageModel>>> GetSent(GridDataBound dataGrid, int fromUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="fromUserId"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<MessageModel>>> GetDeletedSent(GridDataBound dataGrid, int fromUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> GetByIdForPublic(int messageId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> GetByIdForSender(int messageId, int fromUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> GetByIdForReceiver(int messageId, int toUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageModel"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> Send(MessageModel messageModel, int currentUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageModel"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> SaveDraft(MessageModel messageModel, int currentUserId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageModel"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> Add(MessageModel messageModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageModel"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result<MessageModel>> Update(MessageModel messageModel, int currentUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result> DeleteDraft(int messageId, int currentUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result> Delete(int messageId, int currentUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result> Pin(int messageId, int currentUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<Result> Read(int messageId, int currentUserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        Task<Result> Remove(int messageId, int currentUserId);

    }
}
