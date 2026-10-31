---
title: Facebook, Google, and external provider authentication without ASP.NET Core Identity
ai-usage: ai-assisted
description: Use Facebook, Google, Twitter, etc. account user authentication without ASP.NET Core Identity.
monikerRange: '>= aspnetcore-3.1'
ms.date: 04/09/2026
---
# Use social sign-in provider authentication without ASP.NET Core Identity

By [Kirk Larkin](https://twitter.com/serpent5) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

[Using external login providers with Identity in ASP.NET Core](index.md) describes how to enable users to sign in using OAuth 2.0 with credentials from external authentication providers. The approach described in that article includes ASP.NET Core Identity as an authentication provider.

This sample demonstrates how to use an external authentication provider **without** ASP.NET Core Identity. This approach is useful for apps that don't require all of the features of ASP.NET Core Identity, but still require integration with a trusted external authentication provider.

This sample uses [Google authentication](google-logins.md) for authenticating users. Using Google authentication shifts many of the complexities of managing the sign-in process to Google. To integrate with a different external authentication provider, see the following articles:

* [Facebook authentication](facebook-logins.md)
* [Microsoft authentication](microsoft-logins.md)
* [Twitter authentication](twitter-logins.md)
* [Other providers](other-logins.md)

## Configuration

In `Program.cs`, configure the app's authentication schemes with the <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*>, <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*>, and <xref:Microsoft.Extensions.DependencyInjection.GoogleExtensions.AddGoogle*> methods:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Program.cs" id="snippet_AddAuthentication":::

The call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> sets the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultScheme>. The `DefaultScheme` is the default scheme used by the following `HttpContext` authentication extension methods:

* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync*>

Setting the app's `DefaultScheme` to <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Cookies") configures the app to use Cookies as the default scheme for these extension methods. Setting the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultChallengeScheme> to `Google.Apis.Auth.AspNetCore3.GoogleOpenIdConnectDefaults.AuthenticationScheme` ("`GoogleOpenIdConnect`") configures the app to use Google as the default scheme for calls to `ChallengeAsync`. `DefaultChallengeScheme` overrides `DefaultScheme`. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions> for more properties that override `DefaultScheme` when set.

In `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization*>. This middleware combination sets the <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> property and runs the authorization middleware for requests:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Program.cs" id="snippet_UseAuthentication" highlight="4-5":::

To learn more about authentication schemes, see [Authentication Concepts](../index.md#authentication-concepts). To learn more about cookie authentication, see [Use cookie authentication without ASP.NET Core Identity](../cookie.md).

## Apply authorization

Test the app's authentication configuration by applying the [[Authorize]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to a controller, action, or page. The following code limits access to the *Privacy* page to users that have been authenticated:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Pages/Privacy.cshtml.cs" id="snippet_Class" highlight="1":::

## Save the access token

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens> defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties> after a successful authorization. `SaveTokens` is set to `false` by default to reduce the size of the final authentication cookie.

To save access and refresh tokens after a successful authorization, set `SaveTokens` to `true` in `Program.cs`:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Snippets/Program.cs" id="snippet_SaveTokens" highlight="12":::

To retrieve a saved token, use <xref:Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokenAsync*>. The following example retrieves the token named `access_token`:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Snippets/Pages/Privacy.cshtml.cs" id="snippet_OnGetAsync" highlight="3-4":::

## Sign out

To sign out the current user and delete their cookie, call <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync*>. The following code adds a `Logout` page handler to the *Index* page:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Pages/Index.cshtml.cs" id="snippet_Class":::

Notice that the call to `SignOutAsync` doesn't specify an authentication scheme. The app uses the `DefaultScheme`, `CookieAuthenticationDefaults.AuthenticationScheme`, as a fallback.

## Additional resources

* [Simple authorization in ASP.NET Core](../../authorization/simple.md)
* [Persist additional claims and tokens from external providers in ASP.NET Core](additional-claims.md)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[Using external login providers with Identity in ASP.NET Core](index.md) describes how to enable users to sign in using OAuth 2.0 with credentials from external authentication providers. The approach described in that article includes ASP.NET Core Identity as an authentication provider.

This sample demonstrates how to use an external authentication provider **without** ASP.NET Core Identity. This approach is useful for apps that don't require all of the features of ASP.NET Core Identity, but still require integration with a trusted external authentication provider.

This sample uses [Google authentication](google-logins.md) for authenticating users. Using Google authentication shifts many of the complexities of managing the sign-in process to Google. To integrate with a different external authentication provider, see the following articles:

* [Facebook authentication](facebook-logins.md)
* [Microsoft authentication](microsoft-logins.md)
* [Twitter authentication](twitter-logins.md)
* [Other providers](other-logins.md)

## Configuration

In the `ConfigureServices` method, configure the app's authentication schemes with the <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*>, <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*>, and <xref:Microsoft.Extensions.DependencyInjection.GoogleExtensions.AddGoogle*> methods:

:::code language="csharp" source="social-without-identity/samples/snapshot/3.x/Startup.cs" id="snippet_ConfigureServices":::

The call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> sets the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultScheme>. The `DefaultScheme` is the default scheme used by the following `HttpContext` authentication extension methods:

* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync*>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync*>

Setting the app's `DefaultScheme` to <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Cookies") configures the app to use Cookies as the default scheme for these extension methods. Setting the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultChallengeScheme> to <xref:Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Google") configures the app to use Google as the default scheme for calls to `ChallengeAsync`. `DefaultChallengeScheme` overrides `DefaultScheme`. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions> for more properties that override `DefaultScheme` when set.

In `Startup.Configure`, call <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization*> between calling <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting*> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints*>. This middleware combination sets the <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> property and runs the authorization middleware for requests:

:::code language="csharp" source="social-without-identity/samples/snapshot/3.x/Startup.cs" id="snippet_UseAuthentication" highlight="3-4":::

To learn more about authentication schemes, see [Authentication Concepts](../index.md#authentication-concepts). To learn more about cookie authentication, see [Use cookie authentication without ASP.NET Core Identity](../cookie.md).

## Apply authorization

Test the app's authentication configuration by applying the [[Authorize]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to a controller, action, or page. The following code limits access to the *Privacy* page to users that have been authenticated:

:::code language="csharp" source="social-without-identity/samples/snapshot/3.x/Pages/Privacy.cshtml.cs" id="snippet_Class" highlight="1":::

## Sign out

To sign out the current user and delete their cookie, call <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync*>. The following code adds a `Logout` page handler to the *Index* page:

:::code language="csharp" source="social-without-identity/samples/snapshot/3.x/Pages/Index.cshtml.cs" id="snippet_Class" highlight="3-7":::

Notice that the call to `SignOutAsync` doesn't specify an authentication scheme. The app's `DefaultScheme` of `CookieAuthenticationDefaults.AuthenticationScheme` is used as a fallback.

## Additional resources

* [Simple authorization in ASP.NET Core](../../authorization/simple.md)
* [Persist additional claims and tokens from external providers in ASP.NET Core](additional-claims.md)

:::moniker-end
