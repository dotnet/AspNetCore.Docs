### Adopt automatic CSRF protection

.NET 11 adds an automatic Cross-Site Request Forgery (CSRF) protection middleware that's enabled by default in apps built with `WebApplication.CreateBuilder`. The middleware inspects the `Sec-Fetch-Site` and `Origin` headers on unsafe HTTP methods and records a validation verdict on the request. Form-consuming components — MVC actions, minimal API form binding, and Blazor server-side rendering (SSR) form posts — enforce that verdict and return `400 Bad Request` for cross-origin form posts that aren't trusted.

Depending on how your app uses antiforgery today:

* **If the app calls `AddAntiforgery()` and `UseAntiforgery()` explicitly:** consider dropping both calls and relying on the automatic CSRF protection instead. For most apps this is a one-line change and doesn't require any other code updates. The token-based system remains available if you still need it — see <xref:migration/antiforgery-to-csrf> for the trade-offs.
* **If the app doesn't configure antiforgery explicitly:** you now get CSRF protection automatically. Same-origin browser traffic, safe HTTP methods, and non-browser clients such as `curl`, mobile apps, and server-to-server callers pass through unchanged. No action is required.

To opt an endpoint out, call `.DisableAntiforgery()` on it. To allow a specific cross-origin browser client, configure [CORS](xref:security/cors) so the endpoint's resolved policy trusts the caller's origin; the CSRF middleware honors that policy.

For a full description of the middleware, the validation rules, and how it interacts with the token-based antiforgery system, see <xref:security/csrf-protection>.

