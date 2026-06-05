---
title: Automatic CSRF protection in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Learn how the automatic Cross-Site Request Forgery (CSRF) protection middleware in .NET 11 uses Fetch Metadata and Origin validation to block cross-origin write requests by default.
monikerRange: '>= aspnetcore-11.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 06/05/2026
uid: security/csrf-protection
---
# Automatic CSRF protection in ASP.NET Core

Starting in .NET 11, ASP.NET Core ships an automatic Cross-Site Request Forgery (CSRF) protection middleware that's enabled by default in apps built with `WebApplication.CreateBuilder`. Unlike the [token-based antiforgery system](xref:security/anti-request-forgery), this middleware doesn't issue or validate tokens. Instead, it inspects the [Fetch Metadata](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site) headers that modern browsers attach to every request and the [`Origin`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Origin) header as a fallback, then rejects cross-origin write requests that aren't explicitly trusted.

For most apps, no code changes are required: same-origin browser requests, safe HTTP methods, and non-browser clients (`curl`, server-to-server, mobile apps) all pass through unaffected. The middleware primarily affects apps that accept cross-origin write requests from a browser — for example, a Single Page App (SPA) hosted on a different origin than its API. Those scenarios need to either configure [CORS](xref:security/cors) to declare the trusted origin or opt the endpoint out.

This middleware is *additive* to the token-based antiforgery system. The two protections coexist and can both be active on the same endpoint. For a comparison of when each one applies, see [Interaction with token-based antiforgery](#interaction-with-token-based-antiforgery) later in this article.

## How it works

For every request, the middleware evaluates a short chain of rules and either allows the request to continue or short-circuits the response with HTTP `400 Bad Request`. The checks run in order, and the first match wins:

1. **Safe HTTP methods are always allowed.** `GET`, `HEAD`, `OPTIONS`, and `TRACE` requests pass through. This follows [RFC 7231 §4.2.1](https://datatracker.ietf.org/doc/html/rfc7231#section-4.2.1) and is consistent with the long-standing rule that endpoints shouldn't change state on `GET`.
1. **`Sec-Fetch-Site: same-origin` or `Sec-Fetch-Site: none` is allowed.** Modern browsers send `Sec-Fetch-Site` on every request. `same-origin` covers normal in-app navigation and fetch, and `none` covers requests initiated directly by the user (typing a URL, using a bookmark). This is the hot path — most legitimate browser traffic exits here.
1. **A trusted origin from CORS is allowed.** If the request carries an `Origin` header and the endpoint's resolved CORS policy trusts that origin, the request is allowed. The middleware resolves the policy the same way the CORS middleware does: per-endpoint policy from `[EnableCors("name")]` first, then the default policy registered with `AddDefaultPolicy`. See [Allowing cross-origin clients](#allowing-cross-origin-clients) for important limits on this rule.
1. **Any other `Sec-Fetch-Site` value is denied.** When `Sec-Fetch-Site` is `cross-site` or `same-site` and the origin isn't trusted via CORS, the request is rejected.
1. **No `Sec-Fetch-Site`, but `Origin` is present:** the middleware compares the `Origin` to `scheme://host[:port]` built from the request. If they match, the request is allowed; otherwise it's denied. This is the fallback path for browsers older than the Fetch Metadata spec (released ~2020).
1. **No `Sec-Fetch-Site` and no `Origin`: the request is allowed.** Browsers always send at least one of these on a write request, so a request missing both is almost certainly a non-browser client such as `curl`, Postman, a mobile app, or a server-to-server caller. CSRF is a browser-only attack vector, so these requests pass through.

Denied requests receive a [4xx client error response](https://developer.mozilla.org/docs/Web/HTTP/Status#client_error_responses), and the endpoint code doesn't run.

### Why `Sec-Fetch-Site` and `Origin` can be trusted

Both `Sec-Fetch-Site` and `Origin` are [forbidden request headers](https://developer.mozilla.org/docs/Glossary/Forbidden_request_header): they're set by the browser and JavaScript running in the page can't override or forge them. A malicious page can't disguise a cross-origin request as same-origin by attaching its own header value — the browser strips or rejects the attempt. That's what makes Fetch Metadata a reliable CSRF signal without requiring a server-issued token.

## Default behavior

The middleware is registered automatically by `WebApplication.CreateBuilder` and runs after authentication and authorization. It validates each request using the registered `ICsrfProtection` implementation, which by default applies the rules described in [How it works](#how-it-works). The default implementation can be replaced; see [Customizing: implement `ICsrfProtection`](#customizing-implement-icsrfprotection). To turn the middleware off entirely, see [Disabling globally](#disabling-globally).

The result is that a minimal app like the following is already protected:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/widgets", (Widget w) => Results.Created($"/api/widgets/{w.Id}", w));

app.Run();
```

A browser making a same-origin `POST /api/widgets` request reaches the endpoint normally. A browser at `https://attacker.example.com` posting to the same URL is rejected with `400` before the endpoint runs. A `curl` request without `Sec-Fetch-Site` or `Origin` is allowed.

The middleware integrates with the existing antiforgery model:

* **Minimal APIs:** Calling `.DisableAntiforgery()` on an endpoint opts that endpoint out of *both* the token-based middleware and this middleware. The same metadata (`IAntiforgeryMetadata { RequiresValidation = false }`) is checked by both.
* **MVC controllers and actions:** `[IgnoreAntiforgeryToken]` is bridged to the same metadata in .NET 11, so it also opts the endpoint out of both protections.

## Allowing cross-origin clients

The most common scenario that requires action is a browser-based client hosted on a different origin than the API — for example, a SPA at `https://app.contoso.com` calling an API at `https://api.contoso.com`. Such requests are rejected by default because `Sec-Fetch-Site` will be `same-site` or `cross-site` rather than `same-origin`.

The CSRF middleware doesn't introduce its own trust list. It reuses the same CORS policy that the [CORS middleware](xref:security/cors) resolves for the endpoint: if that policy allows the request's `Origin`, the CSRF middleware allows the request.

The policy is picked per-endpoint in this order:

1. `[EnableCors("api")]` (MVC) or `.RequireCors("api")` (Minimal API) → the named policy `"api"`.
1. No CORS metadata on the endpoint → the default policy registered with `AddDefaultPolicy`.
1. No matching policy (named policy not registered, no default policy, or `services.AddCors()` never called) → no CORS-derived trust. The middleware falls through to the `Sec-Fetch-Site` and Origin-vs-Host rules.

A minimal example using a default policy and a Minimal API endpoint:

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

app.MapPost("/api/widgets", (Widget w) => Results.Created($"/api/widgets/{w.Id}", w));

app.Run();
```

For a named policy on a single endpoint:

```csharp
app.MapPost("/api/widgets", (Widget w) => Results.Created($"/api/widgets/{w.Id}", w))
   .RequireCors("api");
```

> [!WARNING]
> `AllowAnyOrigin` is intentionally **not** honored as a CSRF trust signal. `AllowAnyOrigin` means "any browser can read this resource", which is a different concern than "any origin may mutate state on the user's behalf". Treating `AllowAnyOrigin` as trusted would turn this middleware into a no-op for cross-origin writes. Apps that need a public-read CORS policy combined with CSRF-protected writes should list trusted write origins explicitly with `WithOrigins`, or [opt write endpoints out](#opting-an-endpoint-out) if they don't rely on cookie-based authentication.

`[DisableCors]` on an endpoint isn't a CSRF opt-out. It skips the CORS-derived trust step, and the request still has to satisfy the `Sec-Fetch-Site` and Origin-vs-Host rules. To opt out of CSRF protection, see [Opting an endpoint out](#opting-an-endpoint-out).

For details on configuring CORS itself — `AddCors`, `AddDefaultPolicy`, `AddPolicy`, `WithOrigins`, and the rest of the policy builder API — see <xref:security/cors>.

## Opting an endpoint out

If an endpoint isn't browser-reachable, or is secured by a non-cookie mechanism such as a bearer token or API key, opt it out individually rather than disabling the middleware globally.

**Minimal APIs** — call `DisableAntiforgery` on the endpoint or group:

```csharp
app.MapPost("/api/webhook", (WebhookPayload p) => Results.Accepted())
   .DisableAntiforgery();
```

**MVC controllers** — apply `[IgnoreAntiforgeryToken]` to the action or controller:

```csharp
[ApiController]
[Route("api/[controller]")]
[IgnoreAntiforgeryToken]
public class WebhookController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] WebhookPayload payload) => Accepted();
}
```

Either approach adds `IAntiforgeryMetadata { RequiresValidation = false }` to the endpoint, which the CSRF middleware honors by skipping validation.

> [!WARNING]
> Disabling CSRF protection on an endpoint should only be done when the endpoint isn't vulnerable to CSRF attacks — for example, endpoints that aren't callable from a browser, or that are secured with non-cookie authentication such as bearer tokens or API keys. Don't disable CSRF protection on browser-accessible endpoints that rely on cookies for authentication.

## Disabling globally

The middleware can be disabled across the entire app using the `DisableCsrfProtection` configuration key. This is an escape hatch — prefer per-endpoint opt-outs.

In `appsettings.json`:

```json
{
  "DisableCsrfProtection": true
}
```

Or as an environment variable:

```
ASPNETCORE_DisableCsrfProtection=true
```

When this key is set to `true`, `WebApplication` skips registering the middleware in the pipeline. The `ICsrfProtection` service remains registered, so anything that resolves it directly continues to work.

## Browser support

`Sec-Fetch-Site` is supported by all current versions of Chromium-based browsers, Firefox, and Safari. For an authoritative compatibility table, see the [MDN reference for `Sec-Fetch-Site`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site).

Older browsers that predate Fetch Metadata don't send `Sec-Fetch-Site`. For those clients, the middleware falls back to comparing the `Origin` header against the request's scheme and host. Browsers have sent `Origin` on cross-origin write requests for many years, so this fallback covers essentially all legacy browser traffic.

Non-browser clients — `curl`, Postman, mobile apps, server-to-server callers — typically send neither `Sec-Fetch-Site` nor `Origin`. Those requests are allowed because CSRF is a browser-only attack vector that depends on the browser automatically attaching ambient credentials such as cookies. A non-browser client that wants to attack the API has no need for CSRF; it can simply call the API directly with whatever credentials it possesses.

## Customizing: implement `ICsrfProtection`

The decision logic lives behind a one-method interface:

```csharp
namespace Microsoft.AspNetCore.Antiforgery;

public interface ICsrfProtection
{
    ValueTask<CsrfProtectionResult> ValidateAsync(HttpContext context);
}
```

To replace the default implementation, register a singleton in DI. Because the framework uses `TryAddSingleton`, an explicit `AddSingleton` call overrides the default:

```csharp
builder.Services.AddSingleton<ICsrfProtection, AllowlistCsrfProtection>();
```

A custom implementation is useful when the trust model doesn't fit CORS — for example, when a fixed allowlist of partner origins is preferred, or when stricter rules are needed:

```csharp
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

public sealed class AllowlistCsrfProtection : ICsrfProtection
{
    private static readonly HashSet<string> SafeMethods =
        new(StringComparer.OrdinalIgnoreCase) { "GET", "HEAD", "OPTIONS", "TRACE" };

    private static readonly HashSet<string> TrustedOrigins =
        new(StringComparer.OrdinalIgnoreCase)
        {
            "https://app.contoso.com",
            "https://admin.contoso.com",
        };

    public ValueTask<CsrfProtectionResult> ValidateAsync(HttpContext context)
    {
        if (SafeMethods.Contains(context.Request.Method))
        {
            return ValueTask.FromResult(CsrfProtectionResult.Allowed());
        }

        var origin = context.Request.Headers.Origin.ToString();
        var allowed = !string.IsNullOrEmpty(origin) && TrustedOrigins.Contains(origin);

        return ValueTask.FromResult(
            allowed ? CsrfProtectionResult.Allowed() : CsrfProtectionResult.Denied());
    }
}
```

The middleware still honors `.DisableAntiforgery()` / `[IgnoreAntiforgeryToken]` regardless of which implementation is registered — opt-out is handled by the middleware itself before `ValidateAsync` is called.

## Interaction with token-based antiforgery

The two CSRF defenses target different layers and are designed to coexist:

| Aspect | Token-based `AntiforgeryMiddleware` | Automatic CSRF protection middleware |
|---|---|---|
| Introduced | ASP.NET Core 2.0+ | .NET 11 |
| Activation | Opt-in via `app.UseAntiforgery()` (or implicitly by `AddMvc` / `MapRazorPages` / `AddRazorComponents`) | Auto-injected by `WebApplication.CreateBuilder` |
| Validates | Synchronized token (form field + cookie pair) | `Sec-Fetch-Site` / `Origin` headers |
| Requires | <xref:security/data-protection/introduction> for token encryption | No tokens, no state |
| Browser scope | All browsers that send cookies | All modern browsers; `Origin` fallback for legacy |
| Per-endpoint opt-out | `.DisableAntiforgery()` / `[IgnoreAntiforgeryToken]` | Same — both honor the same metadata |

The token-based middleware specifically protects against the classic CSRF attack pattern in which a malicious site triggers a form `POST` to a vulnerable site using the user's ambient cookies. The automatic CSRF middleware addresses the same threat at the HTTP layer using browser-supplied metadata. Both can be active on the same endpoint, and many apps will benefit from defense in depth:

* **Razor Pages, MVC, and Blazor SSR apps** that already use the token system gain an additional layer that doesn't require form participation.
* **Minimal API apps** that don't use forms get a useful default without needing to call `app.UseAntiforgery()` or thread `IAntiforgery` through endpoints.
* **APIs called from cross-origin SPAs** can rely on this middleware combined with a CORS allowlist, and skip the token system entirely if the API never serves HTML forms.

For details on the token-based system — including form integration, AJAX flows, configuration via `AntiforgeryOptions`, and `IAntiforgery` APIs — see <xref:security/anti-request-forgery>.

## Adopting CSRF-only protection in existing apps

For apps that are upgrading from .NET 10 and already use the token-based system, the automatic CSRF middleware can replace it entirely in many scenarios. For guidance on when to drop the token-based system and how to do so, see <xref:migration/antiforgery-to-csrf>.

## Troubleshooting

**Symptom:** Same-origin requests from a browser succeed, but cross-origin requests return `400` with no body.

**Cause:** The cross-origin request was rejected by the CSRF middleware. The endpoint code didn't run; this is the expected default behavior.

**Resolution:** Choose one of the following, depending on the scenario:

* If the calling origin is known and trusted, [allow it via CORS](#allowing-cross-origin-clients).
* If the endpoint isn't browser-reachable or uses non-cookie authentication, [opt it out](#opting-an-endpoint-out) with `.DisableAntiforgery()` or `[IgnoreAntiforgeryToken]`.
* If the entire app needs to opt out (for example, during a migration window), [disable globally](#disabling-globally).

**Diagnosing:** The middleware logs every denial at `Debug` level under the category `Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware` with event name `CsrfRequestDenied`. Enable `Debug` logging for that category in `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware": "Debug"
    }
  }
}
```

A denial then appears in the log as:

```
dbug: Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware[1]
      Cross-origin CSRF protection denied request POST /api/widgets from origin 'https://attacker.example.com'.
```

**Reproducing locally:** Use `curl` with an explicit `Origin` header to simulate a cross-origin browser request:

```bash
curl -i -X POST https://localhost:{PORT}/api/widgets \
     -H "Origin: https://attacker.example.com" \
     -H "Content-Type: application/json" \
     -d '{"name":"test"}'
```

Replace `{PORT}` with the app's local HTTPS port. Without the `Origin` header, the same request is allowed because `curl` doesn't send `Sec-Fetch-Site` either, and a request with neither header is treated as a non-browser client.

## Additional resources

* <xref:security/anti-request-forgery> — the token-based antiforgery system, including form integration and `IAntiforgery` APIs.
* <xref:migration/antiforgery-to-csrf> — when and how to drop the token-based system in favor of the automatic middleware.
* <xref:security/cors> — configuring CORS policies, which this middleware uses as its trusted-origin source.
* [MDN — `Sec-Fetch-Site`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site)
* [MDN — `Origin`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Origin)
