using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System.Reflection;
using System.Text;

namespace KeyVaultConfigProviderSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

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

    #region snippet1
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
