---
title: Disable automatic cookie authentication in ASP.NET Core
author: John0King
description: Disable automatic cookie authentication in ASP.NET Core
ms.author: riande
ms.date: 5/22/2019
uid: security/authentication/disable-cookie
---
# Disable automatic cookie authentication in ASP.NET Core

By [John King](https://github.com/John0King)

The `[Authorize]` Attribute will automatic challenge the current authentication scheme, and it's great for browser to direct visit, but it doesn't work well with `ajax`, you need to know the server is not authenticated or not authorized and show login or error message use javascript, in this scenario  you may want to disable automatic challenge of `Cookies` authentication scheme and return HTTP StatusCode `401` instead when it's an `ajax` call.

Use one of the following approaches to disable automatic cookie authentication:

* Send an HTTP header or query string called `X-Requested-With` with a value of `XMLHttpRequest`
* Handle the various `CookieAuthenticationEvents` methods to do a custom check for whether it's an AJAX request.

### Send an HTTP header or query string called `X-Requested-With`

#### [using raw ajax](#tab/tabid-1)

[!code-javascript[ajax-raw.js](disable-cookie/samples/CookieAjax/wwwroot/js/ajax-raw.js)]

#### [using jquery ajax](#tab/tabid-2)

[!code-javascript[ajax-jquery.js](disable-cookie/samples/CookieAjax/wwwroot/js/ajax-jquery.js)]

> [!NOTE]
> jquery's `$.ajax()` will automatic add `X-Requested-With:XMLHttpRequest` header

***

### Configure  `CookieAuthenticationEvents` to do a custom check

#### [configure cookie](#tab/tabid-cs1)

[!code-csharp[Startup.cs](disable-cookie/samples/CookieAjax/Startup.cs?name=DisableCookie)]

> [!NOTE]
> the default check on `CookieAuthenticationEvents.OnRedirectToLogin`, `CookieAuthenticationEvents.OnRedirectToAccessDenied`,
> `CookieAuthenticationEvents.OnRedirectToLogout`, `CookieAuthenticationEvents.OnRedirectToReturnUrl` is to check the `X-Requested-With` from `Request.Header` or `Request.Query`, that why the first way work.

***
