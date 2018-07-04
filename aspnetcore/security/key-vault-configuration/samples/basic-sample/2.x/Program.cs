using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

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
                    var builtConfig = config.Build();

                    var keyVaultConfigBuilder = new ConfigurationBuilder();

                    keyVaultConfigBuilder.AddAzureKeyVault(
                        $"https://{builtConfig["Vault"]}.vault.azure.net/",
                        builtConfig["ClientId"],
                        builtConfig["ClientSecret"]);

                    var keyVaultConfig = keyVaultConfigBuilder.Build();

                    config.AddConfiguration(keyVaultConfig);
                })
                .UseStartup<Startup>();
        #endregion
    }
}
