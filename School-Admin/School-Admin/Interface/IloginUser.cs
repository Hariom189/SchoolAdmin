using Model;

namespace School_Admin.Interface
{
    public interface IloginUser
    {
        LoginResponse UserLogin(LoginRequest loginRequest,string IP);
    }
}
