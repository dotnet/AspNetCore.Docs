---
title: Enable Cross-Origin Requests (CORS) in ASP.NET Core
author: rick-anderson
description: Learn how CORS as a standard for allowing or rejecting cross-origin requests in an ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 11/27/2018
uid: security/cors
---
# Enable Cross-Origin Requests (CORS) in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Mike Wasson](https://github.com/mikewasson), and [Tom Dykstra](https://github.com/tdykstra)

Browser security prevents a web page from making requests to a different domain than the one that served the web page. This restriction is called the *same-origin policy*. The same-origin policy prevents a malicious site from reading sensitive data from another site. Sometimes, you might want to allow other sites make cross-origin requests to your app.

[Cross Origin Resource Sharing](https://www.w3.org/TR/cors/) (CORS) is a W3C standard that allows a server to relax the same-origin policy. Using CORS, a server can explicitly allow some cross-origin requests while rejecting others. CORS is safer and more flexible than earlier techniques, such as [JSONP](https://wikipedia.org/wiki/JSONP). This topic shows how to enable CORS in an ASP.NET Core app.

## Same origin

Two URLs have the same origin if they have identical schemes, hosts, and ports ([RFC 6454](https://tools.ietf.org/html/rfc6454)).

These two URLs have the same origin:

* `https://example.com/foo.html`
* `https://example.com/bar.html`

These URLs have different origins than the previous two URLs:

* `https://example.net` &ndash; Different domain
* `https://www.example.com/foo.html` &ndash; Different subdomain
* `http://example.com/foo.html` &ndash; Different scheme
* `https://example.com:9000/foo.html` &ndash; Different port

Internet Explorer doesn't consider the port when comparing origins.

## Enable CORS with middleware

CORS Middleware handles cross-origin requests. The following code enables CORS for the entire app with the specified origins:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup3.cs?name=snippet2&highlight=13-18)]

In the preceding code, the <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors*> extension method enables cores. The lambda takes a <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder> object. [Configuration options](#cors-policy-options), such as `WithOrigins`, are described later in this topic. The policy allows cross-origin requests from the listed origins only.

Note:

* `UseCors` must be called before `UseMvc`.
* The URL must **not** contain a trailing slash (`/`). If the URL terminates with `/`, the comparison returns `false` and no header is returned.

<!-- 
CORS Middleware must precede any defined endpoints in your app where you want to support cross-origin requests (for example, before the call to `UseMvc` for MVC/Razor Pages Middleware).
-->

See [Test CORS](#test) for instructions on testing this app.

### CORS with named policy

The following code enables CORS for the entire app with the specified origins:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup.cs?name=snippet&highlight=8,14-23,39)]

The preceding code sets the policy name to "_myAllowSpecificOrigins". The policy name is arbitrary.

The <xref:Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions.AddCors*> method call adds CORS services to the app's service container:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup.cs?name=snippet2)]

See [CORS policy options](#cpo) in this document for more information.

The <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder> method can chain methods, as shown in the following code:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup2.cs?name=snippet2)]

The sample code enables CORS middleware:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup.cs?name=snippet3&highlight=12)]

The preceding highlighted code applies CORS policies to all the apps endpoints via [CORS Middleware](#enable-cors-with-cors-middleware).

See [Enable CORS in Razor Pages, controllers, and action methods](#ecors) to apply CORS policy at the page/controller/action level.

<a name="ecors"></a>

## Enable CORS in Razor Pages, controllers, and action methods

The following code enables CORS for the entire app with the specified origins:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup.cs?name=snippet&highlight=8,14-23,39)]

The preceding code sets the policy name to "_myAllowSpecificOrigins". The policy name is arbitrary.

The [&lbrack;EnableCors&rbrack;](xref:Microsoft.AspNetCore.Cors.EnableCorsAttribute) attribute provides an alternative to applying CORS globally. The `[EnableCors("{Policy String}")]` attribute can be applied to a:

* Razor Page `PageModel`
* Razor Page action method
* Controller
* Controller action method

You can apply different policies to controller/page model/action with the  `[EnableCors("{Policy String}")]` attribute. When the `[EnableCors("{Policy String}")]` attribute is applied to a controllers/page model/action method, and CORS is enabled in middleware, the attribute takes precedence.

Policies have the following precedence:

1. Action method
1. Controller or `PageModel`
1. Middleware

The following code applies `"AnotherPolicy"` to `ActionResult<string> Get(int id)` and `"MyPolicy"` to non-decorated methods in the controller:

Controllers/WidgetController.cs
[!code-csharp[](cors/sample/Cors/WebAPI/Controllers/WidgetController.cs?name=snippet&highlight=1,15)]

### Disable CORS

The [&lbrack;DisableCors&rbrack;](xref:Microsoft.AspNetCore.Cors.DisableCorsAttribute) attribute disables CORS for the controller/page model/action.

[!code-csharp[](cors/sample/CorsMVC/Controllers/ValuesController.cs?name=DisableOnAction&highlight=2)]

<a name="cpo"></a>

## CORS policy options

This section describes the various options that you can set in a CORS policy. The <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions.AddPolicy*> method is called in `Startup.ConfigureServices`.

* [Set the allowed origins](#set-the-allowed-origins)
* [Set the allowed HTTP methods](#set-the-allowed-http-methods)
* [Set the allowed request headers](#set-the-allowed-request-headers)
* [Set the exposed response headers](#set-the-exposed-response-headers)
* [Credentials in cross-origin requests](#credentials-in-cross-origin-requests)
* [Set the preflight expiration time](#set-the-preflight-expiration-time)

For some options, it may be helpful to read the [How CORS works](#how-cors-works) section first.

## Set the allowed origins

<xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyOrigin*> &ndash; Allows CORS requests from all origins with any scheme (`http` or `https`). `AllowAnyOrigin` is insecure because *any website* can make cross-origin requests to the app.

  ::: moniker range=">= aspnetcore-2.2"

  > [!NOTE]
  > Specifying `AllowAnyOrigin` and `AllowCredentials` is an insecure configuration and can result in cross-site request forgery. The CORS service returns an invalid CORS response when an app is configured with both methods.

  ::: moniker-end

  ::: moniker range="< aspnetcore-2.2"

  > [!NOTE]
  > Specifying `AllowAnyOrigin` and `AllowCredentials` is an insecure configuration and can result in cross-site request forgery. For a secure app, specify an exact list of origins if the client must authorize itself to access server resources.

  ::: moniker-end

  `AllowAnyOrigin` affects preflight requests and the `Access-Control-Allow-Origin` header. For more information, see the [Preflight requests](#preflight-requests) section.

::: moniker range=">= aspnetcore-2.0"

<xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.SetIsOriginAllowedToAllowWildcardSubdomains*> &ndash; Sets the <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.IsOriginAllowed*> property of the policy to be a function that allows origins to match a configured wildcarded domain when evaluating if the origin is allowed.

  [!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=100-104&highlight=4)]

::: moniker-end

### Set the allowed HTTP methods

<xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyMethod*>:

* Allows any HTTP method:
* Affects preflight requests and the `Access-Control-Allow-Methods` header. For more information, see the [Preflight requests](#preflight-requests) section.

### Set the allowed request headers

To allow specific headers to be sent in a CORS request, called *author request headers*, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithHeaders*> and specify the allowed headers:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=55-60&highlight=5)]

To allow all author request headers, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyHeader*>:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=64-69&highlight=5)]

This setting affects preflight requests and the `Access-Control-Request-Headers` header. For more information, see the [Preflight requests](#preflight-requests) section.

::: moniker range=">= aspnetcore-2.2"

A CORS Middleware policy match to specific headers specified by `WithHeaders` is only possible when the headers sent in `Access-Control-Request-Headers` exactly match the headers stated in `WithHeaders`.

For instance, consider an app configured as follows:

```csharp
app.UseCors(policy => policy.WithHeaders(HeaderNames.CacheControl));
```

CORS Middleware declines a preflight request with the following request header because `Content-Language` ([HeaderNames.ContentLanguage](xref:Microsoft.Net.Http.Headers.HeaderNames.ContentLanguage)) isn't listed in `WithHeaders`:

```
Access-Control-Request-Headers: Cache-Control, Content-Language
```

The app returns a *200 OK* response but doesn't send the CORS headers back. Therefore, the browser doesn't attempt the cross-origin request.

::: moniker-end

::: moniker range="< aspnetcore-2.2"

CORS Middleware always allows four headers in the `Access-Control-Request-Headers` to be sent regardless of the values configured in CorsPolicy.Headers. This list of headers includes:

* `Accept`
* `Accept-Language`
* `Content-Language`
* `Origin`

For instance, consider an app configured as follows:

```csharp
app.UseCors(policy => policy.WithHeaders(HeaderNames.CacheControl));
```

CORS Middleware responds successfully to a preflight request with the following request header because `Content-Language` is always whitelisted:

```
Access-Control-Request-Headers: Cache-Control, Content-Language
```

::: moniker-end

### Set the exposed response headers

By default, the browser doesn't expose all of the response headers to the app. For more information, see [W3C Cross-Origin Resource Sharing (Terminology): Simple Response Header](https://www.w3.org/TR/cors/#simple-response-header).

The response headers that are available by default are:

* `Cache-Control`
* `Content-Language`
* `Content-Type`
* `Expires`
* `Last-Modified`
* `Pragma`

The CORS specification calls these headers *simple response headers*. To make other headers available to the app, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithExposedHeaders*>:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=73-78&highlight=5)]

### Credentials in cross-origin requests

Credentials require special handling in a CORS request. By default, the browser doesn't send credentials with a cross-origin request. Credentials include cookies and HTTP authentication schemes. To send credentials with a cross-origin request, the client must set `XMLHttpRequest.withCredentials` to `true`.

Using `XMLHttpRequest` directly:

```javascript
var xhr = new XMLHttpRequest();
xhr.open('get', 'https://www.example.com/api/test');
xhr.withCredentials = true;
```

In jQuery:

```jQuery
$.ajax({
  type: 'get',
  url: 'https://www.example.com/home',
  xhrFields: {
    withCredentials: true
}
```

In addition, the server must allow the credentials. To allow cross-origin credentials, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowCredentials*>:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=82-87&highlight=5)]

The HTTP response includes an `Access-Control-Allow-Credentials` header, which tells the browser that the server allows credentials for a cross-origin request.

If the browser sends credentials but the response doesn't include a valid `Access-Control-Allow-Credentials` header, the browser doesn't expose the response to the app, and the cross-origin request fails.

Be careful when allowing cross-origin credentials. A website at another domain can send a signed-in user's credentials to the app on the user's behalf without the user's knowledge.

The CORS specification also states that setting origins to `"*"` (all origins) is invalid if the `Access-Control-Allow-Credentials` header is present.

### Preflight requests

For some CORS requests, the browser sends an additional request before making the actual request. This request is called a *preflight request*. The browser can skip the preflight request if the following conditions are true:

* The request method is GET, HEAD, or POST.
* The app doesn't set request headers other than `Accept`, `Accept-Language`, `Content-Language`, `Content-Type`, or `Last-Event-ID`.
* The `Content-Type` header, if set, has one of the following values:
  * `application/x-www-form-urlencoded`
  * `multipart/form-data`
  * `text/plain`

The rule on request headers set for the client request applies to headers that the app sets by calling `setRequestHeader` on the `XMLHttpRequest` object. The CORS specification calls these headers *author request headers*. The rule doesn't apply to headers the browser can set, such as `User-Agent`, `Host`, or `Content-Length`.

The following is an example of a preflight request:

```
OPTIONS https://myservice.azurewebsites.net/api/test HTTP/1.1
Accept: */*
Origin: https://myclient.azurewebsites.net
Access-Control-Request-Method: PUT
Access-Control-Request-Headers: accept, x-my-custom-header
Accept-Encoding: gzip, deflate
User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)
Host: myservice.azurewebsites.net
Content-Length: 0
```

The pre-flight request uses the HTTP OPTIONS method. It includes two special headers:

* `Access-Control-Request-Method`: The HTTP method that will be used for the actual request.
* `Access-Control-Request-Headers`: A list of request headers that the app sets on the actual request. As stated earlier, this doesn't include headers that the browser sets, such as `User-Agent`.

A CORS preflight request might include an `Access-Control-Request-Headers` header, which indicates to the server the headers that are sent with the actual request.

To allow specific headers, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithHeaders*>:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=55-60&highlight=5)]

To allow all author request headers, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowAnyHeader*>:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=64-69&highlight=5)]

Browsers aren't entirely consistent in how they set `Access-Control-Request-Headers`. If you set headers to anything other than `"*"` (or use <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy.AllowAnyHeader*>), you should include at least `Accept`, `Content-Type`, and `Origin`, plus any custom headers that you want to support.

The following is an example response to the preflight request (assuming that the server allows the request):

```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 0
Access-Control-Allow-Origin: https://myclient.azurewebsites.net
Access-Control-Allow-Headers: x-my-custom-header
Access-Control-Allow-Methods: PUT
Date: Wed, 20 May 2015 06:33:22 GMT
```

The response includes an `Access-Control-Allow-Methods` header that lists the allowed methods and optionally an `Access-Control-Allow-Headers` header, which lists the allowed headers. If the preflight request succeeds, the browser sends the actual request.

If the preflight request is denied, the app returns a *200 OK* response but doesn't send the CORS headers back. Therefore, the browser doesn't attempt the cross-origin request.

### Set the preflight expiration time

The `Access-Control-Max-Age` header specifies how long the response to the preflight request can be cached. To set this header, call <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.SetPreflightMaxAge*>:

[!code-csharp[](cors/sample/CorsExample4/Startup.cs?range=91-96&highlight=5)]

## How CORS works

This section describes what happens in a CORS request at the level of the HTTP messages. It's important to understand how CORS works so that the CORS policy can be configured correctly and debugged when unexpected behaviors occur.

The CORS specification introduces several new HTTP headers that enable cross-origin requests. If a browser supports CORS, it sets these headers automatically for cross-origin requests. Custom JavaScript code isn't required to enable CORS.

The following is an example of a cross-origin request. The `Origin` header provides the domain of the site that's making the request:

```
GET https://myservice.azurewebsites.net/api/test HTTP/1.1
Referer: https://myclient.azurewebsites.net/
Accept: */*
Accept-Language: en-US
Origin: https://myclient.azurewebsites.net
Accept-Encoding: gzip, deflate
User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)
Host: myservice.azurewebsites.net
```

If the server allows the request, it sets the `Access-Control-Allow-Origin` header in the response. The value of this header either matches the `Origin` header from the request or is the wildcard value `"*"`, meaning that any origin is allowed:

```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: text/plain; charset=utf-8
Access-Control-Allow-Origin: https://myclient.azurewebsites.net
Date: Wed, 20 May 2015 06:27:30 GMT
Content-Length: 12

Test message
```

If the response doesn't include the `Access-Control-Allow-Origin` header, the cross-origin request fails. Specifically, the browser disallows the request. Even if the server returns a successful response, the browser doesn't make the response available to the client app.

<a name="test"></a>

## Test CORS



## Additional resources

* [Cross-Origin Resource Sharing (CORS)](https://developer.mozilla.org/docs/Web/HTTP/CORS)
