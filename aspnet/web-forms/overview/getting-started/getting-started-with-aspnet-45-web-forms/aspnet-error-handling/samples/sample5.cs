using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WingtipToys.Logic
{
  // Create our own utility for exceptions
  public sealed class ExceptionUtility
  {
    // All methods are static, so this can be private
    private ExceptionUtility()
    { }

    // Log an Exception
    public static void LogException(Exception exc, string source)
    {
      // Include logic for logging exceptions
      // Get the absolute path to the log file
      string logFile = "~/App_Data/ErrorLog.txt";
      logFile = HttpContext.Current.Server.MapPath(logFile);

      // Open the log file for append and write the log
      StreamWriter sw = new StreamWriter(logFile, true);
      sw.WriteLine("********** {0} **********", DateTime.Now);
      if (exc.InnerException != null)
      {
        sw.Write("Inner Exception Type: ");
        sw.WriteLine(exc.InnerException.GetType().ToString());
        sw.Write("Inner Exception: ");
        sw.WriteLine(exc.InnerException.Message);
        sw.Write("Inner Source: ");
        sw.WriteLine(exc.InnerException.Source);
        if (exc.InnerException.StackTrace != null)
        {
          sw.WriteLine("Inner Stack Trace: ");
          sw.WriteLine(exc.InnerException.StackTrace);
        }
      }
      sw.Write("Exception Type: ");
      sw.WriteLine(exc.GetType().ToString());
      sw.WriteLine("Exception: " + exc.Message);
      sw.WriteLine("Source: " + source);
      sw.WriteLine("Stack Trace: ");
      if (exc.StackTrace != null)
      {
        sw.WriteLine(exc.StackTrace);
        sw.WriteLine();
      }
      sw.Close();
    }
  }
}
