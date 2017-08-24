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
        #region snippet1
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();

            var config = builder.Build();

            builder.AddAzureKeyVault(
                    $"https://{config["Vault"]}.vault.azure.net/",
                    config["ClientId"],
                    config["ClientSecret"]);

            Configuration = builder.Build();
        }
        #endregion

        public IConfigurationRoot Configuration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
                var document = string.Format(Markup.Text, Configuration["SecretName"], Configuration["Section:SecretName"], Configuration.GetSection("Section")["SecretName"]);
                context.Response.ContentLength = encoding.GetByteCount(document);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(document);
            });
        }
    }
}
