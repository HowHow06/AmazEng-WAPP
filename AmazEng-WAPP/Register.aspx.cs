using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System.Data.Entity;
using System.Web.Security;
using System.Threading;

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
            IQueryable<Member> memberQuery;
            string name = txtName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string repassword = txtRePassword.Text;
            bool rememberMe = ckbTerms.Checked;
            string role = "member";
            Member member;


            //Check if password and reenter password is same value

            if(password != repassword)
            {
                Util.ShowAlert(this.Page, "Password Does not Match!");
                return;
            }


            //Check if email is valid

            if (!email.Contains("@"))
            {
                Util.ShowAlert(this.Page, "Please Enter Valid Email Address!");
                txtEmail.Text = " ";
            }
            //Check if all data is filled out in the form

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || (rememberMe==false))
            {
                Util.ShowAlert(this.Page, "Please Fill Up All Fields!");
                return;
            }



            // Check if the user record exists, if yes registration is not performed
            
            member = Auth.CheckRegisteredMember(username, email, db);

            //Get number of lines from database

            

            if (member is null)
            {

                int row_count =
            db.Database.ExecuteSqlCommand(@"
               SELECT COUNT(1) FROM dbo.Members;
            ");
                int MemberId = row_count + 1;

                db.Members.Add(
                new Member
                {
                    Id = MemberId,
                    Name = name,
                    Username = username,
                    Password = Auth.CreatePasswordHash(password),
                    Email = email,
                }
                );
                db.SaveChanges();
                MemberId = 0;


               

                ScriptManager.RegisterStartupScript(this, this.GetType(), 
"alert",
"alert('Member Registration Success!');window.location ='Login.aspx';", 
true);
               
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
"alert",
"alert('Member Record Exists!');window.location ='Login.aspx';",
true);
            }

        }
            
    }
}