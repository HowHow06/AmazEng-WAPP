using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace AmazEng_WAPP.Class.Utils
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public static bool IsValidName(string name)
        {
            try
            {
                return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
            }
            catch
            {
                return false;
            }
        }
    }
}