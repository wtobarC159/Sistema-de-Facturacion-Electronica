using Microsoft.IdentityModel.Tokens;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sistema_de_Facturacion_Electronica.Servicios
{
    public class TokenService : IGenerarToken
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _SecurityKey;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
            _SecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:LLaveFirma"]!));
        }

        public string GenerarToken(Usuario NodoUsuario, string Rol)
        {
            var Claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,NodoUsuario.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName,NodoUsuario.UserName!),
                new Claim(ClaimTypes.Role,Rol)
            };

            var CredencialesFirma = new SigningCredentials(_SecurityKey,SecurityAlgorithms.HmacSha256);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(Claims),
                Issuer = _configuration["Jwt:Emisor"],
                Audience = _configuration["wt:Receptor"],
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = CredencialesFirma,               
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
