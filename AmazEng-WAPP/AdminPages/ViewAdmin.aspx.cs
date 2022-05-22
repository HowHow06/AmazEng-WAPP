using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Services;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages
{
    public partial class ViewAdmin : System.Web.UI.Page
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
                FormAdminDetail.ChangeMode(FormViewMode.Edit);
                return;
            }

            if (string.Equals(mode, "new", StringComparison.OrdinalIgnoreCase))
            {
                //is edit mode
                FormAdminDetail.ChangeMode(FormViewMode.Insert);
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AmazEng_WAPP.Models.Admin FormAdminDetail_GetItem([RouteData] int? id)
        {
            if (id is null)
            {
                Response.Redirect(GetRouteUrl("AdminAdminsRoute", new { }));
                return null;
            }

            AmazengContext db = new AmazengContext();
            var admin = db.Admins.Find(id);

            if (admin is null || admin.DeletedAt != null)
            {
                Response.Redirect(GetRouteUrl("AdminAdminsRoute", new { }));
                return null;
            }
            return admin;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            var adminIdData = RouteData.Values["Id"];

            if (adminIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Admin admin;
            int adminId = Convert.ToInt32((string)adminIdData);
            var uploadProfile = FormAdminDetail.FindControl("uploadProfilePicture") as FileUpload;
            var txtEditName = FormAdminDetail.FindControl("txtEditName") as TextBox;
            var txtEditUsername = FormAdminDetail.FindControl("txtEditUsername") as TextBox;
            var txtEditEmail = FormAdminDetail.FindControl("txtEditEmail") as TextBox;
            var txtAdminRole = FormAdminDetail.FindControl("EditDropDownAdminRole") as DropDownList;
            string profileImagePath = null;
            string AdminRole = txtAdminRole.SelectedValue.ToString();
            int roleId = 0;


            // Debug Code to show selected dropdown value
            // Util.ShowAlert(this.Page, AdminRole);
            //return;



            //get DropDown from Admin Role and process the ID

            if (AdminRole.Equals(""))
            {
                Util.ShowAlert(this.Page, "Please Select Role!");
                return;
            }

            if (AdminRole.Equals("Admin"))
            {
                roleId = 1;
            }

            if (AdminRole.Equals("Super Admin"))
            {
                roleId = 2;
            }



            if (uploadProfile.HasFile)
            {
                string str = uploadProfile.FileName;
                profileImagePath = $"/Public/Uploads/{str}";
                uploadProfile.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }

            admin = db.Admins.Find(adminId);
            admin.Name = txtEditName.Text;
            admin.Username = txtEditUsername.Text;
            admin.Email = txtEditEmail.Text;
            admin.ProfilePicture = profileImagePath;
            admin.RoleId = roleId;
            db.SaveChanges();
            Response.Redirect(GetRouteUrl("AdminViewAdminRoute", new { Id = adminId }));
            return;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var adminIdData = RouteData.Values["Id"];

            if (adminIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Admin admin;
            int adminId = Convert.ToInt32((string)adminIdData);

            admin = db.Admins.Find(adminId);

            db.Admins.Remove(admin);
            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", GetRouteUrl("AdminAdminsRoute", new { }));
        }


        //Check this part for new admin account
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Admin admin;
            var uploadProfile = FormAdminDetail.FindControl("uploadProfilePicture") as FileUpload;
            var txtNewName = FormAdminDetail.FindControl("txtNewName") as TextBox;
            var txtNewUsername = FormAdminDetail.FindControl("txtNewUsername") as TextBox;
            var txtNewEmail = FormAdminDetail.FindControl("txtNewEmail") as TextBox;
            var txtNewPassword = FormAdminDetail.FindControl("txtNewPassword") as TextBox;
            var txtNewRePassword = FormAdminDetail.FindControl("txtNewRePassword") as TextBox;
            var txtAdminRole = FormAdminDetail.FindControl("DropDownAdminRole") as DropDownList;
            string profileImagePath = null;
            int roleId = 0;
            string AdminRole = txtAdminRole.SelectedValue.ToString();


            // Debug Code to show selected dropdown value
            // Util.ShowAlert(this.Page, AdminRole);
            //return;



            //get DropDown from Admin Role and process the ID

            if (AdminRole.Equals(""))
            {
                Util.ShowAlert(this.Page,"Please Select Role!");
                return;
            }

            if (AdminRole.Equals("Admin"))
            {
                roleId = 1;
            }

            if (AdminRole.Equals("Super Admin"))
            {
                roleId = 2;
            }

            
            if (uploadProfile.HasFile)
            {
                string str = uploadProfile.FileName;
                profileImagePath = $"/Public/Uploads/{str}";
                uploadProfile.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }

            db.Admins.Add(
                new Admin
                {
                    Name = txtNewName.Text,
                    Username = txtNewUsername.Text,
                    Email = txtNewEmail.Text,
                    Password = Auth.CreatePasswordHash(txtNewPassword.Text),
                    ProfilePicture = profileImagePath,
                    RoleId = roleId
                }
                );

            db.SaveChanges();
            admin = db.Admins.Where(m => m.Username == txtNewUsername.Text).First();
            Response.Redirect(GetRouteUrl("AdminViewAdminRoute", new { Id = admin.Id, Mode = string.Empty }));
            return;
             
        }



        protected void validatorUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;
            int adminId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            bool isUsernameRegistered = Auth.IsUsernameRegistered(db, username, adminId);
            var validator = FormAdminDetail.FindControl("validatorUsername") as CustomValidator;
            var controlToValidate = FormAdminDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isUsernameRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This username is used by other admin.");
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
            int adminId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            bool isEmailRegistered = Auth.isEmailRegistered(db, email, adminId);
            var validator = FormAdminDetail.FindControl("validatorEditEmail") as CustomValidator;
            var controlToValidate = FormAdminDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isEmailRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This email is used by other admin.");
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
            var validator = FormAdminDetail.FindControl("validatorNewEmail") as CustomValidator;
            var controlToValidate = FormAdminDetail.FindControl(validator.ControlToValidate) as TextBox;


            if (isEmailRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This email is used by other admin.");
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
            var validator = FormAdminDetail.FindControl("validatorNewUsername") as CustomValidator;
            var controlToValidate = FormAdminDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isUsernameRegistered)
            {  //username invalid
                Util.ShowAlert(this, "This username is used by other admin.");
                controlToValidate.Attributes.Add("class", "form-control error");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                args.IsValid = false;
                return;
            }
            controlToValidate.Attributes.Add("class", "form-control");
            validator.Attributes.Add("class", "invalid-feedback");
            args.IsValid = true;
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            Admin admin = db.Admins.Find(adminId);

            if (admin == null)
            {
                return;
            }

            string newPassword = Membership.GeneratePassword(10, 3);
            admin.Password = Auth.CreatePasswordHash(newPassword);
            db.SaveChanges();

            // send reset notice
            EmailService.CreateAndSendHTMLEmail($"<div style='font-family: Arial, Helvetica, sans-serif;'>" +
                $"<p>Dear Admin, </p><br/> " +
                $"<p>Your password has been reset. <br/>" +
                $"Your new password is:<u>{newPassword}</u></p>" +
                $"<br/><br/>" +
                $"Regards,<br/>" +
                $"AmazEng Team" +
                $"</div>"
                ,
                admin.Email
                );
            Util.ShowAlertAndRedirect(this, "The password is successfully reset.", Request.RawUrl);
        }


        //Convert ID to AdminRole Name for the dropdown code 
        //Reference : https://stackoverflow.com/questions/2469005/bind-a-users-role-to-dropdown

        public String GetAdminRoleName(int adminID)
        {
           
            AmazengContext db = new AmazengContext();
            AdminRole admin;
            admin = db.AdminRoles.Find(adminID);
            String adminRoleName = admin.Name;

            return adminRoleName;
        }

    }
}