namespace Hydra.Sale.Core.Models
{
    public class CountryModel
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
        public string TwoLetterIsoCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ThreeLetterIsoCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AllowsBilling { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AllowsShipping { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int NumericIsoCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SubjectToVat { get; set; }


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
        public bool LimitedToStores { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Addresses { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int StateProvinces { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TaxRates { get; set; }


    }
}