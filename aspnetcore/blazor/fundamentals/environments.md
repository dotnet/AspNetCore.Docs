---
title: ASP.NET Core Blazor environments
author: guardrex
description: Learn about environments in Blazor, including how to set the environment.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/fundamentals/environments
---
# ASP.NET Core Blazor environments

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure and read the [environment](xref:fundamentals/environments) in a Blazor app.

[!INCLUDE[](~/blazor/includes/location-client.md)]

:::moniker range=">= aspnetcore-8.0"

For general guidance on setting the environment for a Blazor Web App, see <xref:fundamentals/environments>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

For general guidance on setting the environment for a Blazor Server app, see <xref:fundamentals/environments>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For general guidance on ASP.NET Core app configuration, see <xref:fundamentals/environments>. For server-side app configuration with static files in environments other than the <xref:Microsoft.Extensions.Hosting.Environments.Development> environment during development and testing (for example, <xref:Microsoft.Extensions.Hosting.Environments.Staging>), see <xref:blazor/fundamentals/static-files#static-files-in-non-development-environments>.

:::moniker-end

When running an app locally, the environment defaults to `Development`. When the app is published, the environment defaults to `Production`.

<!-- UPDATE 9.0 The underlying problem with app settings filename 
                case sensitivity is tracked for 9.0 by ...
                https://github.com/dotnet/aspnetcore/issues/25152 -->
                
We recommend the following conventions:

* Always use the "`Development`" environment name for local development. This is because the Blazor framework expects exactly that name when configuring the app and tooling for local development runs of a Blazor app.

* For testing, staging, and production environments, always publish and deploy the app. You can use any environment naming scheme that you wish for published apps, but always use app setting file names with casing of the environment segment that exactly matches the environment name. For staging, use "`Staging`" (capital ":::no-loc text="S":::") as the environment name, and name the app settings file to match (`appsettings.Staging.json`). For production, use "`Production`" (capital ":::no-loc text="P":::") as the environment name, and name the app settings file to match (`appsettings.Production.json`).

The environment is set using any of the following approaches:

* [Blazor start configuration](#set-the-client-side-environment-via-startup-configuration)
* [`blazor-environment` header](#set-the-client-side-environment-via-header)
* [Azure App Service](#set-the-environment-for-azure-app-service)

:::moniker range=">= aspnetcore-8.0"

On the client for a Blazor Web App, the environment is determined from the server via a middleware that communicates the environment to the browser via a header named `blazor-environment`. The header sets the environment when the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost> is created in the client-side `Program` file (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType>).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

On the client for a Blazor Web App or the client of a hosted Blazor WebAssembly app, the environment is determined from the server via a middleware that communicates the environment to the browser via a header named `blazor-environment`. The header sets the environment when the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost> is created in the client-side `Program` file (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType>).

:::moniker-end

For a standalone client app running locally, the development server adds the `blazor-environment` header.

For app's running locally in development, the app defaults to the `Development` environment. Publishing the app defaults the environment to `Production`.

For more information on how to configure the server-side environment, see <xref:fundamentals/environments>.

## Set the client-side environment via startup configuration

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

> [!NOTE]
> For Blazor Web Apps that set the `webAssembly` > `environment` property in `Blazor.start` configuration, it's wise to match the server-side environment to the environment set on the `environment` property. Otherwise, prerendering on the server will operate under a different environment than rendering on the client, which results in arbitrary effects. For general guidance on setting the environment for a Blazor Web App, see <xref:fundamentals/environments>.

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

Using the `environment` property overrides the environment set by the [`blazor-environment` header](#set-the-client-side-environment-via-header).

The preceding approach sets the client's environment without changing the `blazor-environment` header's value, nor does it change the server project's console logging of the startup environment for a Blazor Web App that has adopted global Interactive WebAssembly rendering.

To log the environment to the console in either a standalone Blazor WebAssembly project or the `.Client` project of a Blazor Web App, place the following C# code in the `Program` file after the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost> is created with <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault%2A?displayProperty=nameWithType> and before the line that builds and runs the project (`await builder.Build().RunAsync();`):

```csharp
Console.WriteLine(
    $"Client Hosting Environment: {builder.HostEnvironment.Environment}");
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

## Set the client-side environment via header

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
>
> Although the Blazor framework issues the header name in all lowercase letters (`blazor-enviornment`), you're welcome to use any casing that you desire. For example, a header name that capitalizes each word (`Blazor-Enviornment`) is supported.

## Set the environment for Azure App Service

<!-- UPDATE 9.0 The underlying problem with app settings filename 
                case sensitivity is tracked for 9.0 by ...
                https://github.com/dotnet/aspnetcore/issues/25152 -->

For a standalone client app, you can set the environment manually via [start configuration](#set-the-client-side-environment-via-startup-configuration) or the [`blazor-environment` header](#set-the-client-side-environment-via-header).

For a server-side app, set the environment via an `ASPNETCORE_ENVIRONMENT` app setting in Azure:

1. ***Confirm that the casing of environment segments in app settings file names match their environment name casing exactly***. For example, the matching app settings file name for the `Staging` environment is `appsettings.Staging.json`. If the file name is `appsettings.staging.json` (lowercase "`s`"), the file isn't located, and the settings in the file aren't used in the `Staging` environment.

1. For Visual Studio deployment, confirm that the app is deployed to the correct deployment slot. For an app named `BlazorAzureAppSample`, the app is deployed to the `Staging` deployment slot.

1. In the Azure portal for the environment's deployment slot, set the environment with the `ASPNETCORE_ENVIRONMENT` app setting. For an app named `BlazorAzureAppSample`, the staging App Service Slot is named `BlazorAzureAppSample/Staging`. For the `Staging` slot's configuration, create an app setting for `ASPNETCORE_ENVIRONMENT` with a value of `Staging`. **Deployment slot setting** is enabled for the setting.

When requested in a browser, the `BlazorAzureAppSample/Staging` app loads in the `Staging` environment at `https://blazorazureappsample-staging.azurewebsites.net`.

When the app is loaded in the browser, the response header collection for `blazor.boot.json` indicates that the `blazor-environment` header value is `Staging`.

App settings from the `appsettings.{ENVIRONMENT}.json` file are loaded by the app, where the `{ENVIRONMENT}` placeholder is the app's environment. In the preceding example, settings from the `appsettings.Staging.json` file are loaded.

## Read the environment in a Blazor WebAssembly app

Obtain the app's environment in a component by injecting <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> and reading the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.Environment> property.

`ReadEnvironment.razor`:

```razor
@page "/read-environment"
@using Microsoft.AspNetCore.Components.WebAssembly.Hosting
@inject IWebAssemblyHostEnvironment Env

<h1>Environment example</h1>

<p>Environment: @HostEnvironment.Environment</p>
```

:::moniker range=">= aspnetcore-8.0"

## Read the client-side environment in a Blazor Web App

Assuming that prerendering isn't disabled for a component or the app, a component in the `.Client` project is prerendered on the server. Because the server doesn't have a registered <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment> service, it isn't possible to inject the service and use the service implementation's host environment extension methods and properties during server prerendering. Injecting the service into an Interactive WebAssembly or Interactive Auto component results in the following runtime error:

> :::no-loc text="There is no registered service of type 'Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment'.":::

To address this, create a shared service abstraction and instantiate the service in the server and `.Client` projects with the host environment. The following example demonstrates the approach.

> [!NOTE]
> When using a shared service approach, you can use two distinct service implementations, one for the server project and a separate one for the `.Client` project, or you can use a single service implementation that's configured by server-side or client-side API when the service is created.
>
> The demonstration in this section uses a single service implementation:
>
> * When the service is instantiated on the server, the host environment is provided by <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Environment%2A?displayProperty=nameWithType>.
> * When the service is instantiated on the client, the host environment is provided by <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.Environment%2A?displayProperty=nameWithType>.
>
> The service registrations are shown later in this section.

Add a shared class library project for the Blazor Web App:

* Visual Studio: Right-click the Blazor Web App's solution file in **Solution Explorer**. Select **Add** > **New Project** > **Class Library**. Use the name of the server project with "`.Shared`" added to the end of the name (for example: `BlazorWebAppSample.Shared`).
* Visual Studio Code/.NET CLI: Execute `dotnet new classlib -o {PROJECT NAME}` from a command prompt in the solution's folder. The `-o|--output` option creates a folder for the class library and names the project. For the `{PROJECT NAME}` placeholder, use the name of the server project with "`.Shared`" added to the end of the name (for example: `BlazorWebAppSample.Shared`).

Create a project reference for the class library in both the server and `.Client` projects:

* Visual Studio: Right-click each project and select **Add** > **Project Reference**. Select the checkbox for the shared project and select **OK**.
* Visual Studio Code/.NET CLI: Execute `dotnet add reference {PATH}` in a command shell from each of the server and `.Client` project folders. The `{PATH}` placeholder is the path to the shared class library project.

In the shared (`.Shared`) project:

* Add an interface for the service abstraction.
* Add classes for the service implementation and host environment extensions.

`BlazorHostEnvironment.cs`:

```csharp
public interface IBlazorHostEnvironment
{
    string EnvironmentName { get; set; }
}

public class BlazorHostEnvironment(string environment) : IBlazorHostEnvironment, 
    IDisposable
{
    private bool _disposed;

    public string EnvironmentName { get; set; } = environment;

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
    }
}

public static class BlazorHostEnvironmentExtensions
{
    public static bool IsDevelopment(this IBlazorHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment("Development");
    }

    public static bool IsStaging(this IBlazorHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment("Staging");
    }

    public static bool IsProduction(this IBlazorHostEnvironment hostEnvironment)
    {
        return hostEnvironment.IsEnvironment("Production");
    }

    public static bool IsEnvironment(
        this IBlazorHostEnvironment hostEnvironment,
        string environmentName)
    {
        return string.Equals(
            hostEnvironment.EnvironmentName,
            environmentName,
            StringComparison.OrdinalIgnoreCase);
    }
}
```

In the server project's `Program` file, register a `IBlazorHostEnvironment` service with the `BlazorHostEnvironment` implementation. Set the host environment with <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Environment%2A?displayProperty=nameWithType>, which is only available on the server:

```csharp
builder.Services.AddSingleton<IBlazorHostEnvironment>(
    sp => new BlazorHostEnvironment(builder.Environment.EnvironmentName));
```

In the `.Client` project's `Program` file, register a `IBlazorHostEnvironment` service with the `BlazorHostEnvironment` implementation. Set the host environment with <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.Environment%2A?displayProperty=nameWithType>, which is only available on the client:

```csharp
builder.Services.AddSingleton<IBlazorHostEnvironment>(
    sp => new BlazorHostEnvironment(builder.HostEnvironment.Environment));
```

At this point, the `IBlazorHostEnvironment` service can be injected into an interactive WebAssembly or interactive Auto component. 

During prerendering, the server-side service instance is used to access host environment extension methods and the environment. During client-side WebAssembly component rendering, the client-side service instance is used.

The following component is placed in the `.Client` project to demonstrate using the service. The example assumes that the Interactive Auto render mode is set on a per-page/component basis. If you use the following component in an app that only adopts Interactive WebAssembly rendering, change the `@rendermode` directive to `@rendermode InteractiveWebAssembly`. If your app sets the interactive render mode globally, remove the `@rendermode` directive from the component.

`Pages/Environment.razor`:

```razor
@page "/environment"
@rendermode InteractiveAuto
@inject IBlazorHostEnvironment Environment

<PageTitle>Environment</PageTitle>

<h1>Environment Example</h1>

<ul>
    <li><b>Environment:</b> @Environment.EnvironmentName</li>
    <li><b>Is Development:</b> @Environment.IsDevelopment()</li>
    <li><b>Is Staging:</b> @Environment.IsStaging()</li>
    <li><b>Is Production:</b> @Environment.IsProduction()</li>
    <li><b>Is Environment (Staging):</b> @Environment.IsEnvironment("StAgInG")</li>
</ul>
```

The preceding example can demonstrate that it's possible to have a different server environment than client environment, which isn't recommended and may lead to arbitrary effects. When setting the environment in a Blazor Web App, it's best to match server and `.Client` project environments. Consider the following scenario:

* Implement the client-side (`webassembly`) environment property with the `Staging` environment via `Blazor.start`. See the [Set the client-side environment via startup configuration](#set-the-client-side-environment-via-startup-configuration) section for an example.
* Don't change the server-side `Properties/launchSettings.json` file. Leave the `environmentVariables` section with the `ASPNETCORE_ENVIRONMENT` environment variable set to `Development`.

You can see the values of the above extension methods and the `@Environment.EnvironmentName` property change in the UI of a test app.

When prerendering occurs, the component is rendered in the `Development` environment:

* **Environment:** Development
* **Is Development:** True
* **Is Staging:** False
* **Is Production:** False
* **Is Environment (Staging):** False

When the component is rerendered just a second or two later, after the Blazor bundle is downloaded and the Blazor WebAssembly runtime activates, the values change to reflect that the client is operating in the `Staging` environment:

* **Environment:** Staging
* **Is Development:** False
* **Is Staging:** True
* **Is Production:** False
* **Is Environment (Staging):** True

The preceding example demonstrates why we recommend setting the server environment to match the client environment for development, testing, and production deployments.

For more information, see the [Client-side services fail to resolve during prerendering](xref:blazor/components/render-modes#client-side-services-fail-to-resolve-during-prerendering) section of the *Render modes* article, which appears later in the Blazor documentation.

:::moniker-end

## Read the client-side environment during startup

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
