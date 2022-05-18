using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

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


        public static void ShowAlert(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alertFunction", $"alert('{message}');", true);
        }

        public static void ShowAlertAndRedirect(Page page, string message, string url)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "redirectFunction", $"alert('{message}'); window.location.replace('{url}')", true);
        }

        public static void LogConsole(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "logFunction", $"console.log('{message}');", true);
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
    }
}