using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Services;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class Forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("/", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string emailAddress = txtEmail.Text;
            AmazengContext db = new AmazengContext();

            if (!Auth.isEmailRegistered(db, emailAddress))
            {
                errInvalidEmail.Attributes.Add("class", "invalid-feedback d-inline");
                return;
            }

            string newPassword = Membership.GeneratePassword(10, 3);
            Member member = db.Members.Where(m => m.Email == emailAddress && m.DeletedAt == null).First();
            member.Password = Auth.CreatePasswordHash(newPassword);
            db.SaveChanges();

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(ConfigurationManager.AppSettings["emailServiceFromEmail"]));
            email.To.Add(MailboxAddress.Parse(emailAddress));
            email.Subject = "Password Recovery";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<div style='font-family: Arial, Helvetica, sans-serif;'>" +
                $"<p>Dear Member, </p><br/> " +
                $"<p>Your password has been reset successfully. <br/>" +
                $"Your new password is:<u>{newPassword}</u></p>" +
                $"<br/><br/>" +
                $"Regards,<br/>" +
                $"AmazEng Team" +
                $"</div>"
            };

            EmailService.SendEmail(email);
            Util.ShowAlertAndRedirect(this, "Recovery email is sent to your email, please login with your new password.", GetRouteUrl("LoginRoute", new { }));
        }
    }
}