---
title: API endpoint authentication behavior in ASP.NET Core
author: wadepickett
description: Learn how ASP.NET Core 10 and later handles authentication failures for API endpoints using cookie authentication.
ai-usage: ai-assisted
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.date: 08/06/2025
uid: security/authentication/api-endpoint-auth
---

# API endpoint authentication behavior in ASP.NET Core

:::moniker range=">= aspnetcore-10.0"

When using cookie authentication, API endpoints return appropriate HTTP status codes—such as 401 (Unauthorized) or 403 (Forbidden)—when authentication fails. This approach avoids redirecting unauthenticated requests login pages, which is more suitable for programmatic access scenarios like API clients. This behavior was introduced starting with ASP.NET Core in .NET 10.

## How ASP.NET Core identifies API endpoints

ASP.NET Core automatically applies this behavior to endpoints it recognizes as API-related, including:

- Controllers decorated with the `[ApiController]` attribute
- Minimal API endpoints registered with `MapGet`, `MapPost`, `MapPut`, `MapDelete`, etc.
- Endpoints that explicitly request JSON responses
- SignalR hubs and endpoints

## Default behavior and customization

By default, ASP.NET Core applies cookie authentication logic based on the endpoint type:

- **Web pages**: Redirect to login pages
- **API endpoints**: Return 401 or 403 status codes without redirects

## Configuring the behavior

While the default behavior works for most scenarios, it can be customize if needed:

```csharp
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        // The framework automatically handles API endpoints
        // No additional configuration needed
    });
```

If you need to override the automatic detection for specific endpoints, use the `[Authorize]` attribute with specific authentication schemes or implement custom authentication handlers.

## Migration considerations

This change is designed to be non-breaking for existing applications:

- **Web applications**: Continue to work as before with login page redirects
- **Mixed applications**: API endpoints get proper status codes while web pages get redirects
- **API-only applications**: Benefit from proper HTTP status codes without additional configuration

### Testing your API endpoints

After upgrading to ASP.NET Core 10, verify that your API endpoints return appropriate status codes:

```csharp
[Test]
public async Task UnauthorizedApiRequest_Returns401()
{
    var response = await client.GetAsync("/api/secure-data");
    Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    Assert.False(response.Headers.Location != null); // No redirect
}
```

## Related topics

- <xref:security/authentication/cookie>
- <xref:web-api/index>
- <xref:fundamentals/minimal-apis/responses>
- <xref:signalr/authn-and-authz>

:::moniker-range-end
