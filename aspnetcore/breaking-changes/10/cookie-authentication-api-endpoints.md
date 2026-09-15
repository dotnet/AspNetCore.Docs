---
title: "Cookie login redirects are disabled for known API endpoints"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 10 where cookie authentication no longer redirects to login or access denied URIs for known API endpoints."
ms.custom: https://github.com/aspnet/Announcements/issues/525
ms.date: 09/15/2026
---

# Cookie login redirects are disabled for known API endpoints

By default, unauthenticated and unauthorized requests made to known API endpoints protected by cookie authentication now result in 401 and 403 responses rather than redirecting to a login or access-denied URI.

Known API [endpoints](/aspnet/core/fundamentals/routing) are identified using the new <xref:Microsoft.AspNetCore.Http.Metadata.IDisableCookieRedirectMetadata> interface, and metadata implementing the new interface has been added automatically to the following:

- [`[ApiController]`](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) endpoints.
- Minimal API endpoints that read JSON request bodies or write JSON responses.
- Endpoints using <xref:Microsoft.AspNetCore.Http.TypedResults> return types.
- SignalR endpoints.

The companion <xref:Microsoft.AspNetCore.Http.Metadata.IAllowCookieRedirectMetadata> interface opts an endpoint back in to redirects. It overrides `IDisableCookieRedirectMetadata` no matter the order in which the metadata is added.

The 401 and 403 responses still include a `Location` header holding the login or access-denied URI. Only the status code changes.

Only the challenge (401) and forbid (403) paths consider endpoint metadata. Sign-out and return-URL redirects are unaffected.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, the cookie authentication handler redirected unauthenticated and unauthorized requests to a login or access-denied URI by default for all requests other than [XMLHttpRequests (XHRs)](https://developer.mozilla.org/docs/Web/API/XMLHttpRequest).

## New behavior

Starting in .NET 10, unauthenticated and unauthorized requests made to known API endpoints result in 401 and 403 responses rather than redirecting to a login or access-denied URI. XHRs continue to result in 401 and 403 responses regardless of the target endpoint.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

This change was highly requested. Redirecting unauthenticated requests to a login page doesn't usually make sense for API endpoints, which typically rely on 401 and 403 status codes rather than HTML redirects to communicate auth failures.

## Recommended action

To restore the previous behavior for the whole app, enable the `Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata` switch. Cookie authentication then ignores endpoint metadata, and only XHRs result in 401 and 403 responses, which matches the pre-.NET 10 behavior. Set the switch in the project file so that it applies before any app code runs:

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption
    Include="Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata"
    Value="true" />
</ItemGroup>
```

The switch is read once, the first time cookie authentication is used, so if you set it in code instead, call <xref:System.AppContext.SetSwitch%2A> before the host is built:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Authentication.Cookies.IgnoreRedirectMetadata", true);

var builder = WebApplication.CreateBuilder(args);
```

To restore redirects for individual endpoints instead, call <xref:Microsoft.AspNetCore.Builder.CookieRedirectEndpointConventionBuilderExtensions.AllowCookieRedirect*> or apply the <xref:Microsoft.AspNetCore.Http.AllowCookieRedirectAttribute> to an action method or controller class:

```csharp
app.MapGet("/reports/summary", () => new ReportSummary(1000))
   .AllowCookieRedirect();
```

Conversely, call <xref:Microsoft.AspNetCore.Builder.CookieRedirectEndpointConventionBuilderExtensions.DisableCookieRedirect*> to return 401 and 403 status codes for endpoints that aren't detected as API endpoints automatically.

If you want to always redirect to the login and access-denied URIs for unauthenticated or unauthorized requests regardless of the target endpoint or whether the source of the request is an XHR, you can override <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogin*> and <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToAccessDenied*> as follows:

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

If you want to revert to the exact previous behavior that avoids redirecting for only XHRs, you can override the events with this slightly more complicated logic:

```csharp
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        bool IsXhr(HttpRequest request)
        {
            return string.Equals(request.Query[HeaderNames.XRequestedWith], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers.XRequestedWith, "XMLHttpRequest", StringComparison.Ordinal);
        }

        options.Events.OnRedirectToLogin = context =>
        {
            if (IsXhr(context.Request))
            {
                context.Response.Headers.Location = context.RedirectUri;
                context.Response.StatusCode = 401;
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }

            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            if (IsXhr(context.Request))
            {
                context.Response.Headers.Location = context.RedirectUri;
                context.Response.StatusCode = 403;
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }

            return Task.CompletedTask;
        };
    });
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Http.Metadata.IDisableCookieRedirectMetadata?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.Metadata.IAllowCookieRedirectMetadata?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.AllowCookieRedirectAttribute?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Builder.CookieRedirectEndpointConventionBuilderExtensions.DisableCookieRedirect*?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Builder.CookieRedirectEndpointConventionBuilderExtensions.AllowCookieRedirect*?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogin*?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToAccessDenied*?displayProperty=fullName>

## See also

- [API endpoint authentication behavior in ASP.NET Core](/aspnet/core/security/authentication/api-endpoint-auth?view=aspnetcore-10.0&preserve-view=true)
