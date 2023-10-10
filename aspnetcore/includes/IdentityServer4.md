ASP.NET Core Identity adds user interface (UI) login functionality to ASP.NET Core web apps. To secure web APIs and SPAs, use one of the following:

* [Microsoft Entra ID](/azure/api-management/api-management-howto-protect-backend-with-aad)
* [Azure Active Directory B2C](/azure/active-directory-b2c/active-directory-b2c-custom-rest-api-netfw) (Azure AD B2C)
* [Duende IdentityServer](https://docs.duendesoftware.com/identityserver/v6/overview/). Duende IdentityServer is 3rd party product.

Duende IdentityServer is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core. Duende IdentityServer enables the following security features:

* Authentication as a Service (AaaS)
* Single sign-on/off (SSO) over multiple application types
* Access control for APIs
* Federation Gateway

For more information, see [Overview of Duende IdentityServer](https://docs.duendesoftware.com/identityserver/v6/overview/).

For more information on other authentication providers, see [Community OSS authentication options for ASP.NET Core](xref:security/authentication/community)
