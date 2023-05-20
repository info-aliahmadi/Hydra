using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Auth.Core.Domain
{
    public class Permission :BaseEntity<int>
    {
        public required string Name { get; set; }
        public string? NormalizedName { get; set; }

        public IList<PermissionRole> PermissionRoles { get; set; }
    }
}
