
using Hydra.Auth.Domain;

namespace Hydra.Auth.Interface
{
    public interface ITokenService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string CreateToken(User user, DateTime? expirationDate = null);


    }
}
