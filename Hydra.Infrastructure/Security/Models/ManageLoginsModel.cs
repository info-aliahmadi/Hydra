
using Microsoft.AspNetCore.Identity;

namespace Hydra.Infrastructure.Security.Models
{
    public class ManageLoginsModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        //public IList<AuthenticationScheme> OtherLogins { get; set; }
    }
}
