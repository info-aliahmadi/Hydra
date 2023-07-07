using Microsoft.AspNetCore.Identity;

namespace Hydra.Infrastructure.Security.Domain
{
    public class User : IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }

        //[PersonalData]
        //public DateTime DOB { get; set; }

        [PersonalData]
        public DateTime? RegisterDate { get; set; }

        [PersonalData]
        public string? DefaultLanguage { get; set; }

        [PersonalData]
        public string? DefaultTheme { get; set; }

        [PersonalData]
        public string? Avatar { get; set; }

    }
}
