---
title: Client IP safelist for ASP.NET Core
author: damienbod
description: Learn how to write Middleware or action filters to validate remote IP addresses against a list of approved IP addresses.
ms.author: riande
ms.custom: mvc
ms.date: 03/12/2020
uid: security/ip-safelist
---
# Client IP safelist for ASP.NET Core

By [Damien Bowden](https://twitter.com/damien_bod) and [Tom Dykstra](https://github.com/tdykstra)
 
This article shows three ways to implement an IP address safelist (also known as an allow list) in an ASP.NET Core app. An accompanying sample app demonstrates all three approaches. You can use:

* Middleware to check the remote IP address of every request.
* MVC action filters to check the remote IP address of requests for specific controllers or action methods.
* Razor Pages filters to check the remote IP address of requests for Razor pages.

In each case, a string containing approved client IP addresses is stored in an app setting. The middleware or filter:

* Parses the string into an array. 
* Checks if the remote IP address exists in the array.

Access is allowed if the array contains the IP address. Otherwise, an HTTP 403 Forbidden status code is returned.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/security/ip-safelist/samples) ([how to download](xref:index#how-to-download-a-sample))

## The safelist

The IP safelist is:

* Defined by the `AdminSafeList` property in the *appsettings.json* file.
* A semicolon-delimited string that may contain both [Internet Protocol version 4 (IPv4)](https://wikipedia.org/wiki/IPv4) and [Internet Protocol version 6 (IPv6)](https://wikipedia.org/wiki/IPv6) addresses.

::: moniker range=">= aspnetcore-3.0"

[!code-json[](ip-safelist/samples/3.x/ClientIpAspNetCore/appsettings.json?highlight=2)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-json[](ip-safelist/samples/2.x/ClientIpAspNetCore/appsettings.json?highlight=2)]

::: moniker-end

In the preceding example, the IPv4 addresses of `127.0.0.1` and `192.168.1.5` and the IPv6 loopback address of `::1` (compressed format for `0:0:0:0:0:0:0:1`) are allowed.

## Middleware

The `Startup.Configure` method adds the custom `AdminSafeListMiddleware` middleware type to the app's request pipeline. The safelist string defined in *appsettings.json* is passed to the middleware as a constructor parameter:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](ip-safelist/samples/3.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureAddMiddleware)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureAddMiddleware)]

::: moniker-end

The middleware parses the string into an array and looks for the remote IP address in the array. If the remote IP address isn't found, the middleware returns HTTP 403 Forbidden. This validation process is bypassed for HTTP GET requests.

[!code-csharp[](ip-safelist/samples/Shared/ClientIpSafelistComponents/Middlewares/AdminSafeListMiddleware.cs?name=snippet_ClassOnly)]

## Action filter

If you want a safelist only for specific MVC controllers or action methods, use an action filter. For example:

[!code-csharp[](ip-safelist/samples/Shared/ClientIpSafelistComponents/Filters/ClientIpCheckActionFilter.cs?name=snippet_ClassOnly)]

In `Startup.ConfigureServices`, add the action filter to the MVC filters collection. In the following example, a `ClientIpCheckActionFilter` action filter is added. A console logger is created for the action filter and is assigned to its `Logger` property.

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](ip-safelist/samples/3.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServicesActionFilter)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServicesActionFilter)]

::: moniker-end

The action filter can then be applied to a controller or action method with the [[ServiceFilter]](xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute) attribute:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](ip-safelist/samples/3.x/ClientIpAspNetCore/Controllers/WeatherForecastController.cs?name=snippet_ActionFilter&highlight=1)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Controllers/ValuesController.cs?name=snippet_ActionFilter&highlight=1)]

::: moniker-end

In the sample app, the action filter is applied to the controller's `Get` action method. When you test the app by sending:

* An HTTP GET request, the `[ServiceFilter]` attribute validates the client IP address.
* An HTTP request verb other than GET, the `AdminSafeListMiddleware` middleware validates the client IP address.

## Razor Pages filter

If you want a safelist for a Razor Pages app, use a Razor Pages filter. For example:

[!code-csharp[](ip-safelist/samples/Shared/ClientIpSafelistComponents/Filters/ClientIpCheckPageFilter.cs?name=snippet_ClassOnly)]

In `Startup.ConfigureServices`, the Razor Pages filter is enabled by adding it to the MVC filters collection:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](ip-safelist/samples/3.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServicesPageFilter)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](ip-safelist/samples/2.x/ClientIpAspNetCore/Startup.cs?name=snippet_ConfigureServicesPageFilter)]

::: moniker-end

When you run the sample app and request the *Index* Razor page, the Razor Pages filter validates the client IP address.

## Additional resources

* <xref:fundamentals/middleware/index>
* [Action filters](xref:mvc/controllers/filters#action-filters)
* <xref:razor-pages/filter>
