---
title: Using IIS modules with ASP.NET Core | Microsoft Docs
author: guardrex
description: Reference document describing active and inactive IIS modules with ASP.NET Core replacement options.
keywords: ASP.NET Core, iis, module, reverse-proxy
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

ASP.NET Core applications are hosted by IIS in a reverse-proxy configuration. Some of the native IIS modules and all of the IIS managed modules are not available to process requests for ASP.NET Core applications. In most cases, ASP.NET Core offers alternative technology to replace the features of inactive IIS modules.

## IIS Manager application changes
When using IIS modules with .NET applications, keep in mind that when you interact with the IIS Manager to configure the IIS modules that you're directly changing the *web.config* file of the app. If you deploy a *web.config* with the application, any changes you made in the IIS Manager locally will be overwritten by the new *web.config* file. After you've made changes to an app's *web.config* on the server, mirror those changes in your application project.

## Disabling IIS modules
If you have an active IIS module configured at the server level that you would like to disable for an application, you can do so with an addition to your *web.config* file. Either leave the module in place and deactivate it using a configuration setting for the module (if available) or remove the module from the application.

To deactivate a module without removing it from the application, you can often add a configuration element to your *web.config* file. For example, if you wish to disable the URL Rewrite Module, use the `\<httpRedirect\>` element as shown below.
```xml
<configuration>
  <system.webServer>
     <httpRedirect enabled="false" />
  </system.webServer>
</configuration>
```

If the module can't be disabled with a configuration setting or if you opt to remove the module with *web.config*, you must unlock it first. Click on the IIS server in the IIS Manager **Connections** sidebar. Open the **Modules** in the IIS area. Click on the module you wish to remove in the list. In the **Action** panel on the right, click **Unlock**. At this point, you will be able to add a `\<modules\>` section to your *web.config* file with a `\<remove\>` element to remove the module from the application. Doing this won't affect your use of the module with other applications on the server.
```xml
<configuration> 
  <system.webServer> 
    <modules> 
      <remove name="{Module Name}" /> 
    </modules> 
  </system.webServer> 
</configuration>
```

Consult [IIS `<system.webServer>`](https://www.iis.net/configreference/system.webserver). Module features can often be disabled ...


Middleware offers some direct replacement options (referring to the 3rd table column in the table)

## Native Modules
Module | Active | ASP.NET Core Option
--- | :---: | ---
**Anonymous Authentication**<br>`AnonymousAuthenticationModule` | Yes | 
**Basic Authentication**<br>`BasicAuthenticationModule` | Yes | 
**Client Certification Mapping Authentication**<br>`CertificateMappingAuthenticationModule` | ? | 
**CGI**<br>`CgiModule` | No | 
**Configuration Validation**<br>`ConfigurationValidationModule` | Yes | 
**HTTP Errors**<br>`CustomErrorModule` | No | [Status Code Pages Middleware](xref:fundamentals/error-handling#configuring-status-code-pages)
**Custom Logging**<br>`CustomLoggingModule` | Yes | 
**Default Document**<br>`DefaultDocumentModule` | No | [Default Files Middleware](xref:fundamentals/static-files#serving-a-default-document)
**Digest Authentication**<br>`DigestAuthenticationModule` | Yes | 
**Directory Browsing**<br>`DirectoryListingModule` | No | [Directory Browsing Middleware](xref:fundamentals/static-files#enabling-directory-browsing)
**Dynamic Compression**<br>`DynamicCompressionModule` | Yes | [Response Compression Middleware](xref:fundamentals/response-compression)
**Tracing**<br>`FailedRequestsTracingModule` | Yes | [ASP.NET Core Logging](xref:fundamentals/logging#the-tracesource-provider)
**File Caching**<br>`FileCacheModule` | No | [Response Caching Middleware](xref:performance/caching/middleware)
**HTTP Caching**<br>`HttpCacheModule` | No | [Response Caching Middleware](performance/caching/middleware)
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
* [Publishing to IIS](xref:publishing/iis)
* [IIS Modules Overview](https://www.iis.net/learn/get-started/introduction-to-iis/iis-modules-overview)
* [Customizing IIS 7.0 Roles and Modules](https://technet.microsoft.com/library/cc627313.aspx)
* [IIS `<system.webServer>`](https://www.iis.net/configreference/system.webserver)
