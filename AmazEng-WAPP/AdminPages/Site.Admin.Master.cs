using AmazEng_WAPP.Class.Auth;
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
    public partial class Site_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            Admin admin = Auth.GetLoggedInAdmin(Session, Request, db);
            if (admin == null)
            {
                Response.Redirect(GetRouteUrl("AdminLoginRoute", new { }));
            }

        }

        protected void btnAdminLogout_Click(object sender, EventArgs e)
        {
            Auth.AdminLogout(Session, Request);
            Response.Redirect(GetRouteUrl("AdminLoginRoute", new { }));
        }
    }
}