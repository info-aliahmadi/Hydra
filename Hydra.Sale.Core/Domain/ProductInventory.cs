using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductInventory : BaseEntity<int>
{
    /// <summary>
    /// 
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? AttributeId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public StockType StockType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int ReservedQuantity { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual Product Product { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual ProductAttribute? ProductAttribute { get; set; }
}
public enum StockType
{
    Total = 0,
    PerAttribute = 1
}