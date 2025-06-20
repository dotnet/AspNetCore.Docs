---
title: Incremental migration of IHttpModules
description: Describes how to use the System.Web adapters to incrementally migrate HTTP modules.
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 3/11/2024
ms.topic: article
uid: migration/inc/http-modules
---

# ASP.NET to ASP.NET Core incremental IHttpModule migration

[Modules](../http-modules.md) are types that implement <xref:System.Web.IHttpModule> and are used in ASP.NET Framework to hook into the request pipeline at various events. In an ASP.NET Core application, these should ideally be migrated to middleware. However, there are times when this cannot be done. In order to support migration scenarios in which modules are required and cannot be moved to middleware, System.Web adapters support adding them to ASP.NET Core.

## IHttpModule Example

In order to support modules, an instance of <xref:System.Web.HttpApplication> must be available. If no custom <xref:System.Web.HttpApplication> is used, a default one will be used to add the modules to. Events declared in a custom application (including `Application_Start`) will be registered and run accordingly.

:::code language="csharp" source="~/migration/http-modules/sample8/Program.cs" :::

## Global.asax migration

This infrastructure can be used to migrate usage of `Global.asax` if needed. The source from `Global.asax` is a custom <xref:System.Web.HttpApplication> and the file can be included in an ASP.NET Core application. Since it is named `Global`, the following code can be used to register it:

:::code language="csharp" source="~/migration/http-modules/sample8/Snippets/GlobalSnippet.cs" id="snippet_AddGlobal" :::

As long as the logic within it is available in ASP.NET Core, this approach can be used to incrementally migrate reliance on `Global.asax` to ASP.NET Core.

## Authentication/Authorization events

In order for the authentication and authorization events to run at the desired time, the following pattern should be used:

:::code language="csharp" source="~/migration/http-modules/sample8/Snippets/UseAuthenticationAndAuthorizationSnippet.cs" id="snippet_UseAuthenticationAndAuthorization" :::

If this is not done, the events will still run. However, it will be during the call of `.UseSystemWebAdapters()`.

## HTTP Module pooling

Because modules and applications in ASP.NET Framework were assigned to a request, a new instance is needed for each request. However, since they can be expensive to create, they are pooled using <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1>. In order to customize the actual lifetime of the <xref:System.Web.HttpApplication> instances, a custom pool can be used:

:::code language="csharp" source="~/migration/http-modules/sample8/Snippets/HttpModulePoolingSnippet.cs" id="snippet_ObjectPool" :::

## Additional resources

* [HTTP Module Migration](../http-modules.md)
* [HTTP Handlers and HTTP Modules Overview](/iis/configuration/system.webserver/)