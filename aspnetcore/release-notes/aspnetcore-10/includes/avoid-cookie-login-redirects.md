### Avoid cookie login redirects for known API endpoints

By default, unauthenticated and unauthorized requests made to known API endpoints protected by cookie authentication now result in 401 and 403 responses rather than redirecting to a login or access denied URI.

This change was [highly requested](https://github.com/dotnet/aspnetcore/issues/9039), because redirecting unauthenticated requests to a login page doesn't usually make sense for API endpoints which typically rely on 401 and 403 status codes rather than HTML redirects to communicate auth failures.

Known API [Endpoints](https://learn.microsoft.com/aspnet/core/fundamentals/routing) are identified using the new `IApiEndpointMetadata` interface, and metadata implementing the new interface has been added automatically to the following:

- `[ApiController]` endpoints
- Minimal API endpoints that read JSON request bodies or write JSON responses
- Endpoints using `TypedResults` return types
- SignalR endpoints

When `IApiEndpointMetadata` is present, the cookie authentication handler now returns appropriate HTTP status codes (401 for unauthenticated requests, 403 for forbidden requests) instead of redirecting.

If you want to prevent this new behavior, and always redirect to the login and access denied URIs for unauthenticated or unauthorized requests regardless of the target endpoint, you can override the `RedirectToLogin` and `RedirectToAccessDenied` events as follows:

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

For more information about this breaking change, see [ASP.NET Core breaking changes announcement](https://github.com/aspnet/Announcements/issues/525).