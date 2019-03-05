# Error Handling Sample Application

This sample app demonstrates the scenarios described in the [Handle errors in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/error-handling) topic.

## Configure a custom exception handling page

When the app isn't running in the Development environment, Exception Handling Middleware:

* Catches exceptions.
* Logs exceptions.
* Re-executes the request in an alternate pipeline at the path provided.

## Configure custom exception handling code

An alternative to serving an endpoint for errors with a custom exception handling page is to provide a lambda to `UseExceptionHandler`. Using a lambda with `UseExceptionHandler` allows access to the error before returning the response.

The sample app demonstrates custom exception handling code in `Startup.Configure`. Follow the instructions at the top of the *Startup.cs* file (`LambdaErrorHandler`). After the app starts, trigger an exception with the **Throw Exception** link on the Index page.
