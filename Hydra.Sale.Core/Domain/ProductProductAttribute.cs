using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductProductAttribute : BaseEntity<int>
{
    public int AttributeId { get; set; }

    public int ProductId { get; set; }

    public virtual ProductAttribute Attribute { get; set; }

    public virtual Product Product { get; set; }
}