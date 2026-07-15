---
title: Automatic CSRF protection in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Learn how the automatic Cross-Site Request Forgery (CSRF) protection middleware in .NET 11 uses Fetch Metadata and Origin validation to protect form-handling endpoints from untrusted cross-origin requests.
monikerRange: '>= aspnetcore-11.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/15/2026
uid: security/csrf-protection
---
# Automatic CSRF protection in ASP.NET Core

Starting in .NET 11, ASP.NET Core ships an automatic Cross-Site Request Forgery (CSRF) protection middleware that's enabled by default in apps built with `WebApplication.CreateBuilder`. Unlike the [token-based antiforgery system](xref:security/anti-request-forgery), this middleware doesn't issue or validate tokens. Instead, it inspects the [Fetch Metadata](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site) headers that modern browsers attach to every request, with the [`Origin`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Origin) header as a fallback, and records a validation verdict on the request. The framework's antiforgery enforcement then rejects untrusted cross-origin requests to form-handling endpoints with HTTP `400 Bad Request`.

The middleware validates only endpoints that already require antiforgery validation — the same form-handling endpoints that the token-based system protects: Blazor server-side rendering (SSR) form posts, minimal API endpoints that bind form data, and MVC actions annotated with antiforgery attributes. Endpoints without antiforgery metadata, such as a plain `MapPost` or `[HttpPost]` that binds JSON, pass through unchanged, so nothing that worked on .NET 10 starts failing on .NET 11.

For most apps, no code changes are required: same-origin browser requests, safe HTTP methods, and non-browser clients (`curl`, server-to-server, mobile apps) all pass through unaffected. The middleware primarily affects form-handling endpoints that accept cross-origin requests from a browser — for example, a form posted from a Single Page App (SPA) hosted on a different origin than its API. Those scenarios need to either configure [CORS](xref:security/cors) to declare the trusted origin or opt the endpoint out.

This middleware is *additive* to the token-based antiforgery system. The two protections coexist and can both be active on the same endpoint. For a comparison of when each one applies, see [Interaction with token-based antiforgery](#interaction-with-token-based-antiforgery) later in this article.

## How it works

### Which endpoints are validated

The middleware runs after routing and inspects the matched endpoint. Validation runs only when the endpoint carries antiforgery metadata that requires validation — that is, `IAntiforgeryMetadata` with `RequiresValidation` set to `true`. The framework attaches this metadata automatically to form-handling endpoints:

* Blazor SSR form posts.
* Minimal API endpoints that bind form data, such as an `IFormCollection`, `IFormFile`, or `[FromForm]` parameter.
* MVC actions annotated with `[ValidateAntiForgeryToken]` or `[AutoValidateAntiforgeryToken]`.

The request passes through without validation when:

* No endpoint was matched (routing didn't select an endpoint).
* The matched endpoint has no antiforgery metadata, such as a plain `MapPost` or `[HttpPost]` that binds JSON.
* The endpoint opted out with `.DisableAntiforgery()` or `[IgnoreAntiforgeryToken]`, which sets `RequiresValidation` to `false`.

This scoping matches the token-based antiforgery system, so upgrading from .NET 10 doesn't cause endpoints that previously worked to start returning `400`.

### Validation rules

When an endpoint is in scope, the middleware evaluates a short chain of rules and records either an *allowed* or an *invalid* verdict. The checks run in order, and the first match wins:

1. **Safe HTTP methods are always allowed.** `GET`, `HEAD`, `OPTIONS`, and `TRACE` requests pass through. This follows [RFC 9110 §9.2.1](https://datatracker.ietf.org/doc/html/rfc9110#section-9.2.1) and is consistent with the long-standing rule that endpoints shouldn't change state on `GET`.
1. **`Sec-Fetch-Site: same-origin` or `Sec-Fetch-Site: none` is allowed.** Modern browsers send `Sec-Fetch-Site` on every request. `same-origin` covers normal in-app navigation and fetch, and `none` covers requests initiated directly by the user (typing a URL, using a bookmark). This is the most common code path — most legitimate browser traffic exits here.
1. **A trusted origin from CORS is allowed.** If the request carries an `Origin` header and the endpoint's resolved CORS policy trusts that origin, the request is allowed. The middleware resolves the policy the same way the CORS middleware does: per-endpoint policy from `[EnableCors("name")]` first, then the default policy registered with `AddDefaultPolicy`. See [Allowing cross-origin clients](#allowing-cross-origin-clients) for important limits on this rule.
1. **Any other `Sec-Fetch-Site` value is invalid.** When `Sec-Fetch-Site` is `cross-site` or `same-site` and the origin isn't trusted via CORS, the request is marked invalid.
1. **No `Sec-Fetch-Site`, but `Origin` is present:** the middleware compares the `Origin` to `scheme://host[:port]` built from the request. If they match, the request is allowed; otherwise it's marked invalid. This is the fallback path for browsers older than the Fetch Metadata spec (released ~2020).
1. **No `Sec-Fetch-Site` and no `Origin`: the request is allowed.** Browsers always send at least one of these on a write request, so a request missing both is almost certainly a non-browser client such as `curl`, Postman, a mobile app, or a server-to-server caller. CSRF is a browser-only attack vector, so these requests pass through.

The middleware doesn't short-circuit the request. It records the verdict on the request, and the framework's antiforgery enforcement — minimal API form binding, the MVC antiforgery filter, or Blazor SSR — reads that verdict and returns [`400 Bad Request`](https://developer.mozilla.org/docs/Web/HTTP/Status#client_error_responses) for an invalid request before the endpoint's handler runs. When the app also calls `app.UseAntiforgery()`, the token-based middleware runs afterward and can overwrite the verdict with the result of token validation.

### Why `Sec-Fetch-Site` and `Origin` can be trusted

Both `Sec-Fetch-Site` and `Origin` are [forbidden request headers](https://developer.mozilla.org/docs/Glossary/Forbidden_request_header): they're set by the browser and JavaScript running in the page can't override or forge them. A malicious page can't disguise a cross-origin request as same-origin by attaching its own header value — the browser strips or rejects the attempt. That's what makes Fetch Metadata a reliable CSRF signal without requiring a server-issued token.

## Default behavior

The middleware is registered automatically by `WebApplication.CreateBuilder` when all of the following are true:

* The app has endpoints (at least one endpoint data source). Apps with no endpoints don't get the middleware.
* An `ICsrfProtection` service is registered, which it is by default.
* The `DisableCsrfProtection` configuration key isn't set to `true`. See [Disabling globally](#disabling-globally).

The middleware runs after routing — and after authentication and authorization — so it can observe the matched endpoint and the endpoint's resolved CORS policy. It validates each in-scope request using the registered `ICsrfProtection` implementation, which by default applies the rules described in [Validation rules](#validation-rules). The default implementation can be replaced; see [Customizing: implement `ICsrfProtection`](#customizing-implement-icsrfprotection). To turn the middleware off entirely, see [Disabling globally](#disabling-globally).

The result is that a form-handling endpoint is protected without any additional configuration:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/register", (IFormCollection form) => Results.Ok());

app.Run();
```

Because the endpoint binds form data, the framework marks it as requiring antiforgery validation and the middleware evaluates it. A browser making a same-origin `POST /register` request reaches the endpoint normally. A browser at `https://attacker.example.com` posting to the same URL is rejected with `400` before the handler runs. A `curl` request without `Sec-Fetch-Site` or `Origin` is allowed.

By contrast, an endpoint that binds JSON has no antiforgery metadata, so it isn't in scope and the middleware doesn't validate it:

```csharp
// Not validated by the CSRF middleware — no antiforgery metadata.
app.MapPost("/api/widgets", (Widget w) => Results.Created($"/api/widgets/{w.Id}", w));
```

This matches how the token-based system works: CSRF is a concern for browser-reachable endpoints that rely on ambient cookies, which for forms is handled automatically. APIs that authenticate with a non-cookie mechanism such as a bearer token aren't vulnerable to CSRF and don't need this protection.

## Allowing cross-origin clients

The most common scenario that requires action is a browser-based client that submits a form to an endpoint hosted on a different origin — for example, a SPA at `https://app.contoso.com` posting a form to an API at `https://api.contoso.com`. Such requests are marked invalid by default because `Sec-Fetch-Site` will be `same-site` or `cross-site` rather than `same-origin`.

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

app.MapPost("/register", (IFormCollection form) => Results.Ok());

app.Run();
```

For a named policy on a single endpoint:

```csharp
app.MapPost("/register", (IFormCollection form) => Results.Ok())
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
app.MapPost("/upload", (IFormCollection form) => Results.Accepted())
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

```text
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
| Activation | Opt-in via `app.UseAntiforgery()` (or implicitly by `AddMvc` / `MapRazorPages` / `AddRazorComponents`) | Auto-injected by `WebApplication.CreateBuilder`; validates form-handling endpoints |
| Validates | Synchronized token (form field + cookie pair) | `Sec-Fetch-Site` / `Origin` headers |
| Requires | <xref:security/data-protection/introduction> for token encryption | No tokens, no state |
| Browser scope | All browsers that send cookies | All modern browsers; `Origin` fallback for legacy |
| Per-endpoint opt-out | `.DisableAntiforgery()` / `[IgnoreAntiforgeryToken]` | Same — both honor the same metadata |

The token-based middleware specifically protects against the classic CSRF attack pattern in which a malicious site triggers a form `POST` to a vulnerable site using the user's ambient cookies. The automatic CSRF middleware addresses the same threat at the HTTP layer using browser-supplied metadata. Both can be active on the same endpoint, and many apps will benefit from defense in depth:

* **Razor Pages, MVC, and Blazor SSR apps** that already use the token system gain a header-based check on the same form endpoints, so they stay protected even without the token round-trip.
* **Minimal API apps** that bind form data get CSRF protection automatically, without calling `app.UseAntiforgery()` or threading `IAntiforgery` through endpoints.

For details on the token-based system — including form integration, AJAX flows, configuration via `AntiforgeryOptions`, and `IAntiforgery` APIs — see <xref:security/anti-request-forgery>.

## Adopting CSRF-only protection in existing apps

Apps upgrading from .NET 10 that use the token-based antiforgery system can rely on the automatic CSRF middleware instead in many cases. Both systems protect the same form-handling endpoints, so the automatic middleware is often enough on its own.

Keep the token-based system when:

* The app must support browsers that don't send `Sec-Fetch-Site`. See [Browser support](#browser-support) for the baseline.
* The app uses `IAntiforgeryAdditionalDataProvider` to round-trip extra data inside the antiforgery token.
* A security review or compliance requirement specifies the token defense as an independent layer.

Consider dropping the token-based system when:

* The app targets modern evergreen browsers only.
* Defense in depth at the token layer isn't a hard requirement.

To drop it, remove the `app.UseAntiforgery()` and `AddAntiforgery(...)` calls along with the token plumbing: `@Html.AntiForgeryToken()` and `asp-antiforgery` in Razor views, the `RequestVerificationToken` header in client `fetch`/AJAX code, and the `[ValidateAntiForgeryToken]` and `[AutoValidateAntiforgeryToken]` attributes. Per-endpoint opt-outs (`.DisableAntiforgery()`, `[IgnoreAntiforgeryToken]`) can stay where they are — they also opt the endpoint out of the automatic middleware. If unsure, keep both: they're complementary and there's no functional conflict between them.

For the full upgrade walkthrough, see <xref:migration/100-to-110>.

## Troubleshooting

**Symptom:** Same-origin requests from a browser succeed, but cross-origin requests to a form-handling endpoint return `400` with no body.

**Cause:** The cross-origin request was marked invalid by the CSRF middleware and rejected by the framework's antiforgery enforcement. The endpoint code didn't run; this is the expected default behavior.

**Resolution:** Choose one of the following, depending on the scenario:

* If the calling origin is known and trusted, [allow it via CORS](#allowing-cross-origin-clients).
* If the endpoint isn't browser-reachable or uses non-cookie authentication, [opt it out](#opting-an-endpoint-out) with `.DisableAntiforgery()` or `[IgnoreAntiforgeryToken]`.
* If the entire app needs to opt out (for example, during a migration window), [disable globally](#disabling-globally).

**Diagnosing:** The middleware logs every invalid verdict at `Debug` level under the category `Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware` with event name `CsrfValidationFailed`. Enable `Debug` logging for that category in `appsettings.Development.json`:

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

```text
dbug: Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware[1]
      Cross-origin CSRF protection marked request POST /register from origin 'https://attacker.example.com' as invalid.
```

**Reproducing locally:** Use `curl` with an explicit `Origin` header to simulate a cross-origin browser request to a form-handling endpoint:

```bash
curl -i -X POST https://localhost:{PORT}/register \
     -H "Origin: https://attacker.example.com" \
     -H "Content-Type: application/x-www-form-urlencoded" \
     -d "name=test"
```

Replace `{PORT}` with the app's local HTTPS port. Without the `Origin` header, the same request is allowed because `curl` doesn't send `Sec-Fetch-Site` either, and a request with neither header is treated as a non-browser client.

## Additional resources

* <xref:security/anti-request-forgery> — the token-based antiforgery system, including form integration and `IAntiforgery` APIs.
* <xref:security/cors> — configuring CORS policies, which this middleware uses as its trusted-origin source.
* [MDN — `Sec-Fetch-Site`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site)
* [MDN — `Origin`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Origin)
