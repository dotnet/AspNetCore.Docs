using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System.IO;

namespace KeyVaultConfigProviderSample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddEnvironmentVariables();

                    var builtConfig = config.Build();

                    #region snippet1
                    // The appVersion obtains the app version (5.0.0.0), which 
                    // is set in the project file and obtained from the entry 
                    // assembly. The versionPrefix holds the version without 
                    // dot notation for the PrefixKeyVaultSecretManager.
                    var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
                    var versionPrefix = appVersion.Replace(".", string.Empty);

                    config.AddAzureKeyVault(
                        $"https://{builtConfig["Vault"]}.vault.azure.net/",
                        builtConfig["ClientId"],
                        builtConfig["ClientSecret"],
                        new PrefixKeyVaultSecretManager(versionPrefix));
                    #endregion
                })
                .UseStartup<Startup>()
                .Build();
    }
}
