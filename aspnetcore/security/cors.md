---
title: Enable Cross-Origin Requests (CORS) in ASP.NET Core
author: rick-anderson
description: Learn how CORS as a standard for allowing or rejecting cross-origin requests in an ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 2/8/2019
uid: security/cors
---
# Enable Cross-Origin Requests (CORS) in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This topic shows how to enable CORS in an ASP.NET Core app.

Browser security prevents a web page from making requests to a different domain than the one that served the web page. This restriction is called the *same-origin policy*. The same-origin policy prevents a malicious site from reading sensitive data from another site. Sometimes, you might want to allow other sites make cross-origin requests to your app. For more information see the excellent [Mozilla CORS article](https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS).

[Cross Origin Resource Sharing](https://www.w3.org/TR/cors/) (CORS):

* Is a W3C standard that allows a server to relax the same-origin policy.
* Allows a server to explicitly allow some cross-origin requests while rejecting others.
* Is safer and more flexible than earlier techniques, such as [JSONP](https://wikipedia.org/wiki/JSONP).
* Is **not** a security feature. An API is not safer by allowing CORS. See [How CORS works](#how-cors) for more information.

[View or download sample code]
(https://github.com/aspnet/Docs/tree/live/aspnetcore/security/cors/sample/Cors) ([how to download](xref:tutorials/index#how-to-download-a-sample))

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

## CORS with named policy and middleware

CORS Middleware handles cross-origin requests. The following code enables CORS for the entire app with the specified origins:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup.cs?name=snippet&highlight=8,14-23,38)]

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

Note:

* `UseCors` must be called before `UseMvc`.
* The URL must **not** contain a trailing slash (`/`). If the URL terminates with `/`, the comparison returns `false` and no header is returned.

See [Test CORS](#test) for instructions on testing the preceding code.

<a name="ecors"></a>

## Enable CORS with attributes

The following code creates two named policies for CORS:

[!code-csharp[](cors/sample/Cors/WebAPI/StartupMultiPolicy.cs?name=snippet&highlight=8,14-31,47)]

In the preceding code, `app.UseCors(MyAllowSpecificOrigins);` is the default policy for the app.

The following code creates a named policy for CORS:

[!code-csharp[](cors/sample/Cors/WebAPI/StartupAttribute.cs?name=snippet&highlight=12-20,36)]

The preceding code sets the policy name to "MyAllowSpecificOrigins". The policy name is arbitrary. <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors*> enables the CORS middleware, but does not enable CORS for the app. When using the parameter-less `UseCors()`, the `[EnableCors]` attribute is used to enable CORS.

The [&lbrack;EnableCors&rbrack;](xref:Microsoft.AspNetCore.Cors.EnableCorsAttribute) attribute provides an alternative to applying CORS globally. The `[EnableCors("{Policy String}")]` attribute can be applied to a:

* Razor Page `PageModel`
* Controller
* Controller action method

You can apply different policies to controller/page model/action with the  `[EnableCors("{Policy String}")]` attribute. When the `[EnableCors("{Policy String}")]` attribute is applied to a controllers/page model/action method, and CORS is enabled in middleware, both policies are applied. We recommend against combining policies, use the `[EnableCors]` attribute or middleware.

The following code applies a different policy to each method:

[!code-csharp[](cors/sample/Cors/WebAPI/Controllers/WidgetController.cs?name=snippet)]

## Enable CORS without named policy

CORS is typically enabled with a named policy, either in middleware or with attributes, as shown in the two previous samples.

The following approach enables CORS for the entire app with the specified origins, *without a named policy*:

[!code-csharp[](cors/sample/Cors/WebAPI/Startup3.cs?name=snippet2&highlight=13-17)]

In the preceding code, the <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors*> extension method enables cores. The lambda takes a <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder> object. [Configuration options](#cors-policy-options), such as `WithOrigins`, are described later in this topic. The policy allows cross-origin requests from the listed origins only.

See [Test CORS](#test) for instructions on testing the preceding code.

### Disable CORS

The [&lbrack;DisableCors&rbrack;](xref:Microsoft.AspNetCore.Cors.DisableCorsAttribute) attribute disables CORS for the controller/page model/action.

<a name="cpo"></a>

## CORS policy options

This section describes the various options that you can set in a CORS policy. The <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions.AddPolicy*> method is called in `Startup.ConfigureServices`.

* [Set the allowed origins](#set-the-allowed-origins)
* [Set the allowed HTTP methods](#set-the-allowed-http-methods)
* [Set the allowed request headers](#set-the-allowed-request-headers)
* [Set the exposed response headers](#set-the-exposed-response-headers)
* [Credentials in cross-origin requests](#credentials-in-cross-origin-requests)
* [Set the preflight expiration time](#set-the-preflight-expiration-time)

For some options, it may be helpful to read the [How CORS works](#how-cors) section first.

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

<!-- REVIEW required
I changed from
This setting affects preflight requests and the ...
to
`AllowAnyOrigin` affects preflight requests and the
-->

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

<a name="how-cors"></a>

## How CORS works

This section describes what happens in a [CORS](https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS) request at the level of the HTTP messages.

* CORS is **not** a security feature. CORS is a W3C standard that allows a server to relax the same-origin policy.
  * For example, an malicious actor could use [Prevent Cross-Site Scripting (XSS)](xref:security/cross-site-scripting) against your site and execute a cross-site request to their CORS enabled site to steal information.
* Your API is not safer by allowing CORS.
  * It's up to the client (browser) to enforce CORS. It's up to the browser to enforce CORS. The server executes the request and returns the response, it's the client that returns an error and blocks the response. For example, any of the following tools will display the server response:
     * [Fiddler](https://www.telerik.com/fiddler)
     * [Postman](https://www.getpostman.com/)
     * [.NET HttpClient](dotnet/csharp/tutorials/console-webapiclient)
     * A web browser by entering the URL in the address bar.
* It's a way for a server to allow browsers to execute a cross-origin [XHR](https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest) request that otherwise would be forbidden.
  * Browsers (without CORS) can not do cross-origin requests. Before CORS, [JSONP](https://www.w3schools.com/js/js_json_jsonp.asp) was used to circumvent this restriction. JSONP doesn't use XHR, it uses the `<script>` tag to receive the response. Scripts are allowed to be loaded cross-origin.

The [CORS specification]() introduced several new HTTP headers that enable cross-origin requests. If a browser supports CORS, it sets these headers automatically for cross-origin requests. Custom JavaScript code isn't required to enable CORS.

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

To test CORS:

* [Create an API project](xref:tutorials/first-web-api). Alternatively, you can [download the sample](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/cors/sample/Cors).
* Enable CORS using one of the approaches in this document. For example:

  [!code-csharp[](cors/sample/Cors/WebAPI/StartupTest.cs?name=snippet2&highlight=13-18)]
  
  > [!WARNING]
  > `WithOrigins("https://localhost:5001");` should only be used for testing a sample app similar to the [download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/cors/sample/Cors).

* Create a web app project (Razor Pages or MVC). The sample uses Razor Pages. You can create the web app in the same solution as the API project.
* Add the following highlighted code to the *Index.cshtml* file:

  [!code-csharp[](cors/sample/Cors/ClientApp/Pages/Index.cshtml?highlight=11-99)]

* In the preceding code, replace `url: 'https://<web app>.azurewebsites.net/api/values/1',` with the URL to the deployed app.

* Deploy the API project. For example, [deploy to Azure](xref:host-and-deploy/azure-apps/index).
* Run the Razor Pages or MVC app from the desktop and click on the **Test** button. Use the F12 tools to review error messages.
* Remove the localhost origin from `WithOrigins` and deploy the app. Alternatively, run the client app with a different port. For example, run from Visual Studio.
* Test with the client app. Use the F12 tools to review the error. Depending on the browser, you get an error (in the F12 tools console) similar to the following:

  * Using Edge:

   **SEC7120: [CORS] The origin 'https://localhost:44375' did not find 'https://localhost:44375' in the Access-Control-Allow-Origin response header for cross-origin  resource at 'https://webapi.azurewebsites.net/api/values/1'.**
   
  * Using Chrome:

    **Access to XMLHttpRequest at 'https://webapi.azurewebsites.net/api/values/1' from origin 'https://localhost:44375' has been blocked by CORS policy: No 'Access-Control-Allow-Origin' header is present on the requested resource.**

## Additional resources

* [Cross-Origin Resource Sharing (CORS)](https://developer.mozilla.org/docs/Web/HTTP/CORS)
