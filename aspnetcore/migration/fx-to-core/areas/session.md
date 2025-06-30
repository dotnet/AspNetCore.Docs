---
title: ASP.NET to ASP.NET Core incremental session state migration
description: ASP.NET to ASP.NET Core incremental session state migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/fx-to-core/areas/session
---

# Migrate ASP.NET Framework Session to ASP.NET Core

For most applications, migrating to [ASP.NET Core session](fundamentals/app-state) provides the best performance and maintainability. However, larger applications may need an incremental approach using System.Web adapters.

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

## Choose your migration approach

Two migration strategies are available, each designed for different scenarios:

| Implementation | Best for | Strongly typed | Locking | Session sharing |
|----------------|----------|----------------|---------|-----------------|
| [Wrapped ASP.NET Core](#wrapped-aspnet-core-session-state) | Migrations where session doesn't need to be shared with the legacy app | ✔️ | ⛔ | ⛔ |
| [Remote app](#remote-app-session-state) | Incremental migrations requiring shared session state between apps | ✔️ | ✔️ | ✔️ |

**Use Wrapped ASP.NET Core session** when:
* You're migrating components that don't need to share session data with the legacy application
* You want to leverage ASP.NET Core's native session infrastructure
* You're doing a more complete migration where both apps don't run simultaneously

**Use Remote app session** when:
* You need to share session state between your ASP.NET Framework and ASP.NET Core applications
* You're running both applications simultaneously during migration
* You require the same session locking behavior as ASP.NET Framework

## Understanding the technical differences

These differences between ASP.NET Framework and Core determine your migration approach:

### Session locking

* ASP.NET Framework locks session usage within a session, handling subsequent requests serially
* ASP.NET Core provides no session locking guarantees

### Object serialization

* ASP.NET Framework automatically serializes and deserializes objects (unless using in-memory storage)
* ASP.NET Core requires manual serialization/deserialization and stores data as `byte[]`

### Adapter infrastructure

The [System.Web adapters](~/aspnetcore/migration/fx-to-core/inc/systemweb-adapters.md) bridge these differences through two key interfaces:

* <xref:Microsoft.AspNetCore.SystemWebAdapters.ISessionManager>: Accepts an <xref:Microsoft.AspNetCore.Http.HttpContext> and session metadata, returns an `ISessionState` object
* `Microsoft.AspNetCore.SystemWebAdapters.ISessionState`: Describes session object state and backs the <xref:System.Web.SessionState.HttpSessionState> type

## Wrapped ASP.NET Core session state

Choose this approach when your migrated components don't need to share session data with your legacy application.

The <xref:Microsoft.Extensions.DependencyInjection.WrappedSessionExtensions.AddWrappedAspNetCoreSession> method adds a wraps ASP.NET Core session to work with the adapters. It uses the same backing store as <xref:Microsoft.AspNetCore.Http.ISession> while providing strongly-typed access.

**Configuration for ASP.NET Core:**

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/wrapped/Program.cs" id="snippet_WrapAspNetCoreSession" :::

Your Framework application requires no changes.

For more information, see the [wrapped session state sample app](https://github.com/dotnet/systemweb-adapters/blob/main/samples/SessionLocal/SessionLocalCore/Program.cs)

## Remote app session state

Choose this approach when you need to share session state between your ASP.NET Framework and ASP.NET Core applications during incremental migration.

Remote app session enables communication between applications to retrieve and set session state by exposing an endpoint on the ASP.NET Framework app.

### Prerequisites

Complete the [remote app setup](xref:migration/fx-to-core/inc/remote-app-setup) instructions to connect your ASP.NET Core and ASP.NET Framework applications.

### Serialization configuration

The <xref:System.Web.SessionState.HttpSessionState> object requires serialization for remote app session state.

**For HttpSessionState serialization**, implement `Microsoft.AspNetCore.SystemWebAdapters.SessionState.Serialization.ISessionSerializer`. A default binary writer implementation is provided:

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/remote-session/Program.cs" id="snippet_Serialization" :::

**For strongly-typed session access**, configure JSON serialization. Register each session key to a known type using `JsonSessionSerializerOptions`:

* `RegisterKey<T>(string)` - Registers a session key to a known type. This registration is required for correct serialization/deserialization. Missing registrations cause errors and prevent session access.

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/session/Program.cs" id="snippet_Serialization" :::

### Application configuration

**ASP.NET Core configuration:**

Call `AddRemoteAppSession` and `AddJsonSessionSerializer` to register known session item types:

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/remote-session/Program.cs" id="snippet_Configuration" :::

Session support requires explicit activation. Configure it per-route using ASP.NET Core metadata.

#### Option 1: Annotate controllers

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/remote-session/SomeController.cs" id="snippet_Controller" :::

#### Option 2: Enable globally for all endpoints

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/remote-session/Program.cs" id="snippet_RequireSystemWebAdapterSession" :::

**ASP.NET Framework configuration:**

Add this change to `Global.asax.cs`:

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/remote-session/Global.asax.cs":::

### Communication protocol

#### Readonly sessions

Readonly sessions retrieve session state without locking. The process uses a single `GET` request that returns session state and closes immediately.

![Readonly session will retrieve the session state from the framework app](~/migration/fx-to-core/inc/overview/static/readonly_session.png)

#### Writeable sessions

Writeable sessions require additional steps:

* Start with the same `GET` request as readonly sessions
* Keep the initial `GET` request open until the session completes
* Use an additional `PUT` request to update state
* Close the initial request only after updating is complete

![Writeable session state protocol starts with the same as the readonly](~/migration/fx-to-core/inc/overview/static/writesession.png)
