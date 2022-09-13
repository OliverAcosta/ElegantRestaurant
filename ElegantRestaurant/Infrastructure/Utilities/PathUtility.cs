using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utilities
{
    public class PathUtility
    {
        public static string GetPath()
        {
            return string.Empty;
        }
        public static string GetCurrentDomainPath()
        {
            return System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) 
                + System.IO.Path.DirectorySeparatorChar;
        }
        public static string GetCurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory() +  System.IO.Path.DirectorySeparatorChar;
        }
        public static string GetPathByProcess()
        {
            var process = Process.GetCurrentProcess(); // Or whatever method you are using
            return System.IO.Path.GetDirectoryName(process.MainModule.FileName) + System.IO.Path.DirectorySeparatorChar;
        }

        public static bool CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                   path = Path.GetDirectoryName(path);
                   Directory.CreateDirectory(path);
                   return true;
                }
            }
            catch (Exception){}
            return false;
        }

        public static bool ExistPath(string path)
        {
            return File.Exists(path);
        }
    }
}
