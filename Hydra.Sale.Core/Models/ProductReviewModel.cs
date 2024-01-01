namespace Hydra.Sale.Core.Models
{
    public class ProductReviewModel
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
        public int ProductId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsApproved { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReviewText { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReplyText { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CustomerNotifiedOfReply { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Rating { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int HelpfulYesTotal { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int HelpfulNoTotal { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ProductReviewHelpfulnesses { get; set; }


    }
}