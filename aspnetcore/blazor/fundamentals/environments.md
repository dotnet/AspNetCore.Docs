---
title: ASP.NET Core Blazor environments
author: guardrex
description: Learn about environments in Blazor, including how to set the environment.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/fundamentals/environments
---
# ASP.NET Core Blazor environments

<!-- UPDATE 8.0 This entire article should be checked and
                improved for the BWA world order. The article 
                was originally tied exclusively to WASM 
                scenarios. It should cover client- and 
                server-side scenarios with BWAs. Especially, 
                the scenarios for the Blazor-Environment 
                header must be validated in the BWA world. 
                Clear Azure coverage should be provided. -->

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure and read the [environment](xref:fundamentals/environments) in a Blazor app.

[!INCLUDE[](~/blazor/includes/location-client.md)]

:::moniker range=">= aspnetcore-5.0"

For general guidance on server-side environments, see <xref:fundamentals/environments>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For general guidance on ASP.NET Core app configuration, see <xref:fundamentals/environments>. For server-side app configuration with static files in environments other than the <xref:Microsoft.Extensions.Hosting.Environments.Development> environment during development and testing (for example, <xref:Microsoft.Extensions.Hosting.Environments.Staging>), see <xref:blazor/fundamentals/static-files#static-files-in-non-development-environments>.

:::moniker-end

When running an app locally, the environment defaults to `Development`. When the app is published, the environment defaults to `Production`.

The environment is set using any of the following approaches:

* [Blazor start configuration](#set-the-environment-via-startup-configuration)
* [`Blazor-Environment` header](#set-the-environment-via-header)
* [Azure App Service](#set-the-environment-for-azure-app-service)

<!-- UPDATE 8.0 Confirm that this is still correct -->

:::moniker range=">= aspnetcore-8.0"

On the client for a Blazor Web App, the environment is determined from the server via a middleware that communicates the environment to the browser via a header named `Blazor-Environment`. The header sets the environment when the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost> is created in the client-side `Program` file (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType>).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

On the client for a Blazor Web App or the client of a hosted Blazor WebAssembly app, the environment is determined from the server via a middleware that communicates the environment to the browser via a header named `Blazor-Environment`. The header sets the environment when the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost> is created in the client-side `Program` file (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType>).

:::moniker-end

For a standalone client app running locally, the development server adds the `Blazor-Environment` header.

For app's running locally in development, the app defaults to the `Development` environment. Publishing the app defaults the environment to `Production`.

For more information on how to configure the server-side environment, see <xref:fundamentals/environments>.

## Set the environment via startup configuration

The following example starts Blazor in the `Staging` environment if the hostname includes `localhost`. Otherwise, the environment is set to its default value.

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  if (window.location.hostname.includes("localhost")) {
    Blazor.start({
      webAssembly: {
        environment: "Staging"
      }
    });
  } else {
    Blazor.start();
  }
</script>
```

Standalone Blazor WebAssembly:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  if (window.location.hostname.includes("localhost")) {
    Blazor.start({
      environment: "Staging"
    });
  } else {
    Blazor.start();
  }
</script>
```

In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name. For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

Using the `environment` property overrides the environment set by the [`Blazor-Environment` header](#set-the-environment-via-header).

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Set the environment via header

To specify the environment for other hosting environments, add the `Blazor-Environment` header.

In the following example for IIS, the custom header (`Blazor-Environment`) is added to the published `web.config` file. The `web.config` file is located in the `bin/Release/{TARGET FRAMEWORK}/publish` folder, where the placeholder `{TARGET FRAMEWORK}` is the target framework:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>

    ...

    <httpProtocol>
      <customHeaders>
        <add name="Blazor-Environment" value="Staging" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>
</configuration>
```

> [!NOTE]
> To use a custom `web.config` file for IIS that isn't overwritten when the app is published to the `publish` folder, see <xref:blazor/host-and-deploy/webassembly#use-a-custom-webconfig>.

## Set the environment for Azure App Service

For a standalone client app, you can set the environment manually via [start configuration](#set-the-environment-via-startup-configuration) or the [`Blazor-Environment` header](#set-the-environment-via-header). To set the environment via an `ASPNETCORE_ENVIRONMENT` app setting in Azure:

<!-- UPDATE 8.0 Need to confirm this works for BWA with client-side only -->

1. Confirm that the casing of environment segments in app settings file names match their environment name casing ***exactly***. For example, the matching app settings file name for the `Staging` environment is `appsettings.Staging.json`. If the file name is `appsettings.staging.json` (lowercase "`s`"), the file isn't located, and the settings in the file aren't used in the `Staging` environment.

1. For Visual Studio deployment, confirm that the app is deployed to the correct deployment slot. For an app named `BlazorAzureAppSample`, the app is deployed to the `Staging` deployment slot.

1. In the Azure portal for the environment's deployment slot, set the environment with the `ASPNETCORE_ENVIRONMENT` app setting. For an app named `BlazorAzureAppSample`, the staging App Service Slot is named `BlazorAzureAppSample/Staging`. For the `Staging` slot's configuration, create an app setting for `ASPNETCORE_ENVIRONMENT` with a value of `Staging`. **Deployment slot setting** is enabled for the setting.

When requested in a browser, the `BlazorAzureAppSample/Staging` app loads in the `Staging` environment at `https://blazorazureappsample-staging.azurewebsites.net`.

When the app is loaded in the browser, the response header collection for `blazor.boot.json` indicates that the `Blazor-Environment` header value is `Staging`.

App settings from the `appsettings.{ENVIRONMENT}.json` file are loaded by the app, where the `{ENVIRONMENT}` placeholder is the app's environment. In the preceding example, settings from the `appsettings.Staging.json` file are loaded.

## Read the environment

Obtain the app's environment in a component by injecting <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> and reading the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.Environment> property.

`ReadEnvironment.razor`:

<!-- UPDATE 8.0 Watch the highlights! -->

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/environments/ReadEnvironment.razor" highlight="3,7":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/environments/ReadEnvironment.razor" highlight="3,7":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/environments/ReadEnvironment.razor" highlight="3,7":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/environments/ReadEnvironment.razor" highlight="3,7":::

:::moniker-end

During startup, the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> exposes the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> through the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.HostEnvironment> property, which enables environment-specific logic in host builder code.

In the `Program` file:

```csharp
if (builder.HostEnvironment.Environment == "Custom")
{
    ...
};
```

The following convenience extension methods provided through <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions> permit checking the current environment for `Development`, `Production`, `Staging`, and custom environment names:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsDevelopment%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsProduction%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsStaging%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostEnvironmentExtensions.IsEnvironment%2A>

In the `Program` file:

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
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
