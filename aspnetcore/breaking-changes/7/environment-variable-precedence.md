---
title: "Breaking change: ASPNET-prefixed environment variable precedence"
description: Learn about the breaking change in ASP.NET Core 7.0 where ASPNET-prefixed environment variables now have the lowest precedence for WebApplicationBuilder.
ms.date: 12/02/2022
ms.custom: https://github.com/aspnet/Announcements/issues/498
---
# ASPNET-prefixed environment variable precedence

Starting in .NET 7, and only when using the `WebApplicationBuilder` host, command-line arguments and `DOTNET_`-prefixed environment variables override `ASPNET_`-prefixed environment variables when reading from default host configuration sources. These sources are used to read host variables, such as the content root path and environment name, when the `WebApplicationBuilder` is constructed and serve as a base for app configuration.

`ASPNET_`-prefixed environment variables now have the lowest precedence of all of the default host configuration sources for `WebApplicationBuilder`. For other hosts, such as `ConfigureWebHostDefaults` and `WebHost.CreateDefaultBuilder`, `ASPNET_`-prefixed environment variables still have the highest precedence.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

`ASPNET_`-prefixed environment variables overrode command-line arguments and `DOTNET_`-prefixed environment variables when reading `WebApplicationBuilder`'s [default host configuration](/aspnet/core/fundamentals/configuration/#default-host-configuration-sources).

## New behavior

Command-line arguments and `DOTNET_`-prefixed environment variables override `ASPNET_`-prefixed environment variables when reading `WebApplicationBuilder`'s [default host configuration](/aspnet/core/fundamentals/configuration/#default-host-configuration-sources).

## Type of breaking change

This is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

This change was made to prevent environment variables from overriding explicit command-line arguments when reading host variables. The new behavior is more consistent with application configuration, which has always given command-line arguments the highest precedence.

## Recommended action

If you were using `ASPNETCORE_`-prefixed environment variables to override command-line arguments or `DOTNET_`-prefixed environment variables, use something with a higher priority. This could mean using custom <xref:Microsoft.AspNetCore.Builder.WebApplicationOptions>, which overrides all default hosting configuration sources.

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder?displayProperty=fullName>

## See also

- [Default host configuration sources](/aspnet/core/fundamentals/configuration/#default-host-configuration-sources)
