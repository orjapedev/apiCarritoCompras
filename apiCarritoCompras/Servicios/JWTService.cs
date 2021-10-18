using apiCarritoCompras.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace apiCarritoCompras.Servicios
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string  GenerarToken(Usuario usuario)
        {
            string token = "";
            try
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Email,usuario.Email)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),

                    Expires = DateTime.UtcNow.AddDays(1),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                token = tokenHandler.WriteToken(createdToken).ToString();
            }
            catch (Exception)
            {

                token = "";
                
            }

            return token;
        }
    }

    public interface IJWTService 
    {
       string GenerarToken(Usuario usuario);
    }
}
