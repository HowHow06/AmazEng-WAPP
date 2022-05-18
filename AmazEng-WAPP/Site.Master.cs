using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                return;
            }
            Member currentMember;
            string username = HttpContext.Current.User.Identity.Name;

            AmazengContext db = new AmazengContext();
            currentMember = db.Members.Where(m => m.Username == username).First();

            if (currentMember is null || currentMember.DeletedAt != null)
            {
                // deleted user or invalid user
                FormsAuthentication.SignOut();
                //refresh
                Response.Redirect(Request.RawUrl);
            }


            //string currentUsersName = HttpContext.Current.User.Identity.Name;
            //FormsIdentity ident = HttpContext.Current.User.Identity as FormsIdentity;
            //if (ident is object)
            //{
            //    string currentUserData = ident.Ticket.UserData;

            //    //Util.LogConsole(this.Page, currentUsersName);

            //    Util.LogConsole(this.Page, currentUserData);

            //    //string[] roles = Roles.GetRolesForUser();
            //    //foreach (var role in roles)
            //    //{
            //    //    Util.LogConsole(this.Page, $"Role is: {role}");
            //    //}

            //}
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //sign out from form authentication
            FormsAuthentication.SignOut();
            //refresh
            Response.Redirect(Request.RawUrl);
        }
    }
}