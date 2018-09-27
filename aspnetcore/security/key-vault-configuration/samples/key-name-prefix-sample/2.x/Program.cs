using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KeyVaultConfigProviderSample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        #region snippet1
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // The appVersion obtains the app version (5.0.0.0), which 
                    // is set in the project file and obtained from the entry 
                    // assembly. The versionPrefix holds the version without 
                    // dot notation for the PrefixKeyVaultSecretManager.
                    var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
                    var versionPrefix = appVersion.Replace(".", string.Empty);

                    var builtConfig = config.Build();

                    config.AddAzureKeyVault(
                        $"https://{builtConfig["Vault"]}.vault.azure.net/",
                        builtConfig["ClientId"],
                        builtConfig["ClientSecret"],
                        new PrefixKeyVaultSecretManager(versionPrefix));
                })
                .UseStartup<Startup>();
        #endregion
    }
}
