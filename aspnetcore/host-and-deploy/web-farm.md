---
title: Host ASP.NET Core in a web farm
author: tdykstra
description: Learn how to host multiple instances of an ASP.NET Core app with shared resources in a web farm environment.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2020
uid: host-and-deploy/web-farm
---
# Host ASP.NET Core in a web farm

By [Chris Ross](https://github.com/Tratcher)

A *web farm* is a group of two or more web servers (or *nodes*) that host multiple instances of an app. When requests from users arrive to a web farm, a *load balancer* distributes the requests to the web farm's nodes. Web farms improve:

* **Reliability/availability**: When one or more nodes fail, the load balancer can route requests to other functioning nodes to continue processing requests.
* **Capacity/performance**: Multiple nodes can process more requests than a single server. The load balancer balances the workload by distributing requests to the nodes.
* **Scalability**: When more or less capacity is required, the number of active nodes can be increased or decreased to match the workload. Web farm platform technologies, such as [Azure App Service](https://azure.microsoft.com/services/app-service/), can automatically add or remove nodes at the request of the system administrator or automatically without human intervention.
* **Maintainability**: Nodes of a web farm can rely on a set of shared services, which results in easier system management. For example, the nodes of a web farm can rely upon a single database server and a common network location for static resources, such as images and downloadable files.

This topic describes configuration and dependencies for ASP.NET core apps hosted in a web farm that rely upon shared resources.

## General configuration

<xref:host-and-deploy/index>  
Learn how to set up hosting environments and deploy ASP.NET Core apps. Configure a process manager on each node of the web farm to automate app starts and restarts. Each node requires the ASP.NET Core runtime. For more information, see the topics in the [Host and deploy](xref:host-and-deploy/index) area of the documentation.

<xref:host-and-deploy/proxy-load-balancer>  
Learn about configuration for apps hosted behind proxy servers and load balancers, which often obscure important request information.

<xref:host-and-deploy/azure-apps/index>  
[Azure App Service](https://azure.microsoft.com/services/app-service/) is a [Microsoft cloud computing platform service](https://azure.microsoft.com/) for hosting web apps, including ASP.NET Core. App Service is a fully managed platform that provides automatic scaling, load balancing, patching, and continuous deployment.

## App data

When an app is scaled to multiple instances, there might be app state that requires sharing across nodes. If the state is transient, consider sharing an <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache>. If the shared state requires persistence, consider storing the shared state in a database.

## Required configuration

Data Protection and Caching require configuration for apps deployed to a web farm.

### Data Protection

The [ASP.NET Core Data Protection system](xref:security/data-protection/introduction) is used by apps to protect data. Data Protection relies upon a set of cryptographic keys stored in a *key ring*. When the Data Protection system is initialized, it applies [default settings](xref:security/data-protection/configuration/default-settings) that store the key ring locally. Under the default configuration, a unique key ring is stored on each node of the web farm. Consequently, each web farm node can't decrypt data that's encrypted by an app on any other node. The default configuration isn't generally appropriate for hosting apps in a web farm. An alternative to implementing a shared key ring is to always route user requests to the same node. For more information on Data Protection system configuration for web farm deployments, see <xref:security/data-protection/configuration/overview>.

### Caching

In a web farm environment, the caching mechanism must share cached items across the web farm's nodes. Caching must either rely upon a common Redis cache, a shared SQL Server database, or a custom caching implementation that shares cached items across the web farm. For more information, see <xref:performance/caching/distributed>.

## Dependent components

The following scenarios don't require additional configuration, but they depend on technologies that require configuration for web farms.

| Scenario | Depends on &hellip; |
| -------- | ------------------- |
| Authentication | Data Protection (see <xref:security/data-protection/configuration/overview>).<br><br>For more information, see <xref:security/authentication/cookie> and <xref:security/cookie-sharing>. |
| Identity | Authentication and database configuration.<br><br>For more information, see <xref:security/authentication/identity>. |
| Session | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>) and Caching (see <xref:performance/caching/distributed>).<br><br>For more information, see [Session and state management: Session state](xref:fundamentals/app-state#session-state). |
| TempData | Data Protection (encrypted cookies) (see <xref:security/data-protection/configuration/overview>) or Session (see [Session and state management: Session state](xref:fundamentals/app-state#session-state)).<br><br>For more information, see [Session and state management: TempData](xref:fundamentals/app-state#tempdata). |
| Anti-forgery | Data Protection (see <xref:security/data-protection/configuration/overview>).<br><br>For more information, see <xref:security/anti-request-forgery>. |

## Troubleshoot

### Data Protection and caching

When Data Protection or caching isn't configured for a web farm environment, intermittent errors occur when requests are processed. This occurs because nodes don't share the same resources and user requests aren't always routed back to the same node.

Consider a user who signs into the app using cookie authentication. The user signs into the app on one web farm node. If their next request arrives at the same node where they signed in, the app is able to decrypt the authentication cookie and allows access to the app's resource. If their next request arrives at a different node, the app can't decrypt the authentication cookie from the node where the user signed in, and authorization for the requested resource fails.

When any of the following symptoms occur **intermittently**, the problem is usually traced to improper Data Protection or caching configuration for a web farm environment:

* Authentication breaks: The authentication cookie is misconfigured or can't be decrypted. OAuth (Facebook, Microsoft, Twitter) or OpenIdConnect logins fail with the error "Correlation failed."
* Authorization breaks: Identity is lost.
* Session state loses data.
* Cached items disappear.
* TempData fails.
* POSTs fail: The anti-forgery check fails.

For more information on Data Protection configuration for web farm deployments, see <xref:security/data-protection/configuration/overview>. For more information on caching configuration for web farm deployments, see <xref:performance/caching/distributed>.

## Obtain data from apps

If the web farm apps are capable of responding to requests, obtain request, connection, and additional data from the apps using terminal inline middleware. For more information and sample code, see <xref:test/troubleshoot#obtain-data-from-an-app>.

## Additional resources

* [Custom Script Extension for Windows](/azure/virtual-machines/extensions/custom-script-windows): Downloads and executes scripts on Azure virtual machines, which is useful for post-deployment configuration and software installation.
* <xref:host-and-deploy/proxy-load-balancer>
 