using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoUpdateProLibrary.Model
{
    public static class Log
    {
        public static void WriteMessage(string path, string message)
        {
            try
            {
                using (StreamWriter w = new StreamWriter(path + @"\log.txt"))
                {
                    w.WriteLine(message);
                    w.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void WriteMessage(string message)
        {
            WriteMessage(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), message);
        }
    }
}
