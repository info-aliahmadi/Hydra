namespace Hydra.Sale.Core.Models
{
    public class CurrencyModel
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
        public string CurrencyCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DisplayLocale { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CustomFormatting { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Rate { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool LimitedToStores { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Published { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int DisplayOrder { get; set; }


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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int RoundingTypeId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Orders { get; set; }


    }
}