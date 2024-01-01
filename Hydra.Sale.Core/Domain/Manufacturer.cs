using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Manufacturer : BaseEntity<int>
{
    public string Name { get; set; }

    public string MetaKeywords { get; set; }

    public string MetaTitle { get; set; }

    public string Description { get; set; }

    public string MetaDescription { get; set; }

    public int PictureId { get; set; }

    public bool Published { get; set; }

    public bool Deleted { get; set; }

    public int DisplayOrder { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public virtual ICollection<ProductManufacturer> ProductManufacturers { get; set; } = new List<ProductManufacturer>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}