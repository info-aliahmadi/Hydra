using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class TaxRate : BaseEntity<int>
{
    public int Id { get; set; }

    public int TaxCategoryId { get; set; }

    public int CountryId { get; set; }

    public int StateProvinceId { get; set; }

    public decimal Percentage { get; set; }

    public virtual Country Country { get; set; }

    public virtual StateProvince StateProvince { get; set; }

    public virtual TaxCategory TaxCategory { get; set; }
}