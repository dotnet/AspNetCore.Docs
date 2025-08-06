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

Starting with ASP.NET Core 10, the framework introduces a significant improvement in how authentication failures are handled for API endpoints when using cookie authentication. This change addresses the common issue where API endpoints would redirect unauthenticated requests to login pages, which is inappropriate for programmatic API access.

## The problem

In previous versions of ASP.NET Core, when using cookie authentication, all unauthenticated requests would trigger a redirect to the configured login page. This behavior was problematic for API endpoints because:

- API clients don't expect HTML login pages
- Redirects return 302 status codes instead of proper 401/403 codes
- API clients need clear HTTP status codes to handle authentication failures appropriately

## The solution in ASP.NET Core 10

ASP.NET Core 10 automatically detects known API endpoints and modifies the authentication behavior:

- **Web pages**: Continue to redirect to login pages as before
- **API endpoints**: Return appropriate 401 (Unauthorized) or 403 (Forbidden) status codes without redirects

## Which endpoints are considered API endpoints?

The framework automatically identifies the following as API endpoints:

- Controllers decorated with `[ApiController]` attribute
- Minimal API endpoints registered with `MapGet`, `MapPost`, `MapPut`, `MapDelete`, etc.
- Endpoints that explicitly request JSON responses
- SignalR hubs and endpoints

## Behavior differences

### Before ASP.NET Core 10

```http
GET /api/secure-data HTTP/1.1
Host: example.com

HTTP/1.1 302 Found
Location: /Account/Login?ReturnUrl=%2Fapi%2Fsecure-data
```

### ASP.NET Core 10 and later

```http
GET /api/secure-data HTTP/1.1
Host: example.com

HTTP/1.1 401 Unauthorized
WWW-Authenticate: Cookie
```

## Configuring the behavior

While the default behavior works for most scenarios, you can customize it if needed:

```csharp
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        // The framework automatically handles API endpoints
        // No additional configuration needed
    });
```

If you need to override the automatic detection for specific endpoints, you can use the `[Authorize]` attribute with specific authentication schemes or implement custom authentication handlers.

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