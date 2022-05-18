using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages.MemberPages
{
    public partial class ViewMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var modeRouteData = RouteData.Values["Mode"];
            string mode = "";
            if (modeRouteData is object)
            {
                mode = modeRouteData.ToString();
            }

            if (string.Equals(mode, "edit", StringComparison.OrdinalIgnoreCase))
            {
                //is edit mode
                FormMemberDetail.ChangeMode(FormViewMode.Edit);
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AmazEng_WAPP.Models.Member FormMemberDetail_GetItem([RouteData] int? id)
        {
            if (id is null)
            {
                Response.Redirect(GetRouteUrl("AdminMembersRoute", new { }));
                return null;
            }

            AmazengContext db = new AmazengContext();
            var member = db.Members.Find(id);

            if (member is null || member.DeletedAt != null)
            {
                Response.Redirect(GetRouteUrl("AdminMembersRoute", new { }));
                return null;
            }
            return member;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var memberIdData = RouteData.Values["Id"];

            if (memberIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Member member;
            int memberId = Convert.ToInt32((string)memberIdData);
            var uploadProfile = FormMemberDetail.FindControl("uploadProfilePicture") as FileUpload;
            var txtEditName = FormMemberDetail.FindControl("txtEditName") as TextBox;
            var txtEditUsername = FormMemberDetail.FindControl("txtEditUsername") as TextBox;
            var txtEditEmail = FormMemberDetail.FindControl("txtEditEmail") as TextBox;
            string profileImagePath = null;

            if (uploadProfile.HasFile)
            {
                string str = uploadProfile.FileName;
                profileImagePath = $"/Public/Uploads/{str}";
                uploadProfile.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }

            member = db.Members.Find(memberId);
            member.Name = txtEditName.Text;
            member.Username = txtEditUsername.Text;
            member.Email = txtEditEmail.Text;
            member.ProfilePicture = profileImagePath;
            db.SaveChanges();
            Response.Redirect(GetRouteUrl("AdminViewMemberRoute", new { Id = memberId }));
            return;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var memberIdData = RouteData.Values["Id"];

            if (memberIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Member member;
            int memberId = Convert.ToInt32((string)memberIdData);

            member = db.Members.Find(memberId);

            db.Members.Remove(member);
            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", GetRouteUrl("AdminMembersRoute", new { }));
        }
    }
}