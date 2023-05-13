
namespace Hydra.Auth.Core.Models
{
    public class AccountResult
    {
        public bool Succeeded => Status == AccountStatusEnum.Succeeded;

        public AccountStatusEnum Status { get; set; }

        public string StatusDescription => Status.Description();
        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}
