---
title: Response Caching
author: rick-anderson
description: Explains how to use Response caching to lower bandwidth and increase performance.
keywords: ASP.NET Core, Response caching, HTTP headers
ms.author: riande
manager: wpickett
ms.date: 7/10/2017
ms.topic: article
ms.assetid: cb42035a-60b0-472e-a614-cb79f443f654
ms.prod: asp.net-core
uid: performance/caching/response
---
# Response Caching

By [John Luo](https://github.com/JunTaoLuo), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Steve Smith](https://ardalis.com/)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/response/sample)

## What is Response Caching

*Response caching* adds cache-related headers to responses. These headers specify how you want client, proxy and middleware to cache responses. Response caching can reduce the number of requests a client or proxy makes to the web server. Response caching can also reduce the amount of work the web server performs to generate the response. 

The primary HTTP header used for caching is `Cache-Control`. See the [HTTP 1.1 Caching](https://tools.ietf.org/html/rfc7234#section-5.2) for more information. Common cache directives:

* [public](https://tools.ietf.org/html/rfc7234#section-5.2.2.5)
* [private](https://tools.ietf.org/html/rfc7234#section-5.2.2.6)
* [no-cache](https://tools.ietf.org/html/rfc7234#section-5.2.1.4)
* [Pragma](https://tools.ietf.org/html/rfc7234#section-5.4)
* [Vary](https://tools.ietf.org/html/rfc7231#section-7.1.4)

The web server can cache responses by adding the response caching middleware. See [Response caching middleware](middleware.md) for more information.

## Distributed Cache Tag Helper

The [Distributed Cache Tag Helper](xref:mvc/views/tag-helpers/builtin-th/DistributedCacheTagHelper) enables distributed caching.


## ResponseCache Attribute

The `ResponseCacheAttribute` specifies the parameters necessary for setting appropriate headers in response caching. See [ResponseCacheAttribute](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.responsecacheattribute)  for a description of the parameters.

>[!WARNING]
> Disable caching for content that contains information for authenticated clients. Caching should only be enabled for content that does not change based on a user's identity, or whether a user is logged in.

`VaryByQueryKeys string[]` (requires ASP.NET Core 1.1.0 and higher): When set, the response caching middleware will vary the stored response by the values of the given list of query keys. The response caching middleware must be enabled to set the `VaryByQueryKeys` property, otherwise a runtime exception will be thrown. There is no corresponding HTTP header for the `VaryByQueryKeys` property. This property is an HTTP feature handled by the response caching middleware. For the middleware to serve a cached response, the query string and query string value must match a previous request. For example, consider the following sequence:

| Request          | Result |
| ----------------- | ------------ | 
| `http://example.com?key1=value1` | returned from server |
| `http://example.com?key1=value1` | returned from middleware |
| `http://example.com?key1=value2` | returned from server |

The first request is returned by the server and cached in middleware. The second request is returned by middleware because the query string matches the previous request. The third request is not in the middleware cache because the query string value doesn't match a previous request. 

The `ResponseCacheAttribute` is used to configure and create (via `IFilterFactory`) a `ResponseCacheFilter`. The `ResponseCacheFilter` performs the work of updating the appropriate HTTP headers and features of the response. The filter:

* Removes any existing headers for `Vary`, `Cache-Control`, and `Pragma`. 
* Writes out the appropriate headers based on the properties set in the `ResponseCacheAttribute`. 
* Updates the response caching HTTP feature if `VaryByQueryKeys` is set.

### Vary

This header is only written when the `VaryByHeader` property is set. It is set to the `Vary` property's value. The following sample uses the `VaryByHeader` property.

[!code-csharp[Main](response/sample/Controllers/HomeController.cs?name=snippet_VaryByHeader&highlight=1)]

You can view the response headers with your browsers network tools. The following image shows the Edge F12 output on the **Network** tab when the `About2` action method is refreshed. 

![Edge F12 output on the **Network** tab when the `About2` action method is called](response/_static/vary.png)

### NoStore and Location.None

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

```
Cache-Control: public,max-age=60
   ```

  ### Additional Resources

* [Caching in HTTP from the specification](https://tools.ietf.org/html/rfc7234#section-3)
* [Cache-Control](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9)
