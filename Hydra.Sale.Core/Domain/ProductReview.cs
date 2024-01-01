using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class ProductReview : BaseEntity<int>
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public bool IsApproved { get; set; }

    public string Title { get; set; }

    public string ReviewText { get; set; }

    public string ReplyText { get; set; }

    public bool CustomerNotifiedOfReply { get; set; }

    public int Rating { get; set; }

    public int HelpfulYesTotal { get; set; }

    public int HelpfulNoTotal { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual Product Product { get; set; }

    public virtual ICollection<ProductReviewHelpfulness> ProductReviewHelpfulnesses { get; set; } = new List<ProductReviewHelpfulness>();

    public virtual User User { get; set; }
}