using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class DeliveryDate : BaseEntity<int>
{
    public string Name { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}