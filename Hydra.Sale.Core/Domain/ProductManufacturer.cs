using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductManufacturer : BaseEntity<int>
{
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    public int ProductId { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Manufacturer Manufacturer { get; set; }

    public virtual Product Product { get; set; }
}