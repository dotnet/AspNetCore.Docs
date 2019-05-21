---
title: Disable automatic cookie authentication in ASP.NET Core
author: John0King
description: Disable automatic cookie authentication in ASP.NET Core
ms.author: riande
ms.date: 5/22/2019
uid: security/authentication/disable-cookie
---
# Disable automatic cookie authentication in ASP.NET Core

By [John King](https://github.com/John0King) and [Rick Anderson](https://twitter.com/RickAndMSFT)

The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) specifies that access to a controller or action method is restricted to users who meet the authorization requirement. When the user is not authenticated or doesn't have access to the controller or action method:

* An automatic challenge is issued, redirecting the user to the sign-in page.

This approach works well when using ASP.NET Controllers with views or Razor Pages, but not when using [AJAX](https://developer.mozilla.org/en-US/docs/Web/Guide/AJAX). This document shows several approaches to take when a HTTP StatusCode 401 response is required for unauthenticated/unauthorized requests.

Use one of the following approaches to disable automatic cookie authentication:

* Send an HTTP header or query string called `X-Requested-With` with a value of `XMLHttpRequest`
* Handle the various <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents> methods to do a custom check for whether it's an AJAX request.

## Send an HTTP header or query string called `X-Requested-With`

The following code sends an HTTP header with name `X-Requested-With` and value `XMLHttpRequest`:

[!code-javascript[ajax-raw.js](disable-cookie/sample/js/ajax-raw.js)]

The following code sends query string with name `X-Requested-With` and value `XMLHttpRequest`:

[!code-javascript[ajax-raw.js](disable-cookie/sample/js/ajax-raw-qs.js)]

The following code uses jQuery to send an HTTP header with name `X-Requested-With` and value `XMLHttpRequest`:

[!code-javascript[ajax-jquery.js](disable-cookie/sample/js/ajax-jquery.js)]

The jQuery `$.ajax()` call will adds the `X-Requested-With:XMLHttpRequest` header.

## Configure CookieAuthenticationEvents to check for AJAX requests

The following code, added to `ConfigureServices`, handles the [CookieAuthenticationEvents.OnRedirectToLogin](xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogin) event and verifies the request is an AJAX request:

[!code-csharp[Startup.cs](disable-cookie/sample/Startup.cs?name=snippet)]

The following <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents> verify the [request is from AJAX](https://github.com/aspnet/AspNetCore/blob/v2.2.5/src/Security/Authentication/Cookies/src/CookieAuthenticationEvents.cs#L103-L107) :

* [CookieAuthenticationEvents.OnRedirectToLogin](xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogin)
* [CookieAuthenticationEvents.OnRedirectToAccessDenied](xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToAccessDenied)
* [CookieAuthenticationEvents.OnRedirectToLogout](xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogout)
* [CookieAuthenticationEvents.OnRedirectToReturnUrl](xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToReturnUrl)