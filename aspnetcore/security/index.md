---
title: ASP.NET Core security topics
description: Find topics about working with security in your ASP.NET Core apps, including links to articles on authentication and authorization.
ms.custom: sfi-ropc-nochange
ms.date: 10/22/2026

# customer intent: As an ASP.NET developer, I want to find topics about working with security in ASP.NET, so I can add authentication and authorization features to my apps.
---
# ASP.NET Core security topics

ASP.NET Core enables developers to configure and manage security. The following list provides links to articles about working with security in ASP.NET Core:

* [Authentication](authentication/index.md)
* [Authorization](authorization/introduction.md)
* [Data protection](data-protection/introduction.md)
* [HTTPS enforcement](enforcing-ssl.md)
* [Safe storage of app secrets in development](app-secrets.md)
* [XSRF/CSRF prevention](anti-request-forgery.md)
* [Cross Origin Resource Sharing (CORS)](cors.md)
* [Cross-Site Scripting (XSS) attacks](cross-site-scripting.md)

These security features allow you to build robust and secure ASP.NET Core apps.

For Blazor security coverage, which adds to or supersedes the guidance in this node, see <xref:blazor/security/index> and the other articles in Blazor's *Security and Identity* node.

## ASP.NET Core security features

ASP.NET Core provides many tools and libraries to secure ASP.NET Core apps, such as built-in identity providers and non-Microsoft identity services like Facebook, Twitter, and LinkedIn. ASP.NET Core provides several approaches to store app secrets.

## Authentication vs. Authorization

[Authentication](authentication/index.md) is a process where a user provides credentials that are compared to credentials stored in an operating system, database, app, or resource. When the two sets of credentials match, the user authenticates successfully. They can then perform actions for which they're authorized. The [authorization](authorization/introduction.md) process determines the actions the user is allowed to do.

Another way to think of authentication is to consider it as a way to **enter** a space, where the space is a server, database, app, or resource. Authorization defines **what actions** the user can perform to which objects inside that space (server, database, or app).

## Common vulnerabilities in software

ASP.NET Core and Entity Framework contain features that help you secure your apps and prevent security breaches. The following list of links takes you to documentation detailing techniques to avoid the most common security vulnerabilities in web apps:

* [Cross-Site Scripting (XSS) attacks](cross-site-scripting.md)
* [SQL queries > SQL injection attacks](/ef/core/querying/sql-queries#passing-parameters)
* [Cross-Site Request Forgery (XSRF/CSRF) attacks](anti-request-forgery.md)
* [Open redirect attacks](preventing-open-redirects.md)
* [Software supply chain vulnerabilities (NuGet security best practices)](/nuget/concepts/security-best-practices#knowing-what-is-in-your-environment)

There are more vulnerabilities that you should be aware of. For more information, see the other articles in the **Security and Identity** section of the table of contents.

## Secure authentication flows

We recommend using the most secure authentication option. For Azure services, the most secure authentication is [managed identities](/entra/identity/managed-identities-azure-resources/overview).

Avoid using the Resource Owner Password Credentials (ROPG) grant:

* It exposes the user's password to the client.
* It's a significant security risk.
* Use it only when other authentication flows aren't possible.

Managed identities are a secure way to authenticate to services without needing to store credentials in code, environment variables, or configuration files. Managed identities are available for Azure services, and can be used with Azure SQL, Azure Storage, and other Azure services:

* [Managed identities in Microsoft Entra for Azure SQL](/azure/azure-sql/database/authentication-azure-ad-user-assigned-managed-identity)
* [Managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
* [Secure authentication flows](/entra/identity-platform/authentication-flows-app-scenarios#web-app-that-signs-in-a-user)

When the app is deployed to a test server, an environment variable can be used to set the connection string to a test database server. For more information, see [Configuration](../fundamentals/configuration/index.md). Environment variables are commonly stored in plain, unencrypted text. If the machine or process is compromised, environment variables might be accessible to untrusted parties. We recommend against using environment variables to store a production connection string as it's not the most secure approach.

Configuration data guidelines:

* Never store passwords or other sensitive data in configuration provider code or in plain text configuration files. The [Secret Manager](app-secrets.md) tool can be used to store secrets in development.
* Don't use production secrets in development or test environments.
* Specify secrets outside of the project so that they can't be accidentally committed to a source code repository.

For more information, see:

* [Managed identity best practice recommendations](/entra/identity/managed-identities-azure-resources/managed-identity-best-practice-recommendations)
* [Connecting from your application to resources without handling credentials in your code](/entra/identity/managed-identities-azure-resources/overview-for-developers?tabs=portal%2Cdotnet)
* [Azure services that can use managed identities to access other services](/entra/identity/managed-identities-azure-resources/managed-identities-status)
* [IETF OAuth 2.0 Security Best Current Practice (Section 2.4. Resource Owner Password Credentials Grant)](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics#section-2.4)

For information on other cloud providers, see:

* [AWS (Amazon Web Services): AWS Key Management Service (KMS)](https://aws.amazon.com/kms/)
* [Google Cloud Key Management Service overview](https://docs.cloud.google.com/kms/docs/key-management-service)

[!INCLUDE[](~/includes/reliableWAP_H2.md)]

## Related content

* [Introduction to Identity on ASP.NET Core](authentication/identity.md)
* [Enable QR code generation for TOTP authentication](authentication/identity-enable-qrcodes.md)
* [Using external login providers with Identity in ASP.NET Core](authentication/social/index.md) 
* [Identity management solutions for .NET web apps](identity-management-solutions.md)
