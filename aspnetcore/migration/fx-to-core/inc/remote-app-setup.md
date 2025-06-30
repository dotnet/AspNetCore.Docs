---
title: Remote app setup
description: Remote app setup
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/fx-to-core/inc/remote-app-setup
---

# Remote app setup

In some incremental upgrade scenarios, it's useful for the new ASP.NET Core app to be able to communicate with the original ASP.NET app.

Specifically, this capability is used, currently, for [remote app authentication](xref:migration/fx-to-core/areas/authentication#remote-authenticationn) and [remote session](xref:migration/fx-to-core/areas/session#remote-app-session-state) features.

## Configuration

> [!IMPORTANT]
> Framework and Core applications must use identical virtual directory layouts.
>
> The virtual directory setup is used for route generation, authorization, and other services within the system. At this point, no reliable method has been found to enable different virtual directories due to how ASP.NET Framework works.

**Recommendation**: Ensure your two applications are on different sites (hosts and/or ports) with the same application/virtual directory layout.

To enable the ASP.NET Core app to communicate with the ASP.NET app, it's necessary to make a couple small changes to each app.

You need to configure two configuration values in both applications:

* `RemoteAppApiKey`: A key (required to be parseable as a [GUID](/dotnet/api/system.guid)) that is shared between the two applications. This should be a GUID value like `12345678-1234-1234-1234-123456789012`.
* `RemoteAppUri`: The URI of the remote ASP.NET Framework application (only required in the ASP.NET Core application configuration). This should be the full URL where the ASP.NET Framework app is hosted, such as `https://localhost:44300` or `https://myapp.example.com`.

For ASP.NET Framework applications, add these values to your `web.config` in the `<appSettings>` section:

```xml
<appSettings>
  <add key="RemoteAppApiKey" value="..." />
</appSettings>
```

For ASP.NET Core applications, add these values to your `appsettings.json`:

```json
{
  "RemoteAppApiKey": "...",
  "RemoteAppUri": "https://localhost:44300"
}
```

For ASP.NET Framework applications, it is recommended to use [Configuration Builders](/aspnet/config-builder) to allow injecting values into the application without touching the `web.config`.

### ASP.NET app configuration

To set up the ASP.NET app to be able to receive requests from the ASP.NET Core app:

1. Install the NuGet package [`Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices`](https://www.nuget.org/packages/Microsoft.AspNetCore.SystemWebAdapters)

2. Add the configuration code to the `Application_Start` method in your `Global.asax.cs` file:

```CSharp
protected void Application_Start()
{
    SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
        .AddRemoteAppServer(options =>
        {
            // ApiKey is a string representing a GUID
            options.ApiKey = ConfigurationManager.AppSettings["RemoteAppApiKey"];
        });
    
    // ...existing code...
}
```

In the options configuration method passed to the `AddRemoteAppServer` call, an API key must be specified. The API key is:

* Used to secure the endpoint so that only trusted callers can make requests to it.
* The same API key provided to the ASP.NET Core app when it is configured.
* A string and must be parsable as a [GUID](/dotnet/api/system.guid). Hyphens in the key are optional.

1. Add the `SystemWebAdapterModule` module to the `web.config` if it wasn't already added by NuGet. This module configuration is required for IIS hosting scenarios. The `SystemWebAdapterModule` module is not added automatically when using SDK style projects for ASP.NET Core.

```diff
  <system.webServer>
    <modules>
+      <remove name="SystemWebAdapterModule" />
+      <add name="SystemWebAdapterModule" type="Microsoft.AspNetCore.SystemWebAdapters.SystemWebAdapterModule, Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices" preCondition="managedHandler" />
    </modules>
</system.webServer>
```

### ASP.NET Core app

To set up the ASP.NET Core app to be able to send requests to the ASP.NET app, configure the remote app client by calling `AddRemoteAppClient` after registering System.Web adapter services with `AddSystemWebAdapters`.

Add this configuration to your `Program.cs` file:

```CSharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppClient(options =>
    {
        options.RemoteAppUrl = new(builder.Configuration["RemoteAppUri"]);
        options.ApiKey = builder.Configuration["RemoteAppApiKey"];
    });
```

With both the ASP.NET and ASP.NET Core app updated, extension methods can now be used to set up [remote app authentication](xref:migration/fx-to-core/areas/authentication#remote-authenticationn) or [remote session](xref:migration/fx-to-core/areas/session#remote-app-session-state), as needed.
