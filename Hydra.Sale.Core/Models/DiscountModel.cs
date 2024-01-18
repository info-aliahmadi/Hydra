using Hydra.Sale.Core.Domain;

namespace Hydra.Sale.Core.Models
{
    public class DiscountModel
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
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CouponCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AdminComment { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DiscountType DiscountTypeId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UsePercentage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal DiscountPercentage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal DiscountAmount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? MaximumDiscountAmount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? StartDateUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? EndDateUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RequiresCouponCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DiscountLimitationType DiscountLimitationId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int LimitationTimes { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? MaximumDiscountedQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsActive { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderDiscounts { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Categories { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Manufacturers { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Products { get; set; }


    }
}