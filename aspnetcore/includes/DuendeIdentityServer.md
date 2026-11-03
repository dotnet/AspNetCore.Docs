ASP.NET Core Identity adds user interface (UI) login functionality to ASP.NET Core web apps. To secure web APIs and SPAs, consider one of the following:

* [Microsoft Entra ID](/azure/api-management/api-management-howto-protect-backend-with-aad)
* [OpenIddict](https://documentation.openiddict.com/)
* [Duende IdentityServer](https://docs.duendesoftware.com)
* Other [community-supported authentication solutions](../security/authentication/community.md)

For a comparison of identity solutions, see [Identity management solutions for .NET web apps](../security/identity-management-solutions.md).

Duende IdentityServer is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core. Duende IdentityServer enables the following security features:

* Authentication as a Service (AaaS)
* Single sign-on/off (SSO) over multiple application types
* Access control for APIs
* Federation Gateway

> [!IMPORTANT]
> [Duende Software](https://duendesoftware.com/) might require you to pay a license fee for production use of Duende IdentityServer. For more information, see [Migrate from ASP.NET Core in .NET 5 to .NET 6](../migration/50-to-60.md#project-templates-use-duende-identity-server).

For more information, see the [Duende IdentityServer documentation (Duende Software website)](https://docs.duendesoftware.com).
