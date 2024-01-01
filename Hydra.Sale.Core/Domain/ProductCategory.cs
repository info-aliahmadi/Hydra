using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductCategory : BaseEntity<int>
{
    public int CategoryId { get; set; }

    public int ProductId { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Category Category { get; set; }

    public virtual Product Product { get; set; }
}