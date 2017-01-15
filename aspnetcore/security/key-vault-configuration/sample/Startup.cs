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
                        <style>table{{border-collapse:collapse}}th,td{{padding:8px}}tr:nth-child(even){{background-color:#f2f2f2}}th{{background-color:#4CAF50;color:white}}</style>
                    </head>
                    <body style=""font-family:sans-serif"">
                        <h1>Key Vault Configuration Provider Sample</h1>
                        <div style=""overflow-x:auto"">
                            <table>
                                <tr>
                                    <th>Secret</th>
                                    <th>Key Vault Name</th>
                                    <th>Obtained from Key Vault</th>
                                    <th>Value</th> 
                                </tr>
                                <tr>
                                    <td>MySecret</td>
                                    <td><b>MySecret</b></td>
                                    <td><code>Configuration[""MySecret""]</code></td>
                                    <td>{Configuration["MySecret"]}</td> 
                                </tr>
                                <tr>
                                    <td>Section:MySecret</td>
                                    <td><b>Section--MySecret</b></td>
                                    <td><code>Configuration[""Section:MySecret""]</code></td>
                                    <td>{Configuration["Section:MySecret"]}</td> 
                                </tr>
                                <tr>
                                    <td>Section:MySecret</td>
                                    <td><b>Section--MySecret</b></td>
                                    <td><code>Configuration.GetSection(""Section"")[""MySecret""]</code></td>
                                    <td>{Configuration.GetSection("Section")["MySecret"]}</td> 
                                </tr>
                            </table>
                        </div>
                    </body>
                    </html>";

                context.Response.ContentLength = encoding.GetByteCount(document);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(document);
            });
        }
    }
}
