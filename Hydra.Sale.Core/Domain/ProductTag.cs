using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductTag : BaseEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}