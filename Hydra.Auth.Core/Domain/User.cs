using Microsoft.AspNetCore.Identity;

namespace Hydra.Auth.Core.Domain
{
    public class User : IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
