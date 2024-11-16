using Model;

namespace School_Admin.Interface
{
    public interface IJWTTokenAuth
    {
        string GenerateToken(UserDetails  userDetails);
        string GenerateRefreshToken(string IPaddress);

    }
}
