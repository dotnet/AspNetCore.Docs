---
title: Authentication samples for ASP.NET Core
author: rick-anderson
description: Provides links to the authentication samples in the ASP.NET Core repository.
ms.author: riande
ms.date: 02/21/2021
uid: security/authentication/samples
---
# Authentication samples for ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The [ASP.NET Core repository](https://github.com/dotnet/aspnetcore) contains the following authentication samples (`main` branch):

* [Claims transformation](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/ClaimsTransformation)
* [Cookie authentication](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/Cookies)
* [Custom authorization failure response](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/CustomAuthorizationFailureResponse)
* [Custom policy provider - IAuthorizationPolicyProvider](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/CustomPolicyProvider)
* [Dynamic authentication schemes and options](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/DynamicSchemes)
* [External claims](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/Identity.ExternalClaims)
* [Selecting between cookie and another authentication scheme based on the request](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/PathSchemeSelection)
* [Restricts access to static files](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/StaticFilesAuth)

## Obtain and run the samples

The sample links provided in this article provide samples for the upcoming release of ASP.NET Core. To obtain a sample for the current release or a prior release, perform the following steps:

* Select the release branch of the [ASP.NET Core repository](https://github.com/dotnet/aspnetcore). For example, the `release/5.0` branch contains the samples for the ASP.NET Core 5.0 release.
* Clone or download the ASP.NET Core repository.
* On your local system, verify installation of the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) version matching the clone of the ASP.NET Core repository.
* Navigate to a sample in `aspnetcore/src/Security/samples` folder and run the sample with the [`dotnet run` command](/dotnet/core/tools/dotnet-run).
