# Error Handling Sample Application

This sample app demonstrates the scenarios described in the [Handle errors in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/error-handling) topic.

## Configure a custom exception handling page

When the app isn't running in the Development environment, Exception Handling Middleware:

* Catches exceptions.
* Logs exceptions.
* Re-executes the request in an alternate pipeline at the path provided.

## Configure custom exception handling code

An alternative to serving an endpoint for errors with a custom exception handling page is to provide a lambda to `UseExceptionHandler`. This approach permits the app to work directly with the error before returning a response.

The sample app demonstrates the approach in `Startup.Configure`. Set the preprocessor directive at the top of the `Startup.cs` file from `PageErrorHandler` to `LambdaErrorHandler` and run the app in the Production [environment](https://docs.microsoft.com/aspnet/core/fundamentals/environments). After the app starts, trigger an exception with the **Throw Exception** link on the Index page.

For more information on using preprocessor directives with documentation sample apps, see [Preprocessor directives in sample code](https://docs.microsoft.com/aspnet/core/#preprocessor-directives-in-sample-code).
