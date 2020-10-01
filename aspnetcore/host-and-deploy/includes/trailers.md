HTTP Trailers are similar to HTTP Headers, except they are sent after the response body is sent. For IIS and HTTP.SYS, only HTTP/2 response trailers are supported.

```csharp
if (httpContext.Response.SupportsTrailers())
{
    // Write body
    httpContext.Response.WriteAsync("Hello world");

    httpContext.Response.AppendTrailer("trailername", "TrailerValue");
}
```

In the preceding example code:

* `SupportsTrailers` ensures that trailers are supported for the response.
* `AppendTrailer` appends the trailer.

For HTTP/1.1 requests, Response Trailers must be declared before writing to the response body, by calling `DeclareTrailer`.

```csharp
if (httpContext.Response.SupportsTrailers())
{
    httpContext.Response.DeclareTrailer("trailername");	

    // Write body
    httpContext.Response.WriteAsync("Hello world");

    httpContext.Response.AppendTrailer("trailername", "TrailerValue");
}
```