using Hydra.Kernel;

namespace Hydra.Infrastructure.Security.Domain
{
    public class Permission :BaseEntity<int>
    {
        public required string Name { get; set; }
        public string NormalizedName { get; set; }

        public IList<Role> Roles { get; set; }
    }
}
