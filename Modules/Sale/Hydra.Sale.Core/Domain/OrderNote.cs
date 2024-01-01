using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class OrderNote : BaseEntity<int>
{
    public int Id { get; set; }

    public string Note { get; set; }

    public int UserId { get; set; }

    public int OrderId { get; set; }

    public bool IsRead { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Order Order { get; set; }

    public virtual User User { get; set; }
}