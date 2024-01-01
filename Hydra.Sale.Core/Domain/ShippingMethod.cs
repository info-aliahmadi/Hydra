using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ShippingMethod : BaseEntity<int>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}