---
title: Client IP safelist for ASP.NET Core web API
author: damienbod
description: Learn how to write Middleware or action filters to validate remote IP addresses.
ms.author: tdykstra
ms.custom: mvc
ms.date: 08/31/2018
uid: security/ip-safelist
---
# Client IP safelist for ASP.NET Core web API

By [Damien Bowden](https://twitter.com/damien_bod) and [Tom Dykstra](https://github.com/tdykstra)
 
This article shows two ways to implement a safelist (also known as a whitelist):

* By using ASP.NET Core middleware to check the remote IP address of every request.
* By using ASP.NET Core action filters to check the remote IP address of requests for specific action methods.

The sample app illustrates the middleware approach. A string containing approved client IP addresses is stored in an app setting. The middleware parses the string into a list, and for each request it checks if the remote IP is in the list. If not, it returns an HTTP 403.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/ip-safelist/samples/2.x/ClientIpAspNetCore) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## The safelist

The list is configured in the *appsettings.json* file. It's a semicolon-delimited list and can contain IPv4 and IPv6 addresses.

[!code-json[](ip-safelist/samples/2.x/ClientIpAspNetCore/appsettings.json?highlight=2)]

## The Startup class

The `Configure` method adds the middleware and passes the safelist string to it in a constructor parameter.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_Configure&highlight=7)]

## The middleware

The middleware parses the string into an array and looks for the remote IP address in the array. If the remote IP address is not found, the middleware returns an HTTP 403. This validation process is not done for HTTP Get requests.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/AdminSafeListMiddleware.cs?name=snippet_ClassOnly)]

All non-Get requests are logged at Debug level, and rejected requests are logged at Information level. Here's an example of Debug logging output:

```
2017-09-31 16:45:42.8891|0|ClientIpAspNetCore.AdminWhiteListMiddleware|INFO|  Request from Remote IP address: 192.168.1.4 
2016-09-31 16:45:42.9031|0|ClientIpAspNetCore.AdminWhiteListMiddleware|INFO|  Forbidden Request from Remote IP address: 192.168.1.4 
```

## Action filter alternative

If you want to implement a safelist only for specific controllers or action methods, use an action filter. Here's an action filter example: 

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Filters/ClientIdCheckFilter.cs)]

The action filter is added to the services container.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServices&highlight=3)]

The filter can then be used on a controller or action method.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Controllers/ValuesController.cs?name=snippet_FilterController&highlight=1)]

## Next steps

[Learn more about ASP.NET Core Middleware](xref:fundamentals/middleware).
