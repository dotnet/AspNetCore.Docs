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
                var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
                var document = string.Format(Markup.Text, Configuration["SecretName"], Configuration["Section:SecretName"], Configuration.GetSection("Section")["SecretName"]);
                context.Response.ContentLength = encoding.GetByteCount(document);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(document);
            });
        }
    }
}
