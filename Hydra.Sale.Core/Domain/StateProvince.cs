using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class StateProvince : BaseEntity<int>
{
    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public int CountryId { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; }

    public virtual ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();
}