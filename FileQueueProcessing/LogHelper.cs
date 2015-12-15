using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileQueueProcessing
{
    public static class LogHelper
    {
        public const string LogFileName = "file_log.txt";

        public static void LogMessage(string logMessage)
        {
            CreateLogFile();
            using (StreamWriter w = File.AppendText(LogFileName))
            {
                Log(logMessage, w);
            }
        }

        private static void CreateLogFile()
        {
            if (File.Exists(LogFileName))
            {
                File.Delete(LogFileName);
            }
            File.Create(LogFileName).Close();
        }

        private static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
