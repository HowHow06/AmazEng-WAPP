using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Utils
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
    }
}