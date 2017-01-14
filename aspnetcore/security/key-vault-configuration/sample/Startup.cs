// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KeyVaultConfigProviderSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();

            var config = builder.Build();

            builder.AddAzureKeyVault(
                    $"https://{config["Vault"]}.vault.azure.net/",
                    config["ClientId"],
                    config["ClientSecret"]);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
                var document = $@"<!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""utf-8"" />
                        <title>Key Vault Configuration Provider Sample</title>
                    </head>
                    <body>
                        <h1>Key Vault Configuration Provider Sample</h1>
                        <h2>Secrets &amp; Values</h2>
                        <ul>
                            <li>MySecret: {Configuration["MySecret"]}</li>
                            <li>Section:MySecret using ':' (colon) notation: {Configuration["Section:MySecret"]}</li>
                            <li>Section:MySecret using GetSection(): {Configuration.GetSection("Section")["MySecret"]}</li>
                        </ul>
                    </body>
                    </html>";

                context.Response.ContentLength = encoding.GetByteCount(document);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(document);
            });
        }
    }
}