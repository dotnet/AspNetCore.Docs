---
title: URL Rewriting Middleware | Microsoft Docs
author: guardrex
description: An introduction to URL rewriting and redirecting with instructions on how to use URL Rewriting Middleware in ASP.NET Core applications.
keywords: ASP.NET Core, URL rewriting, URL rewrite, URL redirecting, URL redirect, middleware, apache_mod
ms.author: riande
manager: wpickett
ms.date: 12/30/2016
ms.topic: article
ms.assetid: e6130638-c410-4161-9921-b658ce988bd1
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/url-rewriting
---
# URL Rewriting Middleware

By [Luke Latham](https://github.com/GuardRex) and [Mikael Mengistu](https://github.com/mikaelm12)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/url-rewriting/sample)

URL rewriting is the act of modifying request URLs based on one or more predefined rules. URL rewriting creates an abstraction between resource locations and their addresses so that the locations and addresses are not tightly linked. There are several scenarios where URL rewriting is valuable:
* Moving or replacing server resources temporarily or permanently while maintaining stable locators for those resources
* Splitting request processing across different applications or across areas of one application
* Removing, adding, or reorganizing URL segments on incoming requests
* Optimizing public URLs for Search Engine Optimization (SEO)
* Permitting the use of friendly public URLs to help people predict the content they will find by following a link
* Redirecting insecure requests to secure endpoints
* Preventing image hotlinking

You can define rules for changing the URL in several ways, including regular expression (regex) matching rules, rules based on the Apache mod_rewrite module, rules based on the IIS Rewrite Module, and with your own method and class rule logic. This document introduces URL rewriting with instructions on how to use URL Rewriting Middleware in ASP.NET Core applications.

> [!NOTE]
> URL rewriting can reduce the performance of an application. Where feasible, you should limit the number and complexity of rules.

## URL redirect and URL rewrite
The difference in wording between *URL redirect* and *URL rewrite* may seem subtle at first but has important implications for providing resources to clients. ASP.NET Core's URL Rewriting Middleware is capable of meeting the need for both.

A *URL redirect* is a client-side operation, where the client is instructed to access a resource at another address. This requires a round-trip to the server, and the redirect URL returned to the client will appear in the browser's address bar when the client makes a new request for the resource. If **/resource** is *redirected* to **/different-resource**, the client will request **/resource**, and the server will respond that the client should obtain the resource at **/different-resource** with a status code indicating that the redirect is either temporary or permanent. The client will execute a new request for the resource at the redirect URL.

![A WebAPI service endpoint has been temporarily changed from version 1 (v1) to version 2 (v2) on the server. A client makes a request to the service at the version 1 path /v1/api. The server sends back a 302 (Found) response with the new, temporary path for the service at version 2 /v2/api. The client makes a second request to the service at the redirect URL. The server responds with a 200 (OK) status code.](url-rewriting/_static/url_redirect.png)

When redirecting requests to a different URL, you will indicate whether the redirect is permanent or temporary. The 301 (Moved Permanently) status code is used where the resource has a new, permanent URL and you wish to instruct the client that all future requests for the resource should use the new URL. The client will cache the response when a 301 status code is received. The 302 (Found) status code is used where the redirection is temporary or generally subject to change, such that the client should not store and reuse the redirect URL in the future. For more information, see [RFC 2616: Status Code Definitions](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html).

A *URL rewrite* is a server-side operation to provide a resource from a different resource address. Rewriting a URL doesn't require a round-trip to the server. The rewritten URL is not returned to the client and won't appear in a browser's address bar. When **/resource** is *rewritten* to **/different-resource**, the client will request **/resource**, and the server will *internally* fetch the resource at **/different-resource**. Although the client might be able to retrieve the resource at the rewritten URL, the client won't be informed that the resource exists at the rewritten URL when it makes its request and receives the response.

![A WebAPI service endpoint has been changed from version 1 (v1) to version 2 (v2) on the server. A client makes a request to the service at the version 1 path /v1/api. The request URL is rewritten to access the service at the version 2 path /v2/api. The service responds to the client with a 200 (OK) status code.](url-rewriting/_static/url_rewrite.png)

## URL rewriting sample application
You can explore the features of the URL Rewriting Middleware with the [URL rewriting sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/url-rewriting/sample). The application applies rewrite and redirect rules and shows the resultant rewritten or redirected URL.

## When to use URL Rewriting Middleware
Use URL Rewriting Middleware when you are unable to use the [URL Rewrite module](https://www.iis.net/downloads/microsoft/url-rewrite) in IIS on Windows Server, the [Apache mod_rewrite module](https://httpd.apache.org/docs/2.4/rewrite/) on Apache Server, [URL rewriting on Nginx](https://www.nginx.com/blog/creating-nginx-rewrite-rules/), or your application is hosted on [WebListener server](xref:fundamentals/servers/weblistener). The main reasons to use the server-based URL rewriting technologies in IIS, Apache, or Nginx are that the middleware doesn't support the full features of these modules and the performance of the middleware probably won't match that of the modules. However, there are some features of the server modules that don't work with ASP.NET Core projects, such as the `IsFile` and `IsDirectory` constraints of the IIS Rewrite module. In these scenarios, you can use the middleware instead.

## Package
To include the middleware in your project, add a reference to the  [`Microsoft.AspNetCore.Rewrite`](https://www.nuget.org/packages/Microsoft.AspNetCore.Rewrite/) package. The middleware is available for projects that target .NET Framework 4.5.1 or .NET Standard 1.3 or higher.

## Extension and Options
Establish your URL rewrite and redirect rules by creating an instance of the `RewriteOptions` class with extension methods for each of your rules. Chain multiple rules in the order that you would like them processed. The `RewriteOptions` are passed into the URL Rewriting Middleware as it's added to the request pipeline with `app.UseRewriter(options);`.

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1)]

### URL Redirect
Use `AddRedirect()` to redirect requests. The first parameter will contain your regex for matching on the path of the incoming URL. The second parameter is the replacement string. The third parameter, if present, specifies the status code. If you don't specify the status code, it defaults to 302 (Found), which indicates that the resource has been temporarily moved or replaced.

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1&highlight=2)]

In a browser with developer tools enabled, make a request to the sample application with the path **/redirect-rule/1234/5678**. The regex matches the request path on `redirect-rule/(.*)`, and the path is replaced with **/redirected/1234/5678**. The redirect URL is sent back to the client with a 302 (Found) status code. The browser makes a new request at the redirect URL, which will appear in the browser's address bar. Since no rules in the sample application match on the redirect URL, the second request receives a 200 (OK) response from the application and the body of the response shows the redirect URL. A complete roundtrip is made to the server when a URL is *redirected*.

Original Request: **/redirect-rule/1234/5678**

![Browser window with Developer Tools tracking the requests and responses](url-rewriting/_static/add_redirect.png)

The part of the expression contained by parentheses is called a *capture group*. The dot (`.`) of the expression means *match any character*, and the asterisk (`*`) signifies to *match the preceding character zero or more times*. Therefore, the last two path segments of the URL, `1234/5678`, are captured by capture group `(.*)`. Any value you provide in the request URL after **redirect-rule/** will be captured by this single capture group.

In the replacement string, captured groups are injected into the string with the dollar sign (`$`) followed by the sequence number of the capture. The first capture group value is obtained with `$1`, the second with `$2`, and they continue in sequence for the capture groups in your regex. There is only one captured group in the redirect rule regex in the sample application, so there is only one injected group in the replacement string, which is `$1`. When the rule is applied, the URL becomes **/redirected/1234/5678**.

### URL Redirect to a secure endpoint
Use `AddRedirectToHttps()` to redirect insecure requests to the same host and path with secure HTTPS protocol (**https://**) with the flexibility to choose the status code and port. If the status code is not supplied, the middleware will default to 302 (Found). If the port is not supplied, the middleware will default to `null`, which means the protocol will change to **https://** and the client will access the resource on port 443. The example shows how to set the status code to 301 (Moved Permanently) and change the port to 5001.
```csharp
var options = new RewriteOptions()
    .AddRedirectToHttps(301, 5001);

app.UseRewriter(options);
```
Use `AddRedirectToHttpsPermanent()` to redirect insecure requests to the same host and path with secure HTTPS protocol (**https://** on port 443). The middleware will set the status code to 301 (Moved Permanently).

The sample application is capable of demonstrating how to use `AddRedirectToHttps()` or `AddRedirectToHttpsPermanent()`. Add the extension method to the `RewriteOptions()`. Make an insecure request to the application at any URL. In order to see the response in a browser, you will probably need to dismiss a browser security warning that the self-signed certificate is untrusted.

Original Request using `AddRedirectToHttps(301, 5001)`: **/secure**

![Browser window with Developer Tools tracking the requests and responses](url-rewriting/_static/add_redirect_to_https.png)

Original Request using `AddRedirectToHttpsPermanent()`: **/secure**

![Browser window with Developer Tools tracking the requests and responses](url-rewriting/_static/add_redirect_to_https_permanent.png)

### URL Rewrite
Use `AddRewrite()` to create a rules for rewriting URLs. The first parameter will contain your regex for matching on the incoming URL path. The second parameter is the replacement string. The third parameter, `skipRemainingRules: {true|false}`, will indicate to the middleware whether or not to skip additional rewrite rules if the current rule is applied.

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1&highlight=3)]

Original Request: **/rewrite-rule/1234/5678**

![Browser window with Developer Tools tracking the request and response](url-rewriting/_static/add_rewrite.png)

The first thing you will notice in the regex is the carat (`^`) at the beginning of the expression. This means that matching should be attempted starting at the beginning of the URL path.

In the earlier example with the redirect rule, `redirect-rule/(.*)`, there is no carat at the start of the regex; therefore, any characters may precede **redirect-rule/** in the path for a successful match.

Path | Match
--- | :---:
**/redirect-rule/1234/5678** | Yes
**/my-cool-redirect-rule/1234/5678** | Yes
**/anotherredirect-rule/1234/5678** | Yes

The rewrite rule, `^rewrite-rule/(\d+)/(\d+)`, will only match paths if they start with **rewrite-rule/**. Notice the difference in matching between the rewrite rule below and the redirect rule above.

Path | Match
--- | :---:
**/rewrite-rule/1234/5678** | Yes
**/my-cool-rewrite-rule/1234/5678** | No
**/anotherrewrite-rule/1234/5678** | No

Following the `^rewrite-rule/` portion of the expression, there are two capture groups, `(\d+)/(\d+)`. The `\d` signifies *match a digit (number)*. The plus sign (`+`) means *match one or more of the preceding character*. Therefore, the URL must contain a number followed by a forward-slash followed by another number. These capture groups are injected into the resultant rewritten URL as `$1` and `$2`. The rewrite rule replacement string places the captured groups into the querystring. The requested path of **/rewrite-rule/1234/5678** is rewritten to obtain the resource at **/rewritten?var1=1234&var2=5678**. If a querystring is present on the original request, it's preserved when the URL is rewritten.

There is no roundtrip to the server to obtain the resource. If the resource exists, it's fetched and returned to the client with a 200 (OK) status code. Because the client isn't redirected, the URL in the browser address bar doesn't change. As far as the client is concerned, the URL rewrite operation never occurred.

> [!NOTE]
> `skipRemainingRules: true` should be used whenever possible, because matching rules is an expensive process and slows down application response time. For the fastest application response, order your rewrite rules from most frequently matched to least frequently matched and skip the processing of the remaining rules when a match occurs and no additional rule processing is required.

### Apache mod_rewrite
You can apply Apache mod_rewrite rules with `AddApacheModRewrite()`. The first parameter takes an `IFileProvider`, which is provided in the sample application via [Dependency Injection](dependency-injection.md) by injecting the `IHostingEnvironment` and using it to provide the `ContentRootFileProvider`. The second parameter is the path to your rules file, which is *ApacheModRewrite.txt* in the sample application. You must make sure that the rules file is deployed with the application. For more information and examples of mod_rewrite rules, see [Apache mod_rewrite](https://httpd.apache.org/docs/2.4/rewrite/).

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1&highlight=4)]

The sample application will redirect requests from **/apache-mod-rules-redirect/(.\*)** to **/redirected?id=$1**. The response status code is 302 (Found).

[!code[Main](url-rewriting/sample/ApacheModRewrite.txt)]

Original Request: **/apache-mod-rules-redirect/1234**

![Browser window with Developer Tools tracking the requests and responses](url-rewriting/_static/add_apache_mod_redirect.png)

##### Supported server variables
The middleware supports the following Apache mod_rewrite server variables:
* CONN_REMOTE_ADDR
* HTTP_ACCEPT
* HTTP_CONNECTION
* HTTP_COOKIE
* HTTP_FORWARDED
* HTTP_HOST
* HTTP_REFERER
* HTTP_USER_AGENT
* HTTPS
* IPV6
* QUERY_STRING
* REMOTE_ADDR
* REMOTE_PORT
* REQUEST_FILENAME
* REQUEST_METHOD
* REQUEST_SCHEME
* REQUEST_URI
* SCRIPT_FILENAME
* SERVER_ADDR
* SERVER_PORT
* SERVER_PROTOCOL
* TIME
* TIME_DAY
* TIME_HOUR
* TIME_MIN
* TIME_MON
* TIME_SEC
* TIME_WDAY
* TIME_YEAR

### IIS URL Rewrite Module rules
To use rules that would normally apply to the IIS URL Rewrite Module, use `AddIISUrlRewrite()`. The first parameter takes an `IFileProvider`, while the second parameter is the path to your XML rules file, which is *IISUrlRewrite.xml* in the sample application. You must make sure that the rules file is deployed with the application. Don't point this at your *web.config* file, as these rules should be stored outside of your *web.config* to avoid conflicts with the IIS Rewrite module. For more information and examples of IIS URL Rewrite Module rules, see [Using Url Rewrite Module 2.0](https://www.iis.net/learn/extensions/url-rewrite-module/using-url-rewrite-module-20) and [URL Rewrite Module Configuration Reference](https://www.iis.net/learn/extensions/url-rewrite-module/url-rewrite-module-configuration-reference).

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1&highlight=5)]

The sample application will rewrite requests from **/iis-rules-rewrite/(.\*)** to **/rewritten?id=$1**. The response is sent to the client with a 200 (OK) status code.

[!code-xml[Main](url-rewriting/sample/IISUrlRewrite.xml)]

Original Request: **/iis-rules-rewrite/1234**

![Browser window with Developer Tools tracking the request and response](url-rewriting/_static/add_iis_url_rewrite.png)

If you have an active IIS Rewrite Module with server-level rules configured that would impact your application in undesirable ways, you can disable the IIS Rewrite Module for an application with a change to your *web.config* file. 
```xml
<configuration> 
 <system.webServer> 
  <modules> 
   <remove name="RewriteModule" /> 
  </modules> 
 </system.webServer> 
</configuration>
```

#### Unsupported features
The middleware does not support the following IIS URL Rewrite Module features:
* Global rules ([Basic Middleware #169](https://github.com/aspnet/BasicMiddleware/pull/169))
* Rewrite Maps ([Basic Middleware #168](https://github.com/aspnet/BasicMiddleware/pull/168))
* CustomResponse action ([Basic Middleware #135](https://github.com/aspnet/BasicMiddleware/issues/135))
* Custom Server Variables ([Basic Middleware #183](https://github.com/aspnet/BasicMiddleware/issues/183))
* trackAllCaptures ([Basic Middleware #178](https://github.com/aspnet/BasicMiddleware/pull/178))
* Wildcards
* LogRewrittenUrl

#### Supported server variables
The middleware supports the following IIS URL Rewrite Module server variables:
* CONTENT_LENGTH
* CONTENT_TYPE
* HTTP_ACCEPT
* HTTP_CONNECTION
* HTTP_COOKIE
* HTTP_HOST
* HTTP_REFERER
* HTTP_URL
* HTTP_USER_AGENT
* HTTPS
* LOCAL_ADDR
* QUERY_STRING
* REMOTE_ADDR
* REMOTE_PORT
* REQUEST_FILENAME
* REQUEST_URI

> [!NOTE]
> You can also obtain an `IFileProvider` via a `PhysicalFileProvider`. This approach may provide greater flexibility for the location of your rewrite rules files. Make sure that your rewrite rules files are deployed to the server at the path you provide.
> ```csharp
> PhysicalFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
> ```

### Method-based rule
Use `Add(Action\<RewriteContext\> applyRule)` to implement your own rule logic in a method. The `RewriteContext` exposes the `HttpContext` for use in your method. The `context.Result` determines how additional pipeline processing is handled.

`context.Result` | Action
--- | ---
`RuleResult.ContinueRules` (default) | Continue applying rules
`RuleResult.EndResponse` | Stop applying rules and send the response
`RuleResult.SkipRemainingRules` | Stop applying rules and send the context to the next middleware

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1&highlight=6)]

The sample application demonstrates a method that redirects requests for paths that end with **.xml**. If you make a request for **/file.xml**, it's redirected to **/xmlfiles/file.xml**. The status code is set to 301 (Moved Permanently). For a redirect, you must explicitly set the status code of the response; otherwise, a 200 (OK) status code will be returned and the redirect won't occur on the client.

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet2)]

Original Request: **/file.xml**

![Browser window with Developer Tools tracking the requests and responses for file.xml](url-rewriting/_static/add_redirect_xml_requests.png)

### IRule-based rule
Use `Add(IRule)` to implement your own rule logic in a class that derives from `IRule`. Using an `IRule` provides greater flexibility over using the method-based rule approach. Your derived class may include a constructor, where you can pass in parameters for the `ApplyRule` method.

[!code-csharp[Main](url-rewriting/sample/Startup.cs?name=snippet1&highlight=7-8)]

The values of the parameters in the sample application for the `extension` and the `newPath` are checked to meet several conditions. The `extension` must contain a value, and the value must be **.png**, **.jpg**, or **.gif**. If the `newPath` isn't valid, an `ArgumentException` is thrown. If you make a request for **/image.png**, it's redirected to **/png-images/image.png**. If you make a request for **/image.jpg**, it's redirected to **/jpg-images/image.jpg**. The status code is set to 301 (Moved Permanently), and the `context.Result` is set to stop processing rules and send the response.

[!code-csharp[Main](url-rewriting/sample/RewriteRule.cs?name=snippet1)]

Original Request: **/image.png**

![Browser window with Developer Tools tracking the requests and responses for image.png](url-rewriting/_static/add_redirect_png_requests.png)

Original Request: **/image.jpg**

![Browser window with Developer Tools tracking the requests and responses for image.jpg](url-rewriting/_static/add_redirect_jpg_requests.png)

## Regex Examples

Goal | Regex String &<br>Match Example | Replacement String &<br>Output Example
--- | :---: | :---:
Rewrite path into querystring | `^path/(.*)/(.*)`<br>**/path/abc/123** | `path?var1=$1&var2=$2`<br>/**path?var1=abc&var2=123**
Strip trailing slash | `(.*)/$`<br>**/path/** | `$1`<br>**/path**
Enforce trailing slash | `(.*[^/])$`<br>**/path** | `$1/`<br>**/path/**
Avoid rewriting specific requests | `(.*[^(\.axd)])$`<br>Yes: **/resource.htm**<br>No: **/resource.axd** | `rewritten/$1`<br>**/rewritten/resource.htm**<br>**/resource.axd**
Rearrange URL segments | `path/(.*)/(.*)/(.*)`<br>**path/1/2/3** | `path/$3/$2/$1`<br>**path/3/2/1**
Replace a URL segment | `^(.*)/segment2/(.*)`<br>**/segment1/segment2/segment3** | `$1/replaced/$2`<br>**/segment1/replaced/segment3**

## Additional Resources
* [Application Startup](startup.md)
* [Middleware](middleware.md)
* [Regular expressions in .NET](https://docs.microsoft.com/en-us/dotnet/articles/standard/base-types/regular-expressions)
* [Regular expression language - quick reference](https://docs.microsoft.com/en-us/dotnet/articles/standard/base-types/quick-ref)
* [Apache mod_rewrite](https://httpd.apache.org/docs/2.4/rewrite/)
* [Using Url Rewrite Module 2.0 (for IIS)](https://www.iis.net/learn/extensions/url-rewrite-module/using-url-rewrite-module-20)
* [URL Rewrite Module Configuration Reference](https://www.iis.net/learn/extensions/url-rewrite-module/url-rewrite-module-configuration-reference)
* [IIS URL Rewrite Module Forum](https://forums.iis.net/1152.aspx)
* [Keep a simple URL structure](https://support.google.com/webmasters/answer/76329?hl=en)
* [10 URL Rewriting Tips and Tricks](http://ruslany.net/2009/04/10-url-rewriting-tips-and-tricks/)
* [To slash or not to slash](https://webmasters.googleblog.com/2010/04/to-slash-or-not-to-slash.html)
