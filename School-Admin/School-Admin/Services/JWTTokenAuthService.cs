using Microsoft.IdentityModel.Tokens;
using Model;
using School_Admin.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace School_Admin.Services
{
    public class JWTTokenAuthService : IJWTTokenAuth
    {
        private readonly IConfiguration _configuration;
        public JWTTokenAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateRefreshToken(string IPaddress)
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            return token;
        }

        public string GenerateToken(UserDetails userDetails)
        {
            Appsetting appsetting=new Appsetting();
            appsetting.Key = _configuration["AppSettings:Key"];
            appsetting.issure = _configuration["AppSettings:Issuer"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appsetting.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Here you  can fill claim information from database for the users as well
            var claims = new[] {
                new Claim("id", userDetails.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, userDetails.Name),
                    new Claim(JwtRegisteredClaimNames.Email, userDetails.Email),
                    new Claim("Role", userDetails.UserRole),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(appsetting.issure, appsetting.issure, claims, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Key"])),
                ValidateLifetime = false

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }
    }
}
