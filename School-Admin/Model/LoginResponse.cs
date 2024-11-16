using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginResponse
    {
        public UserDetails UserDetails { get; set; }
        public string AccesToken  { get; set; }
        public string RefreshToken { get; set; }
    }




    public class UserDetails
    {
        public int UserId { get; set; }
        public int UserRoleID { get; set; }
        public string UserRole { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       

    }
}
