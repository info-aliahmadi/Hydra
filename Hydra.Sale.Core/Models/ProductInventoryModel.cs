namespace Hydra.Sale.Core.Models
{
    public class ProductInventoryModel
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
        public int ProductId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int StockQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ReservedQuantity { get; set; }


    }
}