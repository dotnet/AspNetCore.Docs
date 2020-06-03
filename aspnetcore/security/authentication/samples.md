---
title: Authentication samples for ASP.NET Core
author: rick-anderson
description: Provides links to the authentication samples in the ASP.NET Core repository.
ms.author: riande
ms.date: 01/31/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/samples
---
# Authentication samples for ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range=">= aspnetcore-3.0"

The [ASP.NET Core repository](https://github.com/dotnet/AspNetCore) contains the following authentication samples in the *AspNetCore/src/Security/samples* folder:

* [Claims transformation](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/ClaimsTransformation)
* [Cookie authentication](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/Cookies)
* [Custom policy provider - IAuthorizationPolicyProvider](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/CustomPolicyProvider)
* [Dynamic authentication schemes and options](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/DynamicSchemes)
* [External claims](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/Identity.ExternalClaims)
* [Selecting between cookie and another authentication scheme based on the request](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/PathSchemeSelection)
* [Restricts access to static files](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/StaticFilesAuth)

## Run the samples

* Select a [branch](https://github.com/dotnet/AspNetCore). For example, `release/3.1`
* Clone or download the [ASP.NET Core repository](https://github.com/dotnet/AspNetCore).
* Verify you have installed the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) version matching the clone of the ASP.NET Core repository.
* Navigate to a sample in *AspNetCore/src/Security/samples* and run the sample with `dotnet run`.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

The [ASP.NET Core repository](https://github.com/dotnet/AspNetCore) contains the following authentication samples in the *AspNetCore/src/Security/samples* folder:

* [Claims transformation](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/ClaimsTransformation)
* [Cookie authentication](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/Cookies)
* [Custom policy provider - IAuthorizationPolicyProvider](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/CustomPolicyProvider)
* [Dynamic authentication schemes and options](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/DynamicSchemes)
* [External claims](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/Identity.ExternalClaims)
* [Selecting between cookie and another authentication scheme based on the request](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/PathSchemeSelection)
* [Restricts access to static files](https://github.com/dotnet/AspNetCore/tree/release/2.2/src/Security/samples/StaticFilesAuth)

## Run the samples

* Select a [branch](https://github.com/dotnet/AspNetCore). For example, `release/2.2`
* Clone or download the [ASP.NET Core repository](https://github.com/dotnet/AspNetCore).
* Verify you have installed the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) version matching the clone of the ASP.NET Core repository.
* Navigate to a sample in *AspNetCore/src/Security/samples* and run the sample with `dotnet run`.

::: moniker-end
