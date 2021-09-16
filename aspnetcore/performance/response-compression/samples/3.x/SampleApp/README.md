# Response compression sample application (ASP.NET Core 3.x)

This sample illustrates the use of ASP.NET Core 3.x Response Compression Middleware to compress HTTP responses. The sample demonstrates Gzip, Brotli, and custom compression providers for text and image responses and shows how to add a MIME type for compression. For the ASP.NET Core 2.x sample, see [Response compression sample application (ASP.NET Core 2.x)](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/performance/response-compression/samples/2.x).

## Examples in this sample

* `BrotliCompressionProvider`
  * `text/plain`
    * **/** - Lorem Ipsum text file response at 2,044 bytes that compresses to ~979 bytes.
    * **/testfile1kb.txt** - Text file response at 1,033 bytes that compresses to ~36 bytes.
    * **/trickle** - Response issued as single characters at 1 second intervals.
* `GzipCompressionProvider`
  * `text/plain`
    * **/** - Lorem Ipsum text file response at 2,044 bytes that compresses to ~927 bytes.
    * **/testfile1kb.txt** - Text file response at 1,033 bytes that compresses to ~47 bytes.
    * **/trickle** - Response issued as single characters at 1 second intervals.
  * `image/svg+xml`
    * **/banner.svg** - A Scalable Vector Graphics (SVG) image response at 9,707 bytes that compresses to ~4,459 bytes.
* `CustomCompressionProvider`<br>Shows how to implement a custom compression provider for use with the middleware.

When the request includes the `Accept-Encoding` header and response compression is successful, the middleware automatically adds a `Vary: Accept-Encoding` header to the response. The `Vary` header instructs caches to maintain multiple copies of the response based on alternative values of `Accept-Encoding`, so both a compressed (Gzip or Brotli) and uncompressed version are stored in caches for systems that can either accept the compressed or the uncompressed response.

## Use the sample

1. Make a request using [Fiddler](https://www.telerik.com/fiddler), [Firefox Browser Developer](https://www.mozilla.org/firefox/developer/), or [Postman](https://www.getpostman.com/) to the application without an `Accept-Encoding` header and note the response payload, response size, and response headers.
1. Add an `Accept-Encoding: br` or `Accept-Encoding: gzip` header and note the compressed response size and response headers. The response size drops, and the `Content-Encoding` response header is included by the middleware indicating that compression with either Gzip or Brotli occurred. When you look at the response body for the Lorem Ipsum or **testfile1kb.txt** response, you see that the text is compressed and unreadable.
1. Add an `Accept-Encoding: mycustomcompression` header and note the response headers. The `CustomCompressionProvider` is an empty implementation that doesn't actually compress the response, but you can create a custom compression stream wrapper for the `CreateStream()` method.
