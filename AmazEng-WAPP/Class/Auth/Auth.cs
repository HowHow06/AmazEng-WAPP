
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AmazEng_WAPP.Class.Auth
{
    public class Auth
    {

        public static string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        internal static void AdminLogout(HttpSessionState session, HttpRequest request)
        {
            string adminUsername = "";
            var sessionObject = session[Auth.GetAdminSessionName()];

            if (sessionObject is object)
            {
                adminUsername = sessionObject.ToString();
                session.Remove(Auth.GetAdminSessionName());
            }

            HttpContext.Current.Response.Cookies.Remove("rememberMe");

            if (String.IsNullOrEmpty(adminUsername))
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Admin admin = db.Admins.Where(a => a.Username == adminUsername).First();

            if (admin is null)
            {
                return;
            }

            admin.RememberToken = null;
            admin.TokenExpiresAt = null;
            db.SaveChanges();
        }


        internal static Admin GetLoggedInAdmin(HttpSessionState session, HttpRequest request, AmazengContext db)
        {
            if (session[GetAdminSessionName()] is object)
            {
                string adminUsername = session[GetAdminSessionName()].ToString();
                System.Diagnostics.Debug.WriteLine("founded using session");
                return db.Admins.Where(a => a.Username == adminUsername).First();
            }

            if (request.Cookies["rememberToken"] == null)
            {
                System.Diagnostics.Debug.WriteLine("No Cookie");
                return null;
            }

            HttpCookie rememberTokenCookie = request.Cookies["rememberToken"];
            string rememberToken = rememberTokenCookie.Value;
            string adminId = rememberToken.Split('.').ElementAt(1);
            Admin admin;
            admin = db.Admins.Find(Convert.ToInt32(adminId));

            if (admin == null || admin.RememberToken == null || admin.TokenExpiresAt == null)
            {
                return null;
            }

            if (admin.TokenExpiresAt < DateTime.UtcNow)
            {
                return null;
            }

            if (!(IsValidToken(rememberToken, admin.RememberToken)))
            {
                return null;
            }

            System.Diagnostics.Debug.WriteLine("founded using cookie");
            return admin;
        }

        private static bool IsValidToken(string cookieRememberToken, string rememberToken)
        {
            return rememberToken.Equals(Util.ComputeSha256Hash(cookieRememberToken));
        }

        internal static string GetAdminSessionName()
        {
            return "AdminUsername";
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        internal static Member GetMember(string loginKey, string password, AmazengContext db)
        {
            IQueryable<Member> memberQuery;
            Member member;

            if (Validator.IsValidEmail(loginKey))
            {
                memberQuery = db.Members.Where(m => m.Email == loginKey && m.DeletedAt == null);
            }
            else
            {
                memberQuery = db.Members.Where(m => m.Username == loginKey && m.DeletedAt == null);
            }

            if (memberQuery.Any() == false) //member not found
            {
                return null;
            }

            member = memberQuery.First();

            if (!VerifyPassword(password, member.Password))
            {
                return null;
            }

            return member;
        }

        internal static bool IsMemberRegistered(string username, string email, AmazengContext db)
        {
            IQueryable<Member> memberQuery;

            memberQuery = db.Members.Where(m => m.Username == username && m.DeletedAt == null);

            if (memberQuery.Any()) //member found
            {
                return true;
            }

            memberQuery = db.Members.Where(m => m.Email == email && m.DeletedAt == null);
            if (memberQuery.Any()) //member found
            {
                return true;
            }

            return false;
        }



        internal static void ClearExistingAdminRememberToken(Admin admin, AmazengContext db)
        {
            admin.RememberToken = null;
            db.SaveChanges();
            //Member member; //should be admin
            //member = db.Members.Find(id);
            //if (member is null)
            //{
            //    return;
            //}
            //member.RememberToken
        }

        internal static void SetAdminRememberToken(Admin admin, AmazengContext db, HttpCookie rememberMeCookie)
        {
            string tokenHash = Util.ComputeSha256Hash(rememberMeCookie.Value);
            admin.RememberToken = tokenHash;
            admin.TokenExpiresAt = rememberMeCookie.Expires;
            db.SaveChanges();
        }



        internal static HttpCookie GenerateAdminRememberMeCookie(string userId)
        {
            string token = GenerateRandomToken(128);
            string rememberToken = $"{token}.{userId}";

            HttpCookie rememberTokenCookie = new HttpCookie("rememberToken");
            rememberTokenCookie.Value = rememberToken;
            rememberTokenCookie.Expires = DateTime.UtcNow.AddMonths(1);
            rememberTokenCookie.Path = "/";
            return rememberTokenCookie;
        }

        internal static Admin GetAdmin(string loginKey, string password, AmazengContext db)
        {
            IQueryable<Admin> adminQuery;
            Admin admin;

            if (Validator.IsValidEmail(loginKey))
            {
                adminQuery = db.Admins.Where(m => m.Email == loginKey);
            }
            else
            {
                adminQuery = db.Admins.Where(m => m.Username == loginKey);
            }

            if (adminQuery.Any() == false) //member not found
            {
                return null;
            }

            admin = adminQuery.First();

            if (!VerifyPassword(password, admin.Password))
            {
                return null;
            }

            return admin;
        }

        internal static bool IsUsernameRegistered(AmazengContext db, string username, int memberIdToExclude)
        {
            var query = db.Members.Where(m =>
                m.Username == username &&
                m.DeletedAt == null &&
                m.Id != memberIdToExclude
            );
            return query.Any();
        }

        internal static bool IsUsernameRegistered(AmazengContext db, string username)
        {
            var query = db.Members.Where(m =>
                m.Username == username &&
                m.DeletedAt == null
            );
            return query.Any();
        }

        internal static bool IsNameRegistered(AmazengContext db, string name, int tagIdToExclude)
        {
            var query = db.Tags.Where(t =>
                t.Name == name &&
                t.Id != tagIdToExclude
            );
            return query.Any();
        }

        internal static bool IsNameRegistered(AmazengContext db, string name)
        {
            var query = db.Tags.Where(t =>
                t.Name == name 
            );
            return query.Any();
        }


        internal static bool isEmailRegistered(AmazengContext db, string email, int memberIdToExclude)
        {
            var query = db.Members.Where(m =>
                  m.Email == email &&
                  m.DeletedAt == null &&
                  m.Id != memberIdToExclude
              );
            return query.Any();
        }

        internal static bool isEmailRegistered(AmazengContext db, string email)
        {
            var query = db.Members.Where(m =>
                m.Email == email &&
                m.DeletedAt == null
            );
            return query.Any();
        }


        public static void SetCustomAuthCookie(string username, string role, bool rememberMe)
        {
            SetCustomAuthCookie(username, role, rememberMe, null);
        }

        public static string GenerateRandomToken(int numberOfBits)
        {
            int numberOfBytes = numberOfBits / 8;
            byte[] bytes = new byte[numberOfBytes];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static void SetCustomAuthCookie(string username, string role, bool rememberMe, string cookiePath)
        {
            // this commented function is for role based authentication, however, the concept is not application
            // in amazeng website, refer to https://www.codeproject.com/Articles/104384/Authenticate-User-by-Roles-in-ASP-NET

            //// Create a new ticket used for authentication
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            //   1, // Ticket version
            //   username, // Username associated with ticket
            //   DateTime.Now, // Date/time issued
            //   DateTime.Now.AddHours(1), // Date/time to expire
            //   rememberMe, // "true" for a persistent user cookie
            //   role, // User-data, in this case the roles
            //   FormsAuthentication.FormsCookiePath);// Path cookie valid for

            //// Encrypt the cookie using the machine key for secure transport
            //string hash = FormsAuthentication.Encrypt(ticket);
            //HttpCookie cookie = new HttpCookie(
            //   FormsAuthentication.FormsCookieName, // Name of auth cookie
            //   hash); // Hashed ticket

            //// Set the cookie's expiration time to the tickets expiration time
            //if (ticket.IsPersistent)
            //{
            //    cookie.Expires = ticket.Expiration;
            //}

            //// Add the cookie to the list for outgoing response
            //System.Web.HttpContext.Current.Response.Cookies.Add(cookie);


            if (cookiePath is null)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                return;
            }

            FormsAuthentication.SetAuthCookie(username, rememberMe, cookiePath);
        }


    }
}