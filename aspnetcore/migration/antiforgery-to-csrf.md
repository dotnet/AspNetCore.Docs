---
title: Adopt automatic CSRF protection in .NET 11
ai-usage: ai-assisted
author: tdykstra
description: Use the automatic CSRF protection introduced in .NET 11 to simplify or replace the token-based antiforgery system in an existing ASP.NET Core app.
monikerRange: '>= aspnetcore-11.0'
ms.author: tdykstra
ms.date: 06/17/2026
uid: migration/antiforgery-to-csrf
---
# Adopt automatic CSRF protection in .NET 11

.NET 11 ships an automatic Cross-Site Request Forgery (CSRF) protection middleware that validates `Sec-Fetch-Site` and `Origin` headers on every request. It's enabled by default and, for many modern apps, is sufficient on its own. This article helps app authors who are upgrading from .NET 10 decide whether to simplify their existing antiforgery setup, and walks through the steps to do so.

For a full reference on how the new middleware works, see <xref:security/csrf-protection>.

If something stops working after the upgrade — most commonly cross-origin requests from a Single Page App (SPA) that now return HTTP `400` — see [After upgrade: if requests start failing](#after-upgrade-if-requests-start-failing).

## Should I keep the token-based antiforgery system?

Most apps that use the token-based system have `app.UseAntiforgery()` and the `__RequestVerificationToken` plumbing in place. The new middleware doesn't remove or replace any of that — the two protections coexist. The choice is whether to keep both as defense in depth, or simplify by removing the older token-based system.

**Keep the token-based system when:**

* The app must support browsers that don't send `Sec-Fetch-Site`. See the [Browser support](xref:security/csrf-protection#browser-support) section of the reference doc for the baseline.
* A security review or compliance requirement specifies the token defense as an independent layer.
* The app uses `IAntiforgeryAdditionalDataProvider` to round-trip extra data inside the antiforgery token.

**Consider dropping the token-based system when:**

* The app targets modern evergreen browsers only.
* Defense in depth at the token layer isn't a hard requirement.

If unsure, keep both. They're complementary, and there's no functional conflict between them.

## Simplify: drop the token-based system

For apps that fit the second list above, the automatic CSRF middleware alone is enough to defend against the classic CSRF attack. Dropping the token-based system removes the token round-trip, the [Data Protection](xref:security/data-protection/introduction) dependency that the antiforgery system uses for token encryption, and the `IAntiforgery` calls in views and page handlers.

### What to remove

| Item | Where it appears | Reason it can go |
|---|---|---|
| `app.UseAntiforgery()` | `Program.cs` | The automatic CSRF middleware is registered by default. |
| `services.AddAntiforgery(...)` (when used only to configure options) | `Program.cs` | Only needed when the token system is in use. |
| `@Html.AntiForgeryToken()`, `asp-antiforgery` | Razor views / pages | No token to render. |
| `RequestVerificationToken` header in JavaScript / `fetch` calls | Client code | Browser-supplied `Sec-Fetch-Site` and `Origin` replace it. |
| `[ValidateAntiForgeryToken]`, `[AutoValidateAntiforgeryToken]` | MVC controllers | These are token-specific attributes. Without `UseAntiforgery()` they have no effect. |
| `[RequireAntiforgeryToken]` attribute / `RequireAntiforgeryTokenAttribute` metadata | MVC actions and Minimal API endpoints | Token-specific metadata. |

Per-endpoint opt-outs (`.DisableAntiforgery()` on Minimal APIs, `[IgnoreAntiforgeryToken]` on MVC) can stay where they are — both also opt the endpoint out of the new CSRF middleware. Remove them only if the endpoint should be protected after the simplification.

For Blazor static server-side rendering (SSR), removing `app.UseAntiforgery()` is a breaking change that also stops antiforgery token generation. See [Blazor static server-side rendering](#blazor-static-server-side-rendering) before removing it.

### Before / after

Minimal API:

```csharp
// .NET 10 (token-based)
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseAntiforgery();

app.MapPost("/api/widgets", (Widget w) => Results.Created($"/api/widgets/{w.Id}", w));

app.Run();
```

```csharp
// .NET 11 (automatic CSRF only)
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/api/widgets", (Widget w) => Results.Created($"/api/widgets/{w.Id}", w));

app.Run();
```

MVC controller:

```csharp
// .NET 10
[ApiController]
[Route("api/[controller]")]
[AutoValidateAntiforgeryToken]
public class WidgetsController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] Widget w) => CreatedAtAction(nameof(Get), new { id = w.Id }, w);
}
```

```csharp
// .NET 11
[ApiController]
[Route("api/[controller]")]
public class WidgetsController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] Widget w) => CreatedAtAction(nameof(Get), new { id = w.Id }, w);
}
```

Cross-origin SPAs still need a CORS policy listing the trusted origin, regardless of which antiforgery model the app uses. See [Allowing cross-origin clients](xref:security/csrf-protection#allowing-cross-origin-clients) for the resolution rules.

### Blazor static server-side rendering

Removing `app.UseAntiforgery()` is a breaking change for Blazor static server-side rendering (SSR). Without the token-based middleware:

* Form posts are validated by the automatic CSRF middleware using `Sec-Fetch-Site` and `Origin` instead of antiforgery tokens. Blazor SSR endpoints now trust the verdict recorded by the upstream middleware rather than validating the request themselves.
* Blazor stops generating antiforgery tokens for rendered forms, because no middleware is present to validate a token on a later request.

This is appropriate for apps that target modern browsers and rely on the header-based defense. Apps that need antiforgery tokens — for example, to support browsers that don't send `Sec-Fetch-Site` — should keep `app.UseAntiforgery()`. For the formal breaking-change notice, see [Blazor server-side rendering defers antiforgery validation to middleware](/aspnet/core/breaking-changes/11/blazor-server-side-rendering-deferred-cross-site-request-forgery-protection).

## After upgrade: if requests start failing

The automatic CSRF middleware is enabled by default in .NET 11. Same-origin browser requests and non-browser clients (`curl`, server-to-server, mobile apps) are unaffected. Cross-origin browser form posts that aren't covered by a CORS policy are rejected with HTTP `400` when the endpoint processes the form.

### Symptoms

Cross-origin browser form posts that succeeded on .NET 10 fail on .NET 11 with HTTP `400 Bad Request` and an empty response body when the endpoint binds or reads the form. The form processing is rejected before the handler body runs. Endpoints that don't read form data — such as JSON APIs — aren't affected, because the recorded verdict is only enforced by form consumers.

The same request issued from `curl` or another non-browser client typically succeeds, which is a useful quick check that distinguishes the new middleware from other causes:

```bash
# In a browser at https://app.contoso.com posting a form to https://api.contoso.com: 400
# From a terminal, the same request: 200/201 (no Sec-Fetch-Site, no Origin → treated as non-browser)
curl -i -X POST https://api.contoso.com/widgets \
     -H "Content-Type: application/x-www-form-urlencoded" \
     -d "name=test"
```

### Confirm with logs

To confirm the rejection comes from the CSRF middleware, enable `Debug` logging for `Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware` in `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware": "Debug"
    }
  }
}
```

A recorded verdict appears as:

```text
dbug: Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware[1]
      Cross-origin CSRF protection marked request POST /widgets from origin 'https://app.contoso.com' as invalid.
```

### Fix A: allow the origin via CORS

The most common fix is to declare the calling origin in a CORS policy. The CSRF middleware reuses the policy that the CORS middleware resolves for the endpoint, so registering the origin via `AddDefaultPolicy` or `AddPolicy` is enough to allow it.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("https://app.contoso.com")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();
app.UseCors();

app.MapPost("/widgets", (Widget w) => Results.Created($"/widgets/{w.Id}", w));

app.Run();
```

For per-endpoint policies, use `.RequireCors("name")` (Minimal API) or `[EnableCors("name")]` (MVC). For the full resolution priority — and an important caveat: `AllowAnyOrigin` is **not** honored as a CSRF trust signal — see [Allowing cross-origin clients](xref:security/csrf-protection#allowing-cross-origin-clients) in the reference doc. For details on CORS itself, see <xref:security/cors>.

### Fix B: opt the endpoint out

If an endpoint isn't browser-reachable, or is secured by non-cookie credentials (bearer tokens, API keys), opt it out instead of opening it through CORS:

```csharp
// Minimal API
app.MapPost("/api/webhook", (WebhookPayload p) => Results.Accepted())
   .DisableAntiforgery();
```

```csharp
// MVC
[ApiController]
[Route("api/[controller]")]
[IgnoreAntiforgeryToken]
public class WebhookController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] WebhookPayload payload) => Accepted();
}
```

> [!WARNING]
> Don't opt out browser-accessible endpoints that rely on cookies for authentication. Reserve the opt-out for endpoints that aren't callable from a browser, or are secured by non-cookie authentication such as bearer tokens or API keys.

### Escape hatch: disable globally

If the upgrade window is tight and individual fixes will take time, the middleware can be turned off across the entire app with the `DisableCsrfProtection` configuration key:

```json
{
  "DisableCsrfProtection": true
}
```

This is an escape hatch, not a recommended end state. Re-enable as soon as CORS and per-endpoint opt-outs are in place.

> [!WARNING]
> The automatic CSRF middleware also satisfies the antiforgery requirement for endpoints that require validation, even when an app doesn't call `app.UseAntiforgery()`. If an app relies on antiforgery but doesn't call `app.UseAntiforgery()`, disabling the CSRF middleware with `DisableCsrfProtection` removes the only antiforgery middleware in the pipeline. A request to an endpoint that requires validation then throws an exception. The same is true when the app runs on a host that isn't built with `WebApplication`, where the CSRF middleware isn't injected. In either configuration, add `app.UseAntiforgery()` so a middleware is present to validate the request.

## Related

* <xref:security/csrf-protection> — full reference for the new middleware.
* <xref:security/anti-request-forgery> — the token-based antiforgery system.
* <xref:security/cors> — CORS configuration reference.
* [Breaking change: Blazor server-side rendering defers antiforgery validation to middleware](/aspnet/core/breaking-changes/11/blazor-server-side-rendering-deferred-cross-site-request-forgery-protection)
* <xref:migration/100-to-110> — overall .NET 10 → .NET 11 migration guide.
