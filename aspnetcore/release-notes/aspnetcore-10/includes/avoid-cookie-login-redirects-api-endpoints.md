### Avoid cookie login redirects for known API endpoints

Starting in .NET 10, unauthenticated and unauthorized requests to known API endpoints protected by cookie authentication now return HTTP 401 (Unauthorized) or 403 (Forbidden) responses, rather than redirecting to a login or access denied URI.

This change was [highly requested](https://github.com/dotnet/aspnetcore/issues/9039), because redirecting unauthenticated API requests to a login page is typically inappropriate for APIs. API clients expect authentication and authorization failures to be communicated using HTTP status codes, not HTML redirects.

Known API [endpoints](https://learn.microsoft.com/aspnet/core/fundamentals/routing) are identified using the new `IApiEndpointMetadata` interface. Metadata implementing this interface is now automatically applied to:

- `[ApiController]` endpoints
- Minimal API endpoints that read JSON request bodies or write JSON responses
- Endpoints using `TypedResults` return types
- SignalR endpoints

When `IApiEndpointMetadata` is present, the cookie authentication handler returns the appropriate status code (401 for unauthenticated requests, 403 for forbidden requests) instead of performing a redirect.

#### Restoring previous redirect behavior

To prevent this new behavior, and always redirect to the login and access denied URIs for unauthenticated or unauthorized requests regardless of the target endpoint, you can override the `RedirectToLogin` and `RedirectToAccessDenied` as follows:

```csharp
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
        };
    });
```

For more information about this breaking change, see [this GitHub issue](https://github.com/aspnet/Announcements/issues/525).
