### Kestrel applies trailer header timeouts

Kestrel now applies `RequestHeadersTimeout` to fragmented HTTP/2 and HTTP/3 trailer headers that don't finish sending the header block. The same timeout that protects initial request headers now also prevents connections from staying open indefinitely while Kestrel waits for trailer `HEADERS` frames to complete.

```csharp
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(10);
});
```
