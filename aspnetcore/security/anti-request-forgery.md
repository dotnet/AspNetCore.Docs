---
title: Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
content_well_notification: AI-contribution
description: Discover how to prevent attacks against web apps where a malicious website can influence the interaction between a client browser and the app.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/15/2026
uid: security/anti-request-forgery
---
# Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core

By [Fiyaz Hasan](https://twitter.com/FiyazBinHasan) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-8.0"

Cross-site request forgery is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session. Cross-site request forgery is also known as XSRF or CSRF.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send `https://www.good-banking-site.example.com/` a request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can protect against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password they're issued a token containing an authentication ticket. The token can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed with the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Placing a token in the browser local storage and retrieving it and using it as a bearer token provides protection against CSRF attacks. However, should the app be vulnerable to script injection via XSS or a compromised external JavaScript file, a cyberattacker could retrieve any value from local storage and send it to themselves. ASP.NET Core encodes all server side output from variables by default, reducing the risk of XSS. If you override this behavior by using [Html.Raw](xref:System.Web.Mvc.HtmlHelper.Raw%2A) or custom code with untrusted input then you may increase the risk of XSS.

Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, sign-in CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

### Fetch metadata headers

Modern browsers attach [Fetch Metadata](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site) request headers—most importantly `Sec-Fetch-Site`—to every request. `Sec-Fetch-Site` describes the relationship between the origin that initiated the request and the origin being requested: `same-origin` identifies a request the site made to itself, while `same-site` and `cross-site` identify requests initiated by another origin. The [`Origin`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Origin) header carries the initiating origin and serves as a fallback for browsers that predate Fetch Metadata.

`Sec-Fetch-Site` and `Origin` are [forbidden request headers](https://developer.mozilla.org/docs/Glossary/Forbidden_request_header): the browser sets them, and JavaScript running in a page can't override or forge them. That makes them a trustworthy signal for telling a site's own requests apart from cross-site requests without a server-issued token. The [automatic CSRF protection](#automatic-csrf-protection-in-aspnet-core) built into ASP.NET Core uses this signal to reject cross-site form posts that aren't explicitly trusted.

## Automatic CSRF protection in ASP.NET Core

ASP.NET Core ships an automatic CSRF protection middleware that's enabled by default in apps built with `WebApplication.CreateBuilder`. Unlike the [token-based antiforgery system](#antiforgery-in-aspnet-core), this middleware doesn't issue or validate tokens. Instead, it inspects the `Sec-Fetch-Site` and `Origin` [Fetch metadata headers](#fetch-metadata-headers) and records a validation verdict on the request. Components that process submitted form data enforce that verdict, rejecting cross-origin form posts that aren't explicitly trusted.

For most apps, no code changes are required: same-origin browser requests, safe HTTP methods, and non-browser clients (`curl`, server-to-server, mobile apps) all pass through unaffected. The middleware primarily affects apps that accept cross-origin form posts from a browser, such as a site that posts a form to an API on a different origin. Those scenarios need to either configure [CORS](xref:security/cors) to declare the trusted origin or opt the endpoint out.

This middleware is *additive* to the token-based antiforgery system. The two protections coexist and can both be active on the same endpoint. For a comparison of when each one applies, see [Interaction with token-based antiforgery](#interaction-with-token-based-antiforgery).

### How it works

For every request, the middleware evaluates a short chain of rules to reach a verdict—*allowed* or *denied*. The checks run in order, and the first match wins:

1. **Safe HTTP methods are always allowed.** `GET`, `HEAD`, `OPTIONS`, and `TRACE` requests pass through. This follows [RFC 9110 §9.2.1](https://datatracker.ietf.org/doc/html/rfc9110#section-9.2.1) and is consistent with the long-standing rule that endpoints shouldn't change state on `GET`.
1. **`Sec-Fetch-Site: same-origin` or `Sec-Fetch-Site: none` is allowed.** Modern browsers send `Sec-Fetch-Site` on every request. `same-origin` covers normal in-app navigation and fetch, and `none` covers requests initiated directly by the user (typing a URL, using a bookmark). This is the most common code path—most legitimate browser traffic exits here.
1. **A trusted origin from CORS is allowed.** If the request carries an `Origin` header and the endpoint's resolved CORS policy trusts that origin, the request is allowed. The middleware resolves the policy the same way the CORS middleware does: per-endpoint policy from `[EnableCors("name")]` first, then the default policy registered with `AddDefaultPolicy`. See [Allowing cross-origin clients](#allowing-cross-origin-clients) for important limits on this rule.
1. **Any other `Sec-Fetch-Site` value is denied.** When `Sec-Fetch-Site` is `cross-site` or `same-site` and the origin isn't trusted via CORS, the request is denied.
1. **No `Sec-Fetch-Site`, but `Origin` is present:** the middleware compares the `Origin` to `scheme://host[:port]` built from the request. If they match, the request is allowed; otherwise it's denied. This is the fallback path for browsers older than the Fetch Metadata spec (released ~2020).
1. **No `Sec-Fetch-Site` and no `Origin`: the request is allowed.** Browsers always send at least one of these on a write request, so a request missing both is almost certainly a non-browser client such as `curl`, Postman, a mobile app, or a server-to-server caller. CSRF is a browser-only attack vector, so these requests pass through.

The middleware records this verdict on the request rather than ending the request itself. For how and when a denied verdict turns into an HTTP `400 Bad Request` response, see [Deferred validation](#deferred-validation).

### Deferred validation

The middleware doesn't reject a request on its own. Instead, it records its verdict on the request's <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature>—the same feature the token-based antiforgery system uses—where a denied verdict is recorded as *invalid*. The request continues down the pipeline. An invalid verdict becomes an HTTP `400 Bad Request` only when a component that processes form data observes it. This deferral matches how the token-based system already behaves: the verdict is produced early but enforced at the point where a form is consumed.

The following components read <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature> and reject a request with `400 - Bad Request` when the recorded verdict is invalid:

* MVC actions protected by antiforgery.
* Minimal API endpoints that bind a form parameter.
* Blazor SSR endpoints.
* Any code that reads the request form directly, which acts as a backstop.

Each consumer first confirms that an antiforgery or CSRF middleware actually ran before it trusts the verdict, so a pipeline without either middleware doesn't produce false rejections.

A consequence of this model is that an endpoint that never reads form data runs even when the verdict is invalid. For example, a JSON API endpoint that binds its body from JSON, or a handler that ignores the request body, isn't rejected automatically on a cross-origin request. The verdict is still recorded on <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature> for code that wants to inspect it, but nothing enforces it. CSRF is a form-and-cookie attack vector, so endpoints that don't consume a browser-submitted form generally don't need this rejection. Endpoints that do process forms—Razor Pages, MVC views, Blazor SSR, and Minimal API form binding—get the protection automatically.

### Default behavior

The middleware is registered automatically by `WebApplication.CreateBuilder` and runs after authentication and authorization. It validates each request using the registered `ICsrfProtection` implementation, which by default applies the rules described in [How it works](#how-it-works). The default implementation can be replaced; see [Customizing: implement `ICsrfProtection`](#customizing-implement-icsrfprotection). To turn the middleware off entirely, see [Disabling globally](#disabling-globally).

The result is that a minimal app with a form-handling endpoint like the following is already protected:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/widgets", ([FromForm] Widget w) =>
    Results.Created($"/widgets/{w.Id}", w));

app.Run();
```

A browser making a same-origin `POST /widgets` request reaches the endpoint normally. A browser at `https://attacker.example.com` posting the same form is rejected with `400 - Bad Request` when the endpoint binds the form, before the handler body runs. A `curl` request without `Sec-Fetch-Site` or `Origin` is allowed.

Because rejection is [deferred to form consumers](#deferred-validation), an endpoint that doesn't read form data—such as a JSON API that binds its body from JSON—isn't rejected automatically, even on a cross-origin request. The verdict is still recorded on the request for code that wants to inspect it.

The middleware integrates with the existing antiforgery model:

* **Minimal APIs:** Calling `.DisableAntiforgery()` on an endpoint opts that endpoint out of *both* the token-based middleware and CSRF protection middleware. The same metadata (`IAntiforgeryMetadata { RequiresValidation = false }`) is checked by both.
* **MVC controllers and actions:** `[IgnoreAntiforgeryToken]` also opts the endpoint out of both protections.

### Allowing cross-origin clients

The most common scenario that requires action is a browser-based client that submits a cross-origin form—for example, a site at `https://app.contoso.com` posting a form to an API at `https://api.contoso.com`. Such form posts are denied by default because `Sec-Fetch-Site` is `same-site` or `cross-site` rather than `same-origin`, and the form consumer enforces that verdict with a `400 - Bad Request`.

The CSRF middleware doesn't introduce its own trust list. It reuses the same CORS policy that the [CORS middleware](xref:security/cors) resolves for the endpoint: if that policy allows the request's `Origin`, the CSRF middleware records an allowed verdict for the request.

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

app.MapPost("/widgets", ([FromForm] Widget w) =>
    Results.Created($"/widgets/{w.Id}", w));

app.Run();
```

For a named policy on a single endpoint:

```csharp
app.MapPost("/widgets", ([FromForm] Widget w) => Results.Created($"/widgets/{w.Id}", w))
   .RequireCors("api");
```

> [!WARNING]
> `AllowAnyOrigin` is intentionally **not** honored as a CSRF trust signal. `AllowAnyOrigin` means "any browser can read this resource," which is a different concern than "any origin may mutate state on the user's behalf." Treating `AllowAnyOrigin` as trusted would turn this middleware into a no-op for cross-origin writes. Apps that need a public-read CORS policy combined with CSRF-protected writes should list trusted write origins explicitly with `WithOrigins` or [opt write endpoints out](#opting-an-endpoint-out) if they don't rely on cookie-based authentication.

`[DisableCors]` on an endpoint isn't a CSRF opt-out. It skips the CORS-derived trust step, and the request still has to satisfy the `Sec-Fetch-Site` and Origin-vs-Host rules. To opt out of CSRF protection, see [Opting an endpoint out](#opting-an-endpoint-out).

For details on configuring CORS itself—`AddCors`, `AddDefaultPolicy`, `AddPolicy`, `WithOrigins`, and the rest of the policy builder API—see <xref:security/cors>.

### Opting an endpoint out

If an endpoint isn't browser-reachable or is secured by a non-cookie mechanism, such as a bearer token or API key, opt it out individually rather than disabling the middleware globally.

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
> Disabling CSRF protection on an endpoint should only be done when the endpoint isn't vulnerable to CSRF attacks—for example, endpoints that aren't callable from a browser or that are secured with non-cookie authentication such as bearer tokens or API keys. Don't disable CSRF protection on browser-accessible endpoints that rely on cookies for authentication.

### Disabling globally

The middleware can be disabled across the entire app using the `DisableCsrfProtection` configuration key. This is an escape hatch—prefer per-endpoint opt-outs.

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

> [!WARNING]
> The automatic CSRF middleware also satisfies the antiforgery requirement for endpoints that require validation, even when an app doesn't call `app.UseAntiforgery()`. If an app relies on antiforgery but doesn't call `app.UseAntiforgery()`, disabling the CSRF middleware globally or running on a host that isn't built with `WebApplication`, where the middleware isn't injected, leaves those endpoints with no antiforgery middleware. A request to such an endpoint then throws an exception. Call `app.UseAntiforgery()` in that configuration.

### Browser support

`Sec-Fetch-Site` is supported by all current versions of Chromium-based browsers, Firefox, and Safari. For an authoritative compatibility table, see the [MDN reference for `Sec-Fetch-Site`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Sec-Fetch-Site).

Older browsers that predate Fetch Metadata don't send `Sec-Fetch-Site`. For those clients, the middleware falls back to comparing the `Origin` header against the request's scheme and host. Browsers have sent `Origin` on cross-origin write requests for many years, so this fallback covers essentially all legacy browser traffic.

Non-browser clients—`curl`, Postman, mobile apps, server-to-server callers—typically send neither `Sec-Fetch-Site` nor `Origin`. Those requests are allowed because CSRF is a browser-only attack vector that depends on the browser automatically attaching ambient credentials such as cookies. A non-browser client that wants to attack the API has no need for CSRF; it can simply call the API directly with whatever credentials it possesses.

### Customizing: implement `ICsrfProtection`

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

A custom implementation is useful when the trust model doesn't fit CORS—for example, when a fixed allowlist of partner origins is preferred, or when stricter rules are needed:

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

The middleware still honors `.DisableAntiforgery()` / `[IgnoreAntiforgeryToken]` regardless of which implementation is registered—opt-out is handled by the middleware itself before `ValidateAsync` is called.

### Interaction with token-based antiforgery

The two CSRF defenses target different layers and are designed to coexist. They also share the same request feature: both record their result on <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature>, and form consumers enforce whatever verdict is present.

| Aspect | Token-based `AntiforgeryMiddleware` | Automatic CSRF protection middleware |
|---|---|---|
| Introduced | ASP.NET Core 2.0+ | .NET 11 |
| Activation | Opt-in via `app.UseAntiforgery()` (or implicitly by `AddMvc` / `MapRazorPages` / `AddRazorComponents`) | Auto-injected by `WebApplication.CreateBuilder` |
| Validates | Synchronized token (form field + cookie pair) | `Sec-Fetch-Site` / `Origin` headers |
| Requires | <xref:security/data-protection/introduction> for token encryption | No tokens, no state |
| Browser scope | All browsers that send cookies | All modern browsers; `Origin` fallback for legacy |
| Per-endpoint opt-out | `.DisableAntiforgery()` / `[IgnoreAntiforgeryToken]` | Same — both honor the same metadata |

The token-based middleware specifically protects against the classic CSRF attack pattern in which a malicious site triggers a form `POST` to a vulnerable site using the user's ambient cookies. The automatic CSRF middleware addresses the same threat at the HTTP layer using browser-supplied metadata. Both can be active on the same endpoint, and many apps will benefit from defense in depth:

* **Razor Pages, MVC, and Blazor SSR apps** that already use the token system gain a header-based check that runs before token validation, without changing the token flow.
* **Minimal API apps** that bind forms get a useful default without needing to call `app.UseAntiforgery()` or thread `IAntiforgery` through endpoints.
* **APIs called from cross-origin SPAs** can rely on this middleware combined with a CORS allowlist, and skip the token system entirely if the API never serves HTML forms.

The automatic CSRF middleware replaces the token-based system in many scenarios, because both protect the same form-handling endpoints. Keep the token-based system when:

* The app must support browsers that don't send `Sec-Fetch-Site`. See [Browser support](#browser-support).
* The app uses <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> to round-trip extra data inside the token.
* A security review or compliance requirement specifies the token defense as an independent layer.

For details on the token-based system, including form integration, AJAX flows, configuration via `AntiforgeryOptions`, and `IAntiforgery` APIs, see [Antiforgery in ASP.NET Core](#antiforgery-in-aspnet-core).

#### Token validation takes precedence

When an app calls `app.UseAntiforgery()`, the token-based middleware runs after the automatic CSRF middleware. The token middleware clears any verdict the CSRF middleware recorded and replaces it with the result of token validation. The token result is authoritative:

* A request that the CSRF middleware marked invalid becomes valid if it carries a valid token.
* A request that the CSRF middleware allowed is marked invalid if its token is missing or invalid.

This ordering means apps that use the token system see the same end-to-end behavior they had before the automatic middleware existed, while apps that don't use tokens fall back to the CSRF middleware's verdict.

### Blazor static server-side rendering

Blazor static server-side rendering (SSR) endpoints participate in the same deferred model. The Razor Components endpoint trusts the verdict recorded on <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature> by the upstream middleware and returns `400 - Bad Request` for a form post only when that verdict is invalid. The endpoint no longer validates the request itself.

The behavior depends on which middleware ran:

* Apps that call `app.UseAntiforgery()` are unchanged. The token-based middleware validates each request, and antiforgery tokens are generated for rendered forms as before.
* Apps that don't call `app.UseAntiforgery()` are protected by the automatic CSRF middleware instead. In that configuration, the endpoint skips antiforgery token generation because no token middleware is present to validate a token on a later request.

This is a behavior change for static SSR that previously removed `app.UseAntiforgery()`: they're now protected by the CSRF middleware rather than left unprotected, and they stop emitting antiforgery tokens. For migration guidance, see <xref:migration/100-to-110>. For the formal breaking-change notice, see [Blazor server-side rendering defers antiforgery validation to middleware](/aspnet/core/breaking-changes/11/blazor-server-side-rendering-deferred-cross-site-request-forgery-protection).

### Troubleshooting

**Symptom:** Same-origin requests from a browser succeed, but cross-origin form posts return `400 - Bad Request` with no body.

**Cause:** The CSRF middleware recorded an invalid verdict for the cross-origin request, and a form-processing component—such as an MVC action, a Minimal API form binding, or a Blazor SSR form post—enforced that verdict with a `400 - Bad Request`. This is the expected default behavior for endpoints that process forms.

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

A recorded verdict then appears in the log as:

```text
dbug: Microsoft.AspNetCore.Antiforgery.CsrfProtectionMiddleware[1]
      Cross-origin CSRF protection marked request POST /widgets from origin 'https://attacker.example.com' as invalid.
```

**Reproducing locally:** Use `curl` with an explicit `Origin` header to simulate a cross-origin browser request against a form endpoint:

```bash
curl -i -X POST https://localhost:{PORT}/widgets \
     -H "Origin: https://attacker.example.com" \
     -H "Content-Type: application/x-www-form-urlencoded" \
     -d "name=test"
```

Replace `{PORT}` with the app's local HTTPS port. The `400 - Bad Request` is observed because the endpoint binds the form, which enforces the recorded verdict. A non-form endpoint returns its normal response because nothing reads the verdict. Without the `Origin` header, the same request is allowed because `curl` doesn't send `Sec-Fetch-Site` either and a request with neither header is treated as a non-browser client.

The token-based antiforgery system described in the rest of this article predates this middleware and remains available. For most apps, the automatic protection is enough on its own. For guidance on when to keep the token-based system and how to migrate, see <xref:migration/100-to-110>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

<a name="anti7"></a>

## Antiforgery in ASP.NET Core

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddRazorComponents%2A>

For more information, see [Antiforgery with Minimal APIs](#afwma).

The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_Form":::

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormAntiforgeryFalse":::

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormTagHelperDisabled":::

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormRemoveTagHelper":::

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrfcsrf-and-razor-pages-1).

The most common approach to protecting against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormControllerExamples":::

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormExplicit":::

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```html
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery with `AddControllers`

Calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> does ***not*** enable antiforgery tokens. <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> must be called to have built-in antiforgery token support.

## Multiple browser tabs and the Synchronizer Token Pattern

Multiple tabs logged in as different users, or one logged in as anonymous, are not supported.

## Configure antiforgery with `AntiforgeryOptions`

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in the app's `Program` file:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptions":::

Set the antiforgery cookie properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

Some browsers don't allow insecure endpoints to set cookies with a 'secure' flag or overwrite cookies whose 'secure' flag is set (for more information, see [Deprecate modification of 'secure' cookies from non-secure origins](https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-cookie-alone-01)). Since mixing secure and insecure endpoints is a common scenario in apps, ASP.NET Core relaxes the restriction on the secure policy on some cookies, such as the antiforgery cookie, by setting the cookie's <xref:Microsoft.AspNetCore.Http.CookieBuilder.SecurePolicy%2A> to [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy). Even if a malicious user steals an antiforgery cookie, they also must steal the antiforgery token that's typically sent via a form field (more common) or a separate request header (less common) plus the authentication cookie. Cookies related to authentication or authorization use a stronger policy than [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy).

Optionally, you can secure the antiforgery cookie in non-`Development` environments using Secure Sockets Layer (SSL), over HTTPS only, with the following <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A?displayProperty=nameWithType> property setting in the app's `Program` file:

```csharp
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddAntiforgery(o =>
    {
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
}
```

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Generate antiforgery tokens with `IAntiforgery`

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Program.cs" id="snippet_Middleware" highlight="5,7-20":::

The preceding example sets a cookie named `XSRF-TOKEN`. The client can read this cookie and provide its value as a header attached to AJAX requests. For example, Angular includes [built-in XSRF protection](https://angular.dev/best-practices/security#httpclient-xsrf-csrf-security) that reads a cookie named `XSRF-TOKEN` by default.

### Require antiforgery validation

The [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) action filter can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_ValidateAntiForgeryToken" highlight="2":::

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_AutoValidateAntiforgeryToken":::

Global example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute" highlight="3":::

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_IgnoreAntiforgeryToken" highlight="1":::

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques, such as request headers or cookies, to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### Blazor

For more information, see <xref:blazor/security/index#antiforgery-support>.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Views/JavaScript/Index.cshtml" highlight="1,6,9,23-26":::

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header. 

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client. However, when injecting the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service isn't possible, use JavaScript to access tokens in cookies:

* Access tokens in an additional request to the server, typically usually `same-origin`.
* Use the cookie's contents to create a header with the token's value. 

Assuming the script sends the token in a request header called `X-XSRF-TOKEN`, configure the antiforgery service to look for the `X-XSRF-TOKEN` header:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptionsJavaScript":::

The following example adds a protected endpoint that writes the request token to a JavaScript-readable cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryEndpoint":::

The following example uses JavaScript to make an AJAX request to obtain the token and make another request with the appropriate header:

:::code language="javascript" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Index.js" highlight="1,15":::

<a name="antimin7"></a>

> [!NOTE]
> When the antiforgery token is provided in both the request header and in the form payload, only the token in the header is validated.

<a name="afwma"></a>

## Antiforgery with Minimal APIs

Call [AddAntiforgery](/dotnet/api/microsoft.extensions.dependencyinjection.antiforgeryservicecollectionextensions.addantiforgery) and <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery(Microsoft.AspNetCore.Builder.IApplicationBuilder)> to register antiforgery services in DI.  Antiforgery tokens are used to mitigate [cross-site request forgery attacks](xref:security/anti-request-forgery).

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_short" highlight="3,7":::

The antiforgery middleware:

* Does ***not*** short-circuit the execution of the rest of the request pipeline.
* Sets the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature> in the <xref:Microsoft.AspNetCore.Http.HttpContext.Features%2A?displayProperty=nameWithType> of the current request.

The antiforgery token is only validated if:

* The endpoint contains metadata implementing <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryMetadata> where `RequiresValidation=true`.
* The HTTP method associated with the endpoint is a relevant [HTTP method](https://developer.mozilla.org/docs/Web/HTTP/Methods) of type POST, PUT, or PATCH.
* The request is associated with a valid endpoint.

Antiforgery Middleware doesn't short-circuit the request pipeline. Endpoint code always runs, even if token validation fails. To observe the outcome of the token validation, resolve the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature> from <xref:Microsoft.AspNetCore.Http.HttpContext.Features%2A?displayProperty=nameWithType> and inspect its <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature.IsValid%2A> property or the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryValidationFeature.Error%2A> property for failure details. This approach is useful when endpoints require custom handling for failed antiforgery validation.

***Note:*** When enabled manually, the antiforgery middleware must run after the authentication and authorization middleware to prevent reading form data when the user is unauthenticated.

By default, Minimal APIs that accept form data require antiforgery token validation and fail before running application code if antiforgery validation isn't successful.

Consider the following `GenerateForm` method:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_html":::

The preceding code has three arguments, the action, the antiforgery token, and a `bool` indicating whether the token should be used.

Consider the following sample:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_all" highlight="6,10":::

In the preceding code, posts to:

* `/todo` require a valid antiforgery token.
* `/todo2` do ***not*** require a valid antiforgery token because <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.DisableAntiforgery%2A> is called.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_post":::

> [!WARNING]
> Calling `.DisableAntiforgery()` disables cross-site request forgery (CSRF) protection for the endpoint. This should only be used when an endpoint is not vulnerable to CSRF attacks, such as:
>
> * Endpoints that are not callable from a browser (for example, internal APIs)
> * Endpoints secured with non-cookie-based authentication (for example, bearer tokens or API keys)
> * Internal or infrastructure endpoints that do not rely on user cookies
>
> Do **not** disable antiforgery validation for browser-accessible endpoints that rely on cookies for authentication or that process user-submitted form data, as this exposes your application to CSRF attacks.

A POST to:

* `/todo` from the form generated by the `/` endpoint succeeds because the antiforgery token is valid.
* `/todo` from the form generated by the `/SkipToken` fails because the antiforgery is not included.
* `/todo2` from the form generated by the `/DisableAntiforgery` endpoint succeeds because the antiforgery is not required.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_post":::

When a form is submitted without a valid antiforgery token:

* In the `Development` environment, an exception is thrown.
* In the `Production` environment, a message is logged.

### HTTP method limitations and `HttpMethodOverrideMiddleware` interaction

For the middleware-based antiforgery path, `AntiforgeryMiddleware` and `UseAntiforgery()` validate antiforgery tokens only for HTTP **POST**, **PUT**, and **PATCH** requests. Other HTTP methods, such as **DELETE**, aren't validated automatically.

To validate antiforgery tokens for other HTTP methods, resolve <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> from DI and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.ValidateRequestAsync%2A> or <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.IsRequestValidAsync%2A> explicitly:

```csharp
app.MapDelete("/item/{id}", async (int id, IAntiforgery antiforgery, HttpContext context) =>
{
    await antiforgery.ValidateRequestAsync(context);
    // Process the DELETE request
});
```

> [!WARNING]
> When `HttpMethodOverrideMiddleware` is configured with `FormFieldName` (form-field mode) and placed before `AntiforgeryMiddleware`, a POST request can be overridden to DELETE (or another non-validated method). Because `AntiforgeryMiddleware` validates only POST, PUT, and PATCH, the overridden request bypasses antiforgery validation.
>
> To protect these endpoints:
>
> * Prefer placing `HttpMethodOverrideMiddleware` after antiforgery validation when your pipeline allows it.
> * Avoid form-field overrides for endpoints that rely on antiforgery validation.
> * If form-field override must run first, validate the antiforgery token explicitly using `IAntiforgery.ValidateRequestAsync`.
>
> For configuration details, see <xref:fundamentals/middleware/index>.

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send `https://www.good-banking-site.example.com/` a request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can protect against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed by the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Placing a token in the browser local storage and retrieving it and using it as a bearer token provides protection against CSRF attacks. However, should the app be vulnerable to script injection via XSS or a compromised external javascript file, a cyberattacker could retrieve any value from local storage and send it to themselves. ASP.NET Core encodes all server side output from variables by default, reducing the risk of XSS. If you override this behavior by using [Html.Raw](xref:System.Web.Mvc.HtmlHelper.Raw%2A) or custom code with untrusted input then you may increase the risk of XSS.

Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, login CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

<a name="anti7"></a>

## Antiforgery in ASP.NET Core

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>

The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_Form":::

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormAntiforgeryFalse":::

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormTagHelperDisabled":::

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormRemoveTagHelper":::

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrfcsrf-and-razor-pages-1).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormControllerExamples":::

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormExplicit":::

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```html
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery with `AddControllers`

Calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> does ***not*** enable antiforgery tokens. <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> must be called to have built-in antiforgery token support.

## Multiple browser tabs and the Synchronizer Token Pattern

With the Synchronizer Token Pattern, only the most recently loaded page contains a valid antiforgery token. Using multiple tabs can be problematic. For example, if a user opens multiple tabs:

 * Only the most recently loaded tab contains a valid antiforgery token.
 * Requests made from previously loaded tabs fail with an error: `Antiforgery token validation failed. The antiforgery cookie token and request token do not match`
 
Consider alternative CSRF protection patterns if this poses an issue.

## Configure antiforgery with `AntiforgeryOptions`

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in the app's `Program` file:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptions":::

Set the antiforgery cookie properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

Some browsers don't allow insecure endpoints to set cookies with a 'secure' flag or overwrite cookies whose 'secure' flag is set (for more information, see [Deprecate modification of 'secure' cookies from non-secure origins](https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-cookie-alone-01)). Since mixing secure and insecure endpoints is a common scenario in apps, ASP.NET Core relaxes the restriction on the secure policy on some cookies, such as the antiforgery cookie, by setting the cookie's <xref:Microsoft.AspNetCore.Http.CookieBuilder.SecurePolicy%2A> to [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy). Even if a malicious user steals an antiforgery cookie, they also must steal the antiforgery token that's typically sent via a form field (more common) or a separate request header (less common) plus the authentication cookie. Cookies related to authentication or authorization use a stronger policy than [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy).

Optionally, you can secure the antiforgery cookie in non-`Development` environments using Secure Sockets Layer (SSL), over HTTPS only, with the following <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A?displayProperty=nameWithType> property setting in the app's `Program` file:

```csharp
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddAntiforgery(o =>
    {
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
}
```

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Generate antiforgery tokens with `IAntiforgery`

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Program.cs" id="snippet_Middleware" highlight="5,7-20":::

The preceding example sets a cookie named `XSRF-TOKEN`. The client can read this cookie and provide its value as a header attached to AJAX requests. For example, Angular includes [built-in XSRF protection](https://angular.dev/best-practices/security#httpclient-xsrf-csrf-security) that reads a cookie named `XSRF-TOKEN` by default.

### Require antiforgery validation

The [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) action filter can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_ValidateAntiForgeryToken" highlight="2":::

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_AutoValidateAntiforgeryToken":::

Global example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute" highlight="3":::

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_IgnoreAntiforgeryToken" highlight="1":::

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Views/JavaScript/Index.cshtml" highlight="1,6,9,23-26":::

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header. 

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client. However, when injecting the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service isn't possible, use JavaScript to access tokens in cookies:

* Access tokens in an additional request to the server, typically usually `same-origin`.
* Use the cookie's contents to create a header with the token's value. 

Assuming the script sends the token in a request header called `X-XSRF-TOKEN`, configure the antiforgery service to look for the `X-XSRF-TOKEN` header:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptionsJavaScript":::

The following example adds a protected endpoint that writes the request token to a JavaScript-readable cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryEndpoint":::

The following example uses JavaScript to make an AJAX request to obtain the token and make another request with the appropriate header:

:::code language="javascript" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Index.js" highlight="1,15":::

<a name="antimin7"></a>

> [!NOTE]
> When the antiforgery token is provided in both the request header and in the form payload, only the token in the header is validated.

### Antiforgery with Minimal APIs

`Minimal APIs` do not support the usage of the included filters (`ValidateAntiForgeryToken`, `AutoValidateAntiforgeryToken`, `IgnoreAntiforgeryToken`), however, <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the required APIs to validate a request.

The following example creates a filter that validates the antiforgery token:

[!code-csharp[](anti-request-forgery/samples/7.x/AntiRequestForgeryMinimalSample/Program.cs?name=snippet_AntiforgeryFilter&highlight=9-10)]

The filter can then be applied to an endpoint:

[!code-csharp[](anti-request-forgery/samples/7.x/AntiRequestForgeryMinimalSample/Program.cs?name=snippet_AntiforgeryEndpoint&highlight=3)]

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range="= aspnetcore-6.0"

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send `https://www.good-banking-site.example.com/` a request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can protect against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed by the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, login CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

## Antiforgery in ASP.NET Core

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>

The [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_Form":::

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormAntiforgeryFalse":::

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormTagHelperDisabled":::

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  :::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormRemoveTagHelper":::

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrfcsrf-and-razor-pages-1).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormControllerExamples":::

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Views/Home/Index.cshtml" id="snippet_FormExplicit":::

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```html
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery with `AddControllers`

Calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> does ***not*** enable antiforgery tokens. <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> must be called to have built-in antiforgery token support.

## Multiple browser tabs and the Synchronizer Token Pattern

With the Synchronizer Token Pattern, only the most recently loaded page contains a valid antiforgery token. Using multiple tabs can be problematic. For example, if a user opens multiple tabs:

 * Only the most recently loaded tab contains a valid antiforgery token.
 * Requests made from previously loaded tabs fail with an error: `Antiforgery token validation failed. The antiforgery cookie token and request token do not match`
 
Consider alternative CSRF protection patterns if this poses an issue.

## Configure antiforgery with `AntiforgeryOptions`

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in the app's `Program` file:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptions":::

Set the antiforgery cookie properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

Some browsers don't allow insecure endpoints to set cookies with a 'secure' flag or overwrite cookies whose 'secure' flag is set (for more information, see [Deprecate modification of 'secure' cookies from non-secure origins](https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-cookie-alone-01)). Since mixing secure and insecure endpoints is a common scenario in apps, ASP.NET Core relaxes the restriction on the secure policy on some cookies, such as the antiforgery cookie, by setting the cookie's <xref:Microsoft.AspNetCore.Http.CookieBuilder.SecurePolicy%2A> to [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy). Even if a malicious user steals an antiforgery cookie, they also must steal the antiforgery token that's typically sent via a form field (more common) or a separate request header (less common) plus the authentication cookie. Cookies related to authentication or authorization use a stronger policy than [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy).

Optionally, you can secure the antiforgery cookie in non-`Development` environments using Secure Sockets Layer (SSL), over HTTPS only, with the following <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A?displayProperty=nameWithType> property setting in the app's `Program` file:

```csharp
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddAntiforgery(o =>
    {
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
}
```

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Generate antiforgery tokens with `IAntiforgery`

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in `Program.cs` using <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>. The following example uses middleware from the app's home page to generate an antiforgery token and send it in the response as a cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Program.cs" id="snippet_Middleware" highlight="5,7-20":::

The preceding example sets a cookie named `XSRF-TOKEN`. The client can read this cookie and provide its value as a header attached to AJAX requests. For example, Angular includes [built-in XSRF protection](https://angular.dev/best-practices/security#httpclient-xsrf-csrf-security) that reads a cookie named `XSRF-TOKEN` by default.

### Require antiforgery validation

The [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) action filter can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_ValidateAntiForgeryToken" highlight="2":::

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_AutoValidateAntiforgeryToken":::

Global example:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute" highlight="3":::

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Controllers/HomeController.cs" id="snippet_IgnoreAntiforgeryToken" highlight="1":::

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Views/JavaScript/Index.cshtml" highlight="1,6,9,23-26":::

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header. 

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client. However, when injecting the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service is not possible, JavaScript can also access token in cookies, obtained from an additional request to the server (usually `same-origin`), and use the cookie's contents to create a header with the token's value. 

Assuming the script sends the token in a request header called `X-XSRF-TOKEN`, configure the antiforgery service to look for the `X-XSRF-TOKEN` header:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryOptionsJavaScript":::

The following example adds a protected endpoint that will write the request token to a JavaScript-readable cookie:

:::code language="csharp" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Program.cs" id="snippet_AddAntiforgeryEndpoint":::

The following example uses JavaScript to make an AJAX request to obtain the token and make another request with the appropriate header:

:::code language="javascript" source="anti-request-forgery/samples/6.x/AntiRequestForgerySample/Snippets/Index.js" highlight="1,15":::

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and so endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Cross-site request forgery (also known as XSRF or CSRF) is an attack against web-hosted apps whereby a malicious web app can influence the interaction between a client browser and a web app that trusts that browser. These attacks are possible because web browsers send some types of authentication tokens automatically with every request to a website. This form of exploit is also known as a *one-click attack* or *session riding* because the attack takes advantage of the user's previously authenticated session.

An example of a CSRF attack:

1. A user signs into `www.good-banking-site.example.com` using forms authentication. The server authenticates the user and issues a response that includes an authentication cookie. The site is vulnerable to attack because it trusts any request that it receives with a valid authentication cookie.
1. The user visits a malicious site, `www.bad-crook-site.example.com`.

   The malicious site, `www.bad-crook-site.example.com`, contains an HTML form similar to the following example:

   :::code language="html" source="anti-request-forgery/samples_snapshot/vulnerable-form.html":::

   Notice that the form's `action` posts to the vulnerable site, not to the malicious site. This is the "cross-site" part of CSRF.

1. The user selects the submit button. The browser makes the request and automatically includes the authentication cookie for the requested domain, `www.good-banking-site.example.com`.
1. The request runs on the `www.good-banking-site.example.com` server with the user's authentication context and can perform any action that an authenticated user is allowed to perform.

In addition to the scenario where the user selects the button to submit the form, the malicious site could:

* Run a script that automatically submits the form.
* Send the form submission as an AJAX request.
* Hide the form using CSS.

These alternative scenarios don't require any action or input from the user other than initially visiting the malicious site.

Using HTTPS doesn't prevent a CSRF attack. The malicious site can send `https://www.good-banking-site.example.com/` a request just as easily as it can send an insecure request.

Some attacks target endpoints that respond to GET requests, in which case an image tag can be used to perform the action. This form of attack is common on forum sites that permit images but block JavaScript. Apps that change state on GET requests, where variables or resources are altered, are vulnerable to malicious attacks. **GET requests that change state are insecure. A best practice is to never change state on a GET request.**

CSRF attacks are possible against web apps that use cookies for authentication because:

* Browsers store cookies issued by a web app.
* Stored cookies include session cookies for authenticated users.
* Browsers send all of the cookies associated with a domain to the web app every request regardless of how the request to app was generated within the browser.

However, CSRF attacks aren't limited to exploiting cookies. For example, Basic and Digest authentication are also vulnerable. After a user signs in with Basic or Digest authentication, the browser automatically sends the credentials until the session ends.

In this context, *session* refers to the client-side session during which the user is authenticated. It's unrelated to server-side sessions or [ASP.NET Core Session Middleware](xref:fundamentals/app-state).

Users can protect against CSRF vulnerabilities by taking precautions:

* Sign out of web apps when finished using them.
* Clear browser cookies periodically.

However, CSRF vulnerabilities are fundamentally a problem with the web app, not the end user.

## Authentication fundamentals

Cookie-based authentication is a popular form of authentication. Token-based authentication systems are growing in popularity, especially for Single Page Applications (SPAs).

### Cookie-based authentication

When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes. Generating and validating this cookie is performed by the Cookie Authentication Middleware. The [middleware](xref:fundamentals/middleware/index) serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property.

### Token-based authentication

When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of [claims](/dotnet/framework/security/claims-based-identity-model) or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't *encrypted*; it's *encoded*. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie. For more information, see the GitHub issue [SPA code sample adds two cookies](https://github.com/dotnet/AspNetCore.Docs/issues/13369).

### Multiple apps hosted at one domain

Shared hosting environments are vulnerable to session hijacking, login CSRF, and other attacks.

Although `example1.contoso.net` and `example2.contoso.net` are different hosts, there's an implicit trust relationship between hosts under the `*.contoso.net` domain. This implicit trust relationship allows potentially untrusted hosts to affect each other's cookies (the same-origin policies that govern AJAX requests don't necessarily apply to HTTP cookies).

Attacks that exploit trusted cookies between apps hosted on the same domain can be prevented by not sharing domains. When each app is hosted on its own domain, there's no implicit cookie trust relationship to exploit.

## ASP.NET Core antiforgery configuration

> [!WARNING]
> ASP.NET Core implements antiforgery using [ASP.NET Core Data Protection](xref:security/data-protection/introduction). The data protection stack must be configured to work in a server farm. For more information, see [Configuring data protection](xref:security/data-protection/configuration/overview).

Antiforgery middleware is added to the [Dependency injection](xref:fundamentals/dependency-injection) container when one of the following APIs is called in `Startup.ConfigureServices`:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>
* <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>
* <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>
* <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>

In ASP.NET Core 2.0 or later, the [FormTagHelper](xref:mvc/views/working-with-forms#the-form-tag-helper) injects antiforgery tokens into HTML form elements. The following markup in a Razor file automatically generates antiforgery tokens:

```cshtml
<form method="post">
    ...
</form>
```

Similarly, <xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm%2A?displayProperty=nameWithType> generates antiforgery tokens by default if the form's method isn't GET.

The automatic generation of antiforgery tokens for HTML form elements happens when the `<form>` tag contains the `method="post"` attribute and either of the following are true:

* The action attribute is empty (`action=""`).
* The action attribute isn't supplied (`<form method="post">`).

Automatic generation of antiforgery tokens for HTML form elements can be disabled:

* Explicitly disable antiforgery tokens with the `asp-antiforgery` attribute:

  ```cshtml
  <form method="post" asp-antiforgery="false">
      ...
  </form>
  ```

* The form element is opted-out of Tag Helpers by using the Tag Helper [! opt-out symbol](xref:mvc/views/tag-helpers/intro#opt-out):

  ```cshtml
  <!form method="post">
      ...
  </!form>
  ```

* Remove the `FormTagHelper` from the view. The `FormTagHelper` can be removed from a view by adding the following directive to the Razor view:

  ```cshtml
  @removeTagHelper Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper, Microsoft.AspNetCore.Mvc.TagHelpers
  ```

> [!NOTE]
> [Razor Pages](xref:razor-pages/index) are automatically protected from XSRF/CSRF. For more information, see [XSRF/CSRF and Razor Pages](xref:razor-pages/index#xsrf).

The most common approach to defending against CSRF attacks is to use the *Synchronizer Token Pattern* (STP). STP is used when the user requests a page with form data:

1. The server sends a token associated with the current user's identity to the client.
1. The client sends back the token to the server for verification.
1. If the server receives a token that doesn't match the authenticated user's identity, the request is rejected.

The token is unique and unpredictable. The token can also be used to ensure proper sequencing of a series of requests (for example, ensuring the request sequence of: page 1 > page 2 > page 3). All of the forms in ASP.NET Core MVC and Razor Pages templates generate antiforgery tokens. The following pair of view examples generates antiforgery tokens:

```cshtml
<form asp-controller="Todo" asp-action="Create" method="post">
    ...
</form>

@using (Html.BeginForm("Create", "Todo"))
{
    ...
}
```

Explicitly add an antiforgery token to a `<form>` element without using Tag Helpers with the HTML helper [`@Html.AntiForgeryToken`](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.AntiForgeryToken%2A):

```cshtml
<form action="/" method="post">
    @Html.AntiForgeryToken()
</form>
```

In each of the preceding cases, ASP.NET Core adds a hidden form field similar to the following example:

```cshtml
<input name="__RequestVerificationToken" type="hidden" value="CfDJ8NrAkS ... s2-m9Yw">
```

ASP.NET Core includes three [filters](xref:mvc/controllers/filters) for working with antiforgery tokens:

* [ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute)
* [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute)
* [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute)

## Antiforgery options

Customize <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions> in `Startup.ConfigureServices`:

```csharp
services.AddAntiforgery(options => 
{
    options.FormFieldName = "AntiforgeryFieldname";
    options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
    options.SuppressXFrameOptionsHeader = false;
});
```

Set the antiforgery cookie properties using the properties of the <xref:Microsoft.AspNetCore.Http.CookieBuilder> class, as shown in the following table.

| Option | Description |
| --- | --- |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A> | Determines the settings used to create the antiforgery cookies. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.FormFieldName%2A> | The name of the hidden form field used by the antiforgery system to render antiforgery tokens in views. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.HeaderName%2A> | The name of the header used by the antiforgery system. If `null`, the system considers only form data. |
| <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.SuppressXFrameOptionsHeader%2A> | Specifies whether to suppress generation of the `X-Frame-Options` header. By default, the header is generated with a value of "SAMEORIGIN". Defaults to `false`. |

Some browsers don't allow insecure endpoints to set cookies with a 'secure' flag or overwrite cookies whose 'secure' flag is set (for more information, see [Deprecate modification of 'secure' cookies from non-secure origins](https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-cookie-alone-01)). Since mixing secure and insecure endpoints is a common scenario in apps, ASP.NET Core relaxes the restriction on the secure policy on some cookies, such as the antiforgery cookie, by setting the cookie's <xref:Microsoft.AspNetCore.Http.CookieBuilder.SecurePolicy%2A> to [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy). Even if a malicious user steals an antiforgery cookie, they also must steal the antiforgery token that's typically sent via a form field (more common) or a separate request header (less common) plus the authentication cookie. Cookies related to authentication or authorization use a stronger policy than [`CookieSecurePolicy.None`](xref:Microsoft.AspNetCore.Http.CookieSecurePolicy).

Optionally, you can secure the antiforgery cookie in non-`Development` environments using Secure Sockets Layer (SSL), over HTTPS only, with the following <xref:Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.Cookie%2A?displayProperty=nameWithType> property setting in the app's `Startup` class:

```csharp
public class Startup
{
    public Startup(IConfiguration configuration, IHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Other services are registered here

        if (!Environment.IsDevelopment())
        {
            services.AddAntiforgery(o =>
            {
                o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
        }
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Request processing pipeline
    }
}
```

For more information, see <xref:Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>.

## Configure antiforgery features with IAntiforgery

<xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> provides the API to configure antiforgery features. `IAntiforgery` can be requested in the `Configure` method of the `Startup` class.

In the following example:

* Middleware from the app's home page is used to generate an antiforgery token and send it in the response as a cookie.
* The request token is sent as a JavaScript-readable cookie with the default Angular naming convention described in the [AngularJS](#angularjs) section.

```csharp
public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)
{
    app.Use(next => context =>
    {
        string path = context.Request.Path.Value;

        if (string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
        {
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }

        return next(context);
    });
}
```

### Require antiforgery validation

[ValidateAntiForgeryToken](xref:Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute) is an action filter that can be applied to an individual action, a controller, or globally. Requests made to actions that have this filter applied are blocked unless the request includes a valid antiforgery token.

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel account)
{
    ManageMessageId? message = ManageMessageId.Error;
    var user = await GetCurrentUserAsync();

    if (user != null)
    {
        var result = 
            await _userManager.RemoveLoginAsync(
                user, account.LoginProvider, account.ProviderKey);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            message = ManageMessageId.RemoveLoginSuccess;
        }
    }

    return RedirectToAction(nameof(ManageLogins), new { Message = message });
}
```

The `ValidateAntiForgeryToken` attribute requires a token for requests to the action methods it marks, including HTTP GET requests. If the `ValidateAntiForgeryToken` attribute is applied across the app's controllers, it can be overridden with the `IgnoreAntiforgeryToken` attribute.

> [!NOTE]
> ASP.NET Core doesn't support adding antiforgery tokens to GET requests automatically.

### Automatically validate antiforgery tokens for unsafe HTTP methods only

ASP.NET Core apps don't generate antiforgery tokens for safe HTTP methods (GET, HEAD, OPTIONS, and TRACE). Instead of broadly applying the `ValidateAntiForgeryToken` attribute and then overriding it with `IgnoreAntiforgeryToken` attributes, the [AutoValidateAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute) attribute can be used. This attribute works identically to the `ValidateAntiForgeryToken` attribute, except that it doesn't require tokens for requests made using the following HTTP methods:

* GET
* HEAD
* OPTIONS
* TRACE

We recommend use of `AutoValidateAntiforgeryToken` broadly for non-API scenarios. This attribute ensures POST actions are protected by default. The alternative is to ignore antiforgery tokens by default, unless `ValidateAntiForgeryToken` is applied to individual action methods. It's more likely in this scenario for a POST action method to be left unprotected by mistake, leaving the app vulnerable to CSRF attacks. All POSTs should send the antiforgery token.

APIs don't have an automatic mechanism for sending the non-cookie part of the token. The implementation probably depends on the client code implementation. Some examples are shown below:

Class-level example:

```csharp
[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
```

Global example:

```csharp
services.AddControllersWithViews(options =>
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
```

### Override global or controller antiforgery attributes

The [IgnoreAntiforgeryToken](xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute) filter is used to eliminate the need for an antiforgery token for a given action (or controller). When applied, this filter overrides `ValidateAntiForgeryToken` and `AutoValidateAntiforgeryToken` filters specified at a higher level (globally or on a controller).

```csharp
[Authorize]
[AutoValidateAntiforgeryToken]
public class ManageController : Controller
{
    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> DoSomethingSafe(SomeViewModel model)
    {
        // no antiforgery token required
    }
}
```

## Refresh tokens after authentication

Tokens should be refreshed after the user is authenticated by redirecting the user to a view or Razor Pages page.

## JavaScript, AJAX, and SPAs

In traditional HTML-based apps, antiforgery tokens are passed to the server using hidden form fields. In modern JavaScript-based apps and SPAs, many requests are made programmatically. These AJAX requests may use other techniques (such as request headers or cookies) to send the token.

If cookies are used to store authentication tokens and to authenticate API requests on the server, CSRF is a potential problem. If local storage is used to store the token, CSRF vulnerability might be mitigated because values from local storage aren't sent automatically to the server with every request. Using local storage to store the antiforgery token on the client and sending the token as a request header is a recommended approach.

### JavaScript

Using JavaScript with views, the token can be created using a service from within the view. Inject the <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery> service into the view and call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgery.GetAndStoreTokens%2A>:

:::code language="cshtml" source="anti-request-forgery/samples/2.x/MvcSample/Views/Home/Ajax.cshtml" highlight="4-10,12-13,35-36":::

This approach eliminates the need to deal directly with setting cookies from the server or reading them from the client.

The preceding example uses JavaScript to read the hidden field value for the AJAX POST header.

JavaScript can also access tokens in cookies and use the cookie's contents to create a header with the token's value.

```csharp
context.Response.Cookies.Append("CSRF-TOKEN", tokens.RequestToken, 
    new Microsoft.AspNetCore.Http.CookieOptions { HttpOnly = false });
```

Assuming the script requests to send the token in a header called `X-CSRF-TOKEN`, configure the antiforgery service to look for the `X-CSRF-TOKEN` header:

```csharp
services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
```

The following example uses JavaScript to make an AJAX request with the appropriate header:

```javascript
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

var csrfToken = getCookie("CSRF-TOKEN");

var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function () {
    if (xhttp.readyState === XMLHttpRequest.DONE) {
        if (xhttp.status === 204) {
            alert('Todo item is created successfully.');
        } else {
            alert('There was an error processing the AJAX request.');
        }
    }
};
xhttp.open('POST', '/api/items', true);
xhttp.setRequestHeader("Content-type", "application/json");
xhttp.setRequestHeader("X-CSRF-TOKEN", csrfToken);
xhttp.send(JSON.stringify({ "name": "Learn C#" }));
```

### AngularJS

AngularJS uses a convention to address CSRF. If the server sends a cookie with the name `XSRF-TOKEN`, the AngularJS `$http` service adds the cookie value to a header when it sends a request to the server. This process is automatic. The client doesn't need to set the header explicitly. The header name is `X-XSRF-TOKEN`. The server should detect this header and validate its contents.

For ASP.NET Core API to work with this convention in your application startup:

* Configure your app to provide a token in a cookie called `XSRF-TOKEN`.
* Configure the antiforgery service to look for a header named `X-XSRF-TOKEN`, which is Angular's default header name for sending the XSRF token.

```csharp
public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)
{
    app.Use(next => context =>
    {
        string path = context.Request.Path.Value;

        if (
            string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
        {
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
                new CookieOptions() { HttpOnly = false });
        }

        return next(context);
    });
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
}
```

> [!NOTE]
> When the antiforgery token is provided in both the request header and in the form payload, only the token in the header is validated.

## Windows authentication and antiforgery cookies

When using Windows Authentication, application endpoints must be protected against CSRF attacks in the same way as done for cookies. The browser implicitly sends the authentication context to the server and so endpoints need to be protected against CSRF attacks.

## Extend antiforgery

The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider> type allows developers to extend the behavior of the anti-CSRF system by round-tripping additional data in each token. The <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData%2A> method is called each time a field token is generated, and the return value is embedded within the generated token. An implementer could return a timestamp, a nonce, or any other value and then call <xref:Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData%2A> to validate this data when the token is validated. The client's username is already embedded in the generated tokens, so there's no need to include this information. If a token includes supplemental data but no `IAntiForgeryAdditionalDataProvider` is configured, the supplemental data isn't validated.

## Additional resources

* <xref:host-and-deploy/web-farm>

:::moniker-end
