namespace Hydra.Sale.Core.Models
{
    public class OrderDiscountModel
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
        public int DiscountId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime CreatedOnUtc { get; set; }


    }
}