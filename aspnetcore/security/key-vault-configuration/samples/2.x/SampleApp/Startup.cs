using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SampleApp
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
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($@"SecretName (Name in Key Vault: 'SecretName'){Environment.NewLine}Obtained from Configuration with Configuration[""SecretName""]{Environment.NewLine}Value: {Configuration["SecretName"]}{Environment.NewLine}{Environment.NewLine}Section:SecretName (Name in Key Vault: 'Section--SecretName'){Environment.NewLine}Obtained from Configuration with Configuration[""Section:SecretName""]{Environment.NewLine}Value: {Configuration["Section:SecretName"]}{Environment.NewLine}{Environment.NewLine}Section:SecretName (Name in Key Vault: 'Section--SecretName'){Environment.NewLine}Obtained from Configuration with Configuration.GetSection(""Section"")[""SecretName""]{Environment.NewLine}Value: {Configuration.GetSection("Section")["SecretName"]}");
            });
        }
    }
}
