using AmazEng_WAPP.Class.Auth;
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
                return;
            }

            if (string.Equals(mode, "new", StringComparison.OrdinalIgnoreCase))
            {
                //is edit mode
                FormMemberDetail.ChangeMode(FormViewMode.Insert);
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
            if (!Page.IsValid)
            {
                return;
            }
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            AmazengContext db = new AmazengContext();
            Member member;
            var uploadProfile = FormMemberDetail.FindControl("uploadProfilePicture") as FileUpload;
            var txtNewName = FormMemberDetail.FindControl("txtNewName") as TextBox;
            var txtNewUsername = FormMemberDetail.FindControl("txtNewUsername") as TextBox;
            var txtNewEmail = FormMemberDetail.FindControl("txtNewEmail") as TextBox;
            var txtNewPassword = FormMemberDetail.FindControl("txtNewPassword") as TextBox;
            var txtNewRePassword = FormMemberDetail.FindControl("txtNewRePassword") as TextBox;
            string profileImagePath = null;

            if (uploadProfile.HasFile)
            {
                string str = uploadProfile.FileName;
                profileImagePath = $"/Public/Uploads/{str}";
                uploadProfile.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }

            db.Members.Add(
                new Member
                {
                    Name = txtNewName.Text,
                    Username = txtNewUsername.Text,
                    Email = txtNewEmail.Text,
                    Password = Auth.CreatePasswordHash(txtNewPassword.Text),
                    ProfilePicture = profileImagePath
                }
                );

            db.SaveChanges();
            member = db.Members.Where(m => m.Username == txtNewUsername.Text).First();
            Response.Redirect(GetRouteUrl("AdminViewMemberRoute", new { Id = member.Id, Mode = string.Empty }));
            return;
        }

        protected void validatorUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;
            int memberId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            bool isUsernameRegistered = Auth.IsUsernameRegistered(db, username, memberId);
            var validator = FormMemberDetail.FindControl("validatorUsername") as CustomValidator;
            var controlToValidate = FormMemberDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isUsernameRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This username is used by other member.");
                controlToValidate.Attributes.Add("class", "form-control error");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                args.IsValid = false;
                return;
            }
            controlToValidate.Attributes.Add("class", "form-control");
            validator.Attributes.Add("class", "invalid-feedback");
            args.IsValid = true;
        }

        protected void validatorEditEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = args.Value;
            int memberId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            bool isEmailRegistered = Auth.isEmailRegistered(db, email, memberId);
            var validator = FormMemberDetail.FindControl("validatorEditEmail") as CustomValidator;
            var controlToValidate = FormMemberDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isEmailRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This email is used by other member.");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                controlToValidate.Attributes.Add("class", "form-control error");
                args.IsValid = false;
                return;
            }
            validator.Attributes.Add("class", "invalid-feedback");
            controlToValidate.Attributes.Add("class", "form-control");
            args.IsValid = true;
        }

        protected void validatorNewEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = args.Value;
            AmazengContext db = new AmazengContext();
            bool isEmailRegistered = Auth.isEmailRegistered(db, email);
            var validator = FormMemberDetail.FindControl("validatorNewEmail") as CustomValidator;
            var controlToValidate = FormMemberDetail.FindControl(validator.ControlToValidate) as TextBox;


            if (isEmailRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This email is used by other member.");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                controlToValidate.Attributes.Add("class", "form-control error");
                args.IsValid = false;
                return;
            }

            validator.Attributes.Add("class", "invalid-feedback");
            controlToValidate.Attributes.Add("class", "form-control");
            args.IsValid = true;
        }

        protected void validatorNewUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;
            AmazengContext db = new AmazengContext();
            bool isUsernameRegistered = Auth.IsUsernameRegistered(db, username);
            var validator = FormMemberDetail.FindControl("validatorNewUsername") as CustomValidator;
            var controlToValidate = FormMemberDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isUsernameRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This username is used by other member.");
                controlToValidate.Attributes.Add("class", "form-control error");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                args.IsValid = false;
                return;
            }
            controlToValidate.Attributes.Add("class", "form-control");
            validator.Attributes.Add("class", "invalid-feedback");
            args.IsValid = true;
        }
    }
}