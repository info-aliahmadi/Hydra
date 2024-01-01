namespace Hydra.Sale.Core.Models
{
    public class ShipmentItemModel
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
        public int ShipmentId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderItemId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Quantity { get; set; }


    }
}