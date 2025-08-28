### Configure suppressing exception handler diagnostics

A new configuration option has been added to the [ASP.NET Core exception handler middleware](xref:fundamentals/error-handling?view=aspnetcore-10.0#exception-handler-page)  to control diagnostic output: `ExceptionHandlerOptions.SuppressDiagnosticsCallback`. This callback is passed context about the request and exception, allowing you to add logic that determines whether the middleware should write exception logs and other telemetry.

This setting is useful when you know an exception is transient or has been handled by the exception handler middleware, and you don't want error logs written to your observability platform.

The middleware's default behavior has also changed: it no longer writes exception diagnostics for exceptions handled by `IExceptionHandler`. Based on user feedback, logging handled exceptions at the error level was often undesirable when `IExceptionHandler.TryHandleAsync` returned `true`.

You can revert to the previous behavior by configuring `SuppressDiagnosticsCallback`:

```csharp
app.UseExceptionHandler(new ExceptionHandlerOptions
{
    SuppressDiagnosticsCallback = context => false;
});
```

For more information about this breaking change, see https://github.com/aspnet/Announcements/issues/524.
