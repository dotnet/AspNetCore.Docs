# ASP.NET Core Response Caching Sample (ASP.NET Core 2.x)

This sample illustrates the usage of ASP.NET Core [Response Caching Middleware](xref:performance/caching/middleware) with ASP.NET Core 2.x. For the ASP.NET Core 1.x sample, see [ASP.NET Core Response Caching Sample (ASP.NET Core 1.x)](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/caching/middleware/samples/1.x).

The application sends a `Hello World!` message and the current time along with a `Cache-Control` header to configure caching behavior. The application also sends a `Vary` header to configure the cache to serve the response only if the `Accept-Encoding` header of subsequent requests matches that from the original request.

When running the sample, a response is served from cache when possible and stored for up to 10 seconds.
