using System;
using System.Linq;
using System.Threading;
using ChangeTokenSample.Data;
using ChangeTokenSample.Enums;
using ChangeTokenSample.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using static ChangeTokenSample.Utilities.Utilities;

namespace ChangeTokenSample.ChangeTokens
{
    public static class ChangeTokens
    {
        #region snippet1
        private static ConfigurationReloadToken _configChangeToken = new ConfigurationReloadToken();
        private static byte[] _appsettingsHash = new byte[20];
        private static byte[] _appsettingsEnvHash = new byte[20];
        #endregion

        #region snippet2
        private static FileChangeToken _fileChangeToken = new FileChangeToken();
        private static byte[] _fileHash = new byte[20];
        #endregion

        #region snippet3
        public static MessageChangeToken MessageChangeToken { get; set; }
        public static MessageChangeType LastMessageChangeType = new MessageChangeType();
        #endregion

        #region snippet4
        public static MessageChangeTokenNoState MessageChangeTokenNoState { get; set; }
        #endregion

        public static void SetupChangeTokens(IConfiguration config, IHostingEnvironment env)
        {
            #region snippet5
            ChangeToken.OnChange(
                () => config.GetReloadToken(),
                () => 
                {
                    byte[] appsettingsHash = ComputeHash("appSettings.json");
                    byte[] appsettingsEnvHash = 
                        ComputeHash($"appSettings.{env.EnvironmentName}.json");

                    if (!_appsettingsHash.SequenceEqual(appsettingsHash) || 
                        !_appsettingsEnvHash.SequenceEqual(appsettingsEnvHash))
                    {
                        _appsettingsHash = appsettingsHash;
                        _appsettingsEnvHash = appsettingsEnvHash;

                        PrintConsole("Configuration changed");
                    }

                    var previousConfigToken = Interlocked.Exchange(
                        ref _configChangeToken, new ConfigurationReloadToken());
                    previousConfigToken.OnReload();
                });
            #endregion

            #region snippet6
            ChangeToken.OnChange(
                () => env.ContentRootFileProvider.Watch(MonitorFile.FilePath),
                () => {
                    byte[] fileHash = ComputeHash(MonitorFile.FilePath);
                    
                    if (!_fileHash.SequenceEqual(fileHash))
                    {
                        _fileHash = fileHash;

                        if (MonitorFile.CurrentFileState == FileState.NotUpdated)
                        {
                            MonitorFile.CurrentFileState = FileState.Updated;
                        }

                        PrintConsole($"{MonitorFile.FileName} changed");
                    }
                    
                    var previousFileToken = Interlocked.Exchange(
                        ref _fileChangeToken, new FileChangeToken());
                    previousFileToken.OnReload();
                });
            #endregion

            #region snippet7
            ChangeToken.OnChange(
                () => MessageChangeToken = new MessageChangeToken(),
                (messageChangeType) => {
                    PrintConsole($"Messages changed: {messageChangeType}");
                }, LastMessageChangeType);
            #endregion

            #region snippet8
            ChangeToken.OnChange(
                () => MessageChangeTokenNoState = new MessageChangeTokenNoState(),
                () => {
                    PrintConsole("Messages changed");
                });
            #endregion
        }

        private static void PrintConsole(string s)
        {
            var consoleString = $"{DateTime.Now} {s}";
            var l = consoleString.Length;

            Console.WriteLine(new string('*', l));
            Console.WriteLine(consoleString);
            Console.WriteLine(new string('*', l));
        }
    }
}
