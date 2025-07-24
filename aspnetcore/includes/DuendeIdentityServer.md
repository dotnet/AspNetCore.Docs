ASP.NET Core Identity adds user interface (UI) login functionality to ASP.NET Core web apps. To secure web APIs and SPAs, use one of the following:

* [Microsoft Entra ID](/azure/api-management/api-management-howto-protect-backend-with-aad)
* [Azure Active Directory B2C](/azure/active-directory-b2c/active-directory-b2c-custom-rest-api-netfw) (Azure AD B2C)
* [Duende Identity Server](https://docs.duendesoftware.com)

Duende Identity Server is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core. Duende Identity Server enables the following security features:

* Authentication as a Service (AaaS)
* Single sign-on/off (SSO) over multiple application types
* Access control for APIs
* Federation Gateway

> [!IMPORTANT]
> [Duende Software](https://duendesoftware.com/) might require you to pay a license fee for production use of Duende Identity Server. For more information, see <xref:migration/50-to-60#project-templates-use-duende-identity-server>.

For more information, see the [Duende Identity Server documentation (Duende Software website)](https://docs.duendesoftware.com).
