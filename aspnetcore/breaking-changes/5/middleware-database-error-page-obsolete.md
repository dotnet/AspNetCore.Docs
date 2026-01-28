---
title: "Breaking change: Middleware: Database error page marked as obsolete"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Middleware: Database error page marked as obsolete"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/432
---
# Middleware: Database error page marked as obsolete

The [DatabaseErrorPageMiddleware](/dotnet/api/microsoft.aspnetcore.diagnostics.entityframeworkcore.databaseerrorpagemiddleware?view=aspnetcore-3.0&preserve-view=false) and its associated extension methods were marked as obsolete in ASP.NET Core 5.0. The middleware and extension methods will be removed in ASP.NET Core 6.0. The functionality will instead be provided by `DatabaseDeveloperPageExceptionFilter` and its extension methods.

For discussion, see the GitHub issue at [dotnet/aspnetcore#24987](https://github.com/dotnet/aspnetcore/issues/24987).

## Version introduced

5.0 RC 1

## Old behavior

`DatabaseErrorPageMiddleware` and its associated extension methods weren't obsolete.

## New behavior

`DatabaseErrorPageMiddleware` and its associated extension methods are obsolete.

## Reason for change

`DatabaseErrorPageMiddleware` was migrated to an extensible API for the [developer exception page](/aspnet/core/fundamentals/error-handling#developer-exception-page). For more information on the extensible API, see GitHub issue [dotnet/aspnetcore#8536](https://github.com/dotnet/aspnetcore/issues/8536).

## Recommended action

Complete the following steps:

1. Stop using `DatabaseErrorPageMiddleware` in your project. For example, remove the `UseDatabaseErrorPage` method call from `Startup.Configure`:

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDatabaseErrorPage();
        }
    }
    ```

1. Add the developer exception page to your project. For example, call the <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A> method in `Startup.Configure`:

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    }
    ```

1. Add the [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore) NuGet package to the project file.

1. Add the database developer page exception filter to the services collection. For example, call the `AddDatabaseDeveloperPageExceptionFilter` method in `Startup.ConfigureServices`:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
    ```

## Affected APIs

- [Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage](/dotnet/api/microsoft.aspnetcore.builder.databaseerrorpageextensions.usedatabaseerrorpage?view=aspnetcore-3.0&preserve-view=false)
- [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware](/dotnet/api/microsoft.aspnetcore.diagnostics.entityframeworkcore.databaseerrorpagemiddleware?view=aspnetcore-3.0&preserve-view=false)

<!--

### Category

ASP.NET Core

### Affected APIs

- `Overload:Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage`
- `T:Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware`

-->
