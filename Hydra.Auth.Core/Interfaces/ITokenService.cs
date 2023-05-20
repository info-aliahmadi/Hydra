using Hydra.Auth.Core.Models;
using Hydra.Infrastructure.Security.Domain;

namespace Hydra.Auth.Core.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string CreateToken(User user, bool rememberMe = false);


    }
}
