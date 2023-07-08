using Microsoft.AspNetCore.Identity;


namespace Hydra.Infrastructure.Security.Domain
{
    public class Role : IdentityRole<int>
    {

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Permission> Permissions { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
