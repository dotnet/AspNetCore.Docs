---
title: "Cookie login redirects are disabled for known API endpoints"
description: "Learn about the breaking change in ASP.NET Core 10 where cookie authentication no longer redirects to login or access denied URIs for known API endpoints."
ms.date: 08/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/525
---

# Cookie login redirects are disabled for known API endpoints

By default, unauthenticated and unauthorized requests made to known API endpoints protected by cookie authentication now result in 401 and 403 responses rather than redirecting to a login or access-denied URI.

Known API [endpoints](/aspnet/core/fundamentals/routing) are identified using the new `IApiEndpointMetadata` <!--xref:Microsoft.AspNetCore.Http.Metadata.IApiEndpointMetadata--> interface, and metadata implementing the new interface has been added automatically to the following:

- [`[ApiController]`](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) endpoints.
- Minimal API endpoints that read JSON request bodies or write JSON responses.
- Endpoints using <xref:Microsoft.AspNetCore.Http.TypedResults> return types.
- SignalR endpoints.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, the cookie authentication handler redirected unauthenticated and unauthorized requests to a login or access-denied URI by default for all requests other than [XMLHttpRequests (XHRs)](https://developer.mozilla.org/docs/Web/API/XMLHttpRequest).

## New behavior

Starting in .NET 10, unauthenticated and unauthorized requests made to known API endpoints result in 401 and 403 responses rather than redirecting to a login or access-denied URI. XHRs continue to result in 401 and 403 responses regardless of the target endpoint.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was highly requested. Redirecting unauthenticated requests to a login page doesn't usually make sense for API endpoints, which typically rely on 401 and 403 status codes rather than HTML redirects to communicate auth failures.

## Recommended action

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

- `Microsoft.AspNetCore.Http.Metadata.IApiEndpointMetadata` <!--xref:Microsoft.AspNetCore.Http.Metadata.IApiEndpointMetadata?displayProperty=fullName-->
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogin*?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToAccessDenied*?displayProperty=fullName>
