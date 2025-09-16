---
title: ASP.NET Core runtime environments
author: tdykstra
description: Learn how to set and control app behavior across runtime environments in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 09/16/2025
uid: fundamentals/environments
---
# ASP.NET Core runtime environments

[!INCLUDE[](~/includes/not-latest-version.md)]

ASP.NET Core configures app behavior based on the runtime *environment*, which usually reflects where the app is running.

Apps usually run in the *Development* environment during local development and testing on a developer's machine with one set of configured behaviors. In contrast, they run in the *Production* environment when deployed to a server with a different set of configured behaviors. Any number of additional environments can be used, such as the *Staging* environment provided by the framework for staging an app prior to live deployment or other environments that developers create.

This article describes app runtime environments, how to use the environment to control app behavior, and how to set the environment.

For Blazor environments guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/environments>.

## Environments

Although the environment can be any string value, the following environment values are provided by the framework:

* <xref:Microsoft.Extensions.Hosting.Environments.Development>
* <xref:Microsoft.Extensions.Hosting.Environments.Staging>
* <xref:Microsoft.Extensions.Hosting.Environments.Production>

The Production environment is configured to maximize security, performance, and app reliability. Common developer settings and configuration that differ from the Development environment include:

* Enabling [caching](xref:performance/caching/memory).
* Bundling and minifying client-side resources, along with potentially serving them from a CDN.
* Disabling diagnostic error pages and enabling friendly error pages.
* Enabling production logging and monitoring. For example, logging is enabled for [Azure Application Insights](/azure/application-insights/app-insights-asp-net-core).

The last environment setting read by the app determines the app's environment. The app's environment can't be changed while the app is running.

## Logging

Output in the command shell of a running app at startup indicates the app's environment. In the following example, the app is running in the Staging environment:

```dotnetcli
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Staging
```

## Environment variables that determine the runtime environment

To determine the runtime environment, ASP.NET Core reads from the following environment variables:

:::moniker range=">= aspnetcore-7.0"

* [`DOTNET_ENVIRONMENT`](xref:fundamentals/configuration/index#default-host-configuration)
* `ASPNETCORE_ENVIRONMENT`

When using <xref:Microsoft.AspNetCore.Builder.WebApplication>, the `DOTNET_ENVIRONMENT` value take precedence over `ASPNETCORE_ENVIRONMENT`. When using <xref:Microsoft.AspNetCore.WebHost>, `ASPNETCORE_ENVIRONMENT` takes precedence.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

* [`DOTNET_ENVIRONMENT`](xref:fundamentals/configuration/index#default-host-configuration)
* `ASPNETCORE_ENVIRONMENT` when the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method is called. The ASP.NET Core web app project templates call `WebApplication.CreateBuilder`. The `ASPNETCORE_ENVIRONMENT` value overrides `DOTNET_ENVIRONMENT`.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [`DOTNET_ENVIRONMENT`](xref:fundamentals/configuration/index#default-host-configuration)
* `ASPNETCORE_ENVIRONMENT` when <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> is called. The ASP.NET Core web app project templates call `ConfigureWebHostDefaults`. The `ASPNETCORE_ENVIRONMENT` value overrides `DOTNET_ENVIRONMENT`.

:::moniker-end

If the `DOTNET_ENVIRONMENT` and `ASPNETCORE_ENVIRONMENT` environment variables aren't set, the Production environment is the default environment.

On Windows and macOS, environment variable names aren't case-sensitive. Linux environment variables are case-sensitive.

## Control code execution by environment

:::moniker range=">= aspnetcore-6.0"

Use <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Environment?displayProperty=nameWithType> or <xref:Microsoft.AspNetCore.Builder.WebApplication.Environment?displayProperty=nameWithType> to conditionally add services or middleware depending on the current environment.

The following code in the app's `Program` file:

* Uses <xref:Microsoft.AspNetCore.Builder.WebApplication.Environment?displayProperty=nameWithType> to distinguish the environment.
* Calls <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>, which adds [Exception Handler Middleware](xref:fundamentals/error-handling) to the request processing pipeline to handle exceptions.
* Calls <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>, which adds [HSTS Middleware](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) to apply the [`Strict-Transport-Security` header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Strict-Transport-Security).

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

The preceding example checks the current environment for the request processing pipeline. To check the current environment while configuring services, use [`builder.Environment`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Environment%2A) instead of [`app.Environment`](xref:Microsoft.AspNetCore.Builder.WebApplication.Environment%2A).

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Use <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> or <xref:Microsoft.AspNetCore.Builder.WebApplication.Environment?displayProperty=nameWithType> to conditionally add services or middleware depending on the current environment.

The following code in `Startup.Configure`:

* Injects <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> into `Startup.Configure` to tailor the code to the environment. This approach is useful when the app only requires adjusting `Startup.Configure` for a few environments with minimal code differences per environment. When many code differences exist per environment, consider using [accessing the environment from a `Startup` class](#access-the-environment-from-a-startup-class), which is covered later in this article.
* Calls <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A> when `ASPNETCORE_ENVIRONMENT` is set to `Development`. The call adds middleware that captures exceptions and generates HTML error responses.
* Calls <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> when the value of `ASPNETCORE_ENVIRONMENT` is set to `Production`, `Staging`, or `Testing`. The call adds [Exception Handler Middleware](xref:fundamentals/error-handling) to the pipeline to handle exceptions.

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Testing"))
    {
        app.UseExceptionHandler("/Error");
    }

    ...
}
```

The preceding example checks the current environment while building the request pipeline. To check the current environment in `Startup.ConfigureServices` while configuring services, inject <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> into the `Startup` class instead of injecting it into `Startup.Configure` and use the injected service to determine the environment in `Startup.ConfigureServices` and `Startup.Configure`.

:::moniker-end

Within the app, the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> provides general information about the app's hosting environment, and the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName?displayProperty=nameWithType> property indicates the app's current environment.

## Control rendered content

Inject <xref:Microsoft.Extensions.Hosting.IHostEnvironment> into a server-rendered Razor component and use the service's extension methods and <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName%2A> property to determine the environment for rendering content:

```razor
@inject IHostEnvironment Env

@if (Env.IsDevelopment())
{
    <div>The environment is Development.</div>
}

@if (!Env.IsDevelopment())
{
    <div>The environment isn't Development.</div>
}

@if (Env.IsStaging() || Env.EnvironmentName == "Testing")
{
    <div>The environment is either Staging or Testing.</div>
}
```

For Blazor Web Apps that require the environment to control client-side rendering, see <xref:blazor/components/prerender#client-side-services-fail-to-resolve-during-prerendering>.

## Set the environment in a command shell when the app is run (`dotnet run`)

Use the [`-e|--environment` option](/dotnet/core/tools/dotnet-run#options) to set the environment:

```dotnetcli
dotnet run -e Staging
```

## Set the environment with the launch settings file (`launchSettings.json`)

The environment for local development can be set in the `Properties\launchSettings.json` file of the project. Environment values set in `launchSettings.json` override values set by the system environment.

The `launchSettings.json` file:

* Is only used on the local development machine.
* Isn't deployed when the app is published.
* May contain multiple profiles, each configuring a different environment.

The following example sets the Staging environment for the `https` launch profile using the `ASPNETCORE_ENVIRONMENT` environment variable:

```json
"https": {
  "commandName": "Project",
  "dotnetRunMessages": true,
  "launchBrowser": true,
  "applicationUrl": "https://localhost:7205",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Staging"
  }
}
```

In Visual Studio, there are two approaches for setting the environment via launch profiles:

* Press <kbd>Alt</kbd>+<kbd>Enter</kbd> or select **Properties** after right-clicking the project in **Solution Explorer**. Select **Debug** > **General**, followed by selecting the **Open debug launch profiles UI** link.

* With the project selected in **Solution Explorer**, select **{PROJECT NAME} Debug Properties** from the **Debug** menu, where the `{PROJECT NAME}` placeholder is a project name.

The preceding approaches open the **Launch Profiles** dialog where you can edit the environment variable settings in the `launchSettings.json` file. Changes made to project profiles may not take effect until the web server is restarted. Kestrel must be restarted before it can detect changes made to its environment.

Profiles can be selected in the Visual Studio UI next to the Start button (►).

When a solution contains multiple projects, only set the environment for the startup project.

Alternatively, use the [`dotnet run`](/dotnet/core/tools/dotnet-run) command with the [`-lp|--launch-profile` option](/dotnet/core/tools/dotnet-run#options) set to the profile's name. *This approach only supports launch profiles based on the `Project` command.*

```dotnetcli
dotnet run -lp "https"
```

When using [Visual Studio Code](https://code.visualstudio.com/) with the [C# Dev Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) ([Getting Started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started)), launch profiles are picked up from the app's `launchSettings.json` file.

If the C# Dev Kit isn't used, set the `ASPNETCORE_ENVIRONMENT` environment variable in the `.vscode/launch.json` in the `env` section, along with any other environment variables set in the section:

```json
"env": {
    "ASPNETCORE_ENVIRONMENT": "Staging",
    ...
},
```

The `.vscode/launch.json` file is only used by Visual Studio Code.

## Set the environment with an environment variable

It's often useful to set a specific environment for testing with an environment variable or platform setting. If the environment isn't set, it defaults to the Production environment, which disables most debugging features. The method for setting the environment depends on the operating system.

### Azure App Service

Apps deployed to [Azure App Service](https://azure.microsoft.com/services/app-service/) adopt the Production environment by default.

To set the `ASPNETCORE_ENVIRONMENT` environment variable, see the following resources in the Azure documentation:

* [Configure an App Service app](/azure/app-service/configure-common?tabs=portal#configure-app-settings)
* [Set up staging environments in Azure App Service](/azure/app-service/web-sites-staged-publishing)

Azure App Service automatically restarts the app after an app setting is added, changed, or deleted.

### Set environment variable for a process

To set the `ASPNETCORE_ENVIRONMENT` environment variable for the current session (command shell) when the app is started using [`dotnet run`](/dotnet/core/tools/dotnet-run), use the following commands. After the environment variable is set, the app is started without a launch profile using the [`--no-launch-profile`](/dotnet/core/tools/dotnet-run#options) option.

1. In the command shell, set the environment variable using the appropriate approach for your operating system.

1. Execute the `dotnet run` command without using a launch profile:

   ```dotnetcli
   dotnet run --no-launch-profile
   ```

When using PowerShell, the preceding steps can be combined in the following two commands. The following example sets the Staging environment:

```powershell
$Env:ASPNETCORE_ENVIRONMENT = "Staging"
dotnet run --no-launch-profile
```

### Set environment variable globally

Use the appropriate guidance for your operating system to set the `ASPNETCORE_ENVIRONMENT` environment variable.

When the `ASPNETCORE_ENVIRONMENT` environment variable is set globally, it takes effect for the [`dotnet run`](/dotnet/core/tools/dotnet-run) command in any command shell opened after the value is set. Environment values set by [launch profiles in the `launchSettings.json` file](#set-the-environment-with-the-launch-settings-file-launchsettingsjson) override values set for the system environment.

### Set the environment for apps deployed to IIS

To set the `ASPNETCORE_ENVIRONMENT` environment variable with the `web.config` file, see <xref:host-and-deploy/iis/web-config#set-environment-variables>.

To set the environment variable on deployment to IIS, include the `<EnvironmentName>` property in the [publish profile (.pubxml)](xref:host-and-deploy/visual-studio-publish-profiles) or project file. The following example sets the environment in `web.config` to the Staging environment when the project is published:

```xml
<PropertyGroup>
  <EnvironmentName>Staging</EnvironmentName>
</PropertyGroup>
```

To set the `ASPNETCORE_ENVIRONMENT` environment variable for an app running in an isolated Application Pool (supported on IIS 10.0 or later), see [Environment Variables &lt;environmentVariables&gt;](/iis/configuration/system.applicationHost/applicationPools/add/environmentVariables/#appcmdexe). When the `ASPNETCORE_ENVIRONMENT` environment variable is set for an Application Pool, its value overrides a setting at the system level.

When hosting an app in IIS and adding or changing the `ASPNETCORE_ENVIRONMENT` environment variable, use ***either*** of the following approaches to have the new value take effect for running apps:

* Execute `net stop was /y` followed by `net start w3svc` in a command shell.
* Restart the server.

### Docker

Set the app's environment using any of the approaches in this section.

#### Use a Dockerfile

Set the `ASPNETCORE_ENVIRONMENT` environment variable within the Dockerfile using the `ENV` instruction:

```
ENV ASPNETCORE_ENVIRONMENT=Staging
```

#### Use Docker Compose

For multi-service apps managed with Docker Compose, define `ASPNETCORE_ENVIRONMENT` environment variables within the `docker-compose.yml` file:

```
version: "3.9"
services:
  web:
    build: .
    ports:
      - "8000:5000"
    environment:
      - ASPNETCORE_ENVIRONMENT=Staging
      - API_KEY=...
```

An environment set at runtime with Docker Compose overrides an environment set by the Dockerfile.

#### Use the `docker run` command

When running the Docker container with the [`docker run` command](https://docs.docker.com/reference/cli/docker/container/run/), Set the `ASPNETCORE_ENVIRONMENT` environment variable with the `-e|--env` option:

```console
docker run -e ASPNETCORE_ENVIRONMENT=Staging aspnet_core_image
```

An environment set at runtime with `docker run` overrides an environment set by the Dockerfile.

#### Docker environment file

Set the `ASPNETCORE_ENVIRONMENT` environment variable using a Docker environment file (`.env`).

`env_variables.env`:

```
ASPNETCORE_ENVIRONMENT=Staging
```

Load the file with the `--env-file` option when executing the [`docker run` command](https://docs.docker.com/reference/cli/docker/container/run/):

```shell
docker run --env-file ./env_variables.env aspnet_core_image
```

An environment set at runtime with `docker run` overrides an environment set by the Dockerfile.

## Set the environment in the app's startup code

:::moniker range=">= aspnetcore-6.0"

To set the environment in code, use <xref:Microsoft.AspNetCore.Builder.WebApplicationOptions.EnvironmentName?displayProperty=nameWithType> when creating <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder>, as shown in the following example:

```csharp
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Staging
}); 
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Call <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseEnvironment%2A> when building the host. For more information, see <xref:fundamentals/host/generic-host#environmentname>.

:::moniker-end

## Load configuration by environment

To load configuration by environment, see <xref:fundamentals/configuration/index#json-configuration-provider>.

## Access the environment from a `Startup` class

Use of a `Startup` class (`Startup.cs`) with [`Configure`](xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A) and [`ConfigureServices`](xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices%2A) methods was required before the release of .NET 6 and remains supported.

Inject <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> into the `Startup` constructor to control code execution. This approach is useful when the app requires configuring startup code for only a few environments with minimal code differences per environment.

In the following example, the environment is held in the `_env` field and controls code execution based on the app's environment:

```csharp
public class Startup
{
    private readonly IWebHostEnvironment _env;

    public Startup(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_env.IsDevelopment())
        {
            ...
        }
        else if (_env.IsStaging())
        {
            ...
        }
        else
        {
            ...
        }
    }

    public void Configure(IApplicationBuilder app)
    {
        if (_env.IsDevelopment())
        {
            ...
        }
        else
        {
            ...
        }

        ...
    }
}
```

## Environment-specific `Startup` class

An app can define multiple `Startup` classes for different environments with the naming convention `Startup{EnvironmentName}` class, where the `{ENVIRONMENT NAME}` placeholder is the environment name.

The class whose name suffix matches the current environment is prioritized. If a matching `Startup{EnvironmentName}` class isn't found, the `Startup` class is used.

To implement environment-based `Startup` classes, create as many `Startup{EnvironmentName}` classes as needed and a fallback `Startup` class:

```csharp
public class StartupDevelopment
{
    ...
}

public class StartupProduction
{
    ...
}

public class Startup
{
    ...
}
```

Where the host builder is created, call <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseStartup%2A?displayProperty=nameWithType>, which accepts an assembly name to load the correct `Startup` class:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args)
{
    var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup(assemblyName);
        });
}
```

## Environment-specific `Startup` class methods

The `Configure` and `ConfigureServices` methods support environment-specific versions of the form `Configure{ENVIRONMENT NAME}` and `Configure{ENVIRONMENT NAME}Services`, where the `{ENVIRONMENT NAME}` placeholder is the environment name. If a matching environment name isn't found for the named methods, the `ConfigureServices` or `Configure` method is used, respectively.

```csharp
public void ConfigureDevelopmentServices(IServiceCollection services)
{
    ...
}

public void ConfigureStagingServices(IServiceCollection services)
{
    ...
}

public void ConfigureProductionServices(IServiceCollection services)
{
    ...
}

public void ConfigureServices(IServiceCollection services)
{
    ...
}
```

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/environments) ([how to download](xref:index#how-to-download-a-sample))
* <xref:fundamentals/startup>
* <xref:fundamentals/configuration/index>
* <xref:blazor/fundamentals/environments>
