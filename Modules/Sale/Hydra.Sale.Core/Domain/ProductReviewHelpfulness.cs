using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductReviewHelpfulness : BaseEntity<int>
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductReviewId { get; set; }

    public bool WasHelpful { get; set; }

    public virtual ProductReview ProductReview { get; set; }

    public virtual User User { get; set; }
}