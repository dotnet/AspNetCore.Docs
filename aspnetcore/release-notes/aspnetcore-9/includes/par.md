### OpenIdConnectHandler adds support for Pushed Authorization Requests (PAR)

We'd like to thank [Joe DeCock](https://github.com/josephdecock) from [Duende Software](https://github.com/DuendeSoftware) for adding Pushed Authorization Requests (PAR) to ASP.NET Core's [OpenIdConnectHandler](/dotnet/api/microsoft.aspnetcore.authentication.openidconnect.openidconnecthandler). Joe described the background and motivation for enabling PAR in [his API proposal](https://github.com/dotnet/aspnetcore/issues/51686) as follows:

> Pushed Authorization Requests (PAR) is a relatively new [OAuth standard](https://datatracker.ietf.org/doc/html/rfc9126) that improves the security of OAuth and OIDC flows by moving authorization parameters from the front channel to the back channel. Thats is, moving authorization parameters from redirect URLs in the browser to direct machine to machine http calls on the back end.
>
> This prevents an attacker in the browser from:
>
> * Seeing authorization parameters, which could leak PII.
> * Tampering with those parameters, e.g., the attacker could change the scope of access being requested.
>
> Pushing the authorization parameters also keeps request URLs short. Authorize parameters can get very long when using more complex OAuth and OIDC features such as [Rich Authorization Requests](https://oauth.net/2/rich-authorization-requests/). URLs that are long cause issues in many browsers and networking infrastructures.
>
> The use of PAR is encouraged by the [FAPI working group](https://openid.net/wg/fapi/) within the OpenID Foundation. For example, [the FAPI2.0 Security Profile](https://openid.bitbucket.io/fapi/fapi-2_0-security-profile.html) requires the use of PAR. This security profile is used by many of the groups working on open banking (primarily in Europe), in health care, and in other industries with high security requirements.
>
> PAR is supported by a number of identity providers, including
>
> * [Duende IdentityServer](https://duendesoftware.com/products/identityserver)
> * [Curity](https://curity.io/product/)
> * [Keycloak](https://www.keycloak.org/)
> * [Authlete](https://www.authlete.com/developers/tutorial/oidc/)

For .NET 9, we have decided to enable PAR by default if the identity provider's discovery document advertises support for PAR, since it should provide enhanced security for providers that support it. The identity provider's discovery document is usually found at `.well-known/openid-configuration`. If this causes problems, you can disable PAR via [OpenIdConnectOptions.PushedAuthorizationBehavior](https://source.dot.net/#Microsoft.AspNetCore.Authentication.OpenIdConnect/OpenIdConnectOptions.cs,99014cc0333b1603) as follows:

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/PAR/Program.cs" id="snippet_1" highlight="8-99":::

To ensure that authentication only succeeds if PAR is used, use [PushedAuthorizationBehavior.Require](https://source.dot.net/#Microsoft.AspNetCore.Authentication.OpenIdConnect/PushedAuthorizationBehavior.cs,3af73de8f33b70c5) instead. This change also introduces a new [OnPushAuthorization](https://source.dot.net/#Microsoft.AspNetCore.Authentication.OpenIdConnect/Events/OpenIdConnectEvents.cs,6a21c8f3a90753c1) event to [OpenIdConnectEvents](/dotnet/api/microsoft.aspnetcore.authentication.openidconnect.openidconnectevents) which can be used customize the pushed authorization request or handle it manually. See the [API proposal](https://github.com/dotnet/aspnetcore/issues/51686) for more details.
