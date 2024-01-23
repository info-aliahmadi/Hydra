using Hydra.Sale.Core.Models.Enums;
using Microsoft.OpenApi.Extensions;

namespace Hydra.Sale.Core.Models
{
    public class OrderModel
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
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ShipmentId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? AddressId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ShippingMethodId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShippingMethodTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte OrderStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ShippingStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ShippingStatusTitle => ShippingStatusId != 0 ? ((ShippingStatus)ShippingStatusId).GetDisplayName() : string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte PaymentStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PaymentStatusTitle => PaymentStatusId != 0 ? ((PaymentStatus)PaymentStatusId).GetDisplayName() : string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte? PaymentMethodId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? UserCurrencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string? UserCurrency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal RefundedAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CustomerIp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AllowStoringCreditCardNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? PaidDateUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Deleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreatedOnUtcString => CreatedOnUtc.ToString("g");

        /// <summary>
        /// 
        /// </summary>
        public DateTime? PaymentDateUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentDateUtcToString => PaymentDateUtc?.ToString("g") ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> OrderNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ShippingTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ShippingAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ShippingAmountTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TransactionTrackingCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentTrackingCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TrackingNumber { get; set; }
    }
}
