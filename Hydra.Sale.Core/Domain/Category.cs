using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Category : BaseEntity<int>
{
    public string Name { get; set; }

    public string MetaKeywords { get; set; }

    public string MetaTitle { get; set; }

    public string Description { get; set; }

    public string MetaDescription { get; set; }

    public int? ParentCategoryId { get; set; }

    public int? PictureId { get; set; }

    public bool ShowOnHomepage { get; set; }

    public bool Published { get; set; }

    public bool Deleted { get; set; }

    public int DisplayOrder { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}