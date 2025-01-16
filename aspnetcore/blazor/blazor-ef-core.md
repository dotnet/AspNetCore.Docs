---
title: ASP.NET Core Blazor with Entity Framework Core (EF Core)
author: guardrex
description: Learn how to use Entity Framework Core (EF Core) in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/16/2025
uid: blazor/blazor-ef-core
---
# ASP.NET Core Blazor with Entity Framework Core (EF Core)

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use [Entity Framework Core (EF Core)](/ef/core/) in server-side Blazor apps.

Server-side Blazor is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor provides requires a special approach to use Entity Framework Core.

> [!NOTE]
> This article addresses EF Core in server-side Blazor apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

:::moniker range=">= aspnetcore-8.0"

This guidance applies to components that adopt interactive server-side rendering (interactive SSR) in a Blazor Web App.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

This guidance applies to the **`Server`** project of a hosted Blazor WebAssembly solution or a Blazor Server app.

:::moniker-end

## Secure authentication flow required for production apps

This article pertains to the use of a local database that doesn't require user authentication. Production apps should use the most secure authentication flow available. For more information on authentication for deployed test and production Blazor apps, see the articles in the [Blazor *Security and Identity* node](xref:blazor/security/index).

For Microsoft Azure services, we recommend using *managed identities*. Managed identities securely authenticate to Azure services without storing credentials in app code. For more information, see the following resources:

* [What are managed identities for Azure resources? (Microsoft Entra documentation)](/entra/identity/managed-identities-azure-resources/overview)
* Azure services documentation
  * [Managed identities in Microsoft Entra for Azure SQL](/azure/azure-sql/database/authentication-azure-ad-user-assigned-managed-identity)
  * [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)

:::moniker range=">= aspnetcore-8.0"

## Build a Blazor movie database app tutorial

For a tutorial experience building an app that uses EF Core for database operations, see <xref:blazor/tutorials/movie-database-app/index>. The tutorial shows you how to create a Blazor Web App that can display and manage movies in a movie database.

:::moniker-end

## Database access

EF Core relies on a <xref:Microsoft.EntityFrameworkCore.DbContext> as the means to [configure database access](/ef/core/miscellaneous/configuring-dbcontext) and act as a [*unit of work*](https://martinfowler.com/eaaCatalog/unitOfWork.html). EF Core provides the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension for ASP.NET Core apps that registers the context as a *scoped* service. In server-side Blazor apps, scoped service registrations can be problematic because the instance is shared across components within the user's circuit. <xref:Microsoft.EntityFrameworkCore.DbContext> isn't thread safe and isn't designed for concurrent use. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the app and leads to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request; but as components can be long-lived, this results in a longer-lived context than may be intended.

The following recommendations are designed to provide a consistent approach to using EF Core in server-side Blazor apps.

* Consider using one context per operation. The context is designed for fast, low overhead instantiation:

  ```csharp
  using var context = new ProductsDatabaseContext();

  return await context.Products.ToListAsync();
  ```

* Use a flag to prevent multiple concurrent operations:

  ```csharp
  if (Loading)
  {
      return;
  }

  try
  {
      Loading = true;

      ...
  }
  finally
  {
      Loading = false;
  }
  ```

  Place database operations after the `Loading = true;` line in the `try` block.
  
  Thread safety isn't a concern, so loading logic doesn't require locking database records. The loading logic is used to disable UI controls so that users don't inadvertently select buttons or update fields while data is fetched.
  
* If there's any chance that multiple threads may access the same code block, [inject a factory](#scope-a-database-context-to-the-lifetime-of-the-component) and make a new instance per operation. Otherwise, injecting and using the context is usually sufficient.

* For longer-lived operations that take advantage of EF Core's [change tracking](/ef/core/querying/tracking) or [concurrency control](/ef/core/saving/concurrency), [scope the context to the lifetime of the component](#scope-a-database-context-to-the-lifetime-of-the-component).

## New `DbContext` instances

The fastest way to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> instance is by using `new` to create a new instance. However, there are scenarios that require resolving additional dependencies:

* Using [`DbContextOptions`](/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context.
* Using a connection string per <xref:Microsoft.EntityFrameworkCore.DbContext>, such as when you use [ASP.NET Core's Identity model](xref:security/authentication/customize_identity_model). For more information, see [Multi-tenancy (EF Core documentation)](/ef/core/miscellaneous/multitenancy).

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

The recommended approach to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> with dependencies is to use a factory. EF Core 5.0 or later provides a built-in factory for creating new contexts.

:::moniker range="< aspnetcore-5.0"

In versions of .NET prior to 5.0, use the following `DbContextFactory`:

```csharp
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorServerDbContextExample.Data
{
    public class DbContextFactory<TContext> 
        : IDbContextFactory<TContext> where TContext : DbContext
    {
        private readonly IServiceProvider provider;

        public DbContextFactory(IServiceProvider provider)
        {
            this.provider = provider ?? throw new ArgumentNullException(
                $"{nameof(provider)}: You must configure an instance of " +
                "IServiceProvider");
        }

        public TContext CreateDbContext() => 
            ActivatorUtilities.CreateInstance<TContext>(provider);
    }
}
```

In the preceding factory:

* <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> satisfies any dependencies via the service provider.
* <xref:Microsoft.EntityFrameworkCore.IDbContextFactory%601> is available in EF Core ASP.NET Core 5.0 or later, so the preceding interface is only required for ASP.NET Core 3.x.

:::moniker-end

The following example configures [SQLite](https://www.sqlite.org/index.html) and enables data logging in an app that manages contacts. The code uses an extension method (<xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContextFactory%2A>) to configure the database factory for DI and provide default options:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddDbContextFactory<ContactContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddDbContextFactory<ContactContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
```

:::moniker-end

The factory is injected into components to create new <xref:Microsoft.EntityFrameworkCore.DbContext> instances.

## Scope a database context to a component method

The factory is injected into the component:

```razor
@inject IDbContextFactory<ContactContext> DbFactory
```

Create a <xref:Microsoft.EntityFrameworkCore.DbContext> for a method using the factory (`DbFactory`):

```csharp
private async Task DeleteContactAsync()
{
    using var context = DbFactory.CreateDbContext();

    if (context.Contacts is not null)
    {
        var contact = await context.Contacts.FirstAsync(...);

        if (contact is not null)
        {
            context.Contacts?.Remove(contact);
            await context.SaveChangesAsync();
        }
    }
}
```

## Scope a database context to the lifetime of the component

You may wish to create a <xref:Microsoft.EntityFrameworkCore.DbContext> that exists for the lifetime of a component. This allows you to use it as a [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html) and take advantage of built-in features, such as change tracking and concurrency resolution.

Implement <xref:System.IDisposable> and inject the factory into the component:

```razor
@implements IDisposable
@inject IDbContextFactory<ContactContext> DbFactory
```

Establish a property for the <xref:Microsoft.EntityFrameworkCore.DbContext>:

```csharp
private ContactContext? Context { get; set; }
```

[`OnInitializedAsync`](xref:blazor/components/lifecycle) is overridden to create the <xref:Microsoft.EntityFrameworkCore.DbContext>:

```csharp
protected override async Task OnInitializedAsync()
{
    Context = DbFactory.CreateDbContext();
}
```

The <xref:Microsoft.EntityFrameworkCore.DbContext> is disposed when the component is disposed:

```csharp
public void Dispose() => Context?.Dispose();
```

## Enable sensitive data logging

<xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> includes application data in exception messages and framework logging. The logged data can include the values assigned to properties of entity instances and parameter values for commands sent to the database. Logging data with <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> is a **security risk**, as it may expose passwords and other [Personally Identifiable Information (PII)](xref:blazor/security/index#personally-identifiable-information-pii) when it logs SQL statements executed against the database.

We recommend only enabling <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> for development and testing:

```csharp
#if DEBUG
    services.AddDbContextFactory<ContactContext>(opt =>
        opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db")
        .EnableSensitiveDataLogging());
#else
    services.AddDbContextFactory<ContactContext>(opt =>
        opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
#endif
```

## Additional resources

* [EF Core documentation](/ef/)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
* [Blazor *Security and Identity* node articles](xref:blazor/security/index)
