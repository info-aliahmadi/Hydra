using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Country : BaseEntity<int>
{
    public string Name { get; set; }

    public string TwoLetterIsoCode { get; set; }

    public string ThreeLetterIsoCode { get; set; }

    public bool AllowsBilling { get; set; }

    public bool AllowsShipping { get; set; }

    public int NumericIsoCode { get; set; }

    public bool SubjectToVat { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }

    public bool LimitedToStores { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();

    public virtual ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();
}