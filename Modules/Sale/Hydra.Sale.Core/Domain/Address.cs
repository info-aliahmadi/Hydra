using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class Address : BaseEntity<int>
{
    public int UserId { get; set; }

    public int CountryId { get; set; }

    public int StateProvinceId { get; set; }

    public string City { get; set; }

    public string County { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Company { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string ZipPostalCode { get; set; }

    public string FaxNumber { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual StateProvince StateProvince { get; set; }

    public virtual User User { get; set; }
}