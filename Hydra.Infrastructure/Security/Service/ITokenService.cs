using Hydra.Infrastructure.Security.Domain;

namespace Hydra.Infrastructure.Security.Service
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
