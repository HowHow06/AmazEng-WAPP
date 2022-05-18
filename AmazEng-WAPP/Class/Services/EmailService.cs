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

namespace AmazEng_WAPP.Class.Services
{
    public class EmailService
    {
        static string smtpEndPoint = ConfigurationManager.AppSettings["emailServiceProviderSmtp"];
        static string smtpPort = ConfigurationManager.AppSettings["emailServiceProviderPort"];
        static string smtpUsername = ConfigurationManager.AppSettings["emailServiceUserName"];
        static string smtpPassword = ConfigurationManager.AppSettings["emailServicePassword"];


        public static void SendEmail(MimeMessage email)
        {

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(smtpEndPoint,
                    Convert.ToInt32(smtpPort),
                    SecureSocketOptions.StartTls);
                smtp.Authenticate(
                   smtpUsername,
                    smtpPassword
                    );
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        internal static MimeMessage CreateHTMLEmail(string htmlText, string toEmail)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(ConfigurationManager.AppSettings["emailServiceFromEmail"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Password Recovery";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlText
            };

            return email;
        }

        internal static void CreateAndSendHTMLEmail(string htmlText, string emailAddress)
        {
            MimeMessage email = CreateHTMLEmail(htmlText, emailAddress);
            SendEmail(email);
        }
    }
}