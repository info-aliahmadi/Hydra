using Hydra.Infrastructure.Security.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Infrastructure.Security.Models
{
    public class UserPermissionModel
    {
        public User User { get; set; }

        public IList<RoleModel> Roles { get; set; }

        public IList<PermissionModel> Permissions { get; set; }
    }
}
