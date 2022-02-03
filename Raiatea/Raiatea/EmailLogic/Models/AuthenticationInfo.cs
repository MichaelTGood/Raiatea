using System;
using System.Collections.Generic;
using System.Text;

namespace Raiatea.EmailLogic.Models
{
    public class AuthenticationInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthenticationInfo() { }
        public AuthenticationInfo(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}
