

namespace Nitro.Core.Interfaces.Settings
{
    public interface ISmsSetting
    {
        string AccountSid { get; set; }
        string AuthToken { get; set; }
        string FromNumber { get; set; }
    }
}
