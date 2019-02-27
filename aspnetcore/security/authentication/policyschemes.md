---
title: Policy schemes in ASP.NET Core
author: rick-anderson
description: Authentication policy schemes make it easier to have a single logical authentication scheme
ms.author: riande
ms.date: 2/28/2019
uid: security/authentication/policyschemes
---

# Policy schemes in ASP.NET Core

Authentication policy schemes make it easier to have a single logical authentication scheme potentially use multiple approaches. For example, a policy scheme might use Google for challenges, and Cookie for everything else. Authentication policy schemes make it:

* Easy to forward any authentication action to another scheme.
* Forward dynamically based on the request.

All authentication schemes that use derived <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions?displayProperty=fullName> and the associated <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler<TOptions>:

* Are automatically policy schemes in ASP.NET Core 2.1 and later.
* The authentication policy schemes can be enabled via configuring the scheme's options.

[!code-csharp[sample](policyschemes/samples/AuthenticationSchemeOptions.cs?name=snippet)]

## Examples
* A higher level scheme that combines lower level schemes, where Google is used for challenges, and Cookie is used for everything else.

[!code-csharp[sample](policyschemes/samples/Startup.cs?name=snippet1)]

* Enables dynamic selection of schemes on a per request basis (i.e. how to mix cookies and api authentication)

[!code-csharp[sample](policyschemes/samples/Startup.cs?name=snippet1)]
