using Microsoft.AspNetCore.Identity;


namespace Hydra.Infrastructure.Security.Domain
{
    public class Role : IdentityRole<int>
    {

        /// <summary>
        /// 
        /// </summary>
        public IList<Permission> Permissions { get; set; }
    }
}
