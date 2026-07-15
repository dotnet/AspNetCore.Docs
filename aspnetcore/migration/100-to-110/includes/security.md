### Automatic CSRF protection

.NET 11 adds automatic Cross-Site Request Forgery (CSRF) protection. When an app is built with `WebApplication.CreateBuilder` and has endpoints, a middleware is wired up by default that inspects the `Sec-Fetch-Site` and `Origin` headers and records a validation verdict on the request.

The middleware validates endpoints that opt in to antiforgery validation — that is, endpoints with metadata implementing `IAntiforgeryMetadata` where `RequiresValidation` is `true`. The framework sets this automatically for:

* All Blazor server-side rendering (SSR) endpoints. Each is protected by default; a page can opt out with `@attribute [RequireAntiforgeryToken(false)]`.
* Minimal API endpoints that bind form data.
* MVC actions that use antiforgery validation, such as those annotated with `[ValidateAntiForgeryToken]` or `[AutoValidateAntiforgeryToken]`.

Endpoints that bind JSON, such as a plain `MapPost` or a Web API `[HttpPost]` action, have no behavioral change.

Going forward, the automatic CSRF protection is the recommended defense, and most apps no longer need the token-based antiforgery system. Keep the token-based system when the app must support browsers that don't send `Sec-Fetch-Site`, uses `IAntiforgeryAdditionalDataProvider`, or must keep the token defense as an independent layer for a compliance requirement. Both protections can coexist.

To simplify an app that configures antiforgery explicitly, drop the `AddAntiforgery()` and `UseAntiforgery()` calls and rely on the automatic protection. For most apps this is a one-line change with no other code updates. For Blazor static SSR, removing `app.UseAntiforgery()` also stops antiforgery token generation for rendered forms; see [Blazor server-side rendering defers antiforgery validation to middleware](/aspnet/core/breaking-changes/11/blazor-server-side-rendering-deferred-cross-site-request-forgery-protection).

A `400 Bad Request` on a cross-origin form post is the CSRF protection working as intended. When the request comes from a legitimate origin, allow that origin rather than suppressing the check:

* Configure [CORS](xref:security/cors) so the endpoint's resolved policy includes the caller's origin. The CSRF middleware honors that policy and allows the request.
* Only opt an endpoint out — with `.DisableAntiforgery()` (minimal APIs) or `[IgnoreAntiforgeryToken]` (MVC) — when it isn't vulnerable to CSRF, such as an endpoint that isn't reachable from a browser or that authenticates with a non-cookie mechanism like a bearer token.

For a full description of the middleware, the validation rules, and how it interacts with the token-based antiforgery system, see <xref:security/csrf-protection>.
