using AmazEng_WAPP.Class.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace AmazEng_WAPP.Class.Utils
{
    public class Util
    {
        public static string GetRelativePath(string relativePath)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, relativePath);
            string sFilePath = Path.GetFullPath(sFile);
            return sFilePath;
        }

        public static string CapitalizeFirstLetter(string text)
        {

            if (text.Length == 0)
            {
                return text;
            }

            if (text.Length == 1)
            {
                return char.ToUpper(text[0]).ToString();
            }

            return char.ToUpper(text[0]) + text.Substring(1);

        }

        public static void ShowAlert(Control contorl, string message)
        {
            ScriptManager.RegisterStartupScript(contorl, contorl.GetType(), "alertFunction", $"alert('{message}');", true);
        }

        public static void ShowAlertAndRedirect(Control control, string message, string url)
        {
            LogConsole(control, "asdasdasd");
            ScriptManager.RegisterStartupScript(control, control.GetType(), "redirectFunction", $"alert('{message}'); window.location.replace('{url}')", true);
        }

        internal static HtmlGenericControl CreateCheckSvgControl()
        {
            HtmlGenericControl svg = new HtmlGenericControl("svg");
            svg.Attributes.Add("class", "icon icon-xxs ms-auto");
            svg.Attributes.Add("fill", "currentColor");
            svg.Attributes.Add("viewBox", "0 0 20 20");
            svg.Attributes.Add("xmlns", "http://www.w3.org/2000/svg");
            svg.InnerHtml = "<path fill-rule='evenodd' d='M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z' clip-rule='evenodd'></path>";
            return svg;
        }

        internal static void ShowConfirmAndRedirect(Control control, string message, string url)
        {
            ScriptManager.RegisterStartupScript(control, control.GetType(),
                "confirmAndRedirectFunction",
                $"if(confirm('{message}')) window.location.replace('{url}')", true);
        }

        public static void LogConsole(Control control, string message)
        {
            ScriptManager.RegisterStartupScript(control, control.GetType(), "logFunction", $"console.log('{message}');", true);
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void LogOutput(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}