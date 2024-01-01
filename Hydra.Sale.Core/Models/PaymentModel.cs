namespace Hydra.Sale.Core.Models
{
    public class PaymentModel
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
        public int OrderId { get; set; }


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
        /// <returns></returns>
        public byte? PaymentTypeId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Status { get; set; }


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
        public string CardType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CardName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CardNumber { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MaskedCreditCardNumber { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CardCvv2 { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CardExpirationMonth { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CardExpirationYear { get; set; }


    }
}