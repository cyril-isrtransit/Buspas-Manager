using BuspasManager.App_Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;

namespace BuspasManager.App_Logs
{

    static class LogClass
    {
        static String logFolderName = GetFoldername();
        static String prefixLogFilename = Assembly.GetCallingAssembly().GetName().Name;

        static Object lockObject = new Object();

        static private String GetFoldername()
        {
            string logFilePath = Path.Combine(Directory.GetParent(AssemblyDirectory).FullName, "Logs");

            if (!Directory.Exists(logFilePath))
                Directory.CreateDirectory(logFilePath);

            return logFilePath;
        }

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        static private String GetFilename()
        {
            return Path.Combine(logFolderName, prefixLogFilename + DateTime.Today.ToString("yyMMdd") + ".txt");
        }

        private static void DeleteOlderLog()
        {
            foreach (String filename in Directory.EnumerateFiles(logFolderName))
            {
                if (!filename.StartsWith(Path.Combine(logFolderName, prefixLogFilename)))
                    continue;

                try
                {
                    if (DateTime.Now > File.GetCreationTime(filename).AddDays(ApplicationSettings.LogDeleteAfterNumberDays))
                        File.Delete(filename);
                }
                catch { }
            }
        }

        public static void SaveToLog(string line)
        {
            try
            {
                String filename = GetFilename();

                if (!File.Exists(filename))
                    DeleteOlderLog();

                lock (lockObject)  // all other threads will wait for y
                {
                    File.AppendAllText(GetFilename(), Environment.NewLine + new String('*', 50) + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + line);
                }
            }
            catch
            {
            }
        }

        public static void SaveExceptionToLog(string file, String method, String exceptionMessage, String methodParams = "")
        {
            SaveToLog("File:" + file + " Method:" + method + (methodParams.Length > 0 ? "Params:" + methodParams : "") + " Exception:" + exceptionMessage);
        }

        public static void SaveExceptionToLog(Exception exception, String methodParams = "", String comment = "")
        {
            String line = " Exception:" + exception.Message
                         + (exception.InnerException != null ? "  inner Exception: " + exception.InnerException.Message : "")
                         + (methodParams.Length > 0 ? "  Params:" + methodParams : "")
                         + (comment.Length > 0 ? "   comment: " + comment : "");

            var stackTrace = new StackTrace(exception, true); // create the stack trace
            //StackFrame stackFrame = stackTrace.GetFrames().FirstOrDefault(x => x.GetFileName() != null );

            foreach (StackFrame stackFrame in stackTrace.GetFrames())
            {
                line += Environment.NewLine
                      + " *** File:" + stackFrame.GetFileName()
                      + "   Method:" + stackFrame.GetMethod()
                      + "   Line:" + stackFrame.GetFileLineNumber()
                      + "   Exception:" + exception.Message;
            }

            SaveToLog(line);
        }

        public static void SaveObjectToLog(String text, Object obj)
        {
            SaveToLog(text + Environment.NewLine + Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public static void SaveObjectToLog(Object sender, String className = "")
        {
            try
            {
                String value = className + ": " + Environment.NewLine;

                foreach (PropertyInfo propertyInfo in sender.GetType().GetProperties())
                    value += propertyInfo.Name + " : " + Convert.ToString(propertyInfo.GetValue(sender, null)) + Environment.NewLine;

                SaveToLog(value);
            }
            catch { }
        }

        public static void ClearLog()
        {
            File.Create(GetFilename()).Close();
        }
    }
}


