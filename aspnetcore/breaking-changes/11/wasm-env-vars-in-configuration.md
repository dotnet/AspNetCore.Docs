---
title: "Breaking change: WebAssemblyHostBuilder loads environment variables into IConfiguration"
description: "Learn about the breaking change in ASP.NET Core 11 where WebAssemblyHostBuilder.CreateDefault adds environment variables to IConfiguration by default."
ms.date: 06/04/2026
ai-usage: ai-assisted
---

# WebAssemblyHostBuilder loads environment variables into IConfiguration

`WebAssemblyHostBuilder.CreateDefault` now calls `AddEnvironmentVariables()` on the configuration builder. Environment variables that are passed into the Blazor WebAssembly runtime through `MonoConfig.environmentVariables` are now visible through `IConfiguration` in addition to <xref:System.Environment.GetEnvironmentVariable*>.

## Version introduced

.NET 11

## Previous behavior

Previously, environment variables that were available to a Blazor WebAssembly app through <xref:System.Environment.GetEnvironmentVariable*> weren't loaded into `IConfiguration`. To read them through `IConfiguration`, you had to add the environment-variables provider manually:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Required to read environment variables through IConfiguration.
builder.Configuration.AddEnvironmentVariables();

var endpoint = builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"];
```

## New behavior

Starting in ASP.NET Core 11, `WebAssemblyHostBuilder.CreateDefault` calls `AddEnvironmentVariables()` for you. Environment variables are visible in `IConfiguration` without any extra setup:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Works without an explicit AddEnvironmentVariables call.
var endpoint = builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"];
```

This aligns the WebAssembly host with `WebApplication.CreateBuilder()`, which has loaded environment variables into `IConfiguration` since .NET 6.

The configuration sources are still ordered so that environment variables override earlier sources (such as `appsettings.json`) and are overridden by later sources (such as command-line arguments). An environment variable with the same name as an `appsettings.json` key (for example, `Logging__LogLevel__Default`) now takes precedence over the JSON value.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

This change aligns the Blazor WebAssembly host with the server-side `WebApplication.CreateBuilder()` configuration sources and unblocks .NET Aspire integration for Blazor WebAssembly. Aspire reads configuration values such as `OTEL_EXPORTER_OTLP_ENDPOINT` from `IConfiguration` for service discovery and OpenTelemetry. For more information, see [dotnet/aspnetcore#64578](https://github.com/dotnet/aspnetcore/pull/64578).

## Recommended action

If you previously called `builder.Configuration.AddEnvironmentVariables()` manually, you can remove that call. The duplicate call is harmless but unnecessary.

If an environment variable in your hosting environment shadows a value in `appsettings.json` and you don't want that, rename the environment variable, or add an additional configuration source after `CreateDefault` returns to override the value:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Re-apply appsettings.json on top of environment variables for a specific key.
builder.Configuration["Logging:LogLevel:Default"] = "Information";
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.CreateDefault*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables*?displayProperty=fullName>
