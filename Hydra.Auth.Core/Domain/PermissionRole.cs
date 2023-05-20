using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Auth.Core.Domain
{
    public class PermissionRole
    {
        public int PermissionId { get; set; }
        public required Permission Permission { get; set; }

        public int RoleId { get; set; }
        public required Role Role { get; set; }

    }
}
