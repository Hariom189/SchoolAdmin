using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using School_Admin.Filter;
using School_Admin.Interface;

namespace School_Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginAuth : ControllerBase
    {
        private readonly IloginUser _iloginUser;
        public LoginAuth(IloginUser iloginUser)
        {
            _iloginUser = iloginUser;
        }
        [HttpPost("Login")]
        
        public ActionResult Login(LoginRequest loginRequest)
        {
            string ip = ipAddress();
           LoginResponse loginResponse= _iloginUser.UserLogin(loginRequest,ip);
            setTokenCookie(loginResponse.RefreshToken);
            loginResponse.RefreshToken = null;

            return Ok(loginResponse);

        }
        [Authorizetion]
        [HttpGet]

        public ActionResult Check()
        {
            string name = "Hariom";
            return Ok(name);
        }
        [HttpPost ("refresh-token")]
        public ActionResult RefreshToken(string name)
        {
            return Ok();

        }
        private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                Path = "https://localhost:7298/",
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
