using DotnetYuzuncuYil.API.Abstraction;
using DotnetYuzuncuYil.Core.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotnetYuzuncuYil.API.Concrete
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        public readonly string tokenKey;
        public JwtAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        public AuthResponseDto Authenticate(string username, string password)
        {
            AuthResponseDto authResponse = new AuthResponseDto();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(tokenKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,username)
                    }),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                authResponse.Token = tokenHandler.WriteToken(token);

                return authResponse;
            }
            catch (Exception ex)
            {
                return authResponse;
            }
        }
    }
}
