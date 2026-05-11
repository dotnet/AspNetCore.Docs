---
title: ASP.NET Core security topics
author: tdykstra
description: Find topics about working with security in your ASP.NET Core apps, including links to articles on authentication and authorization.
ms.author: tdykstra
ms.custom: mvc, sfi-ropc-nochange
ms.date: 05/12/2026
uid: security/index

# customer intent: As an ASP.NET developer, I want to find topics about working with security in ASP.NET, so I can add authentication and authorization features to my apps.
---
# ASP.NET Core security topics

ASP.NET Core enables developers to configure and manage security. The following list provides links to articles about working with security in ASP.NET Core:

* [Authentication](xref:security/authentication/index)
* [Authorization](xref:security/authorization/introduction)
* [Data protection](xref:security/data-protection/introduction)
* [HTTPS enforcement](xref:security/enforcing-ssl)
* [Safe storage of app secrets in development](xref:security/app-secrets)
* [XSRF/CSRF prevention](xref:security/anti-request-forgery)
* [Cross Origin Resource Sharing (CORS)](xref:security/cors)
* [Cross-Site Scripting (XSS) attacks](xref:security/cross-site-scripting)

These security features allow you to build robust and secure ASP.NET Core apps.

For Blazor security coverage, which adds to or supersedes the guidance in this node, see <xref:blazor/security/index> and the other articles in Blazor's *Security and Identity* node.

## ASP.NET Core security features

ASP.NET Core provides many tools and libraries to secure ASP.NET Core apps, such as built-in identity providers and non-Microsoft identity services like Facebook, Twitter, and LinkedIn. ASP.NET Core provides several approaches to store app secrets.

## Authentication vs. Authorization

[Authentication](xref:security/authentication/index) is a process where a user provides credentials that are compared to credentials stored in an operating system, database, app, or resource. When the two sets of credentials match, the user authenticates successfully. They can then perform actions for which they're authorized. The [authorization](xref:security/authorization/introduction) process determines the actions the use is allowed to do.

Another way to think of authentication is to consider it as a way to **enter** a space, where the space is a server, database, app, or resource. Authorization defines **what actions** the user can perform to which objects inside that space (server, database, or app).

## Common vulnerabilities in software

ASP.NET Core and Entity Framework contain features that help you secure your apps and prevent security breaches. The following list of links takes you to documentation detailing techniques to avoid the most common security vulnerabilities in web apps:

* [Cross-Site Scripting (XSS) attacks](xref:security/cross-site-scripting)
* [SQL queries > SQL injection attacks](/ef/core/querying/sql-queries#passing-parameters)
* [Cross-Site Request Forgery (XSRF/CSRF) attacks](xref:security/anti-request-forgery)
* [Open redirect attacks](xref:security/preventing-open-redirects)

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

When the app is deployed to a test server, an environment variable can be used to set the connection string to a test database server. For more information, see [Configuration](xref:fundamentals/configuration/index). Environment variables are commonly stored in plain, unencrypted text. If the machine or process is compromised, environment variables might be accessible to untrusted parties. We recommend against using environment variables to store a production connection string as it's not the most secure approach.

Configuration data guidelines:

* Never store passwords or other sensitive data in configuration provider code or in plain text configuration files. The [Secret Manager](xref:security/app-secrets) tool can be used to store secrets in development.
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

* <xref:security/authentication/identity>
* <xref:security/authentication/identity-enable-qrcodes>
* <xref:security/authentication/social/index> 
* <xref:security/identity-management-solutions>
