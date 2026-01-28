---
title: "Breaking change: Middleware: HTTPS Redirection Middleware throws exception on ambiguous HTTPS ports"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Middleware: HTTPS Redirection Middleware throws exception on ambiguous HTTPS ports"
ms.author: scaddie
ms.date: 02/04/2021
ms.custom: https://github.com/aspnet/Announcements/issues/448
---
# Middleware: HTTPS Redirection Middleware throws exception on ambiguous HTTPS ports

In ASP.NET Core 6.0, the [HTTPS Redirection Middleware](xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A) throws an exception of type <xref:System.InvalidOperationException> when it finds multiple HTTPS ports in the server configuration. The exception's message contains the text "Cannot determine the https port from IServerAddressesFeature, multiple values were found. Set the desired port explicitly on HttpsRedirectionOptions.HttpsPort."

For discussion, see GitHub issue [dotnet/aspnetcore#29222](https://github.com/dotnet/aspnetcore/issues/29222).

## Version introduced

ASP.NET Core 6.0

## Old behavior

When the HTTPS Redirection Middleware isn't explicitly configured with a port, it searches <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature> during the first request to determine the HTTPS port to which it should redirect.

If there are no HTTPS ports or multiple distinct ports, it's unclear which port should be used. The middleware logs a warning and disables itself. HTTP requests are processed normally.

## New behavior

When the HTTPS Redirection Middleware isn't explicitly configured with a port, it searches `IServerAddressesFeature` during the first request to determine the HTTPS port to which it should redirect.

If there are no HTTPS ports, the middleware still logs a warning and disables itself. HTTP requests are processed normally. This behavior supports:

* Development scenarios without HTTPS.
* Hosted scenarios in which TLS is terminated before reaching the server.

If there are multiple distinct ports, it's unclear which port should be used. The middleware throws an exception and fails the HTTP request.

## Reason for change

This change prevents potentially sensitive data from being served over unencrypted HTTP connections when HTTPS is known to be available.

## Recommended action

To enable HTTPS redirection when the server has multiple distinct HTTPS ports, you must specify one port in the configuration. For more information, see [Port configuration](/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&preserve-view=true#port-configuration).

If you don't need the HTTPS Redirection Middleware in your app, remove `UseHttpsRedirection` from *Startup.cs*.

If you need to select the correct HTTPS port dynamically, provide feedback in GitHub issue [dotnet/aspnetcore#21291](https://github.com/dotnet/aspnetcore/issues/21291).

## Affected APIs

<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A?displayProperty=nameWithType>

<!--

## Category

ASP.NET Core

## Affected APIs

`Overload:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection`

-->
