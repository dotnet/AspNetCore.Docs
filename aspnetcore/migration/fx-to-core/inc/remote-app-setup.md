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

Common scenarios this enables:

* Fallback to the legacy application with [YARP](xref:fundamentals/servers/yarp/yarp-overview)
* [Remote app authentication](xref:migration/fx-to-core/areas/authentication#remote-authenticationn)
* [Remote session](xref:migration/fx-to-core/areas/session#remote-app-session-state)

## Configuration

> [!IMPORTANT]
> Framework and Core applications must use identical virtual directory layouts.
>
> The virtual directory setup is used for route generation, authorization, and other services within the system. At this point, no reliable method has been found to enable different virtual directories due to how ASP.NET Framework works.

To enable the ASP.NET Core app to communicate with the ASP.NET app, it's necessary to make a couple small changes to each app.

You need to configure two configuration values in both applications:

* `RemoteAppApiKey`: A key (required to be parseable as a [GUID](/dotnet/api/system.guid)) that is shared between the two applications. This should be a GUID value like `12345678-1234-1234-1234-123456789012`.
* `RemoteAppUri`: The URI of the remote ASP.NET Framework application (only required in the ASP.NET Core application configuration). This should be the full URL where the ASP.NET Framework app is hosted, such as `https://localhost:44300` or `https://myapp.example.com`.

### ASP.NET Framework

> [!IMPORTANT]
> The ASP.NET Framework application should be hosted with SSL enabled. In the remote app setup for incremental migration, it is not required to have direct access externally. It is recommended to only allow access from the client application via the proxy.

For ASP.NET Framework applications, add these values to your `web.config` in the `<appSettings>` section:

> [!IMPORTANT]
> ASP.NET Framework stores its appSettings in `web.config`. However, they can be retrieved from other sources (such as environment variables) with the use of [configuration Builders](/aspnet/config-builder). This makes sharing configuration values much easier between the local and remote applications in this setup.

```xml
<appSettings>
  <add key="RemoteAppApiKey" value="..." />
</appSettings>
```

To configure the application to be available to handle the requests from the ASP.NET Core client, set up the following:

1. Install the NuGet package [`Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices`](https://www.nuget.org/packages/Microsoft.AspNetCore.SystemWebAdapters)

1. Add the configuration code to the `Application_Start` method in your `Global.asax.cs` file:

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
    
1. Add the `SystemWebAdapterModule` module to the `web.config` if it wasn't already added by NuGet. This module configuration is required for IIS hosting scenarios. The `SystemWebAdapterModule` module is not added automatically when using SDK style projects for ASP.NET Core.

```diff
  <system.webServer>
    <modules>
+      <remove name="SystemWebAdapterModule" />
+      <add name="SystemWebAdapterModule" type="Microsoft.AspNetCore.SystemWebAdapters.SystemWebAdapterModule, Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices" preCondition="managedHandler" />
    </modules>
</system.webServer>

### ASP.NET Core

For ASP.NET Core applications, add these values to your `appsettings.json`:

```json
{
  "RemoteAppApiKey": "...",
  "RemoteAppUri": "https://localhost:44300"
}
```

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

## Proxying

To enable proxying from the ASP.NET Core application to the ASP.NET Framework application, you can set up a fallback route that forwards unmatched requests to the legacy application. This allows for a gradual migration where the ASP.NET Core app handles migrated functionality while falling back to the original app for unmigrated features.

1. Install the YARP (Yet Another Reverse Proxy) NuGet package following the [latest guidance](~/fundamentals/servers/yarp/getting-started).

1. Add the required using statements to your `Program.cs`:

    ```csharp
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.SystemWebAdapters;
    ```

1. Register the reverse proxy services in your `Program.cs`:

    ```csharp
    builder.Services.AddReverseProxy();
    ```

1. After building the app and configuring other middleware, add the fallback route mapping:
    
    ```csharp
    var app = builder.Build();
    
    // Configure your other middleware here (authentication, routing, etc.)
    
    // Map the fallback route
    app.MapForwarder("/{**catch-all}", app.ServiceProvider.GetRequiredService<IOptions<RemoteAppClientOptions>>().Value.RemoteAppUrl.OriginalString)
    
        // Ensures this route has the lowest priority (runs last)
        .WithOrder(int.MaxValue)
    
        // Skips remaining middleware when this route matches
        .ShortCircuit();
    
    app.Run();
    ```

With this configuration:

1. **Local routes take precedence**: If the ASP.NET Core application has a matching route, it will handle the request locally
2. **Fallback to legacy app**: Unmatched requests are automatically forwarded to the ASP.NET Framework application
3. **Middleware optimization**: The `.ShortCircuit()` method prevents unnecessary middleware execution when forwarding requests

This setup enables a seamless user experience during incremental migration, where users can access both migrated and legacy functionality through a single endpoint.
