# Response compression sample application (DefaultsSample)

This sample illustrates the use of ASP.NET Core Response Compression Middleware to compress application responses with default settings. The default settings for compression use the `GzipCompressionProvider` with fastest compression and the default MIME types:
* text/plain
* text/css
* application/javascript
* text/html
* application/xml
* text/xml
* application/json
* text/json

## Examples in this sample
`GzipCompressionProvider`: `text/plain`: **/** - Lorem Ipsum text file response at 2,044 bytes that will compress to 927 bytes

When the request includes the `Accept-Encoding` header, the sample adds a `Vary: Accept-Encoding` header to the response. The `Vary` header instructs caches to maintain multiple copies of the response based on alternative values of `Accept-Encoding`, so both a compressed (gzip) and uncompressed version will be stored in caches for systems that can either accept the compressed or the uncompressed response.

## Using the sample
1. Make a request using [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/) to the application without an `Accept-Encoding` header and note the response payload, response size, and response headers.
2. Add an `Accept-Encoding: gzip` header and note the compressed response size and response headers. You will see the response size drop and the `Content-Encoding: gzip` response header. When you look at the response body, you will see that the text has been compressed and is unreadable.
