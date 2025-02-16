using Hydra.Kernel.Data;

namespace Hydra.Infrastructure.Localization.Domain
{
    public class Language : BaseEntity<int>
    {
        public string Name { get; set; }
        public string CultureInfo { get; set; }
        public bool IsVisible { get; set; }

    }
}
