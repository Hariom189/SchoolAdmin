using Model;
using School_Admin.Interface;

namespace School_Admin.Services
{
    public class LoginUserService : IloginUser
    { private readonly IJWTTokenAuth _jwtTokenAuth;
        public LoginUserService(IJWTTokenAuth jWTTokenAuth) {
            _jwtTokenAuth = jWTTokenAuth;
        }
        public LoginResponse UserLogin(LoginRequest loginRequest, string IP)
        {
            LoginResponse loginResponse= new LoginResponse();
            UserDetails userDetails = new UserDetails();
            userDetails.UserId = 1;
            userDetails.Name = "Hariom";
            userDetails.UserRole = "Admin";
            userDetails.UserRoleID = 1;
            userDetails.Email = "om.1987sharma@gmail.com";
            if (loginRequest != null)
            {
                loginRequest.UserID = "Hariom";
                loginRequest.Password = "123";
                loginResponse.UserDetails = userDetails;
                loginResponse .AccesToken= _jwtTokenAuth.GenerateToken(loginResponse.UserDetails);
                loginResponse.RefreshToken = _jwtTokenAuth.GenerateRefreshToken(IP);
            }
            return loginResponse;
        }
        

       
    }
}
