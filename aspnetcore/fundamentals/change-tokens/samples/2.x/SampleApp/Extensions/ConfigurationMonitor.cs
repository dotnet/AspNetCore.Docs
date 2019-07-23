using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using static ChangeTokenSample.Utilities.Utilities;

namespace ChangeTokenSample
{
    #region snippet1
    public interface IConfigurationMonitor
    {
        bool MonitoringEnabled { get; set; }
        string CurrentState { get; set; }
    }
    #endregion

    public class ConfigurationMonitor : IConfigurationMonitor
    {
        private byte[] _appsettingsHash = new byte[20];
        private byte[] _appsettingsEnvHash = new byte[20];
        private readonly IHostingEnvironment _env;

        #region snippet2
        public ConfigurationMonitor(IConfiguration config, IHostingEnvironment env)
        {
            _env = env;

            ChangeToken.OnChange<IConfigurationMonitor>(
                () => config.GetReloadToken(),
                InvokeChanged,
                this);
        }

        public bool MonitoringEnabled { get; set; } = false;
        public string CurrentState { get; set; } = "Not monitoring";
        #endregion

        #region snippet3
        private void InvokeChanged(IConfigurationMonitor state)
        {
            if (MonitoringEnabled)
            {
                byte[] appsettingsHash = ComputeHash("appSettings.json");
                byte[] appsettingsEnvHash = 
                    ComputeHash($"appSettings.{_env.EnvironmentName}.json");

                if (!_appsettingsHash.SequenceEqual(appsettingsHash) || 
                    !_appsettingsEnvHash.SequenceEqual(appsettingsEnvHash))
                {
                    string message = $"State updated at {DateTime.Now}";
                  

                    _appsettingsHash = appsettingsHash;
                    _appsettingsEnvHash = appsettingsEnvHash;

                    WriteConsole("Configuration changed (ConfigurationMonitor Class) " +
                        $"{message}, state:{state.CurrentState}");
                }
            }
        }
        #endregion
    }
}