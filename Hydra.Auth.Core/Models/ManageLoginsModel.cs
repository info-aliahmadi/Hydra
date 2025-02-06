
using Microsoft.AspNetCore.Identity;

namespace Hydra.Auth.Models
{
    public class ManageLoginsModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        //public IList<AuthenticationScheme> OtherLogins { get; set; }
    }
}
