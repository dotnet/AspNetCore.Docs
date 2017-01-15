// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace KeyVaultConfigProviderSample
{
    internal static class Markup
    {
        internal const string Text = @"<!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""utf-8"" />
                <title>Key Vault Configuration Provider Sample</title>
                <style>body{{font-family:sans-serif}}div{{overflow-x:auto}}table{{border-collapse:collapse}}th,td{{padding:8px}}tr:nth-child(even){{background-color:#f2f2f2}}th{{background-color:#4CAF50;color:white}}</style>
            </head>
            <body>
                <h1>Key Vault Configuration Provider Sample</h1>
                <div>
                    <table>
                        <thead>
                            <tr>
                                <th>Secret</th>
                                <th>Key Vault Name</th>
                                <th>Obtained from Key Vault</th>
                                <th>Value</th> 
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>MySecret</td>
                                <td><b>MySecret</b></td>
                                <td><code>Configuration[""MySecret""]</code></td>
                                <td>{0}</td> 
                            </tr>
                            <tr>
                                <td>Section:MySecret</td>
                                <td><b>Section--MySecret</b></td>
                                <td><code>Configuration[""Section:MySecret""]</code></td>
                                <td>{1}</td> 
                            </tr>
                            <tr>
                                <td>Section:MySecret</td>
                                <td><b>Section--MySecret</b></td>
                                <td><code>Configuration.GetSection(""Section"")[""MySecret""]</code></td>
                                <td>{2}</td> 
                            </tr>
                        </tbody>
                    </table>
                </div>
            </body>
            </html>";
    }
}