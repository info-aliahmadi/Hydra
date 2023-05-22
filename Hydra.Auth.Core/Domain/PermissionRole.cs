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
        public Permission Permission { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
