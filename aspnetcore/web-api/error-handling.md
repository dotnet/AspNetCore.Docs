---
title: Error handling with web APIs
author: pranavkm
description: Learn about error handling with web APIs.
ms.author: prkrishn
ms.custom: mvc
ms.date: 09/17/2019
uid: web-api/error-handling
---
# Handle errors in web APIs

This article describes how to handle and customize error handling with ASP.NET Core web APIs.

## Developer Exception Page

The [Developer Exception Page](xref:fundamentals/error-handling) is a useful tool to get detailed stack traces from the server in the event of a server error. In ASP.NET Core 3.0 or later, the Developer Exception Page displays a plain-text response when the client doesn't accept HTML-formatted output. For example:

```
> curl https://localhost:5001/weatherforecast
System.ArgumentException: count
   at errorhandling.Controllers.WeatherForecastController.Get(Int32 x) in D:\work\Samples\samples\aspnetcore\mvc\errorhandling\Controllers\WeatherForecastController.cs:line 35
   at lambda_method(Closure , Object , Object[] )
   at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)
...
```

> [!WARNING]
> Enable the Developer Exception Page **only when the app is running in the Development environment**. You don't want to share detailed exception information publicly when the app runs in production. For more information on configuring environments, see <xref:fundamentals/environments>.

## Exception handler

In non-development environments, the [Exception Handling Middleware](xref:fundamentals/error-handling) can be used to produce an error payload. To use the Exception Handling Middleware:

1. Modify the app's `Startup.Configure` method to use the middleware:

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
        })
    }
    ```

1. Configure a controller action to respond to the `/error` route:

    ```csharp
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
    ```

The preceding code sends an [RFC7807](https://tools.ietf.org/html/rfc7807)-compliant payload to the client.

The Exception Handling Middleware can also be used to provide a more detailed content-negotiated output in local development. Use this approach to produce a consistent payload format across development and production environments:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseExceptionHandler("/error-local-development");
    }
    else
    {
        app.UseExceptionHandler("/error");
    })
}
```

```csharp
[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error-local-development")]
    public IActionResult ErrorLocalDevelopment(
        [FromServices] IWebHostEnvironment webHostEnvironment)
    {
        if (!webHostEnvironment.IsDevelopment())
        {
            throw new InvalidOperationException(
                "This should never be invoked in non-development environments.");
        }

        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        return Problem(
            detail: context.Error.StackTrace,
            title: context.Error.Message);
    }

    [Route("/error")]
    public IActionResult Error() => Problem();
}
```

## Use exceptions to modify the response

You may sometimes want to change the contents of the response from outside of the controller. In ASP.NET 4.x Web API, one way to do this was using the `HttpResponseException` type. ASP.NET Core doesn't include an equivalent type. Support for it can be added using a filter and a well-known exception type. For example:

```csharp
public class HttpResponseException : Exception
{
    public int Status { get; set; } = 500;

    public object Value { get; set; }
}
```

```csharp
public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order { get; set; } = int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) {}

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpResponseException exception)
        {
            context.Result = new ObjectResult(exception.Value)
            {
                Status = exception.Status,
            };
            context.ExceptionHandled = true;
        }
    }
}
```

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options => 
        options.Filters.Add(new HttpResponseExceptionFilter()));
}
```

## Validation failure error response

For web API controllers, MVC responds with a `ValidationProblemDetails` response type when model validation fails. MVC uses the results of <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to construct
the error response for a validation failure. The following example uses the factory to change the default response type to `SerializableError`:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/Startup.cs?name=snippet_DisableProblemDetailsInvalidModelStateResponseFactory&highlight=4-13)]

::: moniker-end

::: moniker range="= aspnetcore-2.2"

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_DisableProblemDetailsInvalidModelStateResponseFactory&highlight=5-14)]

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

## Client error response

For web API controllers, MVC transforms an error result (a result with status code 400 or higher) to a result with <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>. The error response can be configured in one of the following ways:

1. [Use ApiBehaviorOptions.ClientErrorMapping](#use-apibehavioroptionsclienterrormapping)
1. [Implement ProblemDetailsFactory](#implement-problemdetailsfactory)

### Use ApiBehaviorOptions.ClientErrorMapping

Use the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.ClientErrorMapping*> property to configure the contents of the `ProblemDetails` response. For example, the following code updates the `type` property for 404 responses:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=8-9)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=9-10)]

::: moniker-end

### Implement ProblemDetailsFactory

MVC uses `Microsoft.AspNetCore.Mvc.ProblemDetailsFactory` to produce all instances of `ProblemDetails` and `ValidationProblemDetails` This includes client error responses, validation failure error responses, and the `Microsoft.AspNetCore.Mvc.ControllerBase.Problem` and `<xref:Microsoft.AspNetCore.Mvc.ControllerBase.ValidationProblem>` helper methods.

Applications may register a custom implementation of `ProblemDetailsFactory` to customize the problem details response. For example:

```csharp
public void ConfigureServices(IServiceCollection serviceCollection)
{
    services.AddControllers();
    services.AddTransient
        <ProblemDetailsFactory, CustomProblemDetailsFactory>();
}
```
