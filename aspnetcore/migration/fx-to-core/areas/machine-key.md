---
title: ASP.NET machineKey to ASP.NET Core migration
ai-usage: ai-assisted
author: twsouthwick
description: Migrate ASP.NET machineKey-based cryptography to ASP.NET Core data protection in incremental and full migrations.
monikerRange: '>= aspnetcore-6.0'
ms.author: tasou
ms.date: 12/10/2025
ms.topic: article
uid: migration/fx-to-core/areas/machine-key
---

# Migrate ASP.NET machineKey with System.Web adapters

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

## Shared key storage and data protection guidance

Both the ASP.NET Framework app and the ASP.NET Core app must use a shared application name and key repository for data protection so that protected payloads can round-trip between apps.

* Call `SetApplicationName` with the same logical application name in both apps (for example, `"my-app"`).
* Configure `PersistKeysToFileSystem` to point to the same key repository location that both apps can read and write.

> [!NOTE]
> The directory used with `PersistKeysToFileSystem` is the backing store for the shared data protection keys. In production, use a durable, shared store (such as a UNC share, Redis, or Azure Blob Storage) and follow the key management guidance in <xref:security/data-protection/configuration/overview> and <xref:security/data-protection/introduction>.

## Configure the ASP.NET Framework app

In the ASP.NET Framework app, configure `<machineKey>` and the System.Web adapters host so that both apps share the same data protection configuration.

Ensure the `Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices` package is installed in the ASP.NET Framework app. This package is added automatically when you create the migration `FrameworkServices` project and brings in the `Microsoft.AspNetCore.DataProtection.SystemWeb` and hosting dependencies.

For full background on replacing `<machineKey>`, see <xref:security/data-protection/compatibility/replacing-machinekey>.

When the `Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices` package is installed into the ASP.NET Framework app, `<machineKey>` is normally configured automatically. If it isn't present or you need to verify the settings, configure `<machineKey>` in *Web.config* to use the compatibility data protector as shown:

```xml
<configuration>
  <system.web>
    <httpRuntime targetFramework="4.8.1" />
    <machineKey
      compatibilityMode="Framework45"
      dataProtectorType="Microsoft.AspNetCore.DataProtection.SystemWeb.CompatibilityDataProtector,
      Microsoft.AspNetCore.DataProtection.SystemWeb" />
  </system.web>
</configuration>
```

Next, in `Global.asax.cs`, register the System.Web adapters host and configure data protection using the same application name and key repository that the ASP.NET Core app will use. The following example is adapted from the MachineKey Framework sample:

```csharp
using System.IO;
using System.Web;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.SystemWebAdapters.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataProtectionDemo
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            HttpApplicationHost.RegisterHost(builder =>
            {
                builder.AddServiceDefaults();

                builder.AddDataProtection()
                    .SetApplicationName("my-app")
                    .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\myapp-keys\"));
            });
        }
    }
}
```

This configuration:

* Sets a shared application name (`my-app`) that the ASP.NET Core app must also use.
* Configures a shared key repository (for example, a UNC share) that both apps can access.
* Ensures `<machineKey>` operations (forms auth, view state, `MachineKey.Protect`, and related APIs) are routed through ASP.NET Core data protection.
* Runs as part of the ASP.NET Framework host so that existing `<machineKey>`-based features use the same data protection system as ASP.NET Core.

## Configure the ASP.NET Core app

In the ASP.NET Core app, configure data protection with the same application name and key repository and enable the System.Web adapters extension methods so both apps can protect and unprotect the same data.

```csharp
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataProtection()
    .SetApplicationName(MachineKeyExampleHandler.AppName)
    .PersistKeysToFileSystem(
        new DirectoryInfo(Path.Combine(Path.GetTempPath(), "sharedkeys", MachineKeyExampleHandler.AppName)));

var app = builder.Build();

// Configure application

app.Run();
```

Important configuration details:

* `AddSystemWebAdapters` and `UseSystemWebAdapters` are extension methods provided by the System.Web adapters. They are required for using `System.Web.Security.MachineKey`-style APIs and other System.Web abstractions from ASP.NET Core.
* Make sure the ASP.NET Core app references the appropriate System.Web adapters NuGet package (for example, `Microsoft.AspNetCore.SystemWebAdapters`).

