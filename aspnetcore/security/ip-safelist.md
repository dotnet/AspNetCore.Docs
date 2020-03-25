---
title: Client IP safelist for ASP.NET Core
author: damienbod
description: Learn how to write Middleware or action filters to validate remote IP addresses against a list of approved IP addresses.
ms.author: riande
ms.custom: mvc
ms.date: 08/31/2018
uid: security/ip-safelist
---
# Client IP safelist for ASP.NET Core

By [Damien Bowden](https://twitter.com/damien_bod) and [Tom Dykstra](https://github.com/tdykstra)
 
This article shows three ways to implement an IP safelist (also known as a whitelist) in an ASP.NET Core app. You can use:

* Middleware to check the remote IP address of every request.
* Action filters to check the remote IP address of requests for specific controllers or action methods.
* Razor Pages filters to check the remote IP address of requests for Razor pages.

In each case, a string containing approved client IP addresses is stored in an app setting. The middleware or filter parses the string into a list and checks if the remote IP is in the list. If not, an HTTP 403 Forbidden status code is returned.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/security/ip-safelist/samples/2.x/ClientIpAspNetCore) ([how to download](xref:index#how-to-download-a-sample))

## The safelist

The list is configured in the *appsettings.json* file. It's a semicolon-delimited list and can contain IPv4 and IPv6 addresses.

[!code-json[](ip-safelist/samples/2.x/ClientIpAspNetCore/appsettings.json?highlight=2)]

## Middleware

The `Configure` method adds the middleware and passes the safelist string to it in a constructor parameter.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_Configure&highlight=10)]

The middleware parses the string into an array and looks for the remote IP address in the array. If the remote IP address is not found, the middleware returns HTTP 401 Forbidden. This validation process is bypassed for HTTP Get requests.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/AdminSafeListMiddleware.cs?name=snippet_ClassOnly)]

## Action filter

If you want a safelist only for specific controllers or action methods, use an action filter. Here's an example: 

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Filters/ClientIpCheckFilter.cs)]

The action filter is added to the services container.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServices&highlight=3)]

The filter can then be used on a controller or action method.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Controllers/ValuesController.cs?name=snippet_Filter&highlight=1)]

In the sample app, the filter is applied to the `Get` method. So when you test the app by sending a `Get` API request, the attribute is validating the client IP address. When you test by calling the API with any other HTTP method, the middleware is validating the client IP.

## Razor Pages filter 

If you want a safelist for a Razor Pages app, use a Razor Pages filter. Here's an example: 

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Filters/ClientIpCheckPageFilter.cs)]

This filter is enabled by adding it to the MVC Filters collection.

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServices&highlight=7-9)]

When you run the app and request a Razor page, the Razor Pages filter is validating the client IP.

## Next steps

[Learn more about ASP.NET Core Middleware](xref:fundamentals/middleware/index).
