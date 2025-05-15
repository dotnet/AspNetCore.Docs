---
title: IHttpContextAccessor/HttpContext in ASP.NET Core Blazor apps
author: guardrex
description: Learn about IHttpContextAccessor and HttpContext in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 04/29/2025
uid: blazor/components/httpcontext
---
# `IHttpContextAccessor`/`HttpContext` in ASP.NET Core Blazor apps

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

:::moniker range=">= aspnetcore-8.0"

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> generally should be avoided with interactive rendering because a valid <xref:Microsoft.AspNetCore.Http.HttpContext> isn't always available.

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> can be used during static server-side rendering (static SSR), for example in statically-rendered root components, and when [using a token handler for web API calls](xref:blazor/security/additional-scenarios#use-a-token-handler-for-web-api-calls) on the server. **We recommend avoiding <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> when static SSR or code running on the server can't be guaranteed.**

<xref:Microsoft.AspNetCore.Http.HttpContext> can be used as a [cascading parameter](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) only in statically-rendered root components or during static SSR for general tasks, such as inspecting and modifying headers or other properties in the `App` component (`App.razor`). The value is `null` during interactive rendering.

```csharp
[CascadingParameter]
public HttpContext? HttpContext { get; set; }
```

For additional context in *advanced* edge cases&dagger;, see the discussion in the following articles:

* [HttpContext is valid in Interactive Server Rendering Blazor page (`dotnet/AspNetCore.Docs` #34301)](https://github.com/dotnet/AspNetCore.Docs/issues/34301)
* [Security implications of using IHttpContextAccessor in Blazor Server (`dotnet/aspnetcore` #45699)](https://github.com/dotnet/aspnetcore/issues/45699)

&dagger;Most developers building and maintaining Blazor apps don't need to delve into advanced concepts when the general guidance in this article is followed. The most important concept to keep in mind is that <xref:Microsoft.AspNetCore.Http.HttpContext> is fundamentally a server-based, request-response feature that's only generally available on the server during static SSR and only created when a user's circuit is established.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

**Don't use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext> directly or indirectly in the Razor components of server-side Blazor apps.** Blazor apps run outside of the ASP.NET Core pipeline context. The <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to be available within the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>, and <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to hold the context that started the Blazor app.

The recommended approach for passing request state to the Blazor app is through root component parameters during the app's initial rendering. Alternatively, the app can copy the data into a scoped service in the root component's initialization lifecycle event for use across the app. For more information, see <xref:blazor/security/additional-scenarios#pass-tokens-to-a-server-side-blazor-app>.

A critical aspect of server-side Blazor security is that the user attached to a given circuit might become updated at some point after the Blazor circuit is established but the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> ***isn't updated***. For more information on addressing this situation with custom services, see <xref:blazor/security/additional-scenarios#circuit-handler-to-capture-users-for-custom-services>.

:::moniker-end

For guidance on <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> and <xref:Microsoft.AspNetCore.Http.HttpContext> in ASP.NET Core SignalR, see <xref:signalr/httpcontext>.
