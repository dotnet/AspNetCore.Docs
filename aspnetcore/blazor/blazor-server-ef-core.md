---
title: ASP.NET Core Blazor Server with Entity Framework Core (EFCore)
author: JeremyLikness
description: Guidance for using EF Core in Blazor Server apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: jeliknes
ms.custom: mvc
ms.date: 08/14/2020
no-loc: [cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/blazor-server-ef-core
---
# ASP.NET Core Blazor Server with Entity Framework Core (EFCore)

By: [Jeremy Likness](https://github.com/JeremyLikness)

:::moniker range=">= aspnetcore-5.0"

Blazor Server is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor Server provides requires a special approach to use Entity Framework Core. 

> [!NOTE]
> This article addresses EF Core in Blazor Server apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

## Sample app

The sample app was built as a reference for Blazor Server apps that use EF Core. The sample app includes a grid with sorting and filtering, delete, add, and update operations. The sample demonstrates use of EF Core to handle optimistic concurrency.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/5.x/BlazorServerEFCoreSample) ([how to download](xref:index#how-to-download-a-sample))

The sample uses a local [SQLite](https://www.sqlite.org/index.html) database so that it can be used on any platform. The sample also configures database logging to show the SQL queries that are generated. This is configured in `appsettings.Development.json`:

[!code-json[](./common/samples/5.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.Development.json?highlight=8)] 

The grid, add, and view components use the "context-per-operation" pattern, where a context is created for each operation. The edit component uses the "context-per-component" pattern, where a context is created for each component.

## Database access

EF Core relies on a <xref:Microsoft.EntityFrameworkCore.DbContext> as the means to [configure database access](/ef/core/miscellaneous/configuring-dbcontext) and act as a [_unit of work_](https://martinfowler.com/eaaCatalog/unitOfWork.html). EF Core provides the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension for ASP.NET Core apps that registers the context as a _scoped_ service by default. In Blazor Server apps, scoped service registrations can be problematic because the instance is shared across components within the user's circuit. <xref:Microsoft.EntityFrameworkCore.DbContext> isn't thread safe and isn't designed for concurrent use. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the app and leads to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request; but as components can be long-lived, this results in a longer-lived context than may be intended.

The following recommendations are designed to provide a consistent approach to using EF Core in Blazor Server apps. 

* By default, consider using one context per operation. The context is designed for fast, low overhead instantiation:

  ```csharp
  var using context = new MyContext();

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
      // operations go here
  }
  finally 
  {
      Loading = false;
  }
  ```

* For longer-lived operations that take advantage of EF Core's [change tracking](/ef/core/querying/tracking) or [concurrency control](/ef/core/saving/concurrency), [scope the context to the lifetime of the component](#scope-to-the-component-lifetime).

### New DbContext instances

The fastest way to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> instance is by using `new` to create a new instance. However, there are several scenarios that may require resolving additional dependencies. For example, you may wish to use [`DbContextOptions`](https://docs.microsoft.com/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context. 

The recommended solution to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> with dependencies is to use a factory. EF Core 5.0 or later provides a built-in factory for creating new contexts.

The following example configures [SQLite](https://www.sqlite.org/index.html) and enables data logging. The code uses an extension method to configure the database factory for DI and provide default options:

[!code-csharp[](./common/samples/5.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Startup.cs?range=29-31)]

The factory is injected into components and used to create new instances. For example, in `Pages/Index.razor`:

[!code-razor[](./common/samples/5.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor?range=199-212)]

### Scope to the component lifetime

You may wish to create a <xref:Microsoft.EntityFrameworkCore.DbContext> that exists for the lifetime of a component. This allows you to use it as a [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html) and take advantage of built-in features, such as change tracking and concurrency resolution.
You can use the factory to create a context and track it for the lifetime of the component. First, implement <xref:System.IDisposable> and inject the factory as shown in `Pages/EditContact.razor`:

[!code-razor[](./common/samples/5.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=5-7)]

The sample app ensures the contact is disposed when the component is disposed:

[!code-razor[](./common/samples/5.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=181-184)]

Finally, `OnInitializedAsync` is overridden to create a new context. In the sample app, `OnInitializedAsync` loads the contact in the same method:

[!code-razor[](./common/samples/5.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=89-104)]

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor Server is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor Server provides requires a special approach to use Entity Framework Core. 

> [!NOTE]
> This article addresses EF Core in Blazor Server apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

## Sample app

The sample app was built as a reference for Blazor Server apps that use EF Core. The sample app includes a grid with sorting and filtering, delete, add, and update operations. The sample demonstrates use of EF Core to handle optimistic concurrency.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/3.x/BlazorServerEFCoreSample) ([how to download](xref:index#how-to-download-a-sample))

The sample uses a local [SQLite](https://www.sqlite.org/index.html) database so that it can be used on any platform. The sample also configures database logging to show the SQL queries that are generated. This is configured in `appsettings.Development.json`:

[!code-json[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.Development.json?highlight=8)] 

The grid, add, and view components use the "context-per-operation" pattern, where a context is created for each operation. The edit component uses the "context-per-component" pattern, where a context is created for each component.

## Database access

EF Core relies on a <xref:Microsoft.EntityFrameworkCore.DbContext> as the means to [configure database access](/ef/core/miscellaneous/configuring-dbcontext) and act as a [_unit of work_](https://martinfowler.com/eaaCatalog/unitOfWork.html). EF Core provides the <xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.AddDbContext%2A> extension for ASP.NET Core apps that registers the context as a _scoped_ service by default. In Blazor Server apps, this can be problematic because the instance is shared across components within the user's circuit. <xref:Microsoft.EntityFrameworkCore.DbContext> isn't thread safe and isn't designed for concurrent use. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the app and leads to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request; but as components can be long-lived, this results in a longer-lived context than may be intended.

## Database access

The following recommendations are designed to provide a consistent approach to using EF Core in Blazor Server apps. 

* By default, consider using one context per operation. The context is designed for fast, low overhead instantiation:

  ```csharp
  var using context = new MyContext();

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
      // operations go here
  }
  finally 
  {
      Loading = false;
  }
  ```

* For longer-lived operations that take advantage of EF Core's [change tracking](/ef/core/querying/tracking) or [concurrency control](/ef/core/saving/concurrency), [scope the context to the lifetime of the component](#scope-to-the-component-lifetime).

### Create new DbContext instances

The fastest way to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> instance is by using `new` to create a new instance. However, there are several scenarios that may require resolving additional dependencies. For example, you may wish to use [`DbContextOptions`](https://docs.microsoft.com/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context. 

The recommended solution to create a new <xref:Microsoft.EntityFrameworkCore.DbContext> with dependencies is to use a factory. The sample app implements its own factory in `Data/DbContextFactory.cs`. 

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Data/DbContextFactory.cs)]

The following example configures [SQLite](https://www.sqlite.org/index.html) and enables data logging. The code uses an extension method to configure the database factory for DI and provide default options:

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Startup.cs?range=29-31)]

The factory is injected into components and used to create new instances. For example, in `Pages/Index.razor`:

[!code-razor[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor?range=199-212)]

### Scope to the component lifetime

You may wish to create a <xref:Microsoft.EntityFrameworkCore.DbContext> that exists for the lifetime of a component. This allows you to use it as a [unit of work](https://martinfowler.com/eaaCatalog/unitOfWork.html) and take advantage of built-in features, such as change tracking and concurrency resolution.
You can use the factory to create a context and track it for the lifetime of the component. First, implement <xref:System.IDisposable> and inject the factory as shown in `Pages/EditContact.razor`:

[!code-razor[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=5-7)]

The sample app ensures the contact is disposed when the component is disposed:

[!code-razor[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=181-184)]

Finally, `OnInitializedAsync` is overridden to create a new context. In the sample app, `OnInitializedAsync` loads the contact in the same method:

[!code-razor[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=89-104)]

:::moniker-end

## Additional resources

> [EF Core documentation](/ef/)
