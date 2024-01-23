using Hydra.FileStorage.Core.Models;
using Hydra.Kernel.Models;

namespace Hydra.Sale.Core.Models
{
    public class ProductModel
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
        public int CreateUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AuthorModel CreateUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? UpdateUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AuthorModel UpdateUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? PreviewImageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FileUploadModel? PreviewImage { get; set; }

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
        public string MetaDescription { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ShortDescription { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string FullDescription { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AdminComment { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int DeliveryDateId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TaxCategoryId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int StockQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int MinStockQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool NotifyAdminForQuantityBelow { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderMinimumQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int OrderMaximumQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Price { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CurrencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Weight { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Length { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Width { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Height { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? AvailableStartDateTimeUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? AvailableEndDateTimeUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int DisplayOrder { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ApprovedRatingSum { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int NotApprovedRatingSum { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ApprovedTotalReviews { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int NotApprovedTotalReviews { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasDiscountsApplied { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MarkAsNew { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool NotReturnable { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool? AllowedQuantities { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsTaxExempt { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ShowOnHomepage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFreeShipping { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AllowCustomerReviews { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DisplayStockQuantity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DisableBuyButton { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DisableWishlistButton { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AvailableForPreOrder { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CallForPrice { get; set; }


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
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> CategoryIds { get; set; } = new List<int>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> ManufacturerIds { get; set; } = new List<int>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> PictureIds { get; set; } = new List<int>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> ReviewIds { get; set; } = new List<int>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> RelatedProductIds { get; set; } = new List<int>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> ProductTags { get; set; } = new List<string>();


    }
}