---
title: Configure ASP.NET Core Data Protection
author: acasey
description: Learn how to configure Data Protection in ASP.NET Core for multi-instance apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: acasey
ms.custom: mvc
ms.date: 7/15/2024
uid: security/data-protection/configuration/scaling
---
# Configure ASP.NET Core Data Protection

:::moniker range=">= aspnetcore-6.0"

In order to be able to work without user configuration, the Data Protection [default settings](xref:security/data-protection/configuration/default-settings) make certain simplifying assumptions, among them, that all instance of an application (usually only a single instance) will share a file system.  Once an application begins to scale horizontally by adding more instances, it becomes necessary to explicitly configure Data Protection to establish a shared storage location for Data Protection keys.  Otherwise, instances will not recognize each other's keys and will, for example, fail to decrypt anti-forgery tokens encrypted by other instances.  In practice, this means that a form served by one instance but POSTed to another instance will fail.

There are a variety of ways around this problem.  The most general to is explicitly establish a shared location for Data Protection keys.  For a worked example, see <xref:host-and-deploy/scaling-aspnet-apps/scaling-aspnet-apps>.

Newly created Azure Container Apps built using ASP.NET Core Kestrel 8.0 or later will also benefit from automatic configuration.  For more information see https://learn.microsoft.com/en-us/azure/container-apps/dotnet-overview#autoscaling-considerations.

Azure Apps also support automatic key sharing.  For more information see <xref:security/data-protection/configuration/default-settings#key-management>.

TODO: Make that an xref
TODO: At this point, we could mention the environment variable for users who want to roll their own
TODO: App Service has some amount of auto-configuration too, but I doubt there's a page we can link to 
TODO: Do we actually repeat all the links from the article in "Additional resources"?


## Additional resources

* <xref:host-and-deploy/web-farm>
* https://learn.microsoft.com/en-us/azure/container-apps/dotnet-overview#autoscaling-considerations
* <xref:security/data-protection/configuration/default-settings#key-management>

:::moniker-end
