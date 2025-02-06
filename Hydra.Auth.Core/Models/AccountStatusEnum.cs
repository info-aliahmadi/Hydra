using System.ComponentModel;

namespace Hydra.Auth.Models
{
    public enum AccountStatusEnum
    {
        [Description("Succeeded")]
        Succeeded = 0,

        [Description("Failed")]
        Failed = 1,

        [Description("Invalid")]
        Invalid = 2,

        [Description("RequiresTwoFactor")]
        RequiresTwoFactor = 3,

        [Description("IsLockedOut")]
        IsLockedOut = 4,

        [Description("IsNotAllowed")]
        IsNotAllowed = 5,

        [Description("RequireConfirmedEmail")]
        RequireConfirmedEmail = 6,

        [Description("ErrorExternalProvider")]
        ErrorExternalProvider = 7,

        [Description("NullExternalLoginInfo")]
        NullExternalLoginInfo = 8,

        [Description("ExternalLoginFailure")]
        ExternalLoginFailure = 9,

        [Description("InvalidCode")]
        InvalidCode = 10

    }
}
