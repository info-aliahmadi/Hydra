using Hydra.Kernel;

namespace Hydra.Sale.Core.Domain;

public class SearchTerm : BaseEntity<int>
{
    public int Id { get; set; }

    public string Keyword { get; set; }

    public int Count { get; set; }
}