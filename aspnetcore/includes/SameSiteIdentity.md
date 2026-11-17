ASP.NET Core [Identity](../security/authentication/identity.md) is largely unaffected by [SameSite cookies](../security/samesite.md) except for advanced scenarios like `IFrames` or `OpenIdConnect` integration.

When using `Identity`, do ***not*** add any cookie providers or call ` services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)`, `Identity` takes care of that.