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

In multiple authentication scheme scenario(for example as `[Authorize(AuthenticationSchemes ="Cookies,JwtBeare")]`) or an partial page that allow both browser  and `ajax` visit , you may want to disable automatic challenge of `Cookies` authentication scheme and return HTTP StatusCode `401` instead.

Use one of the following approaches to disable automatic cookie authentication:

* Send an HTTP header or query string called `X-Requested-With` with a value of `XMLHttpRequest`
* Handle the various `CookieAuthenticationEvents` methods to do a custom check for whether it's an AJAX request.

### Send an HTTP header or query string called `X-Requested-With`

```js
// using header
var xhr = new XMLHttpRequest();
xhr.open("GET", "/your-api-url", true);
xhr.setRequestHeader("X-Request-With", "XMLHttpRequest");
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
xhr.open("GET", "/your-api-url?X-Request-With=XMLHttpRequest", true);
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
        "X-Request-With":"XMLHttpRequest"
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

```
