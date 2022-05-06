
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Class.Auth
{
    public class Auth
    {
        public static string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


    }
}