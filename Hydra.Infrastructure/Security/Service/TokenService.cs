using Hydra.Infrastructure.Security.Domain;
using Hydra.Infrastructure.Security.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hydra.Infrastructure.Security.Service
{
    public class TokenService : ITokenService
    {
        private const int ExpirationMinutes = 30;
        private readonly IConfiguration _iConfiguration;
        public TokenService(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;

        }
        public string CreateToken(User user, DateTime? expirationDate = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iConfiguration["Authentication:Schemes:Bearer:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                                              {
                                                  new Claim("identity", user.Id.ToString()),
                                                  new Claim(ClaimTypes.Name, user.UserName ?? ""),
                                                  new Claim(ClaimTypes.Email, user.Email ?? ""),
                                                  new Claim(ClaimTypes.Surname, user.Name ?? ""),
                                                  new Claim("avatar", user.Avatar ?? "")
                                              }),
                Expires = expirationDate != null ? expirationDate.Value : DateTime.UtcNow.AddMinutes(ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}