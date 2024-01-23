using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductProductTag
{
    public int ProductTagId { get; set; }
    public ProductTag ProductTag { get; set; }
    
    public int ProductId { get; set; }

    public virtual Product Product { get; set; }
}