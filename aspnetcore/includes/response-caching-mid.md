---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
The Response caching middleware:

* Enables caching server responses based on [HTTP cache headers](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control). Implements the standard HTTP caching semantics. Caches based on HTTP cache headers like proxies do.
* Is typically not beneficial for UI apps such as Razor Pages because browsers generally set request headers that prevent caching. Output caching is being considered for the next version of ASP.NET Core, which will benefit UI apps. With output caching, configuration decides what should be cached independently of HTTP headers. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/27387).
* May be beneficial for public GET or HEAD API requests from clients where the [Conditions for caching](xref:performance/caching/middleware#cfc) are met.

Use [Fiddler](https://www.telerik.com/fiddler), [Postman](https://www.getpostman.com/), or another tool that can explicitly set request headers. Setting headers explicitly is preferred for testing caching. For more information, see [Troubleshooting](xref:performance/caching/middleware#troubleshooting)