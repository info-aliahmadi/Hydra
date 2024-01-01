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
        public byte PaymentStatusId { get; set; }


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
        public decimal OrderShippingTax { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal OrderTax { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal OrderDiscount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal OrderTotal { get; set; }


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
        /// <returns></returns>
        public int OrderDiscounts { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderItems { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderNotes { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Payments { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Shipments { get; set; }


    }
}