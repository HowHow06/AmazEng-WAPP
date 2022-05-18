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
            AmazengContext db = new AmazengContext();
            string name = txtName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string repassword = txtRePassword.Text;
            bool isTermChecked = ckbTerms.Checked;
            bool isMemberRegistered;

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
    }

}


