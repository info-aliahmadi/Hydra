namespace Hydra.Sale.Core.Models
{
    public class ShoppingCartItemModel
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
        public byte ShoppingCartTypeId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Quantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime UpdatedOnUtc { get; set; }


    }
}