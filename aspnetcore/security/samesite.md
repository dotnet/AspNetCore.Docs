---
title: SameSite
author: rick-anderson
description: Learn how to react to SameSite changes in ASP.NET Core
ms.author: riande
ms.custom: mvc
ms.date: 11/11/2019
uid: security/samesite
---
# React to SameSite changes in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The [SameSite 2016 draft](https://tools.ietf.org/html/draft-west-first-party-cookies-07) states:

  This document updates [RFC6265](https://tools.ietf.org/html/rfc6265) by defining a `SameSite` attribute which allows servers to assert that a cookie ought not to be sent along with cross-site requests. This assertion allows user agents to mitigate the risk of cross-origin information leakage, and provides some protection against cross-site request forgery attacks.

>This document updates [RFC6265](https://tools.ietf.org/html/rfc6265) by defining a `SameSite` attribute which allows servers to assert that a cookie ought not to be sent along with cross-site requests. This assertion allows user agents to mitigate the risk of cross-origin information leakage, and provides some protection against cross-site request forgery attacks.

Firefox and Chrome based browsers are making breaking changes to their implementations of [SameSite](https://tools.ietf.org/html/draft-west-first-party-cookies-07) for cookies. The SameSite changes impact remote authentication scenarios such as:

* [OpenID Connect](https://openid.net/connect/) (OIDC)
* [WS-Federation](https://auth0.com/docs/protocols/ws-fed)
* Other cross domain POST requests which use cookies to correlate or otherwise authorize requests.

With this change, OIDC and WS-Federation must opt out by sending `SameSite=None`. However, setting `SameSite=None` doesn't work on iOS 12 and some older versions of other browsers. To support iOS 12 and older browsers, ASP.NET Core app's must detect these browsers and omit `SameSite`.

## SameSite 2016 draft standard

The [SameSite 2016 draft](https://tools.ietf.org/html/draft-west-first-party-cookies-07#section-4.1) extension to HTTP cookies:

* Was intended to mitigate cross site request forgery (CSRF).
* Was designed as a feature servers would opt into by adding the new "SameSite" attribute and attribute values to cookies.
* Is supported in ASP.NET 2.0 and later.

## New SameSite 2019 draft standard

The new [SameSite 2019 draft](https://tools.ietf.org/html/draft-west-cookie-incrementalism-00):

* Is not backwards compatible.
* Cookies are treated as `SameSite=Lax` by default.
* Cookies that explicitly assert `SameSite=None` in order to enable cross-site delivery should be marked as `Secure`. `None` is a new entry to opt out.

`Lax` is OK for most application cookies but breaks cross site scenarios like OIDC and Ws-Federation login. Most [OAuth](https://oauth.net/) logins are not affected due to differences in how the request flows. The new `None` parameter causes compatibility problems with clients that implemented the prior draft standard (for example, iOS 12). Chrome browsers (Chrome 80) are expected to go live in February 2020 confirming to the 2019 SameSite draft standard.

Each ASP.NET Core component that emits cookies needs to decide if `SameSite` is appropriate.

::: moniker range="= aspnetcore-3.1"
ASP.NET Core 3.1 and later provides the following SameSite support:

* Redefines the behavior of `SameSiteMode.None` to emit `SameSite=None`
* Adds a new value `SameSiteMode.Unspecified` to omit the `SameSite` attribute.
* All cookies APIs default to `Unspecified`. Some components that use cookies set values more specific to their scenarios, for example
  * The `OpenIdConnect` correlation cookie.
  * [OpenIdConnectOptions.NonceCookie](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.NonceCookie)

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

ASP.NET Core 3.0 and later aligns SameSite defaults with the new draft standard. The following APIs have changed the default from `SameSiteMode.Lax ` to `SameSiteMode.None`:

* <xref:Microsoft.AspNetCore.Http.CookieOptions> used with [HttpContext.Response.Cookies.Append](xref:Microsoft.AspNetCore.Http.IResponseCookies.Append*)
* <xref:Microsoft.AspNetCore.Http.CookieBuilder>  used as a factory for `CookieOptions`
* [CookiePolicyOptions.MinimumSameSitePolicy](xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions.MinimumSameSitePolicy)

ALL ASP.NET Core components that emit cookies:

* Override the preceding defaults with settings appropriate for their scenarios. The overridden preceding default values have not changed.

| Component | cookie | Default |
| ------------- | ------------- |
| <xref:System.Web.HttpContext.Session>  | [SessionOptions.Cookie](xref:Microsoft.AspNetCore.Builder.SessionOptions.Cookie) |`Lax` |
| <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>  | [CookieTempDataProviderOptions.Cookie](xref:Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions.Cookie) | `Lax` |
| <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> | [AntiforgeryOptions.Cookie](xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie)| `Strict` |
| [CookieExtensions.AddCookie](xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*) | [CookieAuthenticationOptions.Cookie](xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions.CookieName) | `Lax` |
| <xref:Microsoft.Extensions.DependencyInjection.TwitterExtensions.AddTwitter*> | [TwitterOptions.StateCookie ](xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterOptions.StateCookie) | `Lax`  |
| <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler`1> | [RemoteAuthenticationOptions.CorrelationCookie](xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.CorrelationCookie)  | `None` |
| <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect*> | [OpenIdConnectOptions.NonceCookie](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.NonceCookie)| `None` |
::: moniker-end

## Test apps for SameSite problems

Apps that interact with remote sites such as through 3rd party login need to:

* Test the interaction on multiple browsers.
* Apply the [CookiePolicy browser detection and mitigation](#sob) discussed in this document.

Test web apps using a client version that can opt-in to the new SameSite behavior. Chrome, Firefox, and Chromium Edge all have new opt-in feature flags that can be used for testing. After your app applies the SameSite patches, test it with older client versions, especially Safari. For more information, see [Supporting older browsers](#sob) in this document.

### Test with Chrome

Chrome 78+ gives misleading results because it has a temporary mitigation in place. The Chrome 78+ temporary mitigation allows cookies less than two minutes old. Chrome 76 or 77 with the appropriate test flags enabled provides more accurate results. To test the new SameSite behavior toggle `chrome://flags/#same-site-by-default-cookies` to **Enabled**. Older versions of Chrome (75 and below) are reported to fail with the new `None` setting. See [Supporting older browsers](#sob) in this document.

Google does not make older chrome versions available. Follow the instructions at [Download Chromium](https://www.chromium.org/getting-involved/download-chromium) to test older versions of Chrome. Do **not** download Chrome from from links provided by searching for older versions of chrome.

* [Chromium 76 Win64](https://commondatastorage.googleapis.com/chromium-browser-snapshots/index.html?prefix=Win_x64/664998/)
* [Chromium 74 Win64](https://commondatastorage.googleapis.com/chromium-browser-snapshots/index.html?prefix=Win_x64/638880/)

### Test with Safari

Safari 12 strictly implemented the prior draft and fails when the new `None` value is in a cookie. `None` is avoided via the browser detection code [Supporting older browsers](#sob) in this document. Test Safari 12, Safari 13, and WebKit based OS style logins using MSAL, ADAL or whatever library you are using. The problem is dependent on the underlying OS version. OSX Mojave (10.14) and iOS 12 are known to have compatibility problems with the new SameSite behavior. Upgrading the OS to OSX Catalina (10.15) or iOS 13 fixes the problem. Safari does not currently have an opt-in flag for testing the new spec behavior.

### Test with Firefox

Firefox support for the new standard can be tested on version 68+ by opting in on the `about:config` page with the feature flag `network.cookie.sameSite.laxByDefault`. There haven't been reports of compatibility issues with older versions of Firefox.

### Test with Edge browser

Edge supports the old SameSite standard. Edge version 44 doesn't have any known compatibility problems with the new standard.

### Test with Edge (Chromium)

SameSite flags are set on the `edge://flags/#same-site-by-default-cookies` page. No compatibility issues were discovered with Edge Chromium.
<!--  No compatibility issues were observed when testing with Edge Chromium 78. Current version is 79 and soon that will change - So I dropped version #  -->

### Test with Electron

Versions of Electron include older versions of Chromium. For example the version of Electron used by Teams is Chromium 66 which exhibits the older behavior. You must perform your own compatibility testing with the version of Electron your product uses. See [Supporting older browsers](#sob) in the following section.

<a name="sob"></a>

## Supporting older browsers

The 2016 SameSite standard mandated that unknown values must be treated as `SameSite=Strict` values. Older browsers which support the 2016 SameSite standard may break when they see a SameSite property with a value of `None`. Web apps must implement browser detection if they intend to support older browsers. ASP.NET Core doesn't implement browser detection because User-Agents values are highly volatile and change frequently. An extension point in <xref:Microsoft.AspNetCore.CookiePolicy> allows plugging in User-Agent specific logic.

In `Startup.Configure`, add code that calls <xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy*> before calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*> or *any* method that writes cookies:

[!code-csharp[](samesite/sample/Startup.cs?name=snippet5&highlight=18-19)]

In `Startup.ConfigureServices`, add code similar to the following:

::: moniker range="= aspnetcore-3.1"

[!code-csharp[](samesite/sample/Startup31.cs?name=snippet)]

::: moniker-end

::: moniker range="< aspnetcore-3.1"

[!code-csharp[](samesite/sample/Startup.cs?name=snippet)]

::: moniker-end

In the preceding sample, `MyUserAgentDetectionLib.DisallowsSameSiteNone` is a user supplied library that detects if the user agent doesn't support SameSite `None`:

[!code-csharp[](samesite/sample/Startup31.cs?name=snippet2)]

The following code shows a sample `DisallowsSameSiteNone` method:

> [!WARNING]
> The following code is for demonstration only:
> * It should not be considered complete.
> * It is not maintained or supported.

[!code-csharp[](samesite/sample/Startup31.cs?name=snippetX)]

## APIs impacted by the new SameSite 2019 draft standard

* [Http.SameSiteMode](xref:Microsoft.AspNetCore.Http.SameSiteMode)
* [CookieOptions.SameSite](xref:Microsoft.AspNetCore.Http.CookieOptions.SameSite)
* [CookieBuilder.SameSite](xref:Microsoft.AspNetCore.Http.CookieBuilder.SameSite)
* [CookiePolicyOptions.MinimumSameSitePolicy](xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions.MinimumSameSitePolicy)
* <xref:Microsoft.Net.Http.Headers.SameSiteMode?displayProperty=fullName>
* <xref:Microsoft.Net.Http.Headers.SetCookieHeaderValue.SameSite?displayProperty=fullName>