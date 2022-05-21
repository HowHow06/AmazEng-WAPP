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

namespace AmazEng_WAPP
{
    public partial class ManagePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            if (!Auth.VerifyPassword(oldPassword, member.Password))
            {
                Util.ShowAlert(this, "The original password is invalid!");
                return;
            }
            member.Password = Auth.CreatePasswordHash(newPassword);
            db.SaveChanges();
            Util.ShowAlert(this, "Password updated successfully.");
        }
    }
}