---
title: ASP.NET to ASP.NET Core session state migration
description: ASP.NET to ASP.NET Core session state migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/fx-to-core/areas/session
zone_pivot_groups: migration-remote-app-setup
---

# Migrate ASP.NET Framework Session to ASP.NET Core

Session state is a critical component of many web applications, storing user-specific data across HTTP requests. When migrating from ASP.NET Framework to ASP.NET Core, session state presents unique challenges because the two frameworks handle sessions very differently.

## Why session migration is complex

ASP.NET Framework and ASP.NET Core have fundamentally different approaches to session management:

* **ASP.NET Framework** provides automatic object serialization and built-in session locking
* **ASP.NET Core** requires manual serialization and offers no session locking guarantees

These differences mean you can't simply move your session code from Framework to Core without changes.

## Migration strategies overview

You have three main approaches for handling session state during migration:

1. **Complete rewrite** - Rewrite all session code to use ASP.NET Core's native session implementation
2. **Incremental with separate sessions** - Migrate components piece by piece, with each app maintaining its own session state
3. **Incremental with shared sessions** - Migrate components while sharing session data between Framework and Core applications

For most applications, migrating to [ASP.NET Core session](xref:fundamentals/app-state) provides the best performance and maintainability. However, larger applications or those with complex session requirements may benefit from an incremental approach using the System.Web adapters.

## Choose your migration approach

You have three main options for migrating session state from ASP.NET Framework to ASP.NET Core. Your choice depends on your migration timeline, whether you need to run both applications simultaneously, and how much code you're willing to rewrite.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **Are you doing a complete rewrite or incremental migration?**
   * Complete rewrite → [Built-in ASP.NET Core session](#built-in-aspnet-core-session-state)
   * Incremental migration → Continue to question 2

2. **Do both your ASP.NET Framework and ASP.NET Core apps need to access the same session data?**
   * Yes, shared session needed → [Remote app session](#remote-app-session-state)
   * No, separate sessions are fine → [Wrapped ASP.NET Core session](#wrapped-aspnet-core-session-state)

### Understanding the differences

Before diving into implementation details, it's important to understand how ASP.NET Framework and ASP.NET Core handle session state differently:

* **Object serialization**
  * ASP.NET Framework automatically serializes and deserializes objects (unless using in-memory storage)
  * ASP.NET Core requires manual serialization/deserialization and stores data as `byte[]`
* **Session locking**
  * ASP.NET Framework locks session usage within a session, handling subsequent requests serially
  * ASP.NET Core provides no session locking guarantees

### Migration approaches comparison

| Approach | Code Changes | Performance | Session Sharing | When to Use |
|----------|-------------|-------------|-----------------|-------------|
| **[Built-in ASP.NET Core](#built-in-aspnet-core-session-state)** | High - Rewrite all session code | Best | None | Complete rewrites, performance-critical apps |
| **[Wrapped ASP.NET Core](#wrapped-aspnet-core-session-state)** | Low - Keep existing session patterns | Good | None | Incremental migrations, no shared state needed |
| **[Remote app](#remote-app-session-state)** | Low - Keep existing session patterns | Fair | Full | Running both apps simultaneously |

The [System.Web adapters](~/migration/fx-to-core/inc/systemweb-adapters.md) enable the "Wrapped" and "Remote app" approaches by bridging the differences between ASP.NET Framework and Core session implementations through two key interfaces:

* `Microsoft.AspNetCore.SystemWebAdapters.ISessionManager`: Accepts an <xref:Microsoft.AspNetCore.Http.HttpContext> and session metadata, returns an `ISessionState` object
* `Microsoft.AspNetCore.SystemWebAdapters.ISessionState`: Describes session object state and backs the <xref:System.Web.SessionState.HttpSessionState> type

### Shared session state requirements

> [!NOTE]
> To use session state with System.Web adapters, endpoints must explicitly opt-in via metadata implementing `ISessionMetadata`.

In order to support <xref:System.Web.HttpContext.Session>, endpoints must opt-into it via metadata implementing `ISessionMetadata`.

**Recommendation**: To enable this on all MVC endpoints, there is an extension method that can be used as follows:

```cs
app.MapDefaultControllerRoute()
    .RequireSystemWebAdapterSession();
```

This also requires some implementation of a session store. For details of options here, see the sections below on different session approaches.

## Built-in ASP.NET Core session state

Choose this approach when you're performing a complete migration and can rewrite session-related code to use ASP.NET Core's native session implementation.

ASP.NET Core provides a lightweight, high-performance session state implementation that stores data as `byte[]` and requires explicit serialization. This approach offers the best performance but requires more code changes during migration.

For details on how to set this up and use it, see the [ASP.NET session documentation]((xref:fundamentals/app-state.md).

### Pros and cons

| Pros | Cons |
|------|------|
| Best performance and lowest memory footprint | Requires rewriting all session access code |
| Native ASP.NET Core implementation | No automatic object serialization |
| Full control over serialization strategy | No session locking (concurrent requests may conflict) |
| No additional dependencies | Breaking change from ASP.NET Framework patterns |
| Supports all ASP.NET Core session providers | Session keys are case-sensitive (unlike Framework) |

### Migration considerations

When migrating to built-in ASP.NET Core session:

**Code changes required:**
* Replace `Session["key"]` with `HttpContext.Session.GetString("key")`
* Replace `Session["key"] = value` with `HttpContext.Session.SetString("key", value)`
* Add explicit serialization/deserialization for complex objects
* Handle null values explicitly (no automatic type conversion)

**Data migration:**
* Session data structure changes require careful planning
* Consider running both systems in parallel during migration
* Implement session data import/export utilities if needed

**Testing strategy:**
* Unit test session serialization/deserialization logic
* Integration test session behavior across requests
* Load test concurrent session access patterns

**When to choose this approach:**
* You can afford to rewrite session-related code
* Performance is a top priority
* You're not sharing session data with legacy applications
* You want to eliminate System.Web dependencies completely

## Wrapped ASP.NET Core session state

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

Choose this approach when your migrated components don't need to share session data with your legacy application.

The `Microsoft.Extensions.DependencyInjection.WrappedSessionExtensions.AddWrappedAspNetCoreSession` extension method adds a wraps ASP.NET Core session to work with the adapters. It uses the same backing store as <xref:Microsoft.AspNetCore.Http.ISession> while providing strongly-typed access.

**Configuration for ASP.NET Core:**

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/wrapped/Program.cs" id="snippet_WrapAspNetCoreSession" :::

Your Framework application requires no changes.

For more information, see the [wrapped session state sample app](https://github.com/dotnet/systemweb-adapters/blob/main/samples/SessionLocal/SessionLocalCore/Program.cs)

## Remote app session state

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

Choose this approach when you need to share session state between your ASP.NET Framework and ASP.NET Core applications during incremental migration.

Remote app session enables communication between applications to retrieve and set session state by exposing an endpoint on the ASP.NET Framework app.

### Prerequisites

Complete the [remote app setup](xref:migration/fx-to-core/inc/remote-app-setup) instructions to connect your ASP.NET Core and ASP.NET Framework applications.

### Serialization configuration

The <xref:System.Web.SessionState.HttpSessionState> object requires serialization for remote app session state.

In order to serialize session state, a serializer for the state object must be registered:

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/Program.cs" id="snippet_Serialization" :::

In ASP.NET Core, [BinaryFormatter](/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter) was used to automatically serialize session value contents. In order to serialize these with for use with the System.Web adapters, the serialization must be explicitly configured using `ISessionKeySerializer` implementations.

Out of the box, there is a simple JSON serializer that allows each session key to be registered to a known type using `JsonSessionSerializerOptions`:

* `RegisterKey<T>(string)` - Registers a session key to a known type. This registration is required for correct serialization/deserialization. Missing registrations cause errors and prevent session access.

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/Program.cs" id="snippet_Serialization" :::

### Application configuration

:::zone pivot="default"
**ASP.NET Core configuration:**

Call `AddRemoteAppSession` and `AddJsonSessionSerializer` to register known session item types:

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/Program.cs" id="snippet_Configuration" :::

Session support requires explicit activation. Configure it per-route using ASP.NET Core metadata.

#### Option 1: Annotate controllers

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/SomeController.cs" id="snippet_Controller" :::

#### Option 2: Enable globally for all endpoints

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/Program.cs" id="snippet_RequireSystemWebAdapterSession" :::

**ASP.NET Framework configuration:**

Add this change to `Global.asax.cs`:

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/Global.asax.cs":::

:::zone-end

:::zone pivot="aspire"
When using Aspire, the configuration will be done via environment variables and are set by the AppHost. To enable remote session, the option must be enabled:

```csharp
...

var coreApp = builder.AddProject<Projects.CoreApplication>("core")
    .WithHttpHealthCheck()
    .WaitFor(frameworkApp)
    .WithIncrementalMigrationFallback(frameworkApp, options => options.RemoteSession = RemoteSession.Enabled);

...
```

Once this is done, it will be automatically hooked up in both the framework and core applications.

:::zone-end

### Communication protocol

#### Readonly sessions

Readonly sessions retrieve session state without locking. The process uses a single `GET` request that returns session state and closes immediately.

![Readonly session will retrieve the session state from the framework app](~/migration/fx-to-core/areas/session/_static/readonly_session.png)

#### Writeable sessions

Writeable sessions require additional steps:

* Start with the same `GET` request as readonly sessions
* Keep the initial `GET` request open until the session completes
* Use an additional `PUT` request to update state
* Close the initial request only after updating is complete

![Writeable session state protocol starts with the same as the readonly](~/migration/fx-to-core/areas/session/_static/writesession.png)
