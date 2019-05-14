// using System.Reflection;
// using Microsoft.Azure.KeyVault;
// using Microsoft.Azure.Services.AppAuthentication;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Configuration.AzureKeyVault;

public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            if (context.HostingEnvironment.IsProduction())
            {
                // The appVersion obtains the app version (5.0.0.0), which 
                // is set in the project file and obtained from the entry 
                // assembly. The versionPrefix holds the version without 
                // dot notation for the PrefixKeyVaultSecretManager.
                var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
                var versionPrefix = appVersion.Replace(".", string.Empty);

                var builtConfig = config.Build();

                using (var store = new X509Store(StoreName.My,
                    StoreLocation.CurrentUser))
                {
                    store.Open(OpenFlags.ReadOnly);
                    var certs = store.Certificates
                        .Find(X509FindType.FindByThumbprint,
                            builtConfig["AzureADCertThumbprint"], false);

                    config.AddAzureKeyVault(
                        $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                        builtConfig["AzureADApplicationId"],
                        certs.OfType<X509Certificate2>().Single(),
                        new PrefixKeyVaultSecretManager(versionPrefix));

                    store.Close();
                }
            }
        })
        .UseStartup<Startup>();
