using System;
using System.Linq;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.Diagnostics.Management;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole1.SignalRHelper
{
    public class SignalRDiagnosticHelper
    {
        private const string EmulatorCategoryTemplate = "signalr({0}_web)";
        private const string CloudCategoryTemplate = "signalr({0}_in_{1}_web)";

        public static string createSignalRCategoryName()
        {
            if (RoleEnvironment.IsEmulated)
            {
                string id = RoleEnvironment.CurrentRoleInstance.Id.ToLower();
                return string.Format(EmulatorCategoryTemplate, id);
            }
            else
            {
                var name = RoleEnvironment.CurrentRoleInstance.Role.Name.ToLower();
                var number = RoleEnvironment.CurrentRoleInstance.Id.Split(new char[] { '_' }).Last();
                return string.Format(CloudCategoryTemplate, name, number);

            }

        }

        public static void RegisterSignalRPerfCounters()
        {
            TimeSpan ts = new TimeSpan(0, 0, 10);

            RoleInstanceDiagnosticManager roleInstanceDiagnosticManager =
            new RoleInstanceDiagnosticManager(
            RoleEnvironment.GetConfigurationSettingValue("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString"),
            RoleEnvironment.DeploymentId,
            RoleEnvironment.CurrentRoleInstance.Role.Name,
            RoleEnvironment.CurrentRoleInstance.Id);

            // Get the current diagnostic monitor for the role.
            var config = roleInstanceDiagnosticManager.GetCurrentConfiguration() ?? DiagnosticMonitor.GetDefaultInitialConfiguration();

            string connectionString = RoleEnvironment.GetConfigurationSettingValue("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString");
            string deploymentID = RoleEnvironment.DeploymentId;
            string roleName = RoleEnvironment.CurrentRoleInstance.Role.Name;

            // Get the DeploymentDiagnosticManager object for your deployment.
            DeploymentDiagnosticManager diagManager = new DeploymentDiagnosticManager(connectionString, deploymentID);

            var signalRCategoryName = createSignalRCategoryName();

            RegisterCounter("Connections Connected", ts, signalRCategoryName, config);
            RegisterCounter("Connections Reconnected", ts, signalRCategoryName, config);
            RegisterCounter("Connections Disconnected", ts, signalRCategoryName, config);
            RegisterCounter("Connections Current", ts, signalRCategoryName, config);
            RegisterCounter("Connection Messages Received Total", ts, signalRCategoryName, config);
            RegisterCounter("Connection Messages Sent Total", ts, signalRCategoryName, config);
            RegisterCounter("Connection Messages Received/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Connection Messages Sent/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Messages Received Total", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Messages Received/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Message Bus Messages Received/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Messages Published Total", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Messages Published/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Subscribers Current", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Subscribers Total", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Subscribers/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Allocated Workers", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Busy Workers", ts, signalRCategoryName, config);
            RegisterCounter("Message Bus Topics Current", ts, signalRCategoryName, config);
            RegisterCounter("Errors: All Total", ts, signalRCategoryName, config);
            RegisterCounter("Errors: All/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Errors: Hub Resolution Total", ts, signalRCategoryName, config);
            RegisterCounter("Errors: Hub Resolution/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Errors: Hub Invocation Total", ts, signalRCategoryName, config);
            RegisterCounter("Errors: Hub Invocation/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Errors: Tranport Total", ts, signalRCategoryName, config);
            RegisterCounter("Errors: Transport/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Streams Total", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Streams Open", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Streams Buffering", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Errors Total", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Errors/Sec", ts, signalRCategoryName, config);
            RegisterCounter("Scaleout Send Queue Length", ts, signalRCategoryName, config);

            // useful for checking that it is not the category name that is issue
            RegisterCounter("Connection Failures", ts, "TCPV6", config);

            // Apply the updated configuration to the diagnostic monitor. 
            DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", config);
            return;
        }

        public static void RegisterCounter(string counterType, TimeSpan sampleRate, string category, DiagnosticMonitorConfiguration config)
        {
            var counterSpecifier = "\\" + category + "\\" + counterType;
            config.PerformanceCounters.DataSources.Add(new PerformanceCounterConfiguration()
            {
                CounterSpecifier = counterSpecifier,
                SampleRate = sampleRate
            });
        }
    }

}