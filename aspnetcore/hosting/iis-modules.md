---
title: Using IIS Modules with ASP.NET Core | Microsoft Docs
author: guardrex
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 01/23/2017
ms.topic: article
ms.assetid: 492b3a7e-04c5-461b-b96a-38ecee5c64bc
ms.technology: aspnet
ms.prod: aspnet-core
uid: hosting/iis-modules
---
# Using IIS Modules with ASP.NET Core

By [Luke Latham](https://github.com/GuardRex)

Introduction: Some modules work, some don't

Changes in IIS Manager to site result in changes to site's deployed `web.config`. Redeployment of `web.config` with the app will revert the changes made in IIS Manager.

Consult [IIS `<system.webServer>`](https://www.iis.net/configreference/system.webserver). Module features can often be disabled ...
```xml
<configuration>
  <system.webServer>
     <httpRedirect enabled="false" />
  </system.webServer>
</configuration>
```
... or modules enabled at the server level can be disabled:
```xml
<configuration> 
  <system.webServer> 
    <modules> 
      <remove name="{Module Name}" /> 
    </modules> 
  </system.webServer> 
</configuration>
```

Middleware offers some direct replacement options (referring to the 3rd table column in the table)

## Native Modules
Module | Active | ASP.NET Core Option
--- | :---: | ---
**Anonymous Authentication**<br>`AnonymousAuthenticationModule` | Yes | 
**Basic Authentication**<br>`BasicAuthenticationModule` | Yes | 
**Client Certification Mapping Authentication**<br>`CertificateMappingAuthenticationModule` | ? | 
**CGI**<br>`CgiModule` | No | 
**Configuration Validation**<br>`ConfigurationValidationModule` | Yes | 
**HTTP Errors**<br>`CustomErrorModule` | No | **Status Code Pages Middleware**<br>fundamentals/error-handling#configuring-status-code-pages
**Custom Logging**<br>`CustomLoggingModule` | Yes | 
**Default Document**<br>`DefaultDocumentModule` | No | **Default Files Middleware**<br>fundamentals/static-files#serving-a-default-document
**Digest Authentication**<br>`DigestAuthenticationModule` | Yes | 
**Directory Browsing**<br>`DirectoryListingModule` | No | **Directory Browsing Middleware**<br>fundamentals/static-files#enabling-directory-browsing
**Dynamic Compression**<br>`DynamicCompressionModule` | Yes | **Response Compression Middleware**<br>fundamentals/response-compression
**Tracing**<br>`FailedRequestsTracingModule` | Yes | **[ASP.NET Core Logging](xref:fundamentals/logging#the-tracesource-provider)**<br>
**File Caching**<br>`FileCacheModule` | No | **Response Caching Middleware**<br>performance/caching/middleware
**HTTP Caching**<br>`HttpCacheModule` | No | **Response Caching Middleware**<br>performance/caching/middleware
**HTTP Logging**<br>`HttpLoggingModule` | Yes | **ASP.NET Core Logging**<br>Implementations: [elmah.io](https://github.com/elmahio/Elmah.Io.Extensions.Logging), [Loggr](https://github.com/imobile3/Loggr.Extensions.Logging), [NLog](https://github.com/NLog/NLog.Extensions.Logging), [Serilog](https://github.com/serilog/serilog-framework-logging)<br>fundamentals/logging
**HTTP Redirection**<br>`HttpRedirectionModule` | Yes | **URL Rewriting Middleware**<br>fundamentals/url-rewriting
**IIS Client Certificate Mapping Authentication**<br>`IISCertificateMappingAuthenticationModule` | Yes | 
**IP and Domain Restrictions**<br>`IpRestrictionModule` | Yes | 
**ISAPI Filters**<br>`IsapiFilterModule` | Yes | **Middleware**<br>fundamentals/middleware
**ISAPI**<br>`IsapiModule` | Yes | **Middleware**<br>fundamentals/middleware
**Protocol Support**<br>`ProtocolSupportModule` | Yes | 
**Request Filtering**<br>`RequestFilteringModule` | Yes | **URL Rewriting Middleware** `IRule`<br>fundamentals/url-rewriting#irule-based-rule
**Request Monitor**<br>`RequestMonitorModule` | Yes | 
**URL Rewriting**<br>`RewriteModule` | Yes† | **URL Rewriting Middleware**<br>fundamentals/url-rewriting
**Server Side Includes**<br>`ServerSideIncludeModule` | No | 
**Static Compression**<br>`StaticCompressionModule` | No | **Response Compression Middleware**<br>fundamentals/response-compression
**Static Content**<br>`StaticFileModule` | No | **Static File Middleware**<br>fundamentals/static-files
**Token Caching**<br>`TokenCacheModule` | Yes | 
**Custom Tracing**<br>`TracingModule` | ? | https://github.com/aspnet/IISIntegration/issues/314
**URI Caching**<br>`UriCacheModule` | Yes | 
**URL Authorization**<br>`UrlAuthorizationModule` | Yes* | **ASP.NET Core Identity**<br>security/authentication/identity
**Windows Authentication**<br>`WindowsAuthenticationModule` | Yes | 

†The URL Rewrite Module's `isFile` and `isDirectory` do not work with ASP.NET Core applications due to the changes in [directory structure](xref:hosting/directory-structure).

## Managed Modules
Module | Active | ASP.NET Core Option
--- | :---: | ---
AnonymousIdentification | No | 
DefaultAuthentication | No | 
FileAuthorization | No | 
FormsAuthentication | No | **Cookie Authentication Middleware**<br>security/authentication/cookie
OutputCache | No | **Response Caching Middleware**<br>performance/caching/middleware
Profile | No | 
RoleManager | No | 
ScriptModule-4.0 | No | 
Session | No | **Session Middleware**<br>fundamentals/app-state#installing-and-configuring-session
UrlAuthorization | No | 
UrlMappingsModule | No | **URL Rewriting Middleware**<br>fundamentals/url-rewriting
UrlRoutingModule-4.0 | No | **ASP.NET Core  Identity**<br>security/authentication/identity
WindowsAuthentication | No | 

## Resources
* [IIS Modules Overview](https://www.iis.net/learn/get-started/introduction-to-iis/iis-modules-overview)
* [Customizing IIS 7.0 Roles and Modules](https://technet.microsoft.com/library/cc627313.aspx)
* [IIS `<system.webServer>`](https://www.iis.net/configreference/system.webserver)
