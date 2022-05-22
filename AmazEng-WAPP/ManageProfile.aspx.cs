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
    public partial class ManageProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect(GetRouteUrl("LoginRoute", new { }));
            }
            if (!IsPostBack)
            {
                formRefresh();
            }
           
        }

        private void formRefresh()
        {
                AmazengContext db = new AmazengContext();
                Member Member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
                txtUsername.Text = Member.Username.ToString();
                txtName.Text = Member.Name.ToString();
                txtEmail.Text = Member.Email.ToString();
                imgProfilePicture.ImageUrl = Member.ProfilePicture ?? "https://via.placeholder.com/400x400";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var Username = txtUsername.Text;
            var Name = txtName.Text;
            var Email = txtEmail.Text;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email))
            {
                return;
            }
            AmazengContext db = new AmazengContext();
            Member UpdateMember = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            UpdateMember.Name = Name;
            UpdateMember.Email = Email;
            string profileImagePath = null;
            if (txtImageUpload.HasFile)
            {
                string str = txtImageUpload.FileName;
                profileImagePath = $"/Public/Uploads/{str}";
                txtImageUpload.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }
            UpdateMember.ProfilePicture = profileImagePath ?? UpdateMember.ProfilePicture;
            Util.ShowAlert(this.Page, "Edit successfully" );
            db.SaveChanges();
            formRefresh();
        }
    }
}