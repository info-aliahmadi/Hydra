using Hydra.Infrastructure.Security.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiWithAuth
{
    public class TokenService
    {
        private const int ExpirationMinutes = 30;
        private readonly IConfiguration _iConfiguration;
        public TokenService(IConfiguration iConfiguration)
        {
            this._iConfiguration = iConfiguration;

        }
        public static string CreateToken(IConfiguration iconfiguration , User user,bool rememberMe = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iConfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                                              {
                                                    new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
                                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                                                    new Claim("id", user.Id.ToString()),
                                                    new Claim(ClaimTypes.Name, user.UserName??""),
                                                    new Claim(ClaimTypes.Email, user.Email ?? "")
                                              }),
                Expires = rememberMe ? DateTime.UtcNow.AddMonths(6) : DateTime.UtcNow.AddMinutes(ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


    }
}