# ASP.NET Core Response Caching Sample

This sample illustrates the usage of ASP.NET Core [Response Caching Middleware](https://docs.microsoft.com/aspnet/core/performance/caching/middleware).

The app responds with its Index page, including a `Cache-Control` header to configure caching behavior. The app also sets the `Vary` header to configure the cache to serve the response only if the `Accept-Encoding` header of subsequent requests matches that from the original request.

When running the sample, the Index page is served from cache when stored and cached for up to 10 seconds.

To test caching behavior:

* Don't use a browser to test caching behavior. Browsers often add a cache control header on reload that prevent the middleware from serving a cached page. For example, a `Cache-Control` header with a value of `max-age=0`) might be added by the browser.
* Use a developer tool that permits setting the request headers explicitly, such as <a href="https://www.telerik.com/fiddler">Fiddler</a> or <a href="https://www.getpostman.com/">Postman</a>.
