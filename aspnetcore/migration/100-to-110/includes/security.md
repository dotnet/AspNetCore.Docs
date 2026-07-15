### Automatic CSRF protection

.NET 11 adds automatic Cross-Site Request Forgery (CSRF) protection. When an app is built with `WebApplication.CreateBuilder` and has endpoints, a middleware is wired up by default that inspects the `Sec-Fetch-Site` and `Origin` headers on unsafe HTTP methods and records a validation verdict on the request.

The middleware only validates endpoints that already require antiforgery validation, which the framework attaches automatically to form-handling endpoints:

* Blazor server-side rendering (SSR) form posts.
* Minimal API endpoints that bind form data.
* MVC actions annotated with `[ValidateAntiForgeryToken]` or `[AutoValidateAntiforgeryToken]`.

Endpoints without antiforgery metadata — for example, a plain `MapPost` or `[HttpPost]` that binds JSON — aren't affected, so nothing that worked on .NET 10 starts failing on .NET 11.

Going forward, the automatic CSRF protection is the recommended defense, and most apps no longer need the token-based antiforgery system. Keep the token-based system when the app must support browsers that don't send `Sec-Fetch-Site`, uses `IAntiforgeryAdditionalDataProvider`, or must keep the token defense as an independent layer for a compliance requirement. Both protections can coexist.

To simplify an app that configures antiforgery explicitly, drop the `AddAntiforgery()` and `UseAntiforgery()` calls and rely on the automatic protection. For most apps this is a one-line change with no other code updates.

If a cross-origin form post from a browser starts returning `400 Bad Request` after the upgrade:

* Configure [CORS](xref:security/cors) so the endpoint's resolved policy trusts the caller's origin. The CSRF middleware honors that policy.
* Or call `.DisableAntiforgery()` (minimal APIs) or apply `[IgnoreAntiforgeryToken]` (MVC) on endpoints that aren't reachable from a browser or that use non-cookie authentication.

For a full description of the middleware, the validation rules, and how it interacts with the token-based antiforgery system, see <xref:security/csrf-protection>.
