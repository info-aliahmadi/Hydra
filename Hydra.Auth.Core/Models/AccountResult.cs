
using System.ComponentModel;

namespace Hydra.Auth.Core.Models
{
    public class AccountResult
    {
        public bool Succeeded => Status == AccountStatusEnum.Succeeded;

        public AccountStatusEnum Status { get; set; }

        public string StatusDescription => Description(Status);
        public string Message { get; set; }

        public List<string> Errors { get; set; }
        public static string Description(AccountStatusEnum val)
        {
            DescriptionAttribute[]? attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
