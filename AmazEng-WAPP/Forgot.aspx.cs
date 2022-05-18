using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Services;
using AmazEng_WAPP.Class.Utils;
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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class Forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string emailAddress = txtEmail.Text;
            string newPassword = "asdasdasdsa";
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
        }
    }
}