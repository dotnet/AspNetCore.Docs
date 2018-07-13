---
title: Host ASP.NET Core in a web farm
author: guardrex
description: Learn how to host multiple instances of an ASP.NET Core app with shared resources in a web farm environment.
ms.author: riande
ms.custom: mvc
ms.date: 07/13/2018
uid: host-and-deploy/web-farm
---
# Host ASP.NET Core in a web farm

By [Luke Latham](https://github.com/guardrex)

This topic describes configuration and dependencies for ASP.NET core apps hosted in a web farm that rely upon shared resources.

## General configuration

<xref:host-and-deploy/index>  
Learn how to set up hosting environments and deploy ASP.NET Core apps. Configure a process manager on each node of the web farm to automate app starts and restarts. Each node requires the ASP.NET Core runtime. For more information, see the topics in the [Host and deploy](xref:host-and-deploy/index) area of the documentation.

<xref:host-and-deploy/proxy-load-balancer>  
Learn about configuration for apps hosted behind proxy servers and load balancers, which often obscure important request information.

<xref:host-and-deploy/azure-apps/index>  
[Azure App Service](https://azure.microsoft.com/services/app-service/) is a [Microsoft cloud computing platform service](https://azure.microsoft.com/) for hosting web apps, including ASP.NET Core. App Service is a fully managed platform that provides automatic scaling, load balancing, patching, and continuous deployment.

## Required configuration

Data Protection and Caching require configuration for apps deployed to a web farm.

### Data Protection

The [ASP.NET Core Data Protection system](xref:security/data-protection/introduction) is used by apps to protect data. Data Protection relies upon a set of cryptographic keys stored in a *key ring*. When the Data Protection system is initialized, it applies [default settings](xref:security/data-protection/configuration/default-settings) that store the key ring locally. Under the default configuration, a unique key ring is stored on each node of the web farm. Consequently, each web farm node can't decrypt data that's encrypted by an app on any other node. The default configuration isn't generally appropriate for hosting apps in a web farm. An alternative to implementing a shared key ring is to always route user requests to the same node. For more information on Data Protection system configuration for web farm deployments, see <xref:security/data-protection/configuration/overview>.

### Caching

Caching is required by [ASP.NET Core Sessions](xref:fundamentals/app-state#session-state) and when [caching responses](xref:performance/caching/response). In a web farm environment, the caching mechanism must share cached items across the web farm's nodes. Caching must either rely upon a common Redis cache, a shared SQL Server database, or a custom caching implementation that shares cached items across the web farm. For more information, see <xref:performance/caching/distributed> and <xref:performance/caching/response>.

## Dependent components

The following scenarios don't require additional configuration, but they depend on technologies that require configuration for web farms.

| Scenario | Depends on &hellip; |
| -------- | ------------------- |
| Cookie authentication | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>).<br><br>For more information, see <xref:security/authentication/cookie>. |
| Identity | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>) and database configuration.<br><br>For more information, see <xref:security/authentication/identity>. |
| Session | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>) and Caching (see <xref:performance/caching/distributed> and <xref:performance/caching/response>).<br><br>For more information, see [Session and app state: Session state](xref:fundamentals/app-state#session-state). |
| TempData | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>) or Session (see [Session and app state: Session state](xref:fundamentals/app-state#session-state)).<br><br>For more information, see [Session and app state: TempData](xref:fundamentals/app-state#tempdata). |
| Anti-forgery | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>).<br><br>For more information, see <xref:security/anti-request-forgery>. |

## Troubleshoot

When Data Protection or Caching isn't configured for a web farm environment, intermittent errors occur when requests are processed. This occurs because nodes don't share the same resources (or user requests aren't always routed back to the same node).

Consider a user who signs into the app using cookie authentication. The user signs into the app on one web farm node. If their next request arrives at the same node where they signed in, the app is able to decipher the authentication cookie and allows access to the app's resource. If their next request arrives at a different node, the app can't decipher the authentication cookie from the node where the user signed in, and authorization for the requested resource fails.

When any of the following symptoms occur **intermittently**, the problem is usually traced to improper Data Protection or Caching configuration for a web farm environment:

* Authentication breaks &ndash; The authentication cookie is misconfigured or undecipherable.
* Authorization breaks &ndash; Identity is lost.
* Session state loses data.
* Cached items disappear.
* TempData fails.
* POSTs fail &ndash; The anti-forgery check fails.

For more information on Data Protection configuration for web farm deployments, see <xref:security/data-protection/configuration/overview>. For more information on Caching configuration for web farm deployments, see <xref:performance/caching/distributed> and <xref:performance/caching/response>.
