using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductInventory : BaseEntity<int>
{
    public int ProductId { get; set; }

    public int StockQuantity { get; set; }

    public int ReservedQuantity { get; set; }

    public virtual Product Product { get; set; }
}