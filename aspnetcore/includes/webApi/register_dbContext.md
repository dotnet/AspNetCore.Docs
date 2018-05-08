## Register the database context

In this step, the database context is registered with the [dependency injection](xref:fundamentals/dependency-injection) container. Services (such as the DB context) that are registered with the dependency injection (DI) container are available to the controllers.

Register the DB context with the service container using the built-in support for [dependency injection](xref:fundamentals/dependency-injection). Replace the contents of the *Startup.cs* file with the following code:

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Startup.cs?highlight=2,4,12-13)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Startup.cs?highlight=3,5,13-14)]
::: moniker-end

The preceding code:

* Removes the unused code.
* Specifies an in-memory database is injected into the service container.