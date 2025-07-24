### `ExceptionHandlerMiddleware` option to choose the status code based on the exception type

A new option when configuring the `ExceptionHandlerMiddleware` enables app developers to choose what status code to return when an exception occurs during request handling. The new option changes the status code being set in the `ProblemDetails` response from the `ExceptionHandlerMiddleware`.

```csharp
app.UseExceptionHandler(new ExceptionHandlerOptions
{
    StatusCodeSelector = ex => ex is TimeoutException
        ? StatusCodes.Status503ServiceUnavailable
        : StatusCodes.Status500InternalServerError,
});
```
