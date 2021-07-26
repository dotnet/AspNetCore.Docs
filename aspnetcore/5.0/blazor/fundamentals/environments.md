---
title: ASP.NET Core Blazor environments
author: guardrex
description: Learn about environments in Blazor, including how to set the environment.
monikerRange: '>= aspnetcore-5.0 < aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/12/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, Development, Staging, Production]
uid: blazor/fundamentals/environments
---
# ASP.NET Core Blazor environments

> [!NOTE]
> This topic applies to Blazor WebAssembly. For general guidance on ASP.NET Core app configuration, which describes the approaches to use for Blazor Server apps, see <xref:fundamentals/environments>.

When running an app locally, the environment defaults to Development. When the app is published, the environment defaults to Production.

The environment is set using either of the following approaches:

* [Blazor start configuration](#set-the-environment-via-startup-configuration)
* [`blazor-environment` header](#set-the-environment-via-header)

The client-side Blazor app (**`Client`**) of a hosted Blazor WebAssembly solution determines the environment from the **`Server`** app of the solution via a middleware that communicates the environment to the browser. The **`Server`** app adds a header named `blazor-environment` with the environment as the value of the header. The **`Client`** app reads the header. The **`Server`** app of the solution is an ASP.NET Core app, so more information on how to configure the environment is found in <xref:fundamentals/environments>.

For a standalone Blazor WebAssembly app running locally, the development server adds the `blazor-environment` header to specify the Development environment.

## Set the environment via startup configuration

The following example starts Blazor in the Staging environment:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      Blazor.start({
        environment: "Staging"
      });
    </script>
</body>
```

Using the `environment` property overrides the environment set by the [`blazor-environment` header](#set-the-environment-via-header).

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Set the environment via header

To specify the environment for other hosting environments, add the `blazor-environment` header.

In the following example for IIS, the custom header (`blazor-environment`) is added to the published `web.config` file. The `web.config` file is located in the `bin/Release/{TARGET FRAMEWORK}/publish` folder, where the placeholder `{TARGET FRAMEWORK}` is the target framework:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>

    ...

    <httpProtocol>
      <customHeaders>
        <add name="blazor-environment" value="Staging" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>
</configuration>
```

> [!NOTE]
> To use a custom `web.config` file for IIS that isn't overwritten when the app is published to the `publish` folder, see <xref:blazor/host-and-deploy/webassembly#use-a-custom-webconfig>.

Obtain the app's environment in a component by injecting <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> and reading the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.Environment> property.

`Pages/ReadEnvironment.razor`:

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/environments/ReadEnvironment.razor?highlight=3,7)]

During startup, the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> exposes the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> through the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.HostEnvironment> property, which enables environment-specific logic in host builder code.

In `Program.Main` of `Program.cs`:

```csharp
if (builder.HostEnvironment.Environment == "Custom")
{
    ...
};
```

The following convenience extension methods provided through <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions> permit checking the current environment for Development, Production, Staging, and custom environment names:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsDevelopment%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsProduction%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsStaging%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsEnvironment%2A>

In `Program.Main` of `Program.cs`:

```csharp
if (builder.HostEnvironment.IsStaging())
{
    ...
};

if (builder.HostEnvironment.IsEnvironment("Custom"))
{
    ...
};
```

The <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> property can be used during startup when the <xref:Microsoft.AspNetCore.Components.NavigationManager> service isn't available.

## Additional resources

* <xref:blazor/fundamentals/startup>
* <xref:fundamentals/environments>
