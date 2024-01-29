using Hydra.Sale.Core.Models.Enums;
using Microsoft.OpenApi.Extensions;

namespace Hydra.Sale.Core.Models
{
    public class PaymentViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string TransactionTrackingCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PaymentTrackingCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? PaymentDateUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentDateUtcToString => PaymentDateUtc?.ToString("g") ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte? PaymentTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentTypeTitle => PaymentTypeId.HasValue ? ((PaymentType)PaymentTypeId).GetDisplayName() : string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StatusTitle => Status.HasValue && Status != 0 ? ((PaymentStatus)Status).GetDisplayName() : string.Empty;
    }
}