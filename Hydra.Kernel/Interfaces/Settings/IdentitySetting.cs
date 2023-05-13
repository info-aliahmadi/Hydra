


namespace Nitro.Core.Interfaces.Settings
{
    public class IdentitySetting : IIdentitySetting
    {
        public string CookieName { get; set; }
        public bool CookieHttpOnly { get; set; }
        public int ExpireTimeSpan { get; set; }
        public string LoginPath { get; set; }
        public string AccessDeniedPath { get; set; }
        public string LogoutPath { get; set; }
        public bool SlidingExpiration { get; set; }
        public string JwtBearerAudience { get; set; }
        public string JwtBearerAuthority { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireUppercase { get; set; }
        public int RequiredLength { get; set; }
        public int RequiredUniqueChars { get; set; }
        public int DefaultLockoutTimeSpan { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
        public bool AllowedForNewUsers { get; set; }
        public string AllowedUserNameCharacters { get; set; }
        public bool RequireUniqueEmail { get; set; }
        public bool RequireConfirmedEmail { get; set; }
        public bool RequireConfirmedPhoneNumber { get; set; }
    }
}
