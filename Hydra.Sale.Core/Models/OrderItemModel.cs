﻿namespace Hydra.Sale.Core.Models
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
        /// <returns></returns>
        public int Quantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal UnitPriceTax { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal PriceTax { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal DiscountAmountTax { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal UnitPrice { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ShipmentItems { get; set; }


    }
}