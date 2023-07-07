

namespace Hydra.Auth.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string? AvatarFile { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? DefaultLanguage { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
        public IEnumerable<RoleModel> Roles { get; set; }

    }
}
