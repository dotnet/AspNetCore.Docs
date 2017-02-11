using System;
using System.Diagnostics;
using System.Text;
 
namespace WingtipToys.Logging
{
  public class Logger : ILogger
  {
 
    public void Information(string message)
    {
      Trace.TraceInformation(message);
    }
 
    public void Information(string fmt, params object[] vars)
    {
      Trace.TraceInformation(fmt, vars);
    }
 
    public void Information(Exception exception, string fmt, params object[] vars)
    {
      Trace.TraceInformation(FormatExceptionMessage(exception, fmt, vars));
    }
 
    public void Warning(string message)
    {
      Trace.TraceWarning(message);
    }
 
    public void Warning(string fmt, params object[] vars)
    {
      Trace.TraceWarning(fmt, vars);
    }
 
    public void Warning(Exception exception, string fmt, params object[] vars)
    {
      Trace.TraceWarning(FormatExceptionMessage(exception, fmt, vars));
    }
 
    public void Error(string message)
    {
      Trace.TraceError(message);
    }
 
    public void Error(string fmt, params object[] vars)
    {
      Trace.TraceError(fmt, vars);
    }
 
    public void Error(Exception exception, string fmt, params object[] vars)
    {
      Trace.TraceError(FormatExceptionMessage(exception, fmt, vars));
    }
 
    public void TraceApi(string componentName, string method, TimeSpan timespan)
    {
      TraceApi(componentName, method, timespan, "");
    }
 
    public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
    {
      TraceApi(componentName, method, timespan, string.Format(fmt, vars));
    }
    public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
    {
      string message = String.Concat("Component:", componentName, ";Method:", method, ";Timespan:", timespan.ToString(), ";Properties:", properties);
      Trace.TraceInformation(message);
    }
 
    private static string FormatExceptionMessage(Exception exception, string fmt, object[] vars)
    {
      var sb = new StringBuilder();
      sb.Append(string.Format(fmt, vars));
      sb.Append(" Exception: ");
      sb.Append(exception.ToString());
      return sb.ToString();
    }
  }
}