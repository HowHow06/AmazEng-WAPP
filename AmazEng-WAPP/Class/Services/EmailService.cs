using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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
    }
}