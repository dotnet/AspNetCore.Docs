The response caching middleware enables the caching of server responses based on [HTTP Cache-Control headers](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Cache-Control).

* Caching behavior implements standard HTTP caching semantics.

* Caching is based on HTTP cache headers similar to the method used by proxies.

* This form of caching is useful for public GET or HEAD API requests from clients where the [conditions for caching](xref:performance/caching/middleware#cfc) are satisfied.

* For UI apps like Razor Pages, response caching isn't typically beneficial. Browsers commonly set request headers that prevent caching.

  [Output caching](xref:performance/caching/output) (available in .NET 7 and later) is a better approach for UI apps. In this scenario, the configuration determines what to cache independent of HTTP headers.

To test response caching, use [Fiddler](https://www.telerik.com/fiddler) or another tool that can explicitly set request headers. Setting headers explicitly is preferred for testing caching. For more information, see [Response caching middleware > Troubleshooting](xref:performance/caching/middleware#troubleshooting).