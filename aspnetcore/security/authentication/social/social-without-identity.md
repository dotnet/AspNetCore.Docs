---
title: Facebook, Google, and external provider authentication without ASP.NET Core Identity
author: rick-anderson
description: An explanation of using Facebook, Google, Twitter, etc. account user authentication without ASP.NET Core Identity.
ms.author: riande
ms.date: 05/11/2019
uid: security/authentication/social/social-without-identity
---
# Use social sign-in provider authentication without ASP.NET Core Identity

<xref:security/authentication/social/index> describes how to set up an ASP.NET Core app to enable users to sign in using OAuth 2.0 with credentials from external authentication providers. The described approach uses ASP.NET Core Identity as a full-featured authentication provider.

This tutorial demonstrates how to use an external authentication provider without ASP.NET Core Identity. This is useful for apps that do not require all of the features of ASP.NET Core Identity, but still require integration with a trusted external authentication provider.

This tutorial uses [Google authentication](xref:security/authentication/google-logins) for authenticating users, shifting many of the complexities of managing the sign-in process over to Google. To integrate with a different external authentication provider, see the following:

* [Facebook authentication](xref:security/authentication/facebook-logins)
* [Microsoft authentication](xref:security/authentication/microsoft-logins)
* [Twitter authentication](xref:security/authentication/twitter-logins)
* [Other providers](xref:security/authentication/otherlogins)

<!--
TODO: Call out that the instructions use Identity?
-->

<!--
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

[!code-csharp[](social-without-identity/sample/Pages/Index.cshtml.cs?name=snippet&highlight=7-11)]

[!code-csharp[](social-without-identity/sample/Pages/Privacy.cshtml.cs?name=snippet&highlight=1)]
-->
