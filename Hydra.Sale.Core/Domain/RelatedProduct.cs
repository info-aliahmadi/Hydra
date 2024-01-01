using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class RelatedProduct : BaseEntity<int>
{
    public int ProductId1 { get; set; }

    public int ProductId2 { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Product ProductId1Navigation { get; set; }

    public virtual Product ProductId2Navigation { get; set; }
}