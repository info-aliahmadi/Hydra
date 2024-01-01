namespace Hydra.Sale.Core.Models
{
    public class ShipmentModel
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
        public string TrackingNumber { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? TotalWeight { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? ShippedDateUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? DeliveryDateUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? ReadyForPickupDateUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AdminComment { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ShipmentItems { get; set; }


    }
}