---
title: ASP.NET Core runtime environments
author: tdykstra
description: Learn how to set and control app behavior across runtime environments in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 08/29/2025
uid: fundamentals/environments
---
# ASP.NET Core runtime environments

[!INCLUDE[](~/includes/not-latest-version.md)]

ASP.NET Core configures app behavior based on the runtime *environment*, which usually reflects where the app is running. The app's code execution is tailored to the environment in which the app is running.

App's usually run in the *Development* environment during local development and testing on a developer's machine with one set of configured behaviors and in the *Production* environment when deployed to a server with a different set of configured behaviors. Any number of additional environments can be used, such as the *Staging* environment provided by the framework for staging an app prior to live deployment or other environments that developers create.

This article describes app runtime environments, how to set the environment, and how to use the environment to control app behavior.

For Blazor environments guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/environments>.

## Environments

Although the environment can be any string value, the following environment values are provided by the framework:

* <xref:Microsoft.Extensions.Hosting.Environments.Development>
* <xref:Microsoft.Extensions.Hosting.Environments.Staging>
* <xref:Microsoft.Extensions.Hosting.Environments.Production>

The Production environment is configured to maximize security, performance, and app reliability. Some common settings that differ from the Development environment include:

* [Caching](xref:performance/caching/memory) is enabled.
* Client-side resources are bundled, minified, and potentially served from a CDN.
* Diagnostic error pages are disabled.
* Friendly error pages are enabled.
* Production logging and monitoring are enabled. For example, logging is enabled for [Azure Application Insights](/azure/application-insights/app-insights-asp-net-core).

The last environment setting read by the app determines the app's environment. The app's environment can't be changed while the app is running.

On Windows and macOS, environment variables and values aren't case-sensitive. Linux environment variables and values are case-sensitive by default.

## Logging

Output in the command shell of a running app at startup indicates the app's environment. In the following example, the app is running in the Staging environment:

```dotnetcli
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Staging
```

## Environment variables that determine the runtime environment

:::moniker range=">= aspnetcore-7.0"

To determine the runtime environment, ASP.NET Core reads from the following environment variables:

1. [DOTNET_ENVIRONMENT](xref:fundamentals/configuration/index#default-host-configuration)
1. `ASPNETCORE_ENVIRONMENT` when the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method is called. The default ASP.NET Core web app templates call `WebApplication.CreateBuilder`. The `DOTNET_ENVIRONMENT` value overrides `ASPNETCORE_ENVIRONMENT` when `WebApplicationBuilder` is used. For other hosts, such as <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> and <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A?displayProperty=nameWithType>, `ASPNETCORE_ENVIRONMENT` has higher precedence.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

To determine the runtime environment, ASP.NET Core reads from the following environment variables:

1. [`DOTNET_ENVIRONMENT`](xref:fundamentals/configuration/index#default-host-configuration)
1. `ASPNETCORE_ENVIRONMENT` when the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method is called. The default ASP.NET Core web app templates call `WebApplication.CreateBuilder`. The `ASPNETCORE_ENVIRONMENT` value overrides `DOTNET_ENVIRONMENT`.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

To determine the runtime environment, ASP.NET Core reads from the following environment variables:

1. [`DOTNET_ENVIRONMENT`](xref:fundamentals/configuration/index#default-host-configuration)
1. `ASPNETCORE_ENVIRONMENT` when <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> is called. The default ASP.NET Core web app templates call `ConfigureWebHostDefaults`. The `ASPNETCORE_ENVIRONMENT` value overrides `DOTNET_ENVIRONMENT`.

:::moniker-end

If the `DOTNET_ENVIRONMENT` and `ASPNETCORE_ENVIRONMENT` environment variables aren't set, the Production environment is the default environment.

## Control code execution by environment

:::moniker range=">= aspnetcore-6.0"

Use <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Environment?displayProperty=nameWithType> or <xref:Microsoft.AspNetCore.Builder.WebApplication.Environment?displayProperty=nameWithType> to conditionally add services or middleware depending on the current environment.

When the value of `ASPNETCORE_ENVIRONMENT` is anything other than `Development`, the following code in the app's `Program` file:

* Calls <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>, which adds [Exception Handler Middleware](xref:fundamentals/error-handling) to the pipeline to handle exceptions.
* Calls <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>, which adds [HSTS Middleware](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) to apply the `Strict-Transport-Security` header.

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

The preceding example checks the current environment while building the request pipeline. To check the current environment while configuring services, use `builder.Environment` instead of `app.Environment`.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Use <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> or <xref:Microsoft.AspNetCore.Builder.WebApplication.Environment?displayProperty=nameWithType> to conditionally add services or middleware depending on the current environment.

The following code in `Startup.Configure`:

* Injects <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment> into `Startup.Configure`. This approach is useful when the app only requires adjusting `Startup.Configure` for a few environments with minimal code differences per environment.
* Calls <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A>, which captures exceptions and generates HTML error responses, when `ASPNETCORE_ENVIRONMENT` is set to `Development`.
* Calls <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>, which adds [Exception Handler Middleware](xref:fundamentals/error-handling) to the pipeline to handle exceptions, when the value of `ASPNETCORE_ENVIRONMENT` is set to `Production`, `Staging`, or `Testing`.

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

## Control rendered content in Razor Pages and MVC

In Razor Pages and MVC apps, the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) uses the value of <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName?displayProperty=nameWithType> to include or exclude markup in the Tag Helper's element:

```cshtml
<environment include="Development">
    <div>The environment is Development.</div>
</environment>
<environment exclude="Development">
    <div>The environment isn't Development.</div>
</environment>
<environment include="Staging,Development,Testing">
    <div>The environment is any of: Staging, Development, or Testing.</div>
</environment>
```

## Set the environment in a command shell when the app is run (`dotnet run`)

Use the `-e|--environment` flag to set the environment:

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

* Press <kbd>Alt</kbd>+<kbd>Enter</kbd> or select **Properties** after right-clicking the project in **Solution Explorer**. Select **Debug** > **General**, and select the **Open debug launch profiles UI** link.

* With the project selected in **Solution Explorer**, select **{PROJECT NAME} Debug Properties**, where the `{PROJECT NAME}` placeholder is a project name, from the **Debug** menu.

The preceding approaches open the **Launch Profiles** dialog where you can edit the environment variable settings in the `launchSettings.json` file. Changes made to project profiles may not take effect until the web server is restarted. Kestrel must be restarted before it can detect changes made to its environment.

Profiles can be selected in the Visual Studio UI next to the Start button (►).

Alternatively, use the [`dotnet run`](/dotnet/core/tools/dotnet-run) command with the [`-lp|--launch-profile` option](/dotnet/core/tools/dotnet-run#options) set to the profile's name. *This approach only supports Kestrel profiles.*

```dotnetcli
dotnet run -lp "https"
```

When using [Visual Studio Code](https://code.visualstudio.com/), set the `ASPNETCORE_ENVIRONMENT` environment variable in the `.vscode/launch.json` in the `env` section, along with other environment variables set in the section:

```json
"env": {
    "ASPNETCORE_ENVIRONMENT": "Staging",
    ...
},
```

The `.vscode/launch.json` file is used only by Visual Studio Code.

When Visual Studio or Visual Studio Code aren't used as the development environment, edit the `Properties\launchSettings.json` file and change one or more `ASPNETCORE_ENVIRONMENT` environment variable values.

## Set the environment with an environment variable

It's often useful to set a specific environment for testing with an environment variable or platform setting. If the environment isn't set, it defaults to the Production environment, which disables most debugging features. The method for setting the environment depends on the operating system.

### Azure App Service

Apps deployed to [Azure App Service](https://azure.microsoft.com/services/app-service/) adopt the `Production` environment by default.

To set the environment using the Azure portal:

1. Select the app from the **App Services** page.
1. In the **Settings** group, select **Environment variables**.
1. In the **App settings** tab, select **+ Add**.
1. In the **Add/Edit application setting** window, provide `ASPNETCORE_ENVIRONMENT` for the **Name**. For **Value**, provide the environment (for example, `Staging`).
1. Select the **Deployment slot setting** checkbox if you wish the environment setting to remain with the current slot when deployment slots are swapped. For more information, see [Set up staging environments in Azure App Service](/azure/app-service/web-sites-staged-publishing) in the Azure documentation.
1. Select **OK** to close the **Add/Edit application setting** dialog.
1. Select **Save** at the top of the **Configuration** page.

Azure App Service automatically restarts the app after an app setting is added, changed, or deleted.

### Windows

Set the app's environment using any of the approaches in this section.

#### Set environment variable for a process

To set the `ASPNETCORE_ENVIRONMENT` environment variable for the current session (command shell) when the app is started using [`dotnet run`](/dotnet/core/tools/dotnet-run), use the following commands. First, the environment variable is set. Then, the app is started without a launch profile using the [`--no-launch-profile`](/dotnet/core/tools/dotnet-run#options) option.

Command shell: The following commands are shown separately because not all command shells execute multiple commands when pasted at once.

```dotnetcli
set ASPNETCORE_ENVIRONMENT=Staging
```

```dotnetcli
dotnet run --no-launch-profile
```

PowerShell: PowerShell is capable of executing multiple commands at once when pasted together.

```powershell
$Env:ASPNETCORE_ENVIRONMENT = "Staging"
dotnet run --no-launch-profile
```

#### Set environment variable globally

To set the environment variable globally in Windows, use either of the following approaches:

* Open the **Control Panel** > **System** > **Advanced system settings** and add or edit the `ASPNETCORE_ENVIRONMENT` value:

  :::image source="environments/_static/systemsetting_environment.png" alt-text="System Advanced Properties":::

  :::image source="environments/_static/windows_aspnetcore_environment.png" alt-text="ASPNET Core Environment Variable":::

* Open an administrative command prompt and use the `setx` command or open an administrative PowerShell command prompt and use `[Environment]::SetEnvironmentVariable`:

  * ```console
    setx ASPNETCORE_ENVIRONMENT Staging /M
    ```

    The `/M` switch sets the environment variable at the system level. If the `/M` switch isn't used, the environment variable is set for the user account.

  * ```powershell
    [Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Staging", "Machine")
    ```

    The `Machine` option sets the environment variable at the system level. If the option value is changed to `User`, the environment variable is set for the user account.

When the `ASPNETCORE_ENVIRONMENT` environment variable is set globally, it takes effect for the [`dotnet run`](/dotnet/core/tools/dotnet-run) command in any command shell opened after the value is set. Environment values set by launch profiles in the `launchSettings.json` file override values set for the system environment.

#### Set the environment for apps deployed to IIS

To set the `ASPNETCORE_ENVIRONMENT` environment variable with the `web.config` file, see the *Set environment variables* section of <xref:host-and-deploy/iis/web-config#set-environment-variables>.

To set the environment variable on deployment to IIS, include the `<EnvironmentName>` property in the [publish profile (.pubxml)](xref:host-and-deploy/visual-studio-publish-profiles) or project file. The following example sets the environment in `web.config` to the Staging environment when the project is published:

```xml
<PropertyGroup>
  <EnvironmentName>Staging</EnvironmentName>
</PropertyGroup>
```

To set the `ASPNETCORE_ENVIRONMENT` environment variable for an app running in an isolated Application Pool (supported on IIS 10.0 or later), see the *AppCmd.exe command* section of [Environment Variables &lt;environmentVariables&gt;](/iis/configuration/system.applicationHost/applicationPools/add/environmentVariables/#appcmdexe). When the `ASPNETCORE_ENVIRONMENT` environment variable is set for an app pool, its value overrides a setting at the system level.

When hosting an app in IIS and adding or changing the `ASPNETCORE_ENVIRONMENT` environment variable, use one of the following approaches to have the new value take effect for running apps:

* Execute `net stop was /y` followed by `net start w3svc` in a command shell.
* Restart the server.

### macOS and Linux

Setting the current environment for macOS can be performed in-line when running the app in the Terminal shell:

```dotnetcli
ASPNETCORE_ENVIRONMENT=Staging dotnet run
```

Alternatively, set the environment with the [`export`](https://man7.org/linux/man-pages/man1/export.1p.html) command prior to running the app:

```dotnetcli
export ASPNETCORE_ENVIRONMENT=Staging
```

Environment variables set with `export` only exist for the lifetime of the current shell. To persist the setting across multiple sessions or system reboots, add the `export` command to a shell startup file (`.bashrc` or `.bash_profile`).

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

When running the Docker container with the `docker run` command, Set the `ASPNETCORE_ENVIRONMENT` environment variable with the `-e|--env` option:

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

Load the file with the `--env-file` option when executing the `docker run` command:

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

## Environment-based `Startup` class and methods

Use of a `Startup` class (`Startup.cs`) with [`Configure`](xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A) and [`ConfigureServices`](xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices%2A) methods is no longer recommended for apps that target .NET 6 or later. Modern ASP.NET Core project templates place startup code for service configuration and request pipeline processing in the `Program` file. However, use of a `Startup` class remains supported in ASP.NET Core, and you can use the guidance in this section to control code execution by environment using a `Startup` class.

### Inject `IWebHostEnvironment` into the `Startup` class

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

The preceding example is simplified with the use of [primary constructors](/dotnet/csharp/whats-new/tutorials/primary-constructors) in C# 12 (.NET 8) or later:

```csharp
public class Startup(IWebHostEnvironment env)
{
    public void ConfigureServices(IServiceCollection services)
    {
        if (env.IsDevelopment())
        {
            ...
        }
        else if (env.IsStaging())
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
        if (env.IsDevelopment())
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

### `Startup` class conventions

An app can define multiple `Startup` classes for different environments with the naming convention `Startup{EnvironmentName}` class, where the `{ENVIRONMENT NAME}` placeholder is the environment name.

The class whose name suffix matches the current environment is prioritized. If a matching `Startup{EnvironmentName}` class isn't found, the `Startup` class is used. This approach is useful when the app requires configuring startup for several environments with many code differences per environment. Typical apps don't have enough startup code differences across environments to use this approach.

To implement environment-based `Startup` classes, create as many `Startup{EnvironmentName}` classes and a fallback `Startup` class:

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

### `Startup` class method conventions

The `Configure` and `ConfigureServices` methods support environment-specific versions of the form `Configure{ENVIRONMENT NAME}` and `Configure{ENVIRONMENT NAME}Services`, where the `{ENVIRONMENT NAME}` placeholder is the environment name. If a matching environment name isn't found for the named methods, the `ConfigureServices` or `Configure` method is used, respectively. This approach is useful when the app requires configuring startup for several environments with many code differences per environment:

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
