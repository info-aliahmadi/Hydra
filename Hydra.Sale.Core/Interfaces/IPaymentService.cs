using Hydra.Kernel.Extensions;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Models;

namespace Hydra.Sale.Core.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Result<List<PaymentStatusModel>>> GetAllPaymentStatus();
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        Task<Result<PaginatedList<PaymentModel>>> GetList(GridDataBound dataGrid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<PaymentModel>> GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="paymentModel"></param>
        /// <returns></returns>
        Task<Result<PaymentModel>> Add(PaymentModel paymentModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="paymentModel"></param>
        /// <returns></returns>
        Task<Result<PaymentModel>> Update(PaymentModel paymentModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> Delete(int id);

    }
}