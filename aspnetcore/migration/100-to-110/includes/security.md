### Adopt automatic CSRF protection

.NET 11 adds an automatic Cross-Site Request Forgery (CSRF) protection middleware that's enabled by default in apps built with `WebApplication.CreateBuilder`. The middleware inspects the `Sec-Fetch-Site` and `Origin` headers on unsafe HTTP methods and records a validation verdict on the request. Form-consuming components — MVC actions, minimal API form binding, and Blazor server-side rendering (SSR) form posts — enforce that verdict and return `400 Bad Request` for cross-origin form posts that aren't trusted.

Most apps aren't affected: same-origin browser traffic, safe HTTP methods, and non-browser clients such as `curl`, mobile apps, and server-to-server callers pass through unchanged. Apps that accept **cross-origin form posts from a browser** — for example, a site at `https://app.contoso.com` posting a form to an API at `https://api.contoso.com` — need to either:

* Configure [CORS](xref:security/cors) so the API's resolved policy trusts the caller's origin, or
* Opt the endpoint out by calling `.DisableAntiforgery()` on the endpoint.

For a full description of the middleware, how the verdict is computed, and how it interacts with the token-based antiforgery system, see <xref:security/csrf-protection>. Apps that use the token-based antiforgery system today can also review <xref:migration/antiforgery-to-csrf> for guidance on whether to keep or drop token validation.
