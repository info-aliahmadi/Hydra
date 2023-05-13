

namespace Nitro.Core.Interfaces.Settings
{
    public interface IIdentitySetting
    {
        string CookieName { get; set; }
        bool CookieHttpOnly { get; set; }
        int ExpireTimeSpan { get; set; }
        string LoginPath { get; set; }
        string AccessDeniedPath { get; set; }
        string LogoutPath { get; set; }
        bool SlidingExpiration { get; set; }
        string JwtBearerAudience { get; set; }
        string JwtBearerAuthority { get; set; }
        bool RequireDigit { get; set; }
        bool RequireLowercase { get; set; }
        bool RequireNonAlphanumeric { get; set; }
        bool RequireUppercase { get; set; }
        int RequiredLength { get; set; }
        int RequiredUniqueChars { get; set; }
        int DefaultLockoutTimeSpan { get; set; }
        int MaxFailedAccessAttempts { get; set; }
        bool AllowedForNewUsers { get; set; }
        string AllowedUserNameCharacters { get; set; }
        bool RequireUniqueEmail { get; set; }
        bool RequireConfirmedEmail { get; set; }
        bool RequireConfirmedPhoneNumber { get; set; }
    }
}
