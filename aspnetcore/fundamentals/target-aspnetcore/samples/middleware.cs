public async Task Invoke(HttpContext httpContext)
{
    if (httpContext.Request.Path.StartsWithSegments(_path, StringComparison.Ordinal))
    {
        httpContext.Response.StatusCode = (int) HttpStatusCode.OK;
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.ContentLength = _bufferSize;

#if !NETCOREAPP3_1 && !NETCOREAPP5_0
        var syncIOFeature = httpContext.Features.Get<IHttpBodyControlFeature>();
        if (syncIOFeature != null)
        {
            syncIOFeature.AllowSynchronousIO = true;
        }

        using (var sw = new StreamWriter(
            httpContext.Response.Body, _encoding, bufferSize: _bufferSize))
        {
            _json.Serialize(sw, new JsonMessage { message = "Hello, World!" });
        }
#else
        await JsonSerializer.SerializeAsync<JsonMessage>(
            httpContext.Response.Body, new JsonMessage { message = "Hello, World!" });
#endif
        return;
    }

    await _next(httpContext);
}
