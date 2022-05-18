using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages
{
    public partial class AdminLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            Admin admin = Auth.GetLoggedInAdmin(Session, Request, db);

            if (admin is object)
            {
                Session[Auth.GetAdminSessionName()] = admin.Username;
                Response.Redirect(GetRouteUrl("AdminDashboardRoute", new { }), true);
            }
            //Util.ShowAlert(this.Page, "No admin founded");
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            string loginKey = txtLoginKey.Text;
            string password = txtPassword.Text;
            bool rememberMe = ckbRemember.Checked;
            Admin admin;

            if (string.IsNullOrEmpty(loginKey) || string.IsNullOrEmpty(password))
            {
                return;
            }

            admin = Auth.GetAdmin(loginKey, password, db);

            if (admin is null)
            {
                Util.ShowAlert(this.Page, "Invalid Credential!");
                return;
            }

            Session[Auth.GetAdminSessionName()] = admin.Username;

            if (rememberMe)
            {
                HttpCookie rememberTokenCookie = Auth.GenerateAdminRememberMeCookie(admin.Id.ToString());
                Auth.ClearExistingAdminRememberToken(admin, db);
                Auth.SetAdminRememberToken(admin, db, rememberTokenCookie);
                Response.Cookies.Add(rememberTokenCookie);
            }

            Response.Redirect(GetRouteUrl("AdminDashboardRoute", new { }), true);
        }
    }
}