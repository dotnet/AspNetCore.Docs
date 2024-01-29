---
title: ASP.NET Core Blazor configuration
author: guardrex
description: Learn about Blazor app configuration, including app settings, authentication, and logging configuration.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/fundamentals/configuration
---
# ASP.NET Core Blazor configuration

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure Blazor apps, including app settings, authentication, and logging configuration.

[!INCLUDE[](~/blazor/includes/location-client.md)]

For server-side ASP.NET Core app configuration, see <xref:fundamentals/configuration/index>.

On the client, configuration is loaded from the following app settings files by default:

* `wwwroot/appsettings.json`.
* `wwwroot/appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the app's [runtime environment](xref:fundamentals/environments).

> [!NOTE]
> Logging configuration placed into an app settings file in `wwwroot` isn't loaded by default. For more information, see the [Logging configuration](#logging-configuration) section later in this article.
>
> In some scenarios, such as with Azure services, it's important to use an environment file name segment that exactly matches the environment name. For example, use the file name `appsettings.Staging.json` with a capital ":::no-loc text="S":::" for the `Staging` environment. For recommended conventions, see the opening remarks of <xref:blazor/fundamentals/environments>.

Other configuration providers registered by the app can also provide configuration, but not all providers or provider features are appropriate:

* [Azure Key Vault configuration provider](xref:security/key-vault-configuration): The provider isn't supported for managed identity and application ID (client ID) with client secret scenarios. Application ID with a client secret isn't recommended for any ASP.NET Core app, especially client-side apps because the client secret can't be secured client-side to access the Azure Key Vault service.
* [Azure App configuration provider](/azure/azure-app-configuration/quickstart-aspnet-core-app): The provider isn't appropriate for client-side apps because they don't run on a server in Azure.

For more information on configuration providers, see <xref:fundamentals/configuration/index>.

> [!WARNING]
> Configuration and settings files are visible to users on the client, and users can tamper with the data. **Don't store app secrets, credentials, or any other sensitive data in the app's configuration or files.**

## App settings configuration

Configuration in app settings files are loaded by default. In the following example, a UI configuration value is stored in an app settings file and loaded by the Blazor framework automatically. The value is read by a component.

`wwwroot/appsettings.json`:

```json
{
    "h1FontSize": "50px"
}
```

Inject an <xref:Microsoft.Extensions.Configuration.IConfiguration> instance into a component to access the configuration data.

`ConfigExample.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_WebAssembly/Pages/ConfigExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/configuration/ConfigExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/configuration/ConfigExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/configuration/ConfigExample.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/configuration/ConfigExample.razor":::

:::moniker-end

Client security restrictions prevent direct access to files via user code, including settings files for app configuration. To read configuration files in addition to `appsettings.json`/`appsettings.{ENVIRONMENT}.json` from the `wwwroot` folder into configuration, use an <xref:System.Net.Http.HttpClient>.

> [!WARNING]
> Configuration and settings files are visible to users on the client, and users can tamper with the data. **Don't store app secrets, credentials, or any other sensitive data in the app's configuration or files.**

The following example reads a configuration file (`cars.json`) into the app's configuration.

`wwwroot/cars.json`:

```json
{
    "size": "tiny"
}
```

Add the namespace for <xref:Microsoft.Extensions.Configuration?displayProperty=fullName> to the `Program` file:

```csharp
using Microsoft.Extensions.Configuration;
```

Modify the existing <xref:System.Net.Http.HttpClient> service registration to use the client to read the file:

```csharp
var http = new HttpClient()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};

builder.Services.AddScoped(sp => http);

using var response = await http.GetAsync("cars.json");
using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);
```

The preceding example sets the base address with `builder.HostEnvironment.BaseAddress` (<xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress%2A?displayProperty=nameWithType>), which gets the base address for the app and is typically derived from the `<base>` tag's `href` value in the host page.

## Memory Configuration Source

The following example uses a <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationSource> in the `Program` file to supply additional configuration.

Add the namespace for <xref:Microsoft.Extensions.Configuration.Memory?displayProperty=fullName> to the `Program` file:

```csharp
using Microsoft.Extensions.Configuration.Memory;
```

In the `Program` file:

```csharp
var vehicleData = new Dictionary<string, string?>()
{
    { "color", "blue" },
    { "type", "car" },
    { "wheels:count", "3" },
    { "wheels:brand", "Blazin" },
    { "wheels:brand:type", "rally" },
    { "wheels:year", "2008" },
};

var memoryConfig = new MemoryConfigurationSource { InitialData = vehicleData };

builder.Configuration.Add(memoryConfig);
```

Inject an <xref:Microsoft.Extensions.Configuration.IConfiguration> instance into a component to access the configuration data.

`MemoryConfig.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_WebAssembly/Pages/MemoryConfig.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/configuration/MemoryConfig.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/configuration/MemoryConfig.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/configuration/MemoryConfig.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/configuration/MemoryConfig.razor":::

:::moniker-end

Obtain a section of the configuration in C# code with <xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A?displayProperty=nameWithType>. The following example obtains the `wheels` section for the configuration in the preceding example:

```razor
@code {
    protected override void OnInitialized()
    {
        var wheelsSection = Configuration.GetSection("wheels");

        ...
    }
}
```

## Authentication configuration

Provide authentication configuration in an app settings file.

`wwwroot/appsettings.json`:

```json
{
  "Local": {
    "Authority": "{AUTHORITY}",
    "ClientId": "{CLIENT ID}"
  }
}
```

Load the configuration for an Identity provider with <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A?displayProperty=nameWithType> in the `Program` file. The following example loads configuration for an [OIDC provider](xref:blazor/security/webassembly/standalone-with-authentication-library):

```csharp
builder.Services.AddOidcAuthentication(options =>
    builder.Configuration.Bind("Local", options.ProviderOptions));
```

## Logging configuration

*This section applies to apps that configure logging via an app settings file in the `wwwroot` folder.*

Add the [`Microsoft.Extensions.Logging.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Configuration) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

In the app settings file, provide logging configuration. The logging configuration is loaded in the `Program` file.

`wwwroot/appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

In the `Program` file:

```csharp
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));
```

## Host builder configuration

Read host builder configuration from <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Configuration?displayProperty=nameWithType> in the `Program` file:

```csharp
var hostname = builder.Configuration["HostName"];
```

## Cached configuration

Configuration files are cached for offline use. With [Progressive Web Applications (PWAs)](xref:blazor/progressive-web-app), you can only update configuration files when creating a new deployment. Editing configuration files between deployments has no effect because:

* Users have cached versions of the files that they continue to use.
* The PWA's `service-worker.js` and `service-worker-assets.js` files must be rebuilt on compilation, which signal to the app on the user's next online visit that the app has been redeployed.

For more information on how background updates are handled by PWAs, see <xref:blazor/progressive-web-app#background-updates>.

## Options configuration

[Options configuration](xref:fundamentals/configuration/options) requires adding a package reference for the [`Microsoft.Extensions.Options.ConfigurationExtensions`](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions) NuGet package.

[!INCLUDE[](~/includes/package-reference.md)]

Example:

```csharp
builder.Services.Configure<MyOptions>(
    builder.Configuration.GetSection("MyOptions"));
```

Not all of the ASP.NET Core Options features are supported in Razor components. For example, <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> and <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> configuration is supported, but recomputing option values for these interfaces isn't supported outside of reloading the app by either requesting the app in a new browser tab or selecting the browser's reload button. Merely calling [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) doesn't update snapshot or monitored option values when the underlying configuration changes.
