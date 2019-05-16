---
title: Facebook, Google, and external provider authentication without ASP.NET Core Identity
author: rick-anderson
description: An explanation of using Facebook, Google, Twitter, etc. account user authentication without ASP.NET Core Identity.
ms.author: riande
ms.date: 05/11/2019
uid: security/authentication/social/social-without-identity
---
# Use social sign-in provider authentication without ASP.NET Core Identity

This sample provides the minimum code required to use [social authentication](xref:security/authentication/social/index) with an ASP.NET Core web app. This is not a complete sample, it doesn't contain:

* Sign-in and sign-out UI
* Other UI expected in an an authenticated web app.

## Update template generated code

The sample app is created with the following command:

```cli
dotnet new webapp -o WebApp1
```

## Update Startup

Update `ConfigureServices` with the following code:

[!code-csharp[](social-without-identity/sample/Startup.cs?name=snippet1)]

The preceding code:

* Sets the default authentication scheme to cookie authentication.
* Sets the default challenge scheme to Google authentication.
* Gets the Google client ID and client secret from [Secret Manager](xref:security/app-secrets).

### Update Configure

Enable authentication in `Configure`:

[!code-csharp[](social-without-identity/sample/Startup.cs?name=snippet2&highlight=17)]

## Update the Index and Privacy pages

[!code-csharp[](social-without-identity/sample/Pages/Index.cshtml.cs?highlight=10-16)]

[!code-csharp[](social-without-identity/sample/Pages/Index.cshtml.cs?highlight=18-22)]

[!code-csharp[](social-without-identity/sample/Pages/Privacy.cshtml.cs?highlight=6)]
