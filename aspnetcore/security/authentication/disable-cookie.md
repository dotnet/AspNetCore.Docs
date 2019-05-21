---
title: Disable automatic cookie authentication in ASP.NET Core
author: John0King
description: Disable automatic cookie authentication in ASP.NET Core
ms.author: riande
ms.date: 5/22/2019
uid: security/authentication/disable-cookie
---
# Disable automatic cookie authentication in ASP.NET Core

By [John King](https://github.com/John0King) and 

The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) specifies that access to a controller or action method is restricted to users who meet the authorization requirement. When the user is not authenticated or doesn't have access to the controller or action method:

* An automatic challenge is issued, redirecting the user to the sign-in page.

This approach works well when using ASP.NET Controllers with views or Razor Pages, but not when using [AJAX](https://developer.mozilla.org/en-US/docs/Web/Guide/AJAX). This document shows several approaches to take when a HTTP StatusCode 401 response is required for unauthenticated/unauthorized requests.

Use one of the following approaches to disable automatic cookie authentication:

* Send an HTTP header or query string called `X-Requested-With` with a value of `XMLHttpRequest`
* Handle the various `CookieAuthenticationEvents` methods to do a custom check for whether it's an AJAX request.

## Send an HTTP header or query string called `X-Requested-With`

The following code sends an HTTP header with name `X-Requested-With` and value `XMLHttpRequest`:

[!code-javascript[ajax-raw.js](disable-cookie/samples/CookieAjax/wwwroot/js/ajax-raw.js)]

The following code sends query string with name `X-Requested-With` and value `XMLHttpRequest`:

[!code-javascript[ajax-raw.js](disable-cookie/samples/CookieAjax/wwwroot/js/ajax-raw.js-qs)]

The following code uses jQuery to send an HTTP header with name `X-Requested-With` and value `XMLHttpRequest`:

[!code-javascript[ajax-jquery.js](disable-cookie/samples/CookieAjax/wwwroot/js/ajax-jquery.js)]

The jQuery `$.ajax()` call will adds the `X-Requested-With:XMLHttpRequest` header.

### Configure  `CookieAuthenticationEvents` to do a custom check

#### [configure cookie](#tab/tabid-cs1)

[!code-csharp[Startup.cs](disable-cookie/samples/CookieAjax/Startup.cs?name=DisableCookie)]

> [!NOTE]
> the default check on `CookieAuthenticationEvents.OnRedirectToLogin`, `CookieAuthenticationEvents.OnRedirectToAccessDenied`,
> `CookieAuthenticationEvents.OnRedirectToLogout`, `CookieAuthenticationEvents.OnRedirectToReturnUrl` is to check the `X-Requested-With` from `Request.Header` or `Request.Query`, that why the first way work.

***
