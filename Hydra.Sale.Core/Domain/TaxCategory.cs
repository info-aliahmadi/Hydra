using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class TaxCategory : BaseEntity<int>
{
    public string Name { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();
}