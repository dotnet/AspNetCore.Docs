---
title: Policy schemes in ASP.NET Core
author: rick-anderson
description: Authentication policy schemes make it easier to have a single logical authentication scheme
ms.author: riande
ms.date: 12/05/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/policyschemes
---

# Policy schemes in ASP.NET Core

Authentication policy schemes make it easier to have a single logical authentication scheme potentially use multiple approaches. For example, a policy scheme might use Google authentication for challenges, and cookie authentication for everything else. Authentication policy schemes make it:

* Easy to forward any authentication action to another scheme.
* Forward dynamically based on the request.

All authentication schemes that use derived <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions> and the associated <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601>:

* Are automatically policy schemes in ASP.NET Core 2.1 and later.
* Can be enabled via configuring the scheme's options.

[!code-csharp[sample](policyschemes/samples/AuthenticationSchemeOptions.cs?name=snippet)]

## Examples

The following example shows a higher level scheme that combines lower level schemes. Google authentication is used for challenges, and cookie authentication is used for everything else:

[!code-csharp[sample](policyschemes/samples/Startup.cs?name=snippet1)]

The following example enables dynamic selection of schemes on a per request basis. That is, how to mix cookies and API authentication:

 <!-- REVIEW, missing If set in public Func<HttpContext, string> ForwardDefaultSelector -->

[!code-csharp[sample](policyschemes/samples/Startup.cs?name=snippet2)]
