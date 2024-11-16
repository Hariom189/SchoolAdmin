using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_Admin.MiddleWare
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JWTMiddleware(RequestDelegate next,IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                //Validate the token
              
            ValidateToken(context, token);
            await _next(context);
        }
        private void ValidateToken(HttpContext context, string token)
        {
            Appsetting appsetting = new Appsetting();
            appsetting.Key = _configuration["AppSettings:Key"];
            appsetting.issure = _configuration["AppSettings:Issuer"];
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appsetting.Key));
              var t = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidIssuer = appsetting.issure,
                    ValidAudience = appsetting.issure,
                    // set clockskew to zero so tokens expire exactly at token expiration time.
                    ClockSkew = TimeSpan.FromMinutes(1)
                }, out SecurityToken validatedToken) ;
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                // attach user to context on successful jwt validation
                context.Items["User"] = "Hariom";
            }
            catch (Exception)
            {
                
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }

       
    }
}
