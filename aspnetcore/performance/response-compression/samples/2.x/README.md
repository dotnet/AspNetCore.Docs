# Response compression sample application (ASP.NET Core 2.x)

This sample illustrates the use of ASP.NET Core 2.x Response Compression Middleware to compress HTTP responses for. The sample demonstrates Gzip and custom compression providers for text and image responses and shows how to add a MIME type for compression. For the ASP.NET Core 1.x sample, see [Response compression sample application (ASP.NET Core 1.x)](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/samples/1.x).

## Examples in this sample
* `GzipCompressionProvider`
  * `text/plain`
    * **/** - Lorem Ipsum text file response at 2,044 bytes that will compress to 927 bytes
    * **/testfile1kb.txt** - Text file response at 1,033 bytes that will compress to 47 bytes
    * **/trickle** - Response issued as single characters at 1 second intervals 
  * `image/svg+xml`
    * **/banner.svg** - A Scalable Vector Graphics (SVG) image response at 9,707 bytes that will compress to 4,459 bytes
* `CustomCompressionProvider`<br>Shows how to implement a custom compression provider for use with the middleware

When the request includes the `Accept-Encoding` header and response compression is successful, the middleware automatically adds a `Vary: Accept-Encoding` header to the response. The `Vary` header instructs caches to maintain multiple copies of the response based on alternative values of `Accept-Encoding`, so both a compressed (gzip) and uncompressed version are stored in caches for systems that can either accept the compressed or the uncompressed response.

## Using the sample
1. Make a request using [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/) to the application without an `Accept-Encoding` header and note the response payload, response size, and response headers.
2. Add an `Accept-Encoding: gzip` header and note the compressed response size and response headers. The response size drops, and the `Content-Encoding: gzip` response header is included by the middleware. When you look at the response body for the Lorem Ipsum or **testfile1kb.txt** response, you see that the text is compressed and unreadable.
3. Add an `Accept-Encoding: mycustomcompression` header and note the response headers. The `CustomCompressionProvider` is an empty implementation that doesn't actually compress the response, but you can create a custom compression stream wrapper for the `CreateStream()` method.
