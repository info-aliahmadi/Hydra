namespace Hydra.Sale.Core.Models
{
    public class TaxRateModel
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
        public int TaxCategoryId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CountryId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int StateProvinceId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Percentage { get; set; }


    }
}