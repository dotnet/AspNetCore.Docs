---
title: Facebook, Google, and external provider authentication without ASP.NET Core Identity
author: serpent5
description: Use Facebook, Google, Twitter, etc. account user authentication without ASP.NET Core Identity.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 04/05/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/social/social-without-identity
---
# Use social sign-in provider authentication without ASP.NET Core Identity

By [Kirk Larkin](https://twitter.com/serpent5) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

<xref:security/authentication/social/index> describes how to enable users to sign in using OAuth 2.0 with credentials from external authentication providers. The approach described in that article includes ASP.NET Core Identity as an authentication provider.

This sample demonstrates how to use an external authentication provider **without** ASP.NET Core Identity. This approach is useful for apps that don't require all of the features of ASP.NET Core Identity, but still require integration with a trusted external authentication provider.

This sample uses [Google authentication](xref:security/authentication/google-logins) for authenticating users. Using Google authentication shifts many of the complexities of managing the sign-in process to Google. To integrate with a different external authentication provider, see the following articles:

* [Facebook authentication](xref:security/authentication/facebook-logins)
* [Microsoft authentication](xref:security/authentication/microsoft-logins)
* [Twitter authentication](xref:security/authentication/twitter-logins)
* [Other providers](xref:security/authentication/otherlogins)

## Configuration

In `Program.cs`, configure the app's authentication schemes with the <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>, <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie%2A>, and <xref:Microsoft.Extensions.DependencyInjection.GoogleExtensions.AddGoogle%2A> methods:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Program.cs" id="snippet_AddAuthentication":::

The call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> sets the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultScheme>. The `DefaultScheme` is the default scheme used by the following `HttpContext` authentication extension methods:

* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync%2A>

Setting the app's `DefaultScheme` to <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Cookies") configures the app to use Cookies as the default scheme for these extension methods. Setting the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultChallengeScheme> to <xref:Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Google") configures the app to use Google as the default scheme for calls to `ChallengeAsync`. `DefaultChallengeScheme` overrides `DefaultScheme`. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions> for more properties that override `DefaultScheme` when set.

In `Program.cs`, call <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. This middleware combination sets the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property and runs the Authorization Middleware for requests:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Program.cs" id="snippet_UseAuthentication" highlight="4-5":::

To learn more about authentication schemes, see [Authentication Concepts](xref:security/authentication/index#authentication-concepts). To learn more about cookie authentication, see <xref:security/authentication/cookie>.

## Apply authorization

Test the app's authentication configuration by applying the [[Authorize]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to a controller, action, or page. The following code limits access to the *Privacy* page to users that have been authenticated:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Pages/Privacy.cshtml.cs" id="snippet_Class" highlight="1":::

## Save the access token

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens%2A> defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties> after a successful authorization. `SaveTokens` is set to `false` by default to reduce the size of the final authentication cookie.

To save access and refresh tokens after a successful authorization, set `SaveTokens` to `true` in `Program.cs`:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Snippets/Program.cs" id="snippet_SaveTokens" highlight="12":::

To retrieve a saved token, use <xref:Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokenAsync%2A>. The following example retrieves the token named `access_token`:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Snippets/Pages/Privacy.cshtml.cs" id="snippet_OnGetAsync" highlight="3-4":::

## Sign out

To sign out the current user and delete their cookie, call <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync%2A>. The following code adds a `Logout` page handler to the *Index* page:

:::code language="csharp" source="social-without-identity/samples/6.x/SocialWithoutIdentitySample/Pages/Index.cshtml.cs" id="snippet_Class":::

Notice that the call to `SignOutAsync` doesn't specify an authentication scheme. The app uses the `DefaultScheme`, `CookieAuthenticationDefaults.AuthenticationScheme`, as a fallback.

## Additional resources

* <xref:security/authorization/simple>
* <xref:security/authentication/social/additional-claims>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

<xref:security/authentication/social/index> describes how to enable users to sign in using OAuth 2.0 with credentials from external authentication providers. The approach described in that article includes ASP.NET Core Identity as an authentication provider.

This sample demonstrates how to use an external authentication provider **without** ASP.NET Core Identity. This approach is useful for apps that don't require all of the features of ASP.NET Core Identity, but still require integration with a trusted external authentication provider.

This sample uses [Google authentication](xref:security/authentication/google-logins) for authenticating users. Using Google authentication shifts many of the complexities of managing the sign-in process to Google. To integrate with a different external authentication provider, see the following articles:

* [Facebook authentication](xref:security/authentication/facebook-logins)
* [Microsoft authentication](xref:security/authentication/microsoft-logins)
* [Twitter authentication](xref:security/authentication/twitter-logins)
* [Other providers](xref:security/authentication/otherlogins)

## Configuration

In the `ConfigureServices` method, configure the app's authentication schemes with the <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>, <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie%2A>, and <xref:Microsoft.Extensions.DependencyInjection.GoogleExtensions.AddGoogle%2A> methods:

:::code language="csharp" source="social-without-identity/samples_snapshot/3.x/Startup.cs" id="snippet_ConfigureServices":::

The call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> sets the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultScheme>. The `DefaultScheme` is the default scheme used by the following `HttpContext` authentication extension methods:

* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync%2A>
* <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync%2A>

Setting the app's `DefaultScheme` to <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Cookies") configures the app to use Cookies as the default scheme for these extension methods. Setting the app's <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultChallengeScheme> to <xref:Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme?displayProperty=nameWithType> ("Google") configures the app to use Google as the default scheme for calls to `ChallengeAsync`. `DefaultChallengeScheme` overrides `DefaultScheme`. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions> for more properties that override `DefaultScheme` when set.

In `Startup.Configure`, call <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> between calling <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>. This middleware combination sets the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property and runs the Authorization Middleware for requests:

:::code language="csharp" source="social-without-identity/samples_snapshot/3.x/Startup.cs" id="snippet_UseAuthentication" highlight="3-4":::

To learn more about authentication schemes, see [Authentication Concepts](xref:security/authentication/index#authentication-concepts). To learn more about cookie authentication, see <xref:security/authentication/cookie>.

## Apply authorization

Test the app's authentication configuration by applying the [[Authorize]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to a controller, action, or page. The following code limits access to the *Privacy* page to users that have been authenticated:

:::code language="csharp" source="social-without-identity/samples_snapshot/3.x/Pages/Privacy.cshtml.cs" id="snippet_Class" highlight="1":::

## Sign out

To sign out the current user and delete their cookie, call <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync%2A>. The following code adds a `Logout` page handler to the *Index* page:

:::code language="csharp" source="social-without-identity/samples_snapshot/3.x/Pages/Index.cshtml.cs" id="snippet_Class" highlight="3-7":::

Notice that the call to `SignOutAsync` doesn't specify an authentication scheme. The app's `DefaultScheme` of `CookieAuthenticationDefaults.AuthenticationScheme` is used as a fallback.

## Additional resources

* <xref:security/authorization/simple>
* <xref:security/authentication/social/additional-claims>

:::moniker-end
