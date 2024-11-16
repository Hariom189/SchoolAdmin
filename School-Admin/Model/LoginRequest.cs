using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginRequest
    {
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
