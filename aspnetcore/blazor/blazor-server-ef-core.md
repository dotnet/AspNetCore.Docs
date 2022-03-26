---
title: ASP.NET Core Blazor Server with Entity Framework Core (EF Core)
author: JeremyLikness
description: Learn how to use Entity Framework Core (EF Core) in Blazor Server apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: jeliknes
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/blazor-server-ef-core
---
# ASP.NET Core Blazor Server with Entity Framework Core (EF Core)

This article explains how to use [Entity Framework Core (EF Core)](/ef/core/) in Blazor Server apps.

:::moniker range=">= aspnetcore-6.0"

Blazor Server is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor Server provides requires a special approach to use Entity Framework Core.

> [!NOTE]
> This article addresses EF Core in Blazor Server apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

## Sample app

The sample app was built as a reference for Blazor Server apps that use EF Core. The sample app includes a grid with sorting and filtering, delete, add, and update operations. The sample demonstrates use of EF Core to handle optimistic concurrency.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/samples/) ([how to download](xref:index#how-to-download-a-sample))

The sample uses a local [SQLite](https://www.sqlite.org/index.html) database so that it can be used on any platform. The sample also configures database logging to show the SQL queries that are generated. This is configured in `appsettings.Development.json`:

[!code-json[](~/blazor/samples/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.Development.json?highlight=8)]

The grid, add, and view components use the "context-per-operation" pattern, where a context is created for each operation. The edit component uses the "context-per-component" pattern, where a context is created for each component.

> [!NOTE]
> Some of the code examples in this topic require namespaces and services that aren't shown. To inspect the fully working code, including the required [`@using`](xref:mvc/views/razor#using) and [`@inject`](xref:mvc/views/razor#inject) directives for Razor examples, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/samples/).

## Database access

EF Core relies on a <xref:Microsoft.EntityFrameworkCore.DbContext> as the means to [configure database access](/ef/core/miscellaneous/configuring-dbcontext) and act as a [*unit of work*](https://martinfowler.com/eaaCatalog/unitOfWork.html). EF Core provides the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension for ASP.NET Core apps that registers the context as a *scoped* service by default. In Blazor Server apps, scoped service registrations can be problematic because the instance is shared across components within the user's circuit. <xref:Microsoft.EntityFrameworkCore.DbContext> isn't thread safe and isn't designed for concurrent use. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the app and leads to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request; but as components can be long-lived, this results in a longer-lived context than may be intended.

The following recommendations are designed to provide a consistent approach to using EF Core in Blazor Server apps.

* By default, consider using one context per operation. The context is designed for fast, low overhead instantiation:

  ```csharp
  using var context = new MyContext();

  return await context.MyEntities.ToListAsync();
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

  Place operations after the `Loading = true;` line in the `try` block.

* For longer-lived operations that take advantage of EF Core's [change tracking](/ef/core/querying/tracking) or [concurrency control](/ef/core/saving/concurrency), [scope the context to the lifetime of the component](#scope-to-the-component-lifetime).

### New DbContext instances

The fastest way to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> instance is by using `new` to create a new instance. However, there are several scenarios that may require resolving additional dependencies. For example, you may wish to use [`DbContextOptions`](/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context.

The recommended solution to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> with dependencies is to use a factory. EF Core 5.0 or later provides a built-in factory for creating new contexts.

The following example configures [SQLite](https://www.sqlite.org/index.html) and enables data logging. The code uses an extension method (`AddDbContextFactory`) to configure the database factory for DI and provide default options:

[!code-csharp[](~/blazor/samples/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Program.cs?name=snippet1)]

The factory is injected into components and used to create new instances. For example, in `Pages/Index.razor`:

[!code-csharp[](~/blazor/samples/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor?name=snippet1)]

> [!NOTE]
> `Wrapper` is a [component reference](xref:blazor/components/index#capture-references-to-components) to the `GridWrapper` component. See the `Index` component (`Pages/Index.razor`) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/samples/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor).

New <xref:Microsoft.EntityFrameworkCore.DbContext> instances can be created with a factory that allows you to configure the connection string per `DbContext`, such as when you use [ASP.NET Core's Identity model](xref:security/authentication/customize_identity_model). For more information, see [Multi-tenancy (EF Core documentation)](/ef/core/miscellaneous/multitenancy).

### Scope to the component lifetime

You may wish to create a <xref:Microsoft.EntityFrameworkCore.DbContext> that exists for the lifetime of a component. This allows you to use it as a [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html) and take advantage of built-in features, such as change tracking and concurrency resolution.
You can use the factory to create a context and track it for the lifetime of the component. First, implement <xref:System.IDisposable> and inject the factory as shown in `Pages/EditContact.razor`:

```razor
@implements IDisposable
@inject IDbContextFactory<ContactContext> DbFactory
```

The sample app ensures the context is disposed when the component is disposed:

[!code-csharp[](~/blazor/samples/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?name=snippet1)]

Finally, [`OnInitializedAsync`](xref:blazor/components/lifecycle) is overridden to create a new context. In the sample app, [`OnInitializedAsync`](xref:blazor/components/lifecycle) loads the contact in the same method:

[!code-csharp[](~/blazor/samples/6.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?name=snippet2)]

### Enable sensitive data logging

<xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> includes application data in exception messages and framework logging. The logged data can include the values assigned to properties of entity instances and parameter values for commands sent to the database. Logging data with <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> is a **security risk**, as it may expose passwords and other personally identifiable information (PII) when it logs SQL statements executed against the database.

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

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor Server is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor Server provides requires a special approach to use Entity Framework Core.

> [!NOTE]
> This article addresses EF Core in Blazor Server apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

## Sample app

The sample app was built as a reference for Blazor Server apps that use EF Core. The sample app includes a grid with sorting and filtering, delete, add, and update operations. The sample demonstrates use of EF Core to handle optimistic concurrency.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/samples/) ([how to download](xref:index#how-to-download-a-sample))

The sample uses a local [SQLite](https://www.sqlite.org/index.html) database so that it can be used on any platform. The sample also configures database logging to show the SQL queries that are generated. This is configured in `appsettings.Development.json`:

[!code-json[](~/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.Development.json?highlight=8)]

The grid, add, and view components use the "context-per-operation" pattern, where a context is created for each operation. The edit component uses the "context-per-component" pattern, where a context is created for each component.

> [!NOTE]
> Some of the code examples in this topic require namespaces and services that aren't shown. To inspect the fully working code, including the required [`@using`](xref:mvc/views/razor#using) and [`@inject`](xref:mvc/views/razor#inject) directives for Razor examples, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/samples/).

## Database access

EF Core relies on a <xref:Microsoft.EntityFrameworkCore.DbContext> as the means to [configure database access](/ef/core/miscellaneous/configuring-dbcontext) and act as a [*unit of work*](https://martinfowler.com/eaaCatalog/unitOfWork.html). EF Core provides the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension for ASP.NET Core apps that registers the context as a *scoped* service by default. In Blazor Server apps, scoped service registrations can be problematic because the instance is shared across components within the user's circuit. <xref:Microsoft.EntityFrameworkCore.DbContext> isn't thread safe and isn't designed for concurrent use. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the app and leads to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request; but as components can be long-lived, this results in a longer-lived context than may be intended.

The following recommendations are designed to provide a consistent approach to using EF Core in Blazor Server apps.

* By default, consider using one context per operation. The context is designed for fast, low overhead instantiation:

  ```csharp
  using var context = new MyContext();

  return await context.MyEntities.ToListAsync();
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

  Place operations after the `Loading = true;` line in the `try` block.

* For longer-lived operations that take advantage of EF Core's [change tracking](/ef/core/querying/tracking) or [concurrency control](/ef/core/saving/concurrency), [scope the context to the lifetime of the component](#scope-to-the-component-lifetime).

### New DbContext instances

The fastest way to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> instance is by using `new` to create a new instance. However, there are several scenarios that may require resolving additional dependencies. For example, you may wish to use [`DbContextOptions`](/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context.

The recommended solution to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> with dependencies is to use a factory. EF Core 5.0 or later provides a built-in factory for creating new contexts.

The following example configures [SQLite](https://www.sqlite.org/index.html) and enables data logging. The code uses an extension method (`AddDbContextFactory`) to configure the database factory for DI and provide default options:

[!code-csharp[](~/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Startup.cs?name=snippet1)]

The factory is injected into components and used to create new instances. For example, in `Pages/Index.razor`:

[!code-csharp[](~/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor?name=snippet1)]

> [!NOTE]
> `Wrapper` is a [component reference](xref:blazor/components/index#capture-references-to-components) to the `GridWrapper` component. See the `Index` component (`Pages/Index.razor`) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor).

New <xref:Microsoft.EntityFrameworkCore.DbContext> instances can be created with a factory that allows you to configure the connection string per `DbContext`, such as when you use [ASP.NET Core's Identity model](xref:security/authentication/customize_identity_model). For more information, see [Multi-tenancy (EF Core documentation)](/ef/core/miscellaneous/multitenancy).

### Scope to the component lifetime

You may wish to create a <xref:Microsoft.EntityFrameworkCore.DbContext> that exists for the lifetime of a component. This allows you to use it as a [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html) and take advantage of built-in features, such as change tracking and concurrency resolution.
You can use the factory to create a context and track it for the lifetime of the component. First, implement <xref:System.IDisposable> and inject the factory as shown in `Pages/EditContact.razor`:

```razor
@implements IDisposable
@inject IDbContextFactory<ContactContext> DbFactory
```

The sample app ensures the context is disposed when the component is disposed:

[!code-csharp[](~/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?name=snippet1)]

Finally, [`OnInitializedAsync`](xref:blazor/components/lifecycle) is overridden to create a new context. In the sample app, [`OnInitializedAsync`](xref:blazor/components/lifecycle) loads the contact in the same method:

[!code-csharp[](~/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?name=snippet2)]

### Enable sensitive data logging

<xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> includes application data in exception messages and framework logging. The logged data can include the values assigned to properties of entity instances and parameter values for commands sent to the database. Logging data with <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> is a **security risk**, as it may expose passwords and other personally identifiable information (PII) when it logs SQL statements executed against the database.

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

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor Server is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor Server provides requires a special approach to use Entity Framework Core.

> [!NOTE]
> This article addresses EF Core in Blazor Server apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

## Sample app

The sample app was built as a reference for Blazor Server apps that use EF Core. The sample app includes a grid with sorting and filtering, delete, add, and update operations. The sample demonstrates use of EF Core to handle optimistic concurrency.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/samples/) ([how to download](xref:index#how-to-download-a-sample))

The sample uses a local [SQLite](https://www.sqlite.org/index.html) database so that it can be used on any platform. The sample also configures database logging to show the SQL queries that are generated. This is configured in `appsettings.Development.json`:

[!code-json[](~/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.Development.json?highlight=8)]

The grid, add, and view components use the "context-per-operation" pattern, where a context is created for each operation. The edit component uses the "context-per-component" pattern, where a context is created for each component.

> [!NOTE]
> Some of the code examples in this topic require namespaces and services that aren't shown. To inspect the fully working code, including the required [`@using`](xref:mvc/views/razor#using) and [`@inject`](xref:mvc/views/razor#inject) directives for Razor examples, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/samples/).

## Database access

EF Core relies on a <xref:Microsoft.EntityFrameworkCore.DbContext> as the means to [configure database access](/ef/core/miscellaneous/configuring-dbcontext) and act as a [*unit of work*](https://martinfowler.com/eaaCatalog/unitOfWork.html). EF Core provides the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension for ASP.NET Core apps that registers the context as a *scoped* service by default. In Blazor Server apps, this can be problematic because the instance is shared across components within the user's circuit. <xref:Microsoft.EntityFrameworkCore.DbContext> isn't thread safe and isn't designed for concurrent use. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the app and leads to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request; but as components can be long-lived, this results in a longer-lived context than may be intended.

The following recommendations are designed to provide a consistent approach to using EF Core in Blazor Server apps.

* By default, consider using one context per operation. The context is designed for fast, low overhead instantiation:

  ```csharp
  using var context = new MyContext();

  return await context.MyEntities.ToListAsync();
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

  Place operations after the `Loading = true;` line in the `try` block.

* For longer-lived operations that take advantage of EF Core's [change tracking](/ef/core/querying/tracking) or [concurrency control](/ef/core/saving/concurrency), [scope the context to the lifetime of the component](#scope-to-the-component-lifetime).

### New DbContext instances

The fastest way to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> instance is by using `new` to create a new instance. However, there are several scenarios that may require resolving additional dependencies. For example, you may wish to use [`DbContextOptions`](/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context.

The recommended solution to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> with dependencies is to use a factory. The sample app implements its own factory in `Data/DbContextFactory.cs`.

[!code-csharp[](~/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Data/DbContextFactory.cs)]

In the preceding factory:

* <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> satisfies any dependencies via the service provider.
* `IDbContextFactory` is available in EF Core ASP.NET Core 5.0 or later, so the interface is [implemented in the sample app for ASP.NET Core 3.x](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Data/IDbContextFactory.cs).

The following example configures [SQLite](https://www.sqlite.org/index.html) and enables data logging. The code uses an extension method to configure the database factory for DI and provide default options:

[!code-csharp[](~/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Startup.cs?name=snippet1)]

The factory is injected into components and used to create new instances. For example, in `Pages/Index.razor`:

[!code-csharp[](~/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor?name=snippet1)]

> [!NOTE]
> `Wrapper` is a [component reference](xref:blazor/components/index#capture-references-to-components) to the `GridWrapper` component. See the `Index` component (`Pages/Index.razor`) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor).

New <xref:Microsoft.EntityFrameworkCore.DbContext> instances can be created with a factory that allows you to configure the connection string per `DbContext`, such as when you use [ASP.NET Core's Identity model])(xref:security/authentication/customize_identity_model). For more information, see [Multi-tenancy (EF Core documentation)](/ef/core/miscellaneous/multitenancy).

### Scope to the component lifetime

You may wish to create a <xref:Microsoft.EntityFrameworkCore.DbContext> that exists for the lifetime of a component. This allows you to use it as a [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html) and take advantage of built-in features, such as change tracking and concurrency resolution.
You can use the factory to create a context and track it for the lifetime of the component. First, implement <xref:System.IDisposable> and inject the factory as shown in `Pages/EditContact.razor`:

```razor
@implements IDisposable
@inject IDbContextFactory<ContactContext> DbFactory
```

The sample app ensures the context is disposed when the component is disposed:

[!code-csharp[](~/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?name=snippet1)]

Finally, [`OnInitializedAsync`](xref:blazor/components/lifecycle) is overridden to create a new context. In the sample app, [`OnInitializedAsync`](xref:blazor/components/lifecycle) loads the contact in the same method:

[!code-csharp[](~/blazor/samples/3.1/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?name=snippet2)]

In the preceding example:

* When `Busy` is set to `true`, asynchronous operations may begin. When `Busy` is set back to `false`, asynchronous operations should be finished.
* Place additional error handling logic in a `catch` block.

### Enable sensitive data logging

<xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> includes application data in exception messages and framework logging. The logged data can include the values assigned to properties of entity instances and parameter values for commands sent to the database. Logging data with <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.EnableSensitiveDataLogging%2A> is a **security risk**, as it may expose passwords and other personally identifiable information (PII) when it logs SQL statements executed against the database.

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

:::moniker-end
