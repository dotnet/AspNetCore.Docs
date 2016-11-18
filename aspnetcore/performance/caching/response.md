---
title: Response Caching | Microsoft Docs
author: riande
description: Explains how to use Response caching to lower bandwidth and increase performance.
keywords: ASP.NET Core,
ms.author: riande
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: cb42035a-60b0-472e-a614-cb79f443f654
ms.prod: aspnet-core
uid: performance/caching/response
---
# Response Caching

[Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](http://ardalis.com)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/response/sample)

## What is Response Caching

*Response caching* adds cache-related headers to responses. These headers specify how you want client, intermediate (proxy) machines and middleware to cache responses. Response caching can reduce the number of requests a client or proxy makes to the web server. Response caching can also reduce the amount of work the web server performs to generate the response. Repeated matching may be served from the cache of the client, proxy or server. Cached responses can be returned by the client, the proxy or served by the response caching middleware. Cached requests served by the client or proxy save bandwidth and server load. Cached requests served by middleware can reduce web app server load.

The primary HTTP header used for caching is `Cache-Control`. See the [HTTP 1.1 Caching](https://tools.ietf.org/html/rfc7234#section-5.2) and [Cache-Control](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9) for more information. Common cache directives:

* [public](https://tools.ietf.org/html/rfc7234#section-5.2.2.5)
* [private](https://tools.ietf.org/html/rfc7234#section-5.2.2.6)
* [no-cache](https://tools.ietf.org/html/rfc7234#section-5.2.1.4)
* [Pragma](https://tools.ietf.org/html/rfc7234#section-5.4)
* [Vary](https://tools.ietf.org/html/rfc7231#section-7.1.4)

Caching responses on the web server can be enabled by adding the [response caching middleware](https://github.com/aspnet/responsecaching). See [Response caching middleware](middleware.md) for more information.

## ResponseCache Attribute

The [ResponseCacheAttribute](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.responsecacheattribute) specifies the parameters necessary for setting appropriate headers in response caching. See [ResponseCacheAttribute](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.responsecacheattribute)  for a description of the parameters.

`VaryByQueryKeys string[]`: When set, the response caching middleware will vary the stored response by the given list of query keys. The middleware will serve the stored response only if the query keys of the request matches those of the original request that generated the stored response. Setting this property without adding the middleware will throw a runttime exception. 

  There is no corresponding HTTP header for this property. This property is an HTTP feature handled by the response caching middleware. To set the `VaryByQueryKeys` property, the response caching middleware must be enabled.

The `ResponseCacheAttribute` is used to configure and create (via `IFilterFactory`) a `ResponseCacheFilter`. The `ResponseCacheFilter` performs the work of updating the appropriate HTTP headers and features of the response. The filter:

* Removes any existing headers for `Vary`, `Cache-Control`, and `Pragma`. 
* Writes out the appropriate headers based on the properties set in the `ResponseCacheAttribute`. 
* Updates the response caching HTTP feature if `VaryByQueryKeys` is set.

### `Vary` 

This header is only written when the `VaryByHeader` property is set. It is set to the `Vary` property's value. The following sample uses the `VaryByHeader` property.

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_VaryByHeader&highlight=1)]

You can view the response headers with your browsers network tools or the [Fidder tool](http://www.telerik.com/fiddler). The following image shows the Edge F12 output on the **Network** tab when the `About2` action method is called:

![Edge F12 output on the **Network** tab when the `About2` action method is called](response/_static/vary.png)

### `NoStore` and `Location.None`

`NoStore` overrides most of the other properties. When this property is set to `true`, the `Cache-Control` header will be set to "no-store". If `Location` is set to `None`:

* `Cache-Control` is set to `"no-store, no-cache"`. 
* `Pragma` is set to `no-cache`. 

If `NoStore` is `false` and `Location` is `None`,  `Cache-Control` and `Pragma` will be set to `no-cache`.

You typically set `NoStore` to `true` on error pages. For example:

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet1&highlight=1)]

This will result in the following headers:

```javascript
Cache-Control: no-store,no-cache
Pragma: no-cache
```

### Location and Duration

To enable caching, `Duration` must be set to a positive value and `Location` must be either `Any` (the default) or `Client`. In this case, the `Cache-Control` header will be set to the location value followed by the "max-age" of the response.

> [!NOTE]
> `Location`'s options of `Any` and `Client` translate into `Cache-Control` header values of `public` and `private`, respectively. As noted previously, setting `Location` to `None` will set both `Cache-Control` and `Pragma` headers to `no-cache`.

Below is an example showing the headers produced by setting `Duration` and leaving the default `Location` value.

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_duration&highlight=1)]

Produces the following headers:

```javascript
Cache-Control: public,max-age=60
   ```

### Cache Profiles

Instead of duplicating `ResponseCache` settings on many controller action attributes, cache profiles can be configured as options when setting up MVC in the `ConfigureServices` method in `Startup`. Values found in a referenced cache profile will be used as the defaults by the `ResponseCache` attribute, and will be overridden by any properties specified on the attribute.

Setting up a cache profile:

[!code-csharp[Main](response/sample/Startup.cs?name=snippet1)] 

Referencing a cache profile:

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_controller&highlight=1,4)]

The `ResponseCache` attribute can be applied both to actions (methods) as well as controllers (classes). Method-level attributes will override the settings specified in class-level attributes.

In the above example, a class-level attribute specifies a duration of 30 seconds while a method-level attributes references a cache profile with a duration set to 60 seconds.

The resulting header:

```javascript
Cache-Control: public,max-age=60
   ```

  ### Additional Resources

* [Caching in HTTP from the specification](https://tools.ietf.org/html/rfc7234#section-3)
* [Cache-Control](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9)