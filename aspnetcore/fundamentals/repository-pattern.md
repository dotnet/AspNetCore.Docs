---
title: Repository pattern with ASP.NET Core
author: ardalis
description: Learn how to implement the repository app design pattern in an ASP.NET Core app.
ms.author: riande
ms.custom: mvc
ms.date: 07/02/2018
uid: fundamentals/repository-pattern
---
# Repository pattern with ASP.NET Core

By [Steve Smith](https://ardalis.com/), [Scott Addie](https://scottaddie.com), and [Luke Latham](https://github.com/guardrex)

The *repository pattern* is a design pattern that isolates data access behind interface abstractions. Connecting to the database and manipulating data storage objects is performed through methods provided by the interface's implementation. Consequently, there's no need for calling code to deal with database concerns, such as connections, commands, and readers.

Implementation of the repository pattern with ASP.NET Core has the following benefits:

* Organization of the app is less complex with no direct interdependency between the business and data access layers.
* It's easier to reuse database access code because the code is centrally managed by one or more repositories.
* The business domain can be independently unit tested from the database layer.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/repository-pattern/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/repository-pattern/samples) uses the repository pattern to initialize and display a list of movie character names. The app uses [Entity Framework Core](/ef/core/) and an `ApplicationDbContext` class for its data persistence, but the database infrastructure isn't apparent where the data is accessed. Data access and database objects are abstracted behind a [repository](https://martinfowler.com/eaaCatalog/repository.html).

## Repository interface

A repository interface defines the properties and methods for implementation. In the sample app, the repository interface for movie character data is `ICharacterRepository`. `ICharacterRepository` defines the `ListAll` and `Add` methods required to work with `Character` instances in the app:

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](repository-pattern/samples/2.x/RepositoryPatternSample/Interfaces/ICharacterRepository.cs?name=snippet1)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](repository-pattern/samples/1.x/RepositoryPatternSample/Interfaces/ICharacterRepository.cs?name=snippet1)]

::: moniker-end

`Character` is defined as:

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](repository-pattern/samples/2.x/RepositoryPatternSample/Models/Character.cs?name=snippet1)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](repository-pattern/samples/1.x/RepositoryPatternSample/Models/Character.cs?name=snippet1)]

::: moniker-end

## Repository concrete type

The interface is implemented by a concrete type. In the sample app, `CharacterRepository` manages the database context and implements the `ListAll` and `Add` methods:

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](repository-pattern/samples/2.x/RepositoryPatternSample/Models/CharacterRepository.cs?name=snippet1)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](repository-pattern/samples/1.x/RepositoryPatternSample/Models/CharacterRepository.cs?name=snippet1)]

::: moniker-end

## Register the repository service

The repository and database context are registered with the service container in `Startup.ConfigureServices`. In the sample app, `ApplicationDbContext` is configured with the call to the extension method [AddDbContext](/dotnet/api/microsoft.extensions.dependencyinjection.entityframeworkservicecollectionextensions.adddbcontext). `ICharacterRepository` is registered as a scoped service:

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](repository-pattern/samples/2.x/RepositoryPatternSample/Startup.cs?name=snippet1&highlight=4-6,18)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](repository-pattern/samples/1.x/RepositoryPatternSample/Startup.cs?name=snippet1&highlight=4-6,12)]

::: moniker-end

## Inject an instance of the repository

In a class where database access is required, an instance of the repository is requested via the constructor and assigned to a private field for use by class methods. In the sample app, `ICharacterRepository` is used to:

* Populate the database if no characters exist.
* Obtain a list of the characters for display.

Notice how the calling code only interacts with the interface's implementation, `CharacterRepository`. Calling code doesn't use the `ApplicationDbContext` directly:

::: moniker range=">= aspnetcore-2.1"

[!code-csharp[](repository-pattern/samples/2.x/RepositoryPatternSample/Pages/Index.cshtml.cs?name=snippet1)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

[!code-csharp[](repository-pattern/samples/1.x/RepositoryPatternSample/Controllers/HomeController.cs?name=snippet1)]

::: moniker-end

## Generic repository interface

This topic and its sample app demonstrate the simplest implementation of the repository pattern, where one repository is created for each business object. If the app grows beyond a few objects, a *generic repository interface* may reduce the amount of code required to implement the repository pattern. For more information, see [DevIQ: Repository Pattern: Generic Repository Interface](http://deviq.com/repository-pattern/).

## Additional resources

* [DevIQ: Repository Pattern](https://deviq.com/repository-pattern/)
* [Dependency injection](xref:fundamentals/dependency-injection)
* [Dependency injection into views](xref:mvc/views/dependency-injection)
* [Dependency injection into controllers](xref:mvc/controllers/dependency-injection)
* [Dependency injection in requirement handlers](xref:security/authorization/dependencyinjection)
* [Inversion of Control Containers and the Dependency Injection Pattern](https://www.martinfowler.com/articles/injection.html)
