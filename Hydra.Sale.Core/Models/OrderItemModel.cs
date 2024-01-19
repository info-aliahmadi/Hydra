namespace Hydra.Sale.Core.Models
{
    public class OrderItemModel
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
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPriceTax { get; set; }
    }
}