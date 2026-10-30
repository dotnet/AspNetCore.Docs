---
title: Overview of Single Page Apps (SPAs) - ASP.NET Core
ai-usage: ai-assisted
description: Learn how to get started with Single Page Apps (SPAs) in ASP.NET Core and find links to tutorials for detailed procedures.
monikerRange: '>= aspnetcore-6.0'
ms.date: 10/30/2026
uid: spa/intro

# customer intent: As an ASP.NET developer, I want to get an overview of SPAs in ASP.NET Core, so I can determine the appropriate tutorial to create apps.
---
# Overview of Single Page Apps (SPAs) in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

::: moniker range=">= aspnetcore-8.0"

[!INCLUDE [spa-templates-recommend-vs](../../includes/spa-templates-recommend-vs.md)]

## Visual Studio tutorials

To get started, follow one of the tutorials in the Visual Studio documentation:

* [Create an ASP.NET Core app with Angular](/visualstudio/javascript/tutorial-asp-net-core-with-angular)
* [Create an ASP.NET Core app with React](/visualstudio/javascript/tutorial-asp-net-core-with-react)
* [Create an ASP.NET Core app with Vue](/visualstudio/javascript/tutorial-asp-net-core-with-vue)

For more information, see [JavaScript and TypeScript in Visual Studio](/visualstudio/javascript/javascript-in-visual-studio)

[!INCLUDE [spa-templates-new-vs-old](../../includes/spa-templates-new-vs-old.md)]

## Development-server forwarding

Apps that use <xref:Microsoft.AspNetCore.Builder.SpaProxyingExtensions.UseProxyToSpaDevelopmentServer*> from the `Microsoft.AspNetCore.SpaServices.Extensions` package forward HTTP and WebSocket requests that reach this middleware to a configured SPA development server. The target server isn't restricted to localhost. This middleware is intended only for development, not production.

This method differs from the `Microsoft.AspNetCore.SpaProxy` launch-and-redirect mechanism. `UseProxyToSpaDevelopmentServer` makes the outbound connections from the ASP.NET Core app instead of redirecting the browser to the development server.

> [!WARNING]
> Forwarded requests use the ASP.NET Core application's network access, not the connecting client's. User- or process-specific VPN, routing, or firewall policies can allow the application to reach an upstream server that the client can't reach directly. Examples include Windows Filtering Platform rules using [`FWPM_CONDITION_ALE_USER_ID`](/windows/win32/fwp/filtering-condition-identifiers-) and Linux UID-based routing.
>
> For example, an app running as user A can have VPN access that user B doesn't have. If user B can connect to the app and their requests reach this middleware, the app can forward those requests to the configured upstream using its VPN access. Binding the app to localhost doesn't by itself restrict connections to user A. Upstream authentication and authorization requirements still apply.

## Related content

- [Developing Single Page Apps](/aspnet/core/client-side/spa/intro?view=aspnetcore-7.0&preserve-view=true#developing-single-page-apps)

::: moniker-end

[!INCLUDE[](~/client-side/spa/includes/intro6-7.md)]
