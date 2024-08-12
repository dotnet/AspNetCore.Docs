### OpenIdConnectHandler adds support for Pushed Authorization Requests (PAR)

We'd like to thank @josephdecock from @DuendeSoftware for adding Pushed Authorization Requests (PAR) to ASP.NET Core's `OpenIdConnectHandler`. Joe described the background and motivation for enabling PAR in [his API proposal](https://github.com/dotnet/aspnetcore/issues/51686) as follows:

> Pushed Authorization Requests (PAR) is a relatively new [OAuth standard](https://datatracker.ietf.org/doc/html/rfc9126) that improves the security of OAuth and OIDC flows by moving authorization parameters from the front channel to the back channel (that is, from redirect URLs in the browser to direct machine to machine http calls on the back end).
>
> This prevents an attacker in the browser from
>
> * seeing authorization parameters (which could leak PII) and from
> * tampering with those parameters (e.g., the attacker could change the scope of access being requested).
>
> Pushing the authorization parameters also keeps request URLs short. Authorize parameters might get very long when using more complex OAuth and OIDC features such as Rich Authorization Requests, and URLs that are long cause issues in many browsers and networking infrastructure.
>
> The use of PAR is encouraged by the [FAPI working group](https://openid.net/wg/fapi/) within the OpenID Foundation. For example, [the FAPI2.0 Security Profile](https://openid.bitbucket.io/fapi/fapi-2_0-security-profile.html) requires the use of PAR. This security profile is used by many of the groups working on open banking (primarily in Europe), in health care, and in other industries with high security requirements.
>
> PAR is supported by a number of identity providers, including
>
> * Duende IdentityServer
> * Curity
> * Keycloak
> * Authlete

For preview7, we have decided to enable PAR by default if the identity provider's discovery document (usually found at `.well-known/openid-configuration`) advertises support for PAR, since it should provide enhanced security for providers that support it. If this causes problems, you can disable PAR via `OpenIdConnectOptions.PushedAuthorizationBehavior` as follows:

```csharp
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(oidcOptions =>
    {
        // Other provider-specific configuration goes here.

        // The default value is PushedAuthorizationBehavior.UseIfAvailable.
        oidcOptions.PushedAuthorizationBehavior = PushedAuthorizationBehavior.Disable;
    });
```

If you want to ensure that authentication only succeeds if PAR is used, you can use `PushedAuthorizationBehavior.Require` instead. This change also introduces a new `OnPushAuthorization` event to `OpenIdConnectEvents` which can be used customize the pushed authorization request or handle it manually. Please refer to the API proposal for more details.
