namespace Hydra.Sale.Core.Models
{
    public class CategoryModel
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
        public string MetaKeywords { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MetaTitle { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MetaDescription { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ParentCategoryId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? PictureId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ShowOnHomepage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Published { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Deleted { get; set; }


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
        public int ProductCategories { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Discounts { get; set; }


        public List<CategoryModel>? Childs { get; set; } = new List<CategoryModel>();

    }
}