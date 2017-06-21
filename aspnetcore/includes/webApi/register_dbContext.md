## Register the database context

In order to inject the database context into the controller, we need to register it with the [dependency injection](xref:fundamentals/dependency-injection) container. Register the database context with the service container using the built-in support for [dependency injection](xref:fundamentals/dependency-injection). Replace the contents of the *Startup.cs* file with the following:

[!code-csharp[Main](../../tutorials/first-web-api/sample/TodoApi/Startup.cs?highlight=2,4,12)]

The preceding code:

* Removes the code we're not using.
* Specifies an in-memory database is injected into the service container.
