using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KeyVaultConfigProviderSample
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();

            var config = builder.Build();

            #region snippet1
            var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            // Remove periods from the version. Azure Key Vault secret names 
            // are alphanumeric with dashes, so periods aren't allowed in
            // the prefixes.
            var versionPrefix = appVersion.Replace(".", string.Empty);

            builder.AddAzureKeyVault(
                    $"https://{config["Vault"]}.vault.azure.net/",
                    config["ClientId"],
                    config["ClientSecret"]), 
                    new PrefixKeyVaultSecretManager(versionPrefix));
            #endregion

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
                var versionPrefix = appVersion.Replace(".", string.Empty);
                var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
                var document = string.Format(Markup.Text, versionPrefix, Configuration["AppSecret"]);
                context.Response.ContentLength = encoding.GetByteCount(document);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(document);
            });
        }
    }

    #region snippet2
    public class PrefixKeyVaultSecretManager : IKeyVaultSecretManager
    {
        private readonly string _prefix;

        public PrefixKeyVaultSecretManager(string prefix)
        {
            _prefix = $"{prefix}-";
        }

        public bool Load(SecretItem secret)
        {
            // Load a vault secret when its secret name starts with the 
            // prefix. Other secrets won't be loaded.
            return secret.Identifier.Name.StartsWith(_prefix);
        }

        public string GetKey(SecretBundle secret)
        {
            // Remove the prefix from the secret name and replace two 
            // dashes in any name with the KeyDelimiter, which is the 
            // delimiter used in configuration (usually a colon). Azure 
            // Key Vault doesn't allow a colon in secret names.
            return secret.SecretIdentifier.Name
                .Substring(_prefix.Length)
                .Replace("--", ConfigurationPath.KeyDelimiter);
        }
    }
    #endregion
}
