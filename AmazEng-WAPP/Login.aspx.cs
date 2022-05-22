using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("/", true);
            }

            if (Request.QueryString["alert"] is object)
            {
                Util.ShowAlert(this, "This action requires login.");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            string loginKey = txtUsername.Text;
            string password = txtPassword.Text;
            bool rememberMe = ckbRememberMe.Checked;
            string role = "member";
            Member member;

            if (string.IsNullOrEmpty(loginKey) || string.IsNullOrEmpty(password))
            {
                return;
            }

            member = Auth.GetMember(loginKey, password, db);

            if (member is null)
            {
                Util.ShowAlert(this.Page, "Invalid Credential!");
                return;
            }

            Auth.SetCustomAuthCookie(member.Username, role, rememberMe);

            Response.Redirect("/", true);
        }
    }
}