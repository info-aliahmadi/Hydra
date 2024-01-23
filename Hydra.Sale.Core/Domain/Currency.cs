using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Currency : BaseEntity<int>
{
    public string Name { get; set; }

    public string CurrencyCode { get; set; }

    public string DisplayLocale { get; set; }

    public string CustomFormatting { get; set; }

    public decimal Rate { get; set; }

    public bool LimitedToStores { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime UpdatedOnUtc { get; set; }

    public int RoundingTypeId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}