---
title: ASP.NET Core Blazor logging
author: guardrex
description: Learn about logging in Blazor apps, including log level configuration and how to write log messages from Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/logging
---
# ASP.NET Core Blazor logging

::: moniker range=">= aspnetcore-6.0"

## Logging in Blazor WebAssembly apps

Configure custom logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property.

Add the namespace for <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
```

In `Program.cs`, set the minimum logging level with <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> and add the custom logging provider:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddProvider(new CustomLoggingProvider());
```

The `Logging` property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so all of the extension methods available on <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are also available on `Logging`.

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not available for direct use in developer code.

Add the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> and inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> into the component:

```razor
@using Microsoft.Extensions.Logging
@inject ILoggerProvider LoggerProvider
```

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType>:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
    .ConfigureLogging(logging => logging.AddProvider(LoggerProvider))
    .Build();
```

## Logging in Blazor Server apps

For general ASP.NET Core logging guidance that pertains to Blazor Server, see <xref:fundamentals/logging/index>.

## Razor component logging

Loggers respect app startup configuration.

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILogger> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

## Additional resources

* <xref:fundamentals/logging/index>

::: moniker-end

::: moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Logging in Blazor WebAssembly apps

Configure custom logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property.

Add the namespace for <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
```

In `Program.cs`, set the minimum logging level with <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> and add the custom logging provider:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddProvider(new CustomLoggingProvider());
```

The `Logging` property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so all of the extension methods available on <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are also available on `Logging`.

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not available for direct use in developer code.

Add the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> and inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> into the component:

```razor
@using Microsoft.Extensions.Logging
@inject ILoggerProvider LoggerProvider
```

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType>:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
    .ConfigureLogging(logging => logging.AddProvider(LoggerProvider))
    .Build();
```

## Logging in Blazor Server apps

For general ASP.NET Core logging guidance that pertains to Blazor Server, see <xref:fundamentals/logging/index>.

## Razor component logging

Loggers respect app startup configuration.

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILogger> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

## Additional resources

* <xref:fundamentals/logging/index>

::: moniker-end

::: moniker range="< aspnetcore-5.0"

## Logging in Blazor WebAssembly apps

Configure custom logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property.

Add the namespace for <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
```

In `Program.cs`, set the minimum logging level with <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> and add the custom logging provider:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddProvider(new CustomLoggingProvider());
```

The `Logging` property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so all of the extension methods available on <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are also available on `Logging`.

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not available for direct use in developer code.

Add the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> and inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> into the component:

```razor
@using Microsoft.Extensions.Logging
@inject ILoggerProvider LoggerProvider
```

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType>:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
    .ConfigureLogging(logging => logging.AddProvider(LoggerProvider))
    .Build();
```

## Logging in Blazor Server apps

For general ASP.NET Core logging guidance that pertains to Blazor Server, see <xref:fundamentals/logging/index>.

## Razor component logging

Loggers respect app startup configuration.

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILogger> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

## Additional resources

* <xref:fundamentals/logging/index>

::: moniker-end
