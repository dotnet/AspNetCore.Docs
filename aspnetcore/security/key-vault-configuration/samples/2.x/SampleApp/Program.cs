#define Certificate // Managed
// Change to 'Managed' to run the sample in Managed Identity configuration.
// For details, see the Azure Key Vault Configuration Provider topic:
// https://docs.microsoft.com/aspnet/core/security/key-vault-configuration

using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace SampleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

#if Certificate
        #region snippet1
        // using System.Linq;
        // using System.Security.Cryptography.X509Certificates;
        // using Microsoft.Extensions.Configuration;

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (context.HostingEnvironment.IsProduction())
                    {
                        var builtConfig = config.Build();

                        using (var store = new X509Store(StoreLocation.CurrentUser))
                        {
                            store.Open(OpenFlags.ReadOnly);
                            var certs = store.Certificates
                                .Find(X509FindType.FindByThumbprint,
                                    builtConfig["AzureADCertThumbprint"], false);

                            config.AddAzureKeyVault(
                                $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                                builtConfig["AzureADApplicationId"],
                                certs.OfType<X509Certificate2>().Single());

                            store.Close();
                        }
                    }
                })
                .UseStartup<Startup>();
        #endregion
#endif

#if Managed
        #region snippet2
        // using Microsoft.Azure.KeyVault;
        // using Microsoft.Azure.Services.AppAuthentication;
        // using Microsoft.Extensions.Configuration.AzureKeyVault;

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (context.HostingEnvironment.IsProduction())
                    {
                        var builtConfig = config.Build();

                        var azureServiceTokenProvider = new AzureServiceTokenProvider();
                        var keyVaultClient = new KeyVaultClient(
                            new KeyVaultClient.AuthenticationCallback(
                                azureServiceTokenProvider.KeyVaultTokenCallback));

                        config.AddAzureKeyVault(
                            $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                            keyVaultClient,
                            new DefaultKeyVaultSecretManager());
                    }
                })
                .UseStartup<Startup>();
        #endregion
#endif
    }
}
