---
title: Blazor Server with Entity Framework Core (EFCore)
author: JeremyLikness
description: Guidance for using EF Core in Blazor Server apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: jeliknes
ms.custom: mvc
ms.date: 06/26/2020
no-loc: [Blazor, "Blazor Server", "Entity Framework", "EF Core", Razor]
uid: blazor/blazor-server-ef-core
---
# ASP.NET Core Blazor Server Apps with Entity Framework Core

Blazor Server is a stateful app framework. The app maintains an ongoing connection to the server, and the user's state is held in the server's memory in a *circuit*. One example of user state is data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit. The unique application model that Blazor Server provides requires a special approach to use Entity Framework Core. 

> [!NOTE]
> This article addresses EF Core in Blazor Server apps. Blazor WebAssembly apps run in a WebAssembly sandbox that prevents most direct database connections. Running EF Core in Blazor WebAssembly is beyond the scope of this article.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/3.x/BlazorServerEFCoreSample) ([how to download](xref:index#how-to-download-a-sample))

EF Core relies on a `DbContext` as the means to [configure database access](https://docs.microsoft.com/ef/core/miscellaneous/configuring-dbcontext) and act as a _unit of work_. EF Core provides the `AddDbContext` extension for ASP.NET Core apps that registers the context as a _scoped_ service by default. In Blazor Server apps this can be problematic because the instance is shared across components within the user circuit. `DbContext` is not thread safe and is not designed to be used concurrently. The existing lifetimes are inappropriate for these reasons:

* **Singleton** shares state across all users of the application and will lead to inappropriate concurrent use.
* **Scoped** (the default) poses a similar issue between components for the same user.
* **Transient** results in a new instance per request, but as components can be long-lived this results in a longer-lived context than may be intended.

## Use of DbContext in Blazor Server Apps

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
* For longer-lived operations that take advantage of EF Core's [change tracking](https://docs.microsoft.com/ef/core/querying/tracking) and/or [concurrency control](https://docs.microsoft.com/ef/core/saving/concurrency), scope the context to the lifetime of the component.

### Create new DbContext instances

The fastest way to create a new `DbContext` instance is by using `new` to create a new instance. There are several scenarios that may require additional dependencies to be resolved. For example, you may wish to use [DbContextOptions](https://docs.microsoft.com/ef/core/miscellaneous/configuring-dbcontext#configuring-dbcontextoptions) to configure the context. One approach is to register the options in DI and inject them into the component, like this:

```razor
@inject DbContextOptions<MyContext> Options

@code {
    public Task LoadAsync(int id)
    {
        using var context = new MyContext(Options);
        return context.MyEntities.SingleOrDefaultAsync(e => e.Id == id);
    }
}
```

Another solution is to use a factory. EF Core 5.0 (preview) provides a built-in factory for creating new contexts. Because the sample app is based on the latest stable versions and not the preview, it implements its own factory in `Data/DbContextFactory.cs`. 

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Data/DbContextFactory.cs)]

The factory is injected into components and used to create new instances. For example, in `Pages/Index.razor`:

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/Index.razor?range=199-212)]

### Scope to the component lifetime

There are two approaches to scope a context to the component lifetime. If the context is registered with DI, you can use the special `OwningComponentBase` base class to create a control scope. Learn more about the class [here](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.components.owningcomponentbase-1).

The second approach is to use the factory to create a context and track it for the lifetime of the component. First, implement `IDisposable` and inject the factory as shown in `Pages/EditContact.razor`.

[!code-razor[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=5-7)]

The sample app ensures the contact is disposed when the component is:

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=181-184)]

Finally, `OnInitializedAsync` is overridden to create a new context. In the sample app, it loads the contact in the same method.

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/EditContact.razor?range=89-104)]

## The sample app

The sample application was built as a reference for Blazor Server apps the use EF Core. It includes a grid with sorting and filtering, delete, add, and update operations. It demonstrates use of EF Core to handle optimistic concurrency.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/3.x/BlazorServerEFCoreSample) ([how to download](xref:index#how-to-download-a-sample))

By default, the sample uses [SQL Server Express LocalDB](https://docs.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb). You can override the connection string by updating the connection string in `appsettings.json`:

[!code-json[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.json?highlight=3)] 

The sample also configures database logging to show the SQL queries that are generated. This is configured in `appsettings.Development.json`. 

[!code-json[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/appsettings.Development.json?highlight=8)] 

The `Startup.cs` class uses the factory extension to register the context and set the options. 

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Startup.cs?highlight=28-32)]

To make it easier to populate the sample database, a call to ensure it is created and populate random sample contacts is made in `Program.cs`. 

[!code-csharp[](./common/samples/3.x/BlazorServerEFCoreSample/BlazorServerDbContextExample/Program.cs?highlight=15-23)]

> [!CAUTION]
> The included code is for demo purposes only and should not be copied or included in production apps. Instead, consider creating the database using scripts or EF Core's [migrations](https://docs.microsoft.com/ef/core/managing-schemas/migrations/).

## Next Steps

Learn more about EF Core.

> [!div class="nextstepaction"]
> [EF Core documentation](https://docs.microsoft.com/ef/)