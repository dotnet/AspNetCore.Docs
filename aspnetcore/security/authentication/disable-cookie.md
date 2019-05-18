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

```js
// using header
var xhr = new XMLHttpRequest();
xhr.open("GET", "/your-api-url", true);
xhr.setRequestHeader("X-Requested-With", "XMLHttpRequest");
xhr.onreadystatechange = function () {
    if (xhr.readyState == 4) {
        if (xhr.status == 301) {
            // handle authentication here
        }
        else if (xhr.status >= 200 && xhr.status < 300) {
            // do you business logic here
        }
        else {
            console.error("request fail");
        }
    }
};
// using querystring
var xhr = new XMLHttpRequest();
xhr.open("GET", "/your-api-url?X-Requested-With=XMLHttpRequest", true);
xhr.onreadystatechange = function () {
    if (xhr.readyState == 4) {
        if (xhr.status == 301) {
            // handle authentication here
        }
        else if (xhr.status >= 200 && xhr.status < 300) {
            // do you business logic here
        }
        else {
            console.error("request fail");
        }
    }
};

// using jquery

$.ajax("your-api-url",{
    type:"GET",
    headers:{
        "X-Requested-With":"XMLHttpRequest"
    }
})
    .done(function(result){
    // do your business logic here
    })
    .fail(function(xhr){
       if(xhr.states == 301){
        //handle authentication here
       }
    })
```

### Configure  `CookieAuthenticationEvents` to do a custom check

```C#
services.AddAuthentication()
    .AddCookie(op=>
    {
        op.Events.OnRedirectToLogin = context=>{
            var headers = new Microsoft.AspNetCore.Http.Headers.RequestHeaders(context.Request.Headers);
            // when most browser direct access a url, it's request header will contains  {Accept:text/html;}
            // but ajax call only have {Accept:*/* } by default
            if(!headers.Accept.ToString().Contains("html",StringComparison.OrdinalIgnoreCase))
            {
                // ajax call or some non-browser call
                context.Response.Headers["Location"] = context.RedirectUri;
                context.Response.StatusCode = 401;
            }
            else
            {
                // browse
                context.Response.Redirect(context.RedirectUri);
            }
            return Task.CompletedTask;
        };
});
```

note:  the default check on `CookieAuthenticationEvents.OnRedirectToLogin`, `CookieAuthenticationEvents.OnRedirectToAccessDenied`,
`CookieAuthenticationEvents.OnRedirectToLogout`, `CookieAuthenticationEvents.OnRedirectToReturnUrl` is to check the `X-Requested-With` from `Request.Header` or `Request.Query`, that why the first way work.


