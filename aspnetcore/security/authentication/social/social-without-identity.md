---
title: Facebook, Google, and external provider authentication without ASP.NET Core Identity
author: rick-anderson
description: An explanation of using Facebook, Google, Twitter, etc. account user authentication without ASP.NET Core Identity.
ms.author: riande
ms.date: 05/11/2019
uid: security/authentication/social/social-without-identity
---
# Use social sign-in provider authentication without ASP.NET Core Identity

<xref:security/authentication/social/index> describes how to set up an ASP.NET Core app to enable users to sign in using OAuth 2.0 with credentials from external authentication providers. The approach described in that topic uses ASP.NET Core Identity as a full-featured authentication provider.

This sample demonstrates how to use an external authentication provider without ASP.NET Core Identity. This is useful for apps that do not require all of the features of ASP.NET Core Identity, but still require integration with a trusted external authentication provider.

This sample uses [Google authentication](xref:security/authentication/google-logins) for authenticating users, shifting many of the complexities of managing the sign-in process over to Google. To integrate with a different external authentication provider, see the following topics:

* [Facebook authentication](xref:security/authentication/facebook-logins)
* [Microsoft authentication](xref:security/authentication/microsoft-logins)
* [Twitter authentication](xref:security/authentication/twitter-logins)
* [Other providers](xref:security/authentication/otherlogins)

<!--
TODO: Should we call out that the instructions in the linked topics all use Identity?
-->

## Configuration

In the `ConfigureServices` method, configure the app's authentication schemes with the `AddAuthentication`, `AddCookie` and `AddGoogle` methods:

[!code-csharp[](social-without-identity/sample/Startup.cs?name=snippet1)]

<!--
TODO: Rework the following explanation to detail more about DefaultScheme, DefaultChallengeScheme and the fallback mechanism.
-->

The preceding code:

* Sets the default authentication scheme to cookie authentication.
* Sets the default challenge scheme to Google authentication.
* Gets the Google client ID and client secret from [Secret Manager](xref:security/app-secrets).

In the `Configure` method, call the `UseAuthentication` method to invoke the Authentication Middleware that sets the `HttpContext.User` property. Call the `UseAuthentication` method before calling `UseMvcWithDefaultRoute` or `UseMvc`:

[!code-csharp[](social-without-identity/sample/Startup.cs?name=snippet2)]

To learn more about authentication schemes and cookie authentication, see <xref:security/authentication/cookie>.

## Applying simple authorization

Test the app's authentication configuration by applying the `AuthorizeAttribute` attribute to a controller, action or page. The following code limits access to the *Privacy* page to any user that has been authenticated using Google:

[!code-csharp[](social-without-identity/sample/Pages/Privacy.cshtml.cs?name=snippet&highlight=1)]

## Sign out

To sign out the current user and delete their cookie, call [SignOutAsync](/dotnet/api/microsoft.aspnetcore.authentication.authenticationhttpcontextextensions.signoutasync?view=aspnetcore-2.0). The following code adds a `Logout` page handler to the *Index* page:

[!code-csharp[](social-without-identity/sample/Pages/Index.cshtml.cs?name=snippet&highlight=7-11)]

Notice that the call to `SignOutAsync` does not specify an authentication scheme. The app's `DefaultScheme` of `CookieAuthenticationDefaults.AuthenticationScheme` is used as a fall back.

## Additional resources

* <xref:security/authorization/simple>
* <xref:security/authentication/social/additional-claims>
