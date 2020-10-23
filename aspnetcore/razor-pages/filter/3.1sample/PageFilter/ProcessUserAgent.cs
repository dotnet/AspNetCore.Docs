using System.Diagnostics;

namespace PageFilter
{
    public static class ProcessUserAgent
    {
        // App must be run the first time as admin to create this EventLog.
        static ProcessUserAgent()
        {
            _eventLog = new EventLog("_Application");
            _eventLog.Source = "MyApp";
        }
        static EventLog _eventLog;

        public static void Write(string actionName, string filter, string userAgent, string userAgentID)
        {
            if (!userAgent.Contains(userAgentID))
            {
                return;
            }
            var message = actionName + " " + filter + " " + userAgent;

            _eventLog.WriteEntry(message, EventLogEntryType.Information, 101, 2);

            Debug.WriteLine(message);
        }

        public static void Write(string msg)
        {
            _eventLog.WriteEntry(msg, EventLogEntryType.Information);

            Debug.WriteLine(msg);
        }
    }
}
