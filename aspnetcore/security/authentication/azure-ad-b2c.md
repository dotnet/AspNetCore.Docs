---
title: Cloud authentication with Azure Active Directory B2C in ASP.NET Core
ai-usage: ai-assisted
author: guardrex
description: Discover how to set up Azure Active Directory B2C authentication with ASP.NET Core.
ms.author: wpickett
ms.custom: "devx-track-csharp, mvc"
ms.date: 03/25/2026
uid: security/authentication/azure-ad-b2c
---
# Cloud authentication with Azure Active Directory B2C in ASP.NET Core

[!INCLUDE[](~/includes/azure-active-directory-b2c-eol-support-notice.md)]

## Recommended path for new projects

[Microsoft Entra External ID for customers](/entra/external-id/customers/overview-customers-ciam) is the recommended customer identity and access management (CIAM) solution for new ASP.NET Core applications, replacing Azure AD B2C with the latest identity platform features.

To get started with a new project, see [Sign in users in a sample ASP.NET Core web app](/entra/external-id/customers/sample-web-app-dotnet-sign-in).

## Guidance for existing Azure AD B2C projects

Azure AD B2C remains supported for existing applications. Authoritative setup and configuration guidance is maintained in the Azure AD B2C documentation. The following articles cover the topics that ASP.NET Core developers typically need:

| Topic | Article |
|---|---|
| Create a tenant | [Tutorial: Create an Azure AD B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) |
| Register a web application | [Tutorial: Register a web application in Azure AD B2C](/azure/active-directory-b2c/tutorial-register-applications) |
| Configure authentication in an ASP.NET Core app | [Configure authentication in a sample ASP.NET Core web app](/azure/active-directory-b2c/configure-authentication-sample-web-app) |
| Enable multi-factor authentication | [Enable MFA in Azure AD B2C](/azure/active-directory-b2c/multi-factor-authentication) |

## ASP.NET Core integration checklist

After completing identity provider setup using the Entra or Azure AD B2C documentation, complete the following ASP.NET Core-specific steps:

1. **Install NuGet packages** &mdash; Add the [`Microsoft.Identity.Web`](https://www.nuget.org/packages/Microsoft.Identity.Web) and [`Microsoft.Identity.Web.UI`](https://www.nuget.org/packages/Microsoft.Identity.Web.UI) packages:

   ```dotnetcli
   dotnet add package Microsoft.Identity.Web
   dotnet add package Microsoft.Identity.Web.UI
   ```

1. **Configure services in `Program.cs`** &mdash; Call `AddMicrosoftIdentityWebApp` to configure OpenID Connect authentication for the Microsoft identity platform, and call `AddMicrosoftIdentityUI` to add the required sign-in/sign-out UI components. For the full API reference, see the [Microsoft Identity Web documentation](https://github.com/AzureAD/microsoft-identity-web/wiki).

1. **Add configuration** &mdash; Add the `AzureADB2C` section in `appsettings.json` with values that match your tenant and app registration. See [Configure authentication in a sample ASP.NET Core web app](/azure/active-directory-b2c/configure-authentication-sample-web-app) for the complete schema and sample.

## Additional resources

* [Microsoft Entra External ID for customers overview](/entra/external-id/customers/overview-customers-ciam)
* [Azure AD B2C documentation](/azure/active-directory-b2c/)
* [Customize the Azure AD B2C user interface](/azure/active-directory-b2c/customize-ui)
* [Configure password complexity in Azure AD B2C](/azure/active-directory-b2c/password-complexity)
* [Enable multi-factor authentication in Azure AD B2C](/azure/active-directory-b2c/multi-factor-authentication)
* [Microsoft Graph API with Azure AD B2C](/azure/active-directory-b2c/microsoft-graph-operations)
* <xref:security/authentication/index>
