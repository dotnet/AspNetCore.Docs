---
title: API endpoint authentication behavior in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how ASP.NET Core 10 and later handles authentication failures for API endpoints using cookie authentication.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.date: 09/15/2026
uid: security/authentication/api-endpoint-auth
---

# API endpoint authentication behavior in ASP.NET Core

:::moniker range=">= aspnetcore-10.0"

When using cookie authentication, API endpoints return the appropriate HTTP status codes (401 or 403) for authentication failures instead of redirecting unauthenticated requests to login pages. This behavior, which is more suitable for programmatic API access, was introduced in ASP.NET Core in .NET 10.

## How ASP.NET Core identifies API endpoints

ASP.NET Core adds <xref:Microsoft.AspNetCore.Http.Metadata.IDisableCookieRedirectMetadata> to the endpoints that it recognizes as API endpoints, including:

* Controllers decorated with the `[ApiController]` attribute.
* Minimal API endpoints that read JSON request bodies or write JSON responses.
* Endpoints using <xref:Microsoft.AspNetCore.Http.TypedResults> return types.
* SignalR hubs and endpoints.

Detection is based on metadata that's inferred when the app builds its endpoints. It isn't based on the `Accept` header of an incoming request, and it isn't based on which `Map{Verb}` method registered the route.

A minimal API handler whose declared return type is `void`, `string`, or the <xref:Microsoft.AspNetCore.Http.IResult> interface doesn't contribute the metadata through its return type, although the concrete `TypedResults` types such as `Ok<TValue>` do. For example, `app.MapGet("/hello", () => "Hello").RequireAuthorization()` writes a `text/plain` response and takes no JSON request body, so unauthenticated requests to it still redirect to the login page.

## Default behavior

By default, ASP.NET Core applies cookie authentication logic based on the endpoint type:

* **Web pages**: Redirect to the login or access-denied page with a 302 status code.
* **API endpoints**: Return 401 or 403 status codes instead of a 302 redirect.

[XMLHttpRequests (XHRs)](https://developer.mozilla.org/docs/Web/API/XMLHttpRequest) receive 401 and 403 responses regardless of the endpoint they target. That behavior predates .NET 10 and is unchanged.

> [!NOTE]
> Endpoint metadata only affects the challenge (401) and forbid (403) paths. Sign-out redirects aren't affected. When a sign-out request specifies a redirect URI or a valid return URL, non-XHR requests redirect as they did before .NET 10. XHR behavior is unchanged.

## Configure the behavior for specific endpoints

Call <xref:Microsoft.AspNetCore.Builder.CookieRedirectEndpointConventionBuilderExtensions.DisableCookieRedirect*> to return 401 and 403 status codes for endpoints that aren't detected automatically:

```csharp
var api = app.MapGroup("/api").DisableCookieRedirect();

api.MapGet("/status", () => "Ready")
   .RequireAuthorization();
```

Call <xref:Microsoft.AspNetCore.Builder.CookieRedirectEndpointConventionBuilderExtensions.AllowCookieRedirect*> to keep login redirects for endpoints that are detected as API endpoints:

```csharp
app.MapGet("/reports/summary", () => new { Total = 1000 })
   .RequireAuthorization()
   .AllowCookieRedirect();
```

For controllers, apply the <xref:Microsoft.AspNetCore.Http.AllowCookieRedirectAttribute> to an action method or to the controller class:

```csharp
[ApiController]
[Authorize]
[AllowCookieRedirect]
[Route("[controller]")]
public class ReportsController : ControllerBase
{
    [HttpGet("summary")]
    public object GetSummary() => new { Total = 1000 };
}
```

> [!IMPORTANT]
> <xref:Microsoft.AspNetCore.Http.Metadata.IAllowCookieRedirectMetadata> overrides <xref:Microsoft.AspNetCore.Http.Metadata.IDisableCookieRedirectMetadata> no matter the order in which the metadata is added. Calling `DisableCookieRedirect` after `AllowCookieRedirect` on the same endpoint doesn't restore the status code behavior.

## Opt out of the behavior app-wide

To restore the pre-.NET 10 behavior for an entire app, enable the `Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata` switch. When it's enabled, cookie authentication ignores endpoint metadata and only XHRs result in 401 and 403 responses.

Set the switch in the project file so that it applies before any app code runs:

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption
    Include="Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata"
    Value="true" />
</ItemGroup>
```

The switch can also be set in code. It's read once, the first time cookie authentication is used, so call <xref:System.AppContext.SetSwitch%2A> before the host is built:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata", true);

var builder = WebApplication.CreateBuilder(args);
```

## Breaking change considerations

The change introduced in .NET 10 is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change). An app that combines cookie authentication with endpoints that ASP.NET Core detects as API endpoints returns 401 and 403 responses where it previously returned a 302 redirect to the login or access-denied page. For the full breaking change notice, see [Cookie login redirects are disabled for known API endpoints](/aspnet/core/breaking-changes/10/cookie-authentication-api-endpoints).

Consider the impact on each kind of app:

* **Web applications**: Page endpoints continue to redirect to the login page.
* **Mixed applications**: API endpoints return status codes while web pages get redirects, so browser code that followed the redirect must handle 401 and 403 instead.
* **API-only applications**: Return proper HTTP status codes without additional configuration.

To keep the previous behavior, call `AllowCookieRedirect` on the affected endpoints, apply `[AllowCookieRedirect]` to the affected controllers, or enable the `Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata` switch for the whole app.

### Testing your API endpoints

After upgrading to ASP.NET Core in .NET 10, verify that your API endpoints return appropriate status codes:

```csharp
[Fact]
public async Task UnauthorizedApiRequest_Returns401()
{
    var response = await client.GetAsync("/api/secure-data");

    Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

    // The handler sets the Location header before setting the status code,
    // so the login URI is still present on the 401 response.
    Assert.NotNull(response.Headers.Location);
}
```

## Related topics

* <xref:security/authentication/cookie>
* <xref:web-api/index>
* <xref:fundamentals/minimal-apis/responses>
* <xref:signalr/authn-and-authz>
* [Cookie login redirects are disabled for known API endpoints](/aspnet/core/breaking-changes/10/cookie-authentication-api-endpoints)

:::moniker-end
