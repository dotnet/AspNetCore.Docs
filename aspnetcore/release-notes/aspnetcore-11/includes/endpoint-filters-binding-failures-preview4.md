### Endpoint filters observe parameter-binding failures

When a minimal API endpoint has any filters or filter factories configured, the filter pipeline now runs even if parameter binding fails. Filters can read `HttpContext.Response.StatusCode == 400` and substitute their own response body.

In the `Development` environment, set `RouteHandlerOptions.ThrowOnBadRequest = false` so the framework returns a 400 that the filter can observe instead of throwing <xref:Microsoft.AspNetCore.Http.BadHttpRequestException> to the developer exception page. This is already the default in non-`Development` environments.

Thank you [@marcominerva](https://github.com/marcominerva) for this contribution!
