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
        public string ShippingStatusTitle => ((ShippingStatus)ShippingStatusId).GetDisplayName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte PaymentStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PaymentStatusTitle => ((PaymentStatus)PaymentStatusId).GetDisplayName();

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
    }
}
