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
        private Member Member;
        private Member UpdateMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            Member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            txtUsername.Text = Member.Username.ToString();
            txtName.Text = Member.Name.ToString();
            txtEmail.Text = Member.Email.ToString();
           // imgProfilePicture.ImageUrl = Member.ProfilePicture;
          //  txtImageUpload.
        }
    //    private void RenderProfilePicture()
    //    {
    //        if (!string.IsNullOrEmpty(Member.ProfilePicture))
    //        {
    //            imgProfilePicture.ImageUrl = Member.ProfilePicture;
    //        }
    //    }

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
            UpdateMember = db.GetMemberByUsername(Username);
            UpdateMember.Name = Name;
            UpdateMember.Email = Email;

            Util.ShowAlert(this.Page, "Edit successfully" + UpdateMember.Name + Name + txtName.Text.ToString());
            db.SaveChanges();
            return;
        }
    }
}