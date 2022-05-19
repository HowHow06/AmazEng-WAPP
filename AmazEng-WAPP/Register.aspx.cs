using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AmazEng_WAPP
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            string name = txtName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string repassword = txtRePassword.Text;
            bool isTermChecked = ckbTerms.Checked;
            bool isMemberRegistered;

            //Check if name contains numbers and special characters
            if (!Validator.IsValidName(name))
            {
                Util.ShowAlert(this.Page, "Name Cannot Contain Numbers/Special Characters!");
                return;
            }

            //Check if password and reenter password is same value
            if (password != repassword)
            {
                Util.ShowAlert(this.Page, "Password Does not Match!");
                return;
            }

            //Check if email is valid
            if (!Validator.IsValidEmail(email))
            {
                Util.ShowAlert(this.Page, "Please Enter Valid Email Address!");
                return;
            }

            //Check if all data is filled out in the form
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Util.ShowAlert(this.Page, "Please Fill Up All Fields!");
                return;
            }

            if (isTermChecked == false)
            {
                Util.ShowAlert(this.Page, "Please Accept the terms and condition.");
                return;
            }


            // Check if the user record exists, if yes registration is not performed
            isMemberRegistered = Auth.IsMemberRegistered(username, email, db);

            if (isMemberRegistered)
            {
                Util.ShowAlert(Page, "Member Record Exists!");
                return;
            }

            db.Members.Add(
            new Member
            {
                Name = name,
                Username = username,
                Password = Auth.CreatePasswordHash(password),
                Email = email,
            }
            );
            db.SaveChanges();


            Util.ShowAlertAndRedirect(Page, "Member Registration Success!", GetRouteUrl("LoginRoute", new { }));
        }

        protected void validatorUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;
            int memberId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            bool isUsernameRegistered = Auth.IsUsernameRegistered(db, username, memberId);
            var validator = validatorUsername;
            var controlToValidate = usernameField.FindControl(validator.ControlToValidate) as TextBox;

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
            var validator = validatorEditEmail;
            var controlToValidate = emailField.FindControl(validator.ControlToValidate) as TextBox;

            if (isEmailRegistered)
            {  //email invalid
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

        protected void validatorTerms_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isTermsChecked = ckbTerms.Checked;
            validatorTerms.Visible = !isTermsChecked;
            args.IsValid = isTermsChecked;
        }
    }

}


