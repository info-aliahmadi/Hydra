namespace Hydra.Sale.Core.Models
{
    public class ProductReviewHelpfulnessModel
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
        public int ProductReviewId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool WasHelpful { get; set; }


    }
}